using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.UI.Point_of_sale
{
    public partial class frmApplyDiscount : Form
    {
        private readonly PromotionsDAL _promotionsDAL = new PromotionsDAL();
        private readonly decimal _subtotal;
        private List<Promotions> _activePromos = new List<Promotions>();

        public Promotions AppliedPromotion { get; private set; }
        public string SelectedDiscountType { get; private set; } = "None"; // "PromoCode", "Percentage", "Fixed", "None"
        public decimal DiscountRate { get; private set; } = 0.00m;
        public decimal CalculatedDiscount { get; private set; } = 0.00m;

        public frmApplyDiscount(decimal cartSubtotal, Promotions initialPromo = null, string initialType = "None", decimal initialRate = 0)
        {
            InitializeComponent();
            _subtotal = Math.Max(0, cartSubtotal);
            AppliedPromotion = initialPromo;
            SelectedDiscountType = initialType;
            DiscountRate = initialRate;
        }

        private void frmApplyDiscount_Load(object sender, EventArgs e)
        {
            lblSubtotalVal.Text = $"${_subtotal:N2}";
            LoadActivePromotions();

            // Set initial state
            if (AppliedPromotion != null)
            {
                rbPromo.Checked = true;
                txtPromoCode.Text = AppliedPromotion.PromotionName;
                CheckAndApplyPromo(AppliedPromotion.PromotionName, silent: true);
            }
            else if (SelectedDiscountType == "Percentage" && DiscountRate > 0)
            {
                rbPercent.Checked = true;
                numPercent.Value = Math.Min(100, DiscountRate);
            }
            else if (SelectedDiscountType == "Fixed" && DiscountRate > 0)
            {
                rbFixed.Checked = true;
                numFixed.Value = Math.Min(10000, DiscountRate);
            }
            else
            {
                rbPercent.Checked = true;
            }

            Recalculate();
        }

        private void LoadActivePromotions()
        {
            try
            {
                _activePromos = _promotionsDAL.GetActivePromotions() ?? new List<Promotions>();
                cmbActivePromos.Items.Clear();
                cmbActivePromos.Items.Add("-- Select from active promotions --");

                foreach (var p in _activePromos)
                {
                    cmbActivePromos.Items.Add($"{p.ProductName}: {p.FormattedDiscount} OFF ({p.PromotionName})");
                }
                cmbActivePromos.SelectedIndex = 0;
            }
            catch
            {
                // Ignore fallback
            }
        }

        private void DiscountType_CheckedChanged(object sender, EventArgs e)
        {
            pnlPromo.Visible = rbPromo.Checked;
            pnlPercent.Visible = rbPercent.Checked;
            pnlFixed.Visible = rbFixed.Checked;

            Recalculate();
        }

        private void QuickPercent_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2Button btn && decimal.TryParse(btn.Text.Replace("%", "").Trim(), out decimal p))
            {
                numPercent.Value = p;
                Recalculate();
            }
        }

        private void QuickFixed_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2Button btn && decimal.TryParse(btn.Text.Replace("$", "").Trim(), out decimal f))
            {
                numFixed.Value = f;
                Recalculate();
            }
        }

        private void numPercent_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void numFixed_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void txtPromoCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPromoCode.Text))
            {
                AppliedPromotion = null;
                lblPromoDetails.Text = "Enter promo name or choose from active promos";
                lblPromoDetails.ForeColor = Color.Gray;
                Recalculate();
            }
        }

        private void cmbActivePromos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActivePromos.SelectedIndex > 0 && cmbActivePromos.SelectedIndex - 1 < _activePromos.Count)
            {
                var selected = _activePromos[cmbActivePromos.SelectedIndex - 1];
                txtPromoCode.Text = selected.PromotionName;
                AppliedPromotion = selected;
                lblPromoDetails.Text = $"✅ {selected.ProductName}: {selected.FormattedDiscount} OFF applied!";
                lblPromoDetails.ForeColor = Color.SeaGreen;
                Recalculate();
            }
        }

        private void btnCheckCode_Click(object sender, EventArgs e)
        {
            string name = txtPromoCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a promotion name to check.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPromoCode.Focus();
                return;
            }

            CheckAndApplyPromo(name, silent: false);
        }

        private bool CheckAndApplyPromo(string query, bool silent)
        {
            var promo = _activePromos.FirstOrDefault(p => 
                p.PromotionName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                p.ProductName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                p.Barcode.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

            if (promo == null)
            {
                AppliedPromotion = null;
                lblPromoDetails.Text = $"❌ Promotion '{query}' not found.";
                lblPromoDetails.ForeColor = Color.Crimson;
                if (!silent) MessageBox.Show($"Promotion '{query}' was not found.", "Invalid Promotion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Recalculate();
                return false;
            }

            if (!promo.IsCurrentlyActive)
            {
                AppliedPromotion = null;
                lblPromoDetails.Text = $"⚠️ Promotion '{promo.PromotionName}' is expired.";
                lblPromoDetails.ForeColor = Color.DarkOrange;
                if (!silent) MessageBox.Show($"Promotion '{promo.PromotionName}' has expired.", "Promo Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Recalculate();
                return false;
            }

            AppliedPromotion = promo;
            lblPromoDetails.Text = $"✅ {promo.ProductName}: {promo.FormattedDiscount} OFF ({promo.PromotionName})";
            lblPromoDetails.ForeColor = Color.SeaGreen;
            if (!silent) MessageBox.Show($"Promotion '{promo.PromotionName}' ({promo.FormattedDiscount} off) applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Recalculate();
            return true;
        }

        private void Recalculate()
        {
            decimal discount = 0.00m;

            if (rbPromo.Checked)
            {
                if (AppliedPromotion != null && AppliedPromotion.IsCurrentlyActive)
                {
                    discount = Math.Round(_subtotal * (AppliedPromotion.DiscountPercent / 100m), 2);
                }
            }
            else if (rbPercent.Checked)
            {
                decimal rate = numPercent.Value;
                if (rate > 0)
                {
                    discount = Math.Round(_subtotal * (rate / 100m), 2);
                }
            }
            else if (rbFixed.Checked)
            {
                decimal fixedVal = numFixed.Value;
                if (fixedVal > 0)
                {
                    discount = Math.Min(_subtotal, fixedVal);
                }
            }

            CalculatedDiscount = discount;
            decimal grandTotal = Math.Max(0, _subtotal - CalculatedDiscount);

            lblDiscountVal.Text = CalculatedDiscount > 0 ? $"-${CalculatedDiscount:N2}" : "$0.00";
            lblGrandTotalVal.Text = $"${grandTotal:N2}";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (rbPromo.Checked)
            {
                string name = txtPromoCode.Text.Trim();
                if (!string.IsNullOrWhiteSpace(name) && AppliedPromotion == null)
                {
                    if (!CheckAndApplyPromo(name, silent: false))
                    {
                        return;
                    }
                }

                SelectedDiscountType = AppliedPromotion != null ? "PromoCode" : "None";
                DiscountRate = AppliedPromotion != null ? AppliedPromotion.DiscountPercent : 0;
            }
            else if (rbPercent.Checked)
            {
                AppliedPromotion = null;
                SelectedDiscountType = numPercent.Value > 0 ? "Percentage" : "None";
                DiscountRate = numPercent.Value;
            }
            else if (rbFixed.Checked)
            {
                AppliedPromotion = null;
                SelectedDiscountType = numFixed.Value > 0 ? "Fixed" : "None";
                DiscountRate = numFixed.Value;
            }

            Recalculate();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AppliedPromotion = null;
            SelectedDiscountType = "None";
            DiscountRate = 0;
            CalculatedDiscount = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
