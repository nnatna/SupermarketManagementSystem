using Supermarket.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using Supermarket.DAL;

namespace Supermarket.UI.Dashboard
{
    public partial class frrmDashoard : Form
    {
        private readonly DashboardDAL _dashboardDAL = new DashboardDAL();
        private bool _isLoading = false;

        public frrmDashoard()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(dgvRecentSales);
            UIThemeHelper.ApplyModernGridStyle(dgvStockAlerts);
            ConfigureGrids();
        }

        private void ConfigureGrids()
        {
            dgvRecentSales.AutoGenerateColumns = false;
            dgvStockAlerts.AutoGenerateColumns = false;
        }

        private async void frrmDashoard_Load(object sender, EventArgs e)
        {
            await LoadDashboardDataAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await LoadDashboardDataAsync();
            btnRefresh.Enabled = true;
        }

        public async Task LoadDashboardDataAsync()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                lblLastUpdated.Text = "Updating data...";

                // Fetch data in parallel
                var summaryTask = _dashboardDAL.GetSummaryMetricsAsync();
                var trendTask = _dashboardDAL.GetSalesTrendLast7DaysAsync();
                var categoryTask = _dashboardDAL.GetCategoryDistributionAsync();
                var recentSalesTask = _dashboardDAL.GetRecentSalesAsync(8);
                var stockAlertsTask = _dashboardDAL.GetCriticalStockAlertsAsync(8);

                await Task.WhenAll(summaryTask, trendTask, categoryTask, recentSalesTask, stockAlertsTask);

                var summary = await summaryTask;
                var trendPoints = await trendTask;
                var categoryShares = await categoryTask;
                var recentSales = await recentSalesTask;
                var stockAlerts = await stockAlertsTask;

                // 1. Update KPI Summary Cards
                UpdateSummaryCards(summary);

                // 2. Render Charts
                RenderSalesTrendChart(trendPoints);
                RenderCategoryChart(categoryShares);

                // 3. Populate DataGridViews
                dgvRecentSales.DataSource = recentSales;
                dgvStockAlerts.DataSource = stockAlerts;

                lblLastUpdated.Text = $"Last updated: {DateTime.Now:hh:mm:ss tt}";
            }
            catch (Exception ex)
            {
                lblLastUpdated.Text = "Update failed";
                System.Diagnostics.Debug.WriteLine("Dashboard Load Error: " + ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void UpdateSummaryCards(DashboardSummaryDTO summary)
        {
            if (summary == null) return;

            // Card 1: Today Sales
            lblTodaySalesVal.Text = $"${summary.TodaySales:N2}";
            lblTodayOrdersSub.Text = $"{summary.TodayOrders} order{(summary.TodayOrders == 1 ? "" : "s")} completed today";

            // Card 2: Month Sales
            lblMonthSalesVal.Text = $"${summary.MonthlySales:N2}";
            lblMonthOrdersSub.Text = $"{summary.MonthlyOrders} order{(summary.MonthlyOrders == 1 ? "" : "s")} this month";

            // Card 3: Total Products
            lblProductsVal.Text = $"{summary.TotalProducts} Items";
            lblInventoryValSub.Text = $"Stock Value: ${summary.TotalInventoryValue:N2}";

            // Card 4: Stock Alerts
            lblStockAlertVal.Text = $"{summary.LowStockCount} Low";
            lblOutOfStockSub.Text = $"{summary.OutOfStockCount} Out of stock";
        }

        private void RenderSalesTrendChart(List<ChartDataPointDTO> trendPoints)
        {
            try
            {
                chartSalesTrend.Datasets.Clear();

                chartSalesTrend.Title.Text = "";
                chartSalesTrend.Legend.Display = false;

                GunaSplineDataset splineDataset = new GunaSplineDataset();
                splineDataset.Label = "Revenue ($)";
                splineDataset.BorderColor = Color.FromArgb(79, 70, 229); // Indigo
                splineDataset.FillColor = Color.FromArgb(40, 99, 102, 241);
                splineDataset.BorderWidth = 3;
                splineDataset.PointRadius = 4;
                splineDataset.PointFillColors.Add(Color.FromArgb(79, 70, 229));

                if (trendPoints != null && trendPoints.Count > 0)
                {
                    foreach (var pt in trendPoints)
                    {
                        splineDataset.DataPoints.Add(pt.Label, (double)pt.Value);
                    }
                }
                else
                {
                    splineDataset.DataPoints.Add("No Data", 0);
                }

                chartSalesTrend.Datasets.Add(splineDataset);
                chartSalesTrend.Update();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Sales Trend Chart Error: " + ex.Message);
            }
        }

        private void RenderCategoryChart(List<CategoryShareDTO> categoryShares)
        {
            try
            {
                chartCategories.Datasets.Clear();

                chartCategories.Title.Text = "";
                chartCategories.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
                chartCategories.Legend.Display = true;

                GunaDoughnutDataset doughnutDataset = new GunaDoughnutDataset();
                doughnutDataset.Label = "Products";

                Color[] palette = new Color[]
                {
                    Color.FromArgb(59, 130, 246),  // Blue
                    Color.FromArgb(16, 185, 129),  // Emerald
                    Color.FromArgb(245, 158, 11),  // Amber
                    Color.FromArgb(239, 68, 68),   // Red
                    Color.FromArgb(139, 92, 246),  // Purple
                    Color.FromArgb(236, 72, 153),  // Pink
                    Color.FromArgb(20, 184, 166),  // Teal
                    Color.FromArgb(100, 116, 139)  // Slate
                };

                if (categoryShares != null && categoryShares.Count > 0)
                {
                    int colorIdx = 0;
                    foreach (var cat in categoryShares.Where(c => c.ProductCount > 0))
                    {
                        doughnutDataset.DataPoints.Add(cat.CategoryName, cat.ProductCount);
                        doughnutDataset.FillColors.Add(palette[colorIdx % palette.Length]);
                        colorIdx++;
                    }
                }

                if (doughnutDataset.DataPoints.Count == 0)
                {
                    doughnutDataset.DataPoints.Add("No Data", 1);
                    doughnutDataset.FillColors.Add(Color.FromArgb(203, 213, 225));
                }

                chartCategories.Datasets.Add(doughnutDataset);
                chartCategories.Update();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Category Chart Error: " + ex.Message);
            }
        }

        private void dgvRecentSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvRecentSales.Columns[e.ColumnIndex].Name;

            if (colName == "colAmt")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = $"${val:N2}";
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Green
                    e.CellStyle.SelectionForeColor = Color.FromArgb(16, 185, 129);
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colDate")
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("MM/dd HH:mm");
                    e.CellStyle.SelectionForeColor = dgvRecentSales.DefaultCellStyle.ForeColor;
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
                e.CellStyle.SelectionForeColor = dgvRecentSales.DefaultCellStyle.ForeColor;
            }
        }

        private void dgvStockAlerts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvStockAlerts.Columns[e.ColumnIndex].Name;

            if (colName == "colStockStatus" || colName == "colStock")
            {
                if (dgvStockAlerts.Rows[e.RowIndex].DataBoundItem is LowStockItemDTO item)
                {
                    if (item.CurrentStock <= 0)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Red
                        e.CellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else if (item.CurrentStock <= item.AlertLevel)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6); // Amber
                        e.CellStyle.SelectionForeColor = Color.FromArgb(217, 119, 6);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                }
            }
            else
            {
                e.CellStyle.SelectionForeColor = dgvStockAlerts.DefaultCellStyle.ForeColor;
            }
        }
    }
}


