using System;
using System.Windows.Forms;

namespace Supermarket.UI.Point_of_sale
{
    using Products = Supermarket.Model.Products;

    public partial class CartItemControl : UserControl
    {
        public Products Product { get; private set; }
        public int Quantity { get; private set; } = 1;
        public decimal Subtotal => Product != null ? Product.Selling_price * Quantity : 0;

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

        private void UpdateUI()
        {
            if (Product == null) return;
            lblProductName.Text = Product.Name;
            lblPrice.Text = $"${Product.Selling_price:N2} each";
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
