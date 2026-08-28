using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProductModel = Supermarket.Model.Products;

namespace Supermarket.UI.Inventory
{
    public partial class frmAddStockAdjustment : Form
    {
        private readonly ProductsDAL _productsDAL = new ProductsDAL();
        private readonly StockAdjustmentsDAL _stockAdjustmentsDAL = new StockAdjustmentsDAL();
        private List<ProductModel> _productsList = new List<ProductModel>();

        public frmAddStockAdjustment()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void frmAddStockAdjustment_Load(object sender, EventArgs e)
        {
            InitDropdowns();
            LoadProducts();
        }

        private void InitDropdowns()
        {
            // Adjustment Types
            cmbType.Items.Clear();
            cmbType.Items.Add("Addition (+)");
            cmbType.Items.Add("Subtraction (-)");
            cmbType.SelectedIndex = -1;

            // Common Adjustment Reasons
            cmbReason.Items.Clear();
            cmbReason.Items.Add("Inventory Count Correction");
            cmbReason.Items.Add("Damaged Goods");
            cmbReason.Items.Add("Expired Products");
            cmbReason.Items.Add("Lost / Stolen");
            cmbReason.Items.Add("Customer Return");
            cmbReason.Items.Add("Supplier Return");
            cmbReason.Items.Add("Internal Store Use");
            cmbReason.Items.Add("Other");
            cmbReason.SelectedIndex = -1;

            dtpAdjustedAt.Value = DateTime.Now;
        }

        private void LoadProducts()
        {
            try
            {
                _productsList = _productsDAL.GetAllProducts() ?? new List<ProductModel>();

                // Create a clean projection for the dropdown
                var productOptions = _productsList.Select(p => new
                {
                    Id = p.Id,
                    DisplayText = string.IsNullOrWhiteSpace(p.Barcode)
                        ? $"{p.Name} (Stock: {p.Stock_quantity})"
                        : $"{p.Name} [{p.Barcode}] (Stock: {p.Stock_quantity})",
                    StockQuantity = p.Stock_quantity
                }).ToList();

                cmbProduct.DataSource = productOptions;
                cmbProduct.DisplayMember = "DisplayText";
                cmbProduct.ValueMember = "Id";
                cmbProduct.SelectedIndex = -1;

                if (productOptions.Count > 0)
                {
                    cmbProduct.SelectedIndex = -1;
                    UpdateCurrentStockDisplay();
                }
                else
                {
                    txtCurrentStock.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentStockDisplay();
        }

        private void UpdateCurrentStockDisplay()
        {
            if (cmbProduct.SelectedValue != null && long.TryParse(cmbProduct.SelectedValue.ToString(), out long productId))
            {
                var prod = _productsList.FirstOrDefault(p => p.Id == productId);
                if (prod != null)
                {
                    txtCurrentStock.Text = prod.Stock_quantity.ToString();
                    return;
                }
            }
            txtCurrentStock.Text = "0";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Product Selection
            if (cmbProduct.SelectedValue == null || !long.TryParse(cmbProduct.SelectedValue.ToString(), out long productId) || productId <= 0)
            {
                MessageBox.Show("Please select a valid product.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProduct.Focus();
                return;
            }

            var product = _productsList.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                MessageBox.Show("Selected product was not found.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate Quantity
            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity (greater than 0).", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            // 3. Determine Adjustment Type
            string type = "addition";
            if (cmbType.SelectedItem != null && cmbType.SelectedItem.ToString().Contains("Subtraction"))
            {
                type = "subtraction";

                // Validate sufficient stock for subtraction
                if (quantity > product.Stock_quantity)
                {
                    MessageBox.Show($"Cannot subtract {quantity} units because the product '{product.Name}' only has {product.Stock_quantity} units in stock.",
                        "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                    return;
                }
            }

            // 4. Validate Reason
            string reason = cmbReason.Text.Trim();
            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Please select or enter a reason for this stock adjustment.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbReason.Focus();
                return;
            }

            // 5. Build Adjustment Model
            var adjustment = new StockAdjustments
            {
                ProductId = productId,
                UserId = 1,
                Type = type,
                Quantity = quantity,
                Reason = reason,
                AdjustedAt = dtpAdjustedAt.Value,
                Status = "Pending"
            };

            // 6. Save via DAL
            bool success = _stockAdjustmentsDAL.AddStockAdjustment(adjustment, out string errorMessage);
            if (success)
            {
                MessageBox.Show("Stock adjustment recorded successfully as Pending! Click the Complete button in the adjustments list to apply stock changes.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save stock adjustment: " + errorMessage,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
