using System;
using System.Drawing;
using System.Windows.Forms;

namespace Supermarket.UI.Point_of_sale
{
    using Products = Supermarket.Model.Products;

    public partial class CardProduct : UserControl
    {
        public Products Product { get; private set; }

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

        public void SetProduct(Products product)
        {
            Product = product;
            if (product == null) return;

            txtProductName.Text = product.Name;
            txtCatagory.Text = string.IsNullOrWhiteSpace(product.Category) ? "General" : product.Category;
            guna2HtmlLabel2.Text = $"${product.Selling_price:N2}";

            if (product.ProductImage != null)
            {
                image.Image = product.ProductImage;
                image.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (product.Stock_quantity <= 0)
            {
                btnAdd.Enabled = false;
                btnAdd.FillColor = Color.LightGray;
            }
            else
            {
                btnAdd.Enabled = true;
                btnAdd.FillColor = Color.WhiteSmoke;
            }
        }
    }
}
