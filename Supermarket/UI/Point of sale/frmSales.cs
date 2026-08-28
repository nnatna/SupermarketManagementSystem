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
    using Promotions = Supermarket.Model.Promotions;

    public partial class frmSales : Form
    {
        private readonly ProductsDAL _productsDAL = new ProductsDAL();
        private readonly SalesDAL _salesDAL = new SalesDAL();
        private readonly CustomersDAL _customersDAL = new CustomersDAL();
        private readonly PromotionsDAL _promotionsDAL = new PromotionsDAL();
        private List<Products> _products = new List<Products>();
        private List<Categories> _categories = new List<Categories>();
        private Promotions _appliedPromotion = null;
        private decimal _currentDiscount = 0.00m;

        private class CustomerComboItem
        {
            public long Id { get; set; }
            public string DisplayText { get; set; }
            public int Points { get; set; }
            public override string ToString() => DisplayText;
        }

        public frmSales()
        {
            InitializeComponent();
        }

        private async void frmSales_Load(object sender, EventArgs e)
        {
            flpnlCurrentOrder.HorizontalScroll.Maximum = 0;
            flpnlCurrentOrder.HorizontalScroll.Visible = false;
            flpnlCurrentOrder.HorizontalScroll.Enabled = false;
            flpnlCurrentOrder.AutoScroll = true;

            txtDiscount.Cursor = Cursors.Hand;
            txtDiscount.Click += txtDiscount_Click;
            guna2HtmlLabel3.Cursor = Cursors.Hand;
            guna2HtmlLabel3.Click += txtDiscount_Click;

            await LoadCategoriesAsync();
            await LoadCustomersAsync();
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

        public async Task LoadCustomersAsync(long selectCustomerId = 0)
        {
            var customers = await Task.Run(() => _customersDAL.GetAllCustomers());

            cmbOrderCustomer.Items.Clear();
            cmbOrderCustomer.Items.Add(new CustomerComboItem
            {
                Id = 0,
                DisplayText = "General Customer",
                Points = 0
            });

            int selectedIndex = 0;
            int currentIndex = 1;

            if (customers != null)
            {
                foreach (var c in customers)
                {
                    string phoneText = string.IsNullOrWhiteSpace(c.Phone) ? "" : $" ({c.Phone})";
                    var item = new CustomerComboItem
                    {
                        Id = c.Id,
                        DisplayText = $"{c.Name}{phoneText} [Pts: {c.Points}]",
                        Points = c.Points
                    };
                    cmbOrderCustomer.Items.Add(item);

                    if (selectCustomerId > 0 && c.Id == selectCustomerId)
                    {
                        selectedIndex = currentIndex;
                    }
                    currentIndex++;
                }
            }

            if (cmbOrderCustomer.Items.Count > 0)
            {
                cmbOrderCustomer.SelectedIndex = selectedIndex;
            }
        }

        private async void btnAddOrderCustomer_Click(object sender, EventArgs e)
        {
            using (var frm = new Customers.frmAddEditCustomer(0))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    var latestCustomers = await Task.Run(() => _customersDAL.GetAllCustomers());
                    long newCustId = latestCustomers != null && latestCustomers.Count > 0 ? latestCustomers.First().Id : 0;
                    await LoadCustomersAsync(newCustId);
                }
            }
        }

        private async Task LoadProductsAsync()
        {
            _products = await Task.Run(() => _productsDAL.GetAllProducts());
            FilterProducts();
        }

        private void FilterProducts()
        {
            if (_products == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedCategory = cmbCategory.SelectedItem?.ToString();

            var query = _products.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
            {
                query = query.Where(p => string.Equals(p.Category, selectedCategory, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p =>
                    (p.Name != null && p.Name.ToLower().Contains(keyword)) ||
                    (p.Barcode != null && p.Barcode.ToLower().Contains(keyword)));
            }

            DisplayProducts(query.ToList());
        }

        private void DisplayProducts(List<Products> productList)
        {
            flpnlShowProduct.SuspendLayout();
            flpnlShowProduct.Controls.Clear();

            var activePromos = _promotionsDAL.GetActivePromotions() ?? new List<Model.Promotions>();
            var promoDict = activePromos
                .Where(p => p != null && p.IsCurrentlyActive)
                .GroupBy(p => p.ProductId)
                .ToDictionary(g => g.Key, g => g.First().DiscountPercent);

            foreach (var prod in productList)
            {
                CardProduct card = new CardProduct();
                decimal discount = 0;
                if (promoDict.TryGetValue(prod.Id, out decimal d))
                {
                    discount = d;
                }

                card.SetProduct(prod, discount);
                card.Margin = new Padding(8);
                card.AddToCartClicked += Card_AddToCartClicked;
                flpnlShowProduct.Controls.Add(card);
            }

            flpnlShowProduct.ResumeLayout();
        }

        private void Card_AddToCartClicked(object sender, Products selectedProduct)
        {
            if (selectedProduct == null) return;

            if (selectedProduct.Stock_quantity <= 0)
            {
                MessageBox.Show($"'{selectedProduct.Name}' is out of stock!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if already in cart
            var existingItem = flpnlCurrentOrder.Controls
                .OfType<CartItemControl>()
                .FirstOrDefault(ci => ci.Product != null && ci.Product.Id == selectedProduct.Id);

            if (existingItem != null)
            {
                if (!existingItem.IncreaseQuantity())
                {
                    MessageBox.Show($"Cannot add more. Available stock: {selectedProduct.Stock_quantity}", "Stock Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                CartItemControl cartItem = new CartItemControl();
                cartItem.SetCartItem(selectedProduct, 1);

                // Auto-apply active promotion for this specific product if exists
                var activePromo = _promotionsDAL.GetActivePromotionByProductId(selectedProduct.Id);
                if (activePromo != null && activePromo.DiscountPercent > 0)
                {
                    cartItem.SetDiscount(activePromo.DiscountPercent);
                }

                cartItem.Margin = new Padding(0, 0, 0, 5);
                int targetWidth = flpnlCurrentOrder.ClientSize.Width - flpnlCurrentOrder.Padding.Horizontal - cartItem.Margin.Horizontal;
                if (targetWidth > 50)
                {
                    cartItem.Width = targetWidth;
                }
                cartItem.ItemRemoved += CartItem_ItemRemoved;
                cartItem.QuantityChanged += CartItem_QuantityChanged;
                flpnlCurrentOrder.Controls.Add(cartItem);
                UpdateCartItemsWidth();
            }

            CalculateTotals();
        }

        private void CartItem_ItemRemoved(object sender, CartItemControl item)
        {
            if (item != null)
            {
                flpnlCurrentOrder.Controls.Remove(item);
                item.Dispose();
                CalculateTotals();
            }
        }

        private string _orderDiscountType = "None"; // "PromoCode", "Percentage", "Fixed", "None"
        private decimal _orderDiscountRate = 0.00m;
        private decimal _orderDiscountAmount = 0.00m;

        private void CartItem_QuantityChanged(object sender, CartItemControl item)
        {
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            var cartItems = flpnlCurrentOrder.Controls.OfType<CartItemControl>().ToList();

            decimal subtotal = cartItems.Sum(ci => ci.Subtotal);
            decimal totalItemDiscounts = cartItems.Sum(ci => ci.TotalItemDiscount);

            decimal orderDiscount = 0.00m;
            if (_appliedPromotion != null && _appliedPromotion.IsCurrentlyActive)
            {
                orderDiscount = Math.Round(subtotal * (_appliedPromotion.DiscountPercent / 100m), 2);
            }
            else if (_orderDiscountType == "Percentage" && _orderDiscountRate > 0)
            {
                orderDiscount = Math.Round(subtotal * (_orderDiscountRate / 100m), 2);
            }
            else if (_orderDiscountType == "Fixed" && _orderDiscountAmount > 0)
            {
                orderDiscount = Math.Min(subtotal, _orderDiscountAmount);
            }

            _currentDiscount = orderDiscount;
            decimal grandTotal = Math.Max(0, subtotal - _currentDiscount);

            txtSubtotal.Text = $"${subtotal:N2}";

            decimal totalAllDiscounts = totalItemDiscounts + _currentDiscount;
            if (_appliedPromotion != null && _currentDiscount > 0)
            {
                txtDiscount.Text = $"${totalAllDiscounts:N2} ({_appliedPromotion.PromotionName})";
            }
            else if (_orderDiscountType == "Percentage" && _orderDiscountRate > 0)
            {
                txtDiscount.Text = $"${totalAllDiscounts:N2} (-{_orderDiscountRate:0.#}%)";
            }
            else if (totalAllDiscounts > 0)
            {
                txtDiscount.Text = $"${totalAllDiscounts:N2}";
            }
            else
            {
                txtDiscount.Text = "$0.00";
            }

            txtTotal.Text = $"${grandTotal:N2}";

            btnPay.Enabled = cartItems.Count > 0;
        }

        public void ApplyPromoCode(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                _appliedPromotion = null;
                _orderDiscountType = "None";
                CalculateTotals();
                return;
            }

            var promo = _promotionsDAL.GetActivePromotions()
                .FirstOrDefault(p => p.PromotionName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                     p.ProductName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                     p.Barcode.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

            if (promo == null)
            {
                MessageBox.Show($"Promotion '{query}' was not found.", "Invalid Promotion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!promo.IsCurrentlyActive)
            {
                MessageBox.Show($"Promotion '{promo.PromotionName}' has expired.", "Promo Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _appliedPromotion = promo;
            _orderDiscountType = "PromoCode";
            CalculateTotals();
            MessageBox.Show($"Promotion '{promo.PromotionName}' ({promo.FormattedDiscount} off) applied successfully!", "Promotion Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtDiscount_Click(object sender, EventArgs e)
        {
            var cartItems = flpnlCurrentOrder.Controls.OfType<CartItemControl>().ToList();
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Please add items to cart before applying a discount.", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal subtotal = cartItems.Sum(ci => ci.Subtotal);
            decimal initialRate = _appliedPromotion != null ? _appliedPromotion.DiscountPercent : (_orderDiscountType == "Percentage" ? _orderDiscountRate : _orderDiscountAmount);
            string initialType = _appliedPromotion != null ? "PromoCode" : _orderDiscountType;

            using (var dlg = new frmApplyDiscount(subtotal, _appliedPromotion, initialType, initialRate))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _appliedPromotion = dlg.AppliedPromotion;
                    _orderDiscountType = dlg.SelectedDiscountType;
                    if (_orderDiscountType == "Percentage")
                    {
                        _orderDiscountRate = dlg.DiscountRate;
                        _orderDiscountAmount = 0;
                    }
                    else if (_orderDiscountType == "Fixed")
                    {
                        _orderDiscountAmount = dlg.DiscountRate;
                        _orderDiscountRate = 0;
                    }
                    else if (_orderDiscountType == "PromoCode" && _appliedPromotion != null)
                    {
                        _orderDiscountRate = _appliedPromotion.DiscountPercent;
                        _orderDiscountAmount = 0;
                    }
                    else
                    {
                        _orderDiscountRate = 0;
                        _orderDiscountAmount = 0;
                    }

                    CalculateTotals();
                }
            }
        }

        private void ClearOrderCart()
        {
            flpnlCurrentOrder.Controls.Clear();
            _appliedPromotion = null;
            _orderDiscountType = "None";
            _orderDiscountRate = 0;
            _orderDiscountAmount = 0;
            CalculateTotals();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (flpnlCurrentOrder.Controls.Count == 0) return;

            var result = MessageBox.Show("Are you sure you want to clear the cart?", "Clear Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearOrderCart();
            }
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
            if (flpnlCurrentOrder == null || flpnlCurrentOrder.IsDisposed) return;
            flpnlCurrentOrder.SuspendLayout();
            try
            {
                flpnlCurrentOrder.HorizontalScroll.Maximum = 0;
                flpnlCurrentOrder.HorizontalScroll.Visible = false;
                flpnlCurrentOrder.HorizontalScroll.Enabled = false;

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
            finally
            {
                flpnlCurrentOrder.ResumeLayout();
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

            decimal totalItemDiscounts = cartItems.Sum(ci => ci.TotalItemDiscount);
            decimal netSubtotal = cartItems.Sum(ci => ci.Subtotal);
            decimal totalDiscount = totalItemDiscounts + _currentDiscount;
            decimal grandTotal = Math.Max(0, netSubtotal - _currentDiscount);

            long selectedCustomerId = 0;
            if (cmbOrderCustomer.SelectedItem is CustomerComboItem item && item.Id > 0)
            {
                selectedCustomerId = item.Id;
            }

            using (frmPayment paymentForm = new frmPayment(cartItems, netSubtotal, totalDiscount, grandTotal, selectedCustomerId, _appliedPromotion?.Id))
            {
                if (paymentForm.ShowDialog(this) == DialogResult.OK)
                {
                    ClearOrderCart();
                    await LoadProductsAsync(); // Refresh product cards and stock levels
                    await LoadCustomersAsync(selectedCustomerId); // Refresh customer list with updated points!
                }
            }
        }
    }
}
