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
            this.StartPosition = FormStartPosition.CenterParent;
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // Note: btnSave, btnCancel, and btnPath are already wired in Designer.
            this.txtImagePath.DoubleClick += btnPath_Click;
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

            var suppliers = _productsDAL.GetAllSuppliers();
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "CompanyName";
            cmbSupplier.ValueMember = "Id";
            cmbSupplier.SelectedIndex = -1;
        }

        private void LoadProductData(long id)
        {
            var product = _productsDAL.GetProductById(id);
            if (product != null)
            {
                txtName.Text = product.Name;
                _barcode = product.Barcode ?? "";
                if (product.SupplierId.HasValue)
                {
                    cmbSupplier.SelectedValue = product.SupplierId.Value;
                }
                if (product.CategoryId.HasValue)
                {
                    UnitCateroy.SelectedValue = product.CategoryId.Value;
                }
                if (product.UnitId.HasValue)
                {
                    cmbUnit.SelectedValue = product.UnitId.Value;
                }
                txtCostPrice.Text = product.Cost_price.ToString("0.00");
                txtSellingPrice.Text = product.Selling_price.ToString("0.00");
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

            long? supplierId = null;
            if (cmbSupplier.SelectedValue != null && long.TryParse(cmbSupplier.SelectedValue.ToString(), out long sId))
            {
                supplierId = sId;
            }

            int? categoryId = UnitCateroy.SelectedValue is int cId ? cId : (int?)null;
            int? unitId = cmbUnit.SelectedValue is int uId ? uId : (int?)null;

            string imagePathToSave = SaveImageFile(txtImagePath.Text.Trim());

            ProductModel product = new ProductModel
            {
                Id = _productId,
                Name = txtName.Text.Trim(),
                Barcode = _barcode ?? "",
                SupplierId = supplierId,
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

        private Bitmap CropAndResizeTo1x1(Image sourceImg, int targetSize = 500)
        {
            int minDim = Math.Min(sourceImg.Width, sourceImg.Height);
            int srcX = (sourceImg.Width - minDim) / 2;
            int srcY = (sourceImg.Height - minDim) / 2;

            int outputSize = targetSize > 0 ? targetSize : minDim;
            Bitmap squareBmp = new Bitmap(outputSize, outputSize);
            using (Graphics g = Graphics.FromImage(squareBmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(sourceImg,
                    new Rectangle(0, 0, outputSize, outputSize),
                    new Rectangle(srcX, srcY, minDim, minDim),
                    GraphicsUnit.Pixel);
            }
            return squareBmp;
        }

        private string SaveImageFile(string selectedPath)
        {
            if (string.IsNullOrWhiteSpace(selectedPath)) return "";

            try
            {
                string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Products");
                if (!Directory.Exists(imagesDir))
                {
                    Directory.CreateDirectory(imagesDir);
                }

                // If path is already a relative path to an existing product image and file exists in BaseDirectory
                if (!Path.IsPathRooted(selectedPath))
                {
                    string combined = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, selectedPath);
                    if (File.Exists(combined))
                    {
                        return selectedPath;
                    }
                }

                string fullSourcePath = Path.GetFullPath(selectedPath);
                if (!File.Exists(fullSourcePath))
                {
                    return selectedPath;
                }

                // If already in target images folder, we can return it
                if (fullSourcePath.StartsWith(imagesDir, StringComparison.OrdinalIgnoreCase))
                {
                    return Path.Combine("Images", "Products", Path.GetFileName(fullSourcePath));
                }

                string newFileName = $"prod_{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid().ToString("N").Substring(0, 6)}.png";
                string destPath = Path.Combine(imagesDir, newFileName);

                // Load image safely using stream, convert to 1:1 square image and save as PNG
                using (var fs = new FileStream(fullSourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var originalImg = Image.FromStream(fs))
                using (var squareImg = CropAndResizeTo1x1(originalImg, 500))
                {
                    squareImg.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                }

                return Path.Combine("Images", "Products", newFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image Process Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return selectedPath;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Product Image";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
