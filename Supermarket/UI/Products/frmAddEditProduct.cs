using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.DAL;
using ProductModel = Supermarket.Model.Products;

namespace Supermarket.UI.Products
{
    public partial class frmAddEditProduct : Form
    {
        private readonly ProductsDAL _productsDAL = new ProductsDAL();
        private long _productId = 0;
        private string _barcode = "";

        public frmAddEditProduct(long productId = 0)
        {
            InitializeComponent();
            _productId = productId;
        }



        private void frmAddEditProduct_Load(object sender, EventArgs e)
        {
            LoadCategoriesAndUnits();

            if (_productId > 0)
            {
                guna2HtmlLabel1.Text = "Edit Product";
                LoadProductData(_productId);
            }
            else
            {
                guna2HtmlLabel1.Text = "Add Product";
                _barcode = GenerateRandomBarcode();
            }
        }

        private string GenerateRandomBarcode()
        {
            Random rnd = new Random();
            return "885" + rnd.Next(100000000, 999999999).ToString();
        }

        private void LoadCategoriesAndUnits()
        {
            var categories = _productsDAL.GetAllCategories();
            UnitCateroy.DataSource = categories;
            UnitCateroy.DisplayMember = "CategoryName";
            UnitCateroy.ValueMember = "CategoryId";
            UnitCateroy.SelectedIndex = -1;

            var units = _productsDAL.GetAllUnits();
            cmbUnit.DataSource = units;
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitId";
            cmbUnit.SelectedIndex = -1;
        }

        private void LoadProductData(long id)
        {
            var product = _productsDAL.GetProductById(id);
            if (product != null)
            {
                txtName.Text = product.Name;
                _barcode = product.Barcode ?? "";
                if (product.CategoryId.HasValue)
                {
                    UnitCateroy.SelectedValue = product.CategoryId.Value;
                }
                if (product.UnitId.HasValue)
                {
                    cmbUnit.SelectedValue = product.UnitId.Value;
                }
                txtCostPrice.Text = product.Cost_price.ToString();
                txtSellingPrice.Text = product.Selling_price.ToString();
                txtStockQuantity.Text = product.Stock_quantity.ToString();
                txtStockAlertLevel.Text = product.Stock_alert_level.ToString();
                txtImagePath.Text = product.Image ?? "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            decimal costPrice = 0;
            decimal.TryParse(txtCostPrice.Text.Trim(), out costPrice);

            decimal sellingPrice = 0;
            decimal.TryParse(txtSellingPrice.Text.Trim(), out sellingPrice);

            int stockQty = 0;
            int.TryParse(txtStockQuantity.Text.Trim(), out stockQty);

            int stockAlertLevel = 0;
            int.TryParse(txtStockAlertLevel.Text.Trim(), out stockAlertLevel);

            int? categoryId = UnitCateroy.SelectedValue is int cId ? cId : (int?)null;
            int? unitId = cmbUnit.SelectedValue is int uId ? uId : (int?)null;

            string imagePathToSave = SaveImageFile(txtImagePath.Text.Trim());

            ProductModel product = new ProductModel
            {
                Id = _productId,
                Name = txtName.Text.Trim(),
                Barcode = _barcode ?? "",
                CategoryId = categoryId,
                UnitId = unitId,
                Cost_price = costPrice,
                Selling_price = sellingPrice,
                Stock_quantity = stockQty,
                Stock_alert_level = stockAlertLevel,
                Image = imagePathToSave
            };

            bool success;
            if (_productId > 0)
            {
                success = _productsDAL.UpdateProduct(product);
            }
            else
            {
                success = _productsDAL.AddProduct(product);
            }

            if (success)
            {
                MessageBox.Show(_productId > 0 ? "Product updated successfully!" : "Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private string SaveImageFile(string selectedPath)
        {
            if (string.IsNullOrWhiteSpace(selectedPath)) return "";

            try
            {
                if (!File.Exists(selectedPath))
                {
                    return selectedPath;
                }

                string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Products");
                if (!Directory.Exists(imagesDir))
                {
                    Directory.CreateDirectory(imagesDir);
                }

                string fullSourcePath = Path.GetFullPath(selectedPath);
                if (fullSourcePath.StartsWith(imagesDir, StringComparison.OrdinalIgnoreCase))
                {
                    return Path.Combine("Images", "Products", Path.GetFileName(fullSourcePath));
                }

                string fileExt = Path.GetExtension(selectedPath);
                string newFileName = $"prod_{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid().ToString("N").Substring(0, 6)}{fileExt}";
                string destPath = Path.Combine(imagesDir, newFileName);

                File.Copy(selectedPath, destPath, true);

                return Path.Combine("Images", "Products", newFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image Copy Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return selectedPath;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Product Image";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

