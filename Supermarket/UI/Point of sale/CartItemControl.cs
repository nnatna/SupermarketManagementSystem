using System;
using System.Drawing;
using System.Windows.Forms;

namespace Supermarket.UI.Point_of_sale
{
    using Products = Supermarket.Model.Products;

    public partial class CartItemControl : UserControl
    {
        public Products Product { get; private set; }
        public int Quantity { get; private set; } = 1;
        
        // Item-level discount properties
        public decimal ItemDiscountPercent { get; set; } = 0.00m;
        public decimal ItemDiscountAmount { get; set; } = 0.00m;

        public decimal TotalItemDiscount => ItemDiscountPercent > 0 
            ? (Product != null ? Math.Round((Product.Selling_price * Quantity) * (ItemDiscountPercent / 100m), 2) : 0)
            : Math.Min(Product != null ? Product.Selling_price * Quantity : 0, ItemDiscountAmount * Quantity);

        public decimal Subtotal => Product != null ? Math.Max(0, (Product.Selling_price * Quantity) - TotalItemDiscount) : 0;

        public event EventHandler<CartItemControl> QuantityChanged;
        public event EventHandler<CartItemControl> ItemRemoved;

        public CartItemControl()
        {
            InitializeComponent();
        }

        public void SetCartItem(Products product, int initialQuantity = 1)
        {
            Product = product;
            Quantity = Math.Max(1, initialQuantity);
            ItemDiscountPercent = 0;
            ItemDiscountAmount = 0;
            UpdateUI();
        }

        public bool IncreaseQuantity()
        {
            if (Product != null && Quantity < Product.Stock_quantity)
            {
                Quantity++;
                UpdateUI();
                QuantityChanged?.Invoke(this, this);
                return true;
            }
            return false;
        }

        public bool DecreaseQuantity()
        {
            if (Quantity > 1)
            {
                Quantity--;
                UpdateUI();
                QuantityChanged?.Invoke(this, this);
                return true;
            }
            return false;
        }

        public void SetDiscount(decimal percent, decimal fixedAmount = 0)
        {
            ItemDiscountPercent = percent;
            ItemDiscountAmount = fixedAmount;
            UpdateUI();
            QuantityChanged?.Invoke(this, this);
        }

        public void UpdateUI()
        {
            if (Product == null) return;
            
            lblProductName.Text = Product.Name;

            if (ItemDiscountPercent > 0)
            {
                decimal discountedUnitPrice = Math.Round(Product.Selling_price * (1m - (ItemDiscountPercent / 100m)), 2);
                lblPrice.Text = $"${discountedUnitPrice:N2} (-{ItemDiscountPercent:0.#}%)";
                lblPrice.ForeColor = Color.Crimson;
            }
            else if (ItemDiscountAmount > 0)
            {
                decimal discountedUnitPrice = Math.Max(0, Product.Selling_price - ItemDiscountAmount);
                lblPrice.Text = $"${discountedUnitPrice:N2} (-${ItemDiscountAmount:N2})";
                lblPrice.ForeColor = Color.Crimson;
            }
            else
            {
                lblPrice.Text = $"${Product.Selling_price:N2} each";
                lblPrice.ForeColor = Color.DimGray;
            }

            lblQuantity.Text = Quantity.ToString();
            lblSubtotal.Text = $"${Subtotal:N2}";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (!IncreaseQuantity())
            {
                MessageBox.Show($"Only {Product.Stock_quantity} items available in stock.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            DecreaseQuantity();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ItemRemoved?.Invoke(this, this);
        }
    }
}
