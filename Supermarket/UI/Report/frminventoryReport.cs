using Supermarket.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.DAL;

namespace Supermarket.UI.Report
{
    public partial class frminventoryReport : Form
    {
        private readonly ReportsDAL _reportsDAL = new ReportsDAL();
        private readonly CategoriesDAL _categoriesDAL = new CategoriesDAL();
        private bool _isLoading = false;

        public frminventoryReport()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(dgvInventory);
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dgvInventory.AutoGenerateColumns = false;
        }

        private async void frminventoryReport_Load(object sender, EventArgs e)
        {
            await PopulateCategoriesAsync();
            await LoadInventoryReportAsync();
        }

        private async Task PopulateCategoriesAsync()
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");

                var categories = _categoriesDAL.GetAllCategories();
                if (categories != null)
                {
                    foreach (var cat in categories)
                    {
                        cmbCategory.Items.Add(cat.CategoryName);
                    }
                }

                cmbCategory.SelectedIndex = 0;
                cmbStockStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Populate Categories Error: " + ex.Message);
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await LoadInventoryReportAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
            cmbStockStatus.SelectedIndex = 0;
            await LoadInventoryReportAsync();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (dgvInventory.DataSource is List<InventoryReportItemDTO> list && list.Count > 0)
            {
                var viewer = new frmReportViewer("rptInventoryReport.rdlc", "DataSet1", list, "Inventory Valuation Report Preview");
                viewer.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No inventory records to generate report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public async Task LoadInventoryReportAsync()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                btnFilter.Enabled = false;
                btnRefresh.Enabled = false;

                string category = cmbCategory.SelectedItem?.ToString();
                string stockStatus = cmbStockStatus.SelectedItem?.ToString();

                var items = await _reportsDAL.GetInventoryReportAsync(category, stockStatus);

                int totalSkus = items.Count;
                int totalQty = items.Sum(i => i.StockQuantity);
                decimal totalCost = items.Sum(i => i.TotalCost);
                decimal totalRetail = items.Sum(i => i.TotalValue);

                lblTotalSkusVal.Text = $"{totalSkus} SKUs";
                lblTotalQtyVal.Text = $"{totalQty:N0} Units";
                lblCostValVal.Text = $"${totalCost:N2}";
                lblRetailValVal.Text = $"${totalRetail:N2}";

                dgvInventory.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Inventory Report: " + ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFilter.Enabled = true;
                btnRefresh.Enabled = true;
                _isLoading = false;
            }
        }

        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvInventory.Columns[e.ColumnIndex].Name;

            if (colName == "colCost" || colName == "colPrice" || colName == "colTotalCost" || colName == "colTotalValue")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = $"${val:N2}";
                    if (colName == "colTotalValue")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Green
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(16, 185, 129);
                    }
                    else
                    {
                        e.CellStyle.SelectionForeColor = dgvInventory.DefaultCellStyle.ForeColor;
                    }
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colMargin")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal margin))
                {
                    e.Value = $"{margin:F1}%";
                    e.CellStyle.SelectionForeColor = dgvInventory.DefaultCellStyle.ForeColor;
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colStatus")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status.Equals("Out of Stock", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Red
                        e.CellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else if (status.Equals("Low Stock", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6); // Amber
                        e.CellStyle.SelectionForeColor = Color.FromArgb(217, 119, 6);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); // Green
                        e.CellStyle.SelectionForeColor = Color.FromArgb(22, 163, 74);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    e.FormattingApplied = true;
                }
            }
            else
            {
                e.CellStyle.SelectionForeColor = dgvInventory.DefaultCellStyle.ForeColor;
            }
        }
    }
}


