using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.DAL;

namespace Supermarket.UI.Point_of_sale
{
    using Products = Supermarket.Model.Products;
    using Sales = Supermarket.Model.Sales;
    using SalesDetails = Supermarket.Model.SalesDetails;
    using Categories = Supermarket.Model.Categories;

    public partial class frmSales : Form
    {
        private readonly ProductsDAL _productsDAL = new ProductsDAL();
        private readonly SalesDAL _salesDAL = new SalesDAL();
        private List<Products> _products = new List<Products>();
        private List<Categories> _categories = new List<Categories>();

        public frmSales()
        {
            InitializeComponent();
        }

        private async void frmSales_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadProductsAsync();
            CalculateTotals();
        }

        private async Task LoadCategoriesAsync()
        {
            _categories = await Task.Run(() => _productsDAL.GetAllCategories());
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            if (_categories != null)
            {
                foreach (var cat in _categories)
                {
                    cmbCategory.Items.Add(cat.CategoryName);
                }
            }

            cmbCategory.SelectedIndex = 0;
        }

        private async Task LoadProductsAsync()
        {
            _products = await Task.Run(() => _productsDAL.GetAllProducts());
            FilterProducts();
        }

        private void FilterProducts()
        {
            if (_products == null) return;

            string searchText = txtSearch.Text.Trim().ToLower();
            string selectedCategory = cmbCategory.SelectedItem?.ToString() ?? "All Categories";

            var filtered = _products.Where(p =>
            {
                bool matchesSearch = string.IsNullOrWhiteSpace(searchText) ||
                                      (p.Name != null && p.Name.ToLower().Contains(searchText)) ||
                                      (p.Barcode != null && p.Barcode.ToLower().Contains(searchText));

                bool matchesCategory = selectedCategory == "All Categories" ||
                                       string.Equals(p.Category, selectedCategory, StringComparison.OrdinalIgnoreCase);

                return matchesSearch && matchesCategory;
            }).ToList();

            DisplayProductCards(filtered);
        }

        private void DisplayProductCards(List<Products> productsList)
        {
            flpnlShowProduct.SuspendLayout();
            flpnlShowProduct.Controls.Clear();

            if (productsList != null)
            {
                foreach (var product in productsList)
                {
                    CardProduct card = new CardProduct();
                    card.SetProduct(product);
                    card.AddToCartClicked += Card_AddToCartClicked;
                    flpnlShowProduct.Controls.Add(card);
                }
            }

            flpnlShowProduct.ResumeLayout(true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void Card_AddToCartClicked(object sender, Products product)
        {
            if (product == null) return;

            if (product.Stock_quantity <= 0)
            {
                MessageBox.Show($"Product '{product.Name}' is out of stock!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find existing cart item for this product
            CartItemControl existingCartItem = flpnlCurrentOrder.Controls
                .OfType<CartItemControl>()
                .FirstOrDefault(ci => ci.Product != null && ci.Product.Id == product.Id);

            if (existingCartItem != null)
            {
                if (!existingCartItem.IncreaseQuantity())
                {
                    MessageBox.Show($"Only {product.Stock_quantity} units available for '{product.Name}'.", "Stock Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                CartItemControl newItem = new CartItemControl();
                int availableWidth = flpnlCurrentOrder.ClientSize.Width - flpnlCurrentOrder.Padding.Horizontal;
                int targetWidth = availableWidth - newItem.Margin.Horizontal;
                if (targetWidth > 50)
                {
                    newItem.Width = targetWidth;
                }
                newItem.SetCartItem(product, 1);
                newItem.QuantityChanged += CartItem_QuantityChanged;
                newItem.ItemRemoved += CartItem_ItemRemoved;
                flpnlCurrentOrder.Controls.Add(newItem);
            }

            UpdateCartItemsWidth();
            CalculateTotals();
        }

        private void CartItem_QuantityChanged(object sender, CartItemControl item)
        {
            CalculateTotals();
        }

        private void CartItem_ItemRemoved(object sender, CartItemControl item)
        {
            flpnlCurrentOrder.Controls.Remove(item);
            item.Dispose();
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            var cartItems = flpnlCurrentOrder.Controls.OfType<CartItemControl>().ToList();
            decimal subtotal = cartItems.Sum(ci => ci.Subtotal);
            decimal discount = 0.00m;
            decimal total = Math.Max(0, subtotal - discount);

            txtSubtotal.Text = $"${subtotal:N2}";
            txtDiscount.Text = $"${discount:N2}";
            txtTotal.Text = $"${total:N2}";
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (flpnlCurrentOrder.Controls.Count == 0) return;

            var result = MessageBox.Show("Are you sure you want to clear all items from the current order?", "Clear Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearOrderCart();
            }
        }

        private void ClearOrderCart()
        {
            flpnlCurrentOrder.Controls.Clear();
            CalculateTotals();
        }

        private void flpnlCurrentOrder_Resize(object sender, EventArgs e)
        {
            UpdateCartItemsWidth();
        }

        private void flpnlCurrentOrder_ControlAdded(object sender, ControlEventArgs e)
        {
            UpdateCartItemsWidth();
        }

        private void flpnlCurrentOrder_ControlRemoved(object sender, ControlEventArgs e)
        {
            UpdateCartItemsWidth();
        }

        private void UpdateCartItemsWidth()
        {
            if (flpnlCurrentOrder == null) return;
            int availableWidth = flpnlCurrentOrder.ClientSize.Width - flpnlCurrentOrder.Padding.Horizontal;
            foreach (Control control in flpnlCurrentOrder.Controls)
            {
                if (control is CartItemControl cartItem)
                {
                    int targetWidth = availableWidth - cartItem.Margin.Horizontal;
                    if (targetWidth > 50 && cartItem.Width != targetWidth)
                    {
                        cartItem.Width = targetWidth;
                    }
                }
            }
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            var cartItems = flpnlCurrentOrder.Controls.OfType<CartItemControl>().ToList();
            if (cartItems.Count == 0)
            {
                MessageBox.Show("The cart is empty. Please add products before checking out.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal subtotal = cartItems.Sum(ci => ci.Subtotal);
            decimal discount = 0.00m;
            decimal grandTotal = Math.Max(0, subtotal - discount);

            var confirmResult = MessageBox.Show(
                $"Proceed with payment for total amount of ${grandTotal:N2}?\nTotal Items: {cartItems.Sum(ci => ci.Quantity)}",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes) return;

            Sales sale = new Sales
            {
                Invoice_number = SalesDAL.GenerateInvoiceNumber(),
                Subtotal = subtotal,
                Discount_amount = discount,
                Grand_total = grandTotal,
                Paid_amount = grandTotal,
                Change_amount = 0,
                Payment_method = "cash",
                Sale_date = DateTime.Now
            };

            List<SalesDetails> details = new List<SalesDetails>();
            foreach (var item in cartItems)
            {
                details.Add(new SalesDetails
                {
                    Product_id = item.Product.Id,
                    Quantity = item.Quantity,
                    Unit_price = item.Product.Selling_price,
                    Subtotal = item.Subtotal
                });
            }

            string errorMessage = string.Empty;
            bool success = await Task.Run(() => _salesDAL.CreateSale(sale, details, out errorMessage));

            if (success)
            {
                MessageBox.Show(
                    $"Payment successful!\n\nInvoice Number: {sale.Invoice_number}\nTotal Amount: ${grandTotal:N2}",
                    "Sale Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearOrderCart();
                await LoadProductsAsync(); // Refresh product cards and stock levels
            }
            else
            {
                MessageBox.Show($"Failed to complete sale: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
