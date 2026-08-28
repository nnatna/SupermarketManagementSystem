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
    public partial class frmSalesReport : Form
    {
        private readonly ReportsDAL _reportsDAL = new ReportsDAL();
        private bool _isLoading = false;

        public frmSalesReport()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(dgvSales);
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dgvSales.AutoGenerateColumns = false;
        }

        private async void frmSalesReport_Load(object sender, EventArgs e)
        {
            // Set default range to current month
            DateTime now = DateTime.Now;
            dtpStartDate.Value = new DateTime(now.Year, now.Month, 1);
            dtpEndDate.Value = now;

            await LoadSalesReportAsync();
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await LoadSalesReportAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            cmbPaymentMethod.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            await LoadSalesReportAsync();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (dgvSales.DataSource is List<SalesReportItemDTO> list && list.Count > 0)
            {
                var viewer = new frmReportViewer("rptSalesReport.rdlc", "DataSet1", list, "Sales & Revenue Report Preview");
                viewer.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No sales records to generate report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public async Task LoadSalesReportAsync()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                btnFilter.Enabled = false;
                btnRefresh.Enabled = false;

                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;
                string paymentMethod = cmbPaymentMethod.SelectedItem?.ToString();
                string status = cmbStatus.SelectedItem?.ToString();

                var sales = await _reportsDAL.GetSalesReportAsync(startDate, endDate, paymentMethod, status);

                // Compute summary metrics
                var activeSales = sales.Where(s => !s.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase)).ToList();

                decimal gross = activeSales.Sum(s => s.Subtotal);
                decimal discounts = activeSales.Sum(s => s.Discount);
                decimal net = activeSales.Sum(s => s.GrandTotal);
                int invoiceCount = activeSales.Count;

                lblGrossVal.Text = $"${gross:N2}";
                lblDiscountVal.Text = $"${discounts:N2}";
                lblNetVal.Text = $"${net:N2}";
                lblInvoicesVal.Text = $"{invoiceCount} Bills";

                dgvSales.DataSource = sales;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Sales Report: " + ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFilter.Enabled = true;
                btnRefresh.Enabled = true;
                _isLoading = false;
            }
        }

        private void dgvSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvSales.Columns[e.ColumnIndex].Name;

            if (colName == "colSubtotal" || colName == "colDiscount" || colName == "colGrandTotal")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = $"${val:N2}";
                    if (colName == "colGrandTotal")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Green
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(16, 185, 129);
                    }
                    else if (colName == "colDiscount" && val > 0)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Red
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
                    }
                    else
                    {
                        e.CellStyle.SelectionForeColor = dgvSales.DefaultCellStyle.ForeColor;
                    }
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colDate")
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("yyyy-MM-dd HH:mm");
                    e.CellStyle.SelectionForeColor = dgvSales.DefaultCellStyle.ForeColor;
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colStatus")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = "Cancelled";
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.Value = "Completed";
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(22, 163, 74);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    e.FormattingApplied = true;
                }
            }
            else
            {
                e.CellStyle.SelectionForeColor = dgvSales.DefaultCellStyle.ForeColor;
            }
        }
    }
}


