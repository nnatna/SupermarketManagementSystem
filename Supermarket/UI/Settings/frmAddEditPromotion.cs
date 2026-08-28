using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.UI.Settings
{
    using Products = Supermarket.Model.Products;

    public partial class frmAddEditPromotion : Form
    {
        private readonly PromotionsDAL _promotionsDAL = new PromotionsDAL();
        private readonly ProductsDAL _productsDAL = new ProductsDAL();
        private readonly long _promoId;
        private Promotions _promotion;
        private List<Products> _products = new List<Products>();
        private bool _isInitializing = true;

        private class ProductComboItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Barcode { get; set; }
            public decimal SellingPrice { get; set; }

            public override string ToString()
            {
                string bc = string.IsNullOrWhiteSpace(Barcode) ? "" : $"[{Barcode}] ";
                return $"{bc}{Name} - ${SellingPrice:N2}";
            }
        }

        public frmAddEditPromotion(long promoId = 0)
        {
            InitializeComponent();
            _promoId = promoId;

            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
        }

        private void frmAddEditPromotion_Load(object sender, EventArgs e)
        {
            _isInitializing = true;
            LoadProductsList();

            if (_promoId > 0)
            {
                lblTitle.Text = "Edit Product Promotion";
                this.Text = "Edit Product Promotion";
                LoadPromotionData();
            }
            else
            {
                lblTitle.Text = "Add Product Promotion";
                this.Text = "Add Product Promotion";
                
                DateTime today = DateTime.Today;
                dtpStartDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpEndDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpStartDate.Value = today;
                dtpEndDate.Value = today.AddDays(30);
                dtpEndDate.MinDate = today;
                numDiscountPercent.Value = 10;
            }

            _isInitializing = false;
            UpdatePricePreview();
        }

        private void LoadProductsList()
        {
            try
            {
                _products = _productsDAL.GetAllProducts() ?? new List<Products>();
                cmbProduct.Items.Clear();
                cmbProduct.Items.Add("-- Select a Product --");

                foreach (var p in _products)
                {
                    cmbProduct.Items.Add(new ProductComboItem
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Barcode = p.Barcode,
                        SellingPrice = p.Selling_price
                    });
                }

                cmbProduct.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPromotionData()
        {
            _promotion = _promotionsDAL.GetPromotionById(_promoId);
            if (_promotion == null)
            {
                MessageBox.Show("Promotion not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            // Select product in combobox
            for (int i = 1; i < cmbProduct.Items.Count; i++)
            {
                if (cmbProduct.Items[i] is ProductComboItem item && item.Id == _promotion.ProductId)
                {
                    cmbProduct.SelectedIndex = i;
                    break;
                }
            }

            txtPromoName.Text = _promotion.PromotionName;
            numDiscountPercent.Value = Math.Max(0.01m, Math.Min(100m, _promotion.DiscountPercent));

            // Safely set Start and End dates
            dtpStartDate.MinDate = DateTimePicker.MinimumDateTime;
            dtpEndDate.MinDate = DateTimePicker.MinimumDateTime;

            DateTime start = _promotion.StartDate >= DateTimePicker.MinimumDateTime ? _promotion.StartDate.Date : DateTime.Today;
            DateTime end = _promotion.EndDate >= DateTimePicker.MinimumDateTime ? _promotion.EndDate.Date : DateTime.Today.AddDays(30);

            dtpStartDate.Value = start;
            dtpEndDate.Value = end >= start ? end : start;
            dtpEndDate.MinDate = start;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            DateTime startDate = dtpStartDate.Value.Date;

            // Automatically adjust EndDate if it's earlier than StartDate
            if (dtpEndDate.Value.Date < startDate)
            {
                dtpEndDate.Value = startDate.AddDays(7);
            }

            dtpEndDate.MinDate = startDate;
            UpdatePricePreview();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            UpdatePricePreview();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is ProductComboItem item && string.IsNullOrWhiteSpace(txtPromoName.Text))
            {
                txtPromoName.Text = $"{item.Name} Discount";
            }
            UpdatePricePreview();
        }

        private void numDiscountPercent_ValueChanged(object sender, EventArgs e)
        {
            UpdatePricePreview();
        }

        private void UpdatePricePreview()
        {
            DateTime start = dtpStartDate.Value.Date;
            DateTime end = dtpEndDate.Value.Date;
            DateTime today = DateTime.Today;

            string statusText;
            Color statusColor;

            if (today < start)
            {
                int daysUntilStart = (int)(start - today).TotalDays;
                statusText = $" [Upcoming in {daysUntilStart} day{(daysUntilStart > 1 ? "s" : "")}]";
                statusColor = Color.DarkOrange;
            }
            else if (today > end)
            {
                statusText = " [Expired]";
                statusColor = Color.Crimson;
            }
            else
            {
                int daysLeft = (int)(end - today).TotalDays;
                statusText = $" [Active - {daysLeft} day{(daysLeft > 1 ? "s" : "")} left]";
                statusColor = Color.DarkGreen;
            }

            if (cmbProduct.SelectedItem is ProductComboItem selected && selected.Id > 0)
            {
                decimal originalPrice = selected.SellingPrice;
                decimal discountPct = numDiscountPercent.Value;
                decimal discountAmount = Math.Round(originalPrice * (discountPct / 100m), 2);
                decimal discountedPrice = Math.Max(0, originalPrice - discountAmount);

                lblPreviewDetails.Text = $"Original: ${originalPrice:N2}  ➔  Discounted: ${discountedPrice:N2} (Save ${discountAmount:N2}){statusText}";
                lblPreviewDetails.ForeColor = statusColor;
            }
            else
            {
                lblPreviewDetails.Text = $"Please select a product above.{statusText}";
                lblPreviewDetails.ForeColor = Color.Gray;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cmbProduct.SelectedItem is ProductComboItem selectedProduct) || selectedProduct.Id <= 0)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProduct.Focus();
                return;
            }

            string name = txtPromoName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a Promotion Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPromoName.Focus();
                return;
            }

            if (numDiscountPercent.Value <= 0 || numDiscountPercent.Value > 100)
            {
                MessageBox.Show("Discount percentage must be between 0.01% and 100%.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDiscountPercent.Focus();
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return;
            }

            string errorMessage;
            bool success;

            if (_promoId > 0 && _promotion != null)
            {
                _promotion.ProductId = selectedProduct.Id;
                _promotion.PromotionName = name;
                _promotion.DiscountPercent = numDiscountPercent.Value;
                _promotion.StartDate = startDate;
                _promotion.EndDate = endDate;

                success = _promotionsDAL.UpdatePromotion(_promotion, out errorMessage);
            }
            else
            {
                var newPromo = new Promotions
                {
                    ProductId = selectedProduct.Id,
                    PromotionName = name,
                    DiscountPercent = numDiscountPercent.Value,
                    StartDate = startDate,
                    EndDate = endDate
                };

                success = _promotionsDAL.AddPromotion(newPromo, out errorMessage);
            }

            if (success)
            {
                MessageBox.Show("Promotion saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save promotion: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
