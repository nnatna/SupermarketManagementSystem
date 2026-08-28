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
    public partial class frmProfitLoss : Form
    {
        private readonly ReportsDAL _reportsDAL = new ReportsDAL();
        private bool _isLoading = false;

        public frmProfitLoss()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(dgvProfitLoss);
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dgvProfitLoss.AutoGenerateColumns = false;
        }

        private async void frmProfitLoss_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpStartDate.Value = new DateTime(now.Year, now.Month, 1);
            dtpEndDate.Value = now;

            await LoadProfitLossReportAsync();
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await LoadProfitLossReportAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            await LoadProfitLossReportAsync();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (dgvProfitLoss.DataSource is List<ProfitLossItemDTO> list && list.Count > 0)
            {
                var viewer = new frmReportViewer("rptProfitLoss.rdlc", "DataSet1", list, "Profit & Loss Statement Preview");
                viewer.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No profit/loss records to generate report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public async Task LoadProfitLossReportAsync()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                btnFilter.Enabled = false;
                btnRefresh.Enabled = false;

                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                var data = await _reportsDAL.GetProfitLossReportAsync(startDate, endDate);
                var summary = data.Item1;
                var items = data.Item2;

                lblRevenueVal.Text = $"${summary.TotalRevenue:N2}";
                lblCogsVal.Text = $"${summary.TotalCostOfGoods:N2}";
                lblProfitVal.Text = $"${summary.GrossProfit:N2}";
                lblMarginVal.Text = $"{summary.ProfitMargin:F1}%";

                dgvProfitLoss.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Profit & Loss Report: " + ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFilter.Enabled = true;
                btnRefresh.Enabled = true;
                _isLoading = false;
            }
        }

        private void dgvProfitLoss_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvProfitLoss.Columns[e.ColumnIndex].Name;

            if (colName == "colRev" || colName == "colCost" || colName == "colGrossProfit")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = $"${val:N2}";
                    if (colName == "colGrossProfit")
                    {
                        if (val >= 0)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Green
                            e.CellStyle.SelectionForeColor = Color.FromArgb(16, 185, 129);
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Red
                            e.CellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
                        }
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else if (colName == "colRev")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); // Blue
                        e.CellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.SelectionForeColor = dgvProfitLoss.DefaultCellStyle.ForeColor;
                    }
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colMarginPct")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal margin))
                {
                    e.Value = $"{margin:F1}%";
                    if (margin >= 0)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(139, 92, 246);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(139, 92, 246);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
                    }
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
            }
            else
            {
                e.CellStyle.SelectionForeColor = dgvProfitLoss.DefaultCellStyle.ForeColor;
            }
        }
    }
}


