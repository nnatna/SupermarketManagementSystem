using Supermarket.Utils;
using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Settings
{
    public partial class frmPromotion : Form
    {
        private readonly PromotionsDAL _promotionsDAL = new PromotionsDAL();
        private List<Promotions> _allPromotions = new List<Promotions>();

        public frmPromotion()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(dgvPromotions);
            dgvPromotions.AutoGenerateColumns = false;
        }

        private async void frmPromotion_Load(object sender, EventArgs e)
        {
            dgvPromotions.AutoGenerateColumns = false;
            PopulateFilterStatus();
            PopulateSortColumns();
            txtSearch.PlaceholderForeColor = Color.Gray;
            dgvPromotions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPromotions.MultiSelect = false;
            dgvPromotions.ReadOnly = true;
            dgvPromotions.CellFormatting += dgvPromotions_CellFormatting;
            dgvPromotions.CellDoubleClick += (s, ev) => { if (ev.RowIndex >= 0) btnEdit_Click(s, ev); };

            await LoadPromotionsAsync();
        }

        private void PopulateFilterStatus()
        {
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All Status");
            cmbFilterStatus.Items.Add("Active");
            cmbFilterStatus.Items.Add("Upcoming");
            cmbFilterStatus.Items.Add("Expired");
            if (cmbFilterStatus.Items.Count > 0)
                cmbFilterStatus.SelectedIndex = 0;
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.Items.Add("Product Name");
            cmbSortColumn.Items.Add("Promotion Name");
            cmbSortColumn.Items.Add("Discount %");
            cmbSortColumn.Items.Add("Start Date");
            cmbSortColumn.Items.Add("End Date");
            if (cmbSortColumn.Items.Count > 0)
                cmbSortColumn.SelectedIndex = 0;
        }

        private async Task LoadPromotionsAsync()
        {
            try
            {
                _allPromotions = await Task.Run(() => _promotionsDAL.GetAllPromotions());
                ApplyFilterAndSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading promotions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilterAndSort()
        {
            if (_allPromotions == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cmbFilterStatus.SelectedItem?.ToString() ?? "All Status";

            // 1. Filter
            IEnumerable<Promotions> query = _allPromotions;

            if (selectedStatus != "All Status")
            {
                if (selectedStatus == "Active")
                {
                    query = query.Where(p => p.Status == "Active");
                }
                else if (selectedStatus == "Upcoming")
                {
                    query = query.Where(p => p.Status == "Upcoming");
                }
                else if (selectedStatus == "Expired")
                {
                    query = query.Where(p => p.Status == "Expired");
                }
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p =>
                    p.Id.ToString().Contains(keyword) ||
                    (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(p.Barcode) && p.Barcode.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(p.PromotionName) && p.PromotionName.ToLower().Contains(keyword))
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Id";
            bool isDescending = btnSortOrder.Checked;

            switch (selectedCol)
            {
                case "Product Name":
                    query = isDescending ? query.OrderByDescending(p => p.ProductName) : query.OrderBy(p => p.ProductName);
                    break;
                case "Promotion Name":
                    query = isDescending ? query.OrderByDescending(p => p.PromotionName) : query.OrderBy(p => p.PromotionName);
                    break;
                case "Discount %":
                    query = isDescending ? query.OrderByDescending(p => p.DiscountPercent) : query.OrderBy(p => p.DiscountPercent);
                    break;
                case "Start Date":
                    query = isDescending ? query.OrderByDescending(p => p.StartDate) : query.OrderBy(p => p.StartDate);
                    break;
                case "End Date":
                    query = isDescending ? query.OrderByDescending(p => p.EndDate) : query.OrderBy(p => p.EndDate);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id);
                    break;
            }

            dgvPromotions.AutoGenerateColumns = false;
            dgvPromotions.DataSource = query.ToList();
        }

        private void dgvPromotions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            string colName = dgvPromotions.Columns[e.ColumnIndex].Name;

            if (colName == "colStatus" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                    e.CellStyle.SelectionForeColor = Color.ForestGreen;
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else if (status.Equals("Expired", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.SelectionForeColor = Color.Crimson;
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.SelectionForeColor = Color.DarkOrange;
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
            else if (colName == "colDiscount" && e.Value != null)
            {
                e.CellStyle.ForeColor = Color.Crimson;
                e.CellStyle.SelectionForeColor = Color.Crimson;
                e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            }
            else if (colName == "colOriginalPrice" && e.Value is decimal origPrice)
            {
                e.Value = $"${origPrice:N2}";
                e.CellStyle.ForeColor = Color.FromArgb(13, 110, 253);
                e.CellStyle.SelectionForeColor = Color.FromArgb(13, 110, 253);
                e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                e.FormattingApplied = true;
            }
            else if (colName == "colDiscountedPrice" && e.Value is decimal discPrice)
            {
                e.Value = $"${discPrice:N2}";
                e.CellStyle.ForeColor = Color.ForestGreen;
                e.CellStyle.SelectionForeColor = Color.ForestGreen;
                e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                e.FormattingApplied = true;
            }
            else if ((colName == "colStartDate" || colName == "colEndDate") && e.Value is DateTime dt)
            {
                e.Value = dt.ToString("yyyy-MM-dd");
                e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                e.FormattingApplied = true;
            }
        }

        private long GetSelectedPromotionId()
        {
            if (dgvPromotions.CurrentRow != null)
            {
                if (dgvPromotions.CurrentRow.DataBoundItem is Promotions promo)
                {
                    return promo.Id;
                }
                else if (dgvPromotions.CurrentRow.Cells["colId"].Value != null &&
                         long.TryParse(dgvPromotions.CurrentRow.Cells["colId"].Value.ToString(), out long id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedPromotionName()
        {
            if (dgvPromotions.CurrentRow != null)
            {
                if (dgvPromotions.CurrentRow.DataBoundItem is Promotions promo)
                {
                    return $"{promo.PromotionName} ({promo.ProductName})";
                }
                else if (dgvPromotions.CurrentRow.Cells["colPromoName"].Value != null)
                {
                    return dgvPromotions.CurrentRow.Cells["colPromoName"].Value.ToString();
                }
            }
            return "selected promotion";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void FilterOrSort_Changed(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void btnSortOrder_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            btnSortOrder.Checked = false;
            if (cmbFilterStatus.Items.Count > 0)
                cmbFilterStatus.SelectedIndex = 0;
            if (cmbSortColumn.Items.Count > 0)
                cmbSortColumn.SelectedIndex = 0;
            await LoadPromotionsAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new frmAddEditPromotion(0))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await LoadPromotionsAsync();
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            long selectedId = GetSelectedPromotionId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a promotion to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new frmAddEditPromotion(selectedId))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await LoadPromotionsAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            long selectedId = GetSelectedPromotionId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a promotion to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string promoName = GetSelectedPromotionName();
            var confirm = MessageBox.Show($"Are you sure you want to delete '{promoName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string errorMsg;
                bool deleted = _promotionsDAL.DeletePromotion(selectedId, out errorMsg);
                if (deleted)
                {
                    MessageBox.Show("Promotion deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPromotionsAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete promotion: " + errorMsg, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


