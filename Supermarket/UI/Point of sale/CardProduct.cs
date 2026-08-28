using System;
using System.Drawing;
using System.Windows.Forms;

namespace Supermarket.UI.Point_of_sale
{
    using Products = Supermarket.Model.Products;

    public partial class CardProduct : UserControl
    {
        public Products Product { get; private set; }
        public decimal DiscountPercent { get; private set; } = 0.00m;

        public event EventHandler<Products> AddToCartClicked;

        public CardProduct()
        {
            InitializeComponent();
            RegisterClickEvents(this);
        }

        private void RegisterClickEvents(Control control)
        {
            if (control != btnAdd)
            {
                control.Click += Card_Click;
            }
            foreach (Control child in control.Controls)
            {
                RegisterClickEvents(child);
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            OnAddToCart();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddToCart();
        }

        private void OnAddToCart()
        {
            if (Product != null)
            {
                AddToCartClicked?.Invoke(this, Product);
            }
        }

        public void SetProduct(Products product, decimal discountPercent = 0.00m)
        {
            Product = product;
            DiscountPercent = Math.Max(0.00m, discountPercent);
            
            if (product == null) return;

            txtProductName.Text = product.Name;
            txtCatagory.Text = string.IsNullOrWhiteSpace(product.Category) ? "General" : product.Category;

            if (DiscountPercent > 0)
            {
                decimal discountedPrice = Math.Round(product.Selling_price * (1.0m - (DiscountPercent / 100.0m)), 2);
                
                // Show original price with strikethrough
                lblOriginalPrice.Text = $"${product.Selling_price:N2}";
                lblOriginalPrice.Visible = true;

                // Show discounted price
                guna2HtmlLabel2.Text = $"${discountedPrice:N2}";
                guna2HtmlLabel2.ForeColor = Color.Crimson;

                // Show discount badge
                lblDiscountBadge.Text = $"-{DiscountPercent:0.#}%";
                lblDiscountBadge.Visible = true;
            }
            else
            {
                // Regular price
                lblOriginalPrice.Visible = false;
                guna2HtmlLabel2.Text = $"${product.Selling_price:N2}";
                guna2HtmlLabel2.ForeColor = Color.FromArgb(220, 20, 60);
                lblDiscountBadge.Visible = false;
            }

            if (product.ProductImage != null)
            {
                image.Image = product.ProductImage;
                image.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (product.Stock_quantity <= 0)
            {
                btnAdd.Enabled = false;
                btnAdd.FillColor = Color.FromArgb(235, 235, 235);
            }
            else
            {
                btnAdd.Enabled = true;
                btnAdd.FillColor = Color.FromArgb(240, 244, 255);
            }
        }
    }
}
