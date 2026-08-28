using Supermarket.Utils;
using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Inventory
{
    public partial class frmStoctAlert : Form
    {
        private readonly StockAdjustmentsDAL _stockAdjustmentsDAL = new StockAdjustmentsDAL();
        private List<vw_StockAlert> _allStockAlerts = new List<vw_StockAlert>();

        public frmStoctAlert()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayStockAlert);
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Load += frmStoctAlert_Load;
            this.txtSearch.TextChanged += txtSearch_TextChanged;
            this.btnSort.Click += btnSort_Click;
            this.cmbSortColumn.SelectedIndexChanged += cmbSortColumn_SelectedIndexChanged;
            this.btnRefesh.Click += btnRefesh_Click;
            this.displayStockAlert.CellFormatting += displayStockAlert_CellFormatting;
        }

        private void ConfigureColumns()
        {
            displayStockAlert.AutoGenerateColumns = false;
            displayStockAlert.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            displayStockAlert.RowTemplate.Height = 45;
            displayStockAlert.ThemeStyle.RowsStyle.Height = 45;

            this.colPartID.DataPropertyName = "PartID";
            this.colBarcode.DataPropertyName = "Barcode";
            this.colProductName.DataPropertyName = "ProductName";
            this.colCategory.DataPropertyName = "CategoryName";
            this.colCurrentStock.DataPropertyName = "CurrentStock";
            this.colAlertQty.DataPropertyName = "AlertQty";
            this.colLastRestocked.DataPropertyName = "LastRestocked";
            this.colStatusText.DataPropertyName = "StatusText";
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Current Stock");
            cmbSortColumn.Items.Add("Product Name");
            cmbSortColumn.Items.Add("Category");
            cmbSortColumn.Items.Add("Alert Quantity");
            cmbSortColumn.Items.Add("Barcode");
            cmbSortColumn.Items.Add("Last Restocked");
            cmbSortColumn.Items.Add("Status");
            cmbSortColumn.Items.Add("ID");

            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmStoctAlert_Load(object sender, EventArgs e)
        {
            ConfigureColumns();
            PopulateSortColumns();

            txtSearch.PlaceholderText = "Search by Product, Barcode, Category...";
            txtSearch.PlaceholderForeColor = Color.Gray;

            await LoadStockAlertsAsync();
        }

        private async Task LoadStockAlertsAsync()
        {
            _allStockAlerts = await Task.Run(() => _stockAdjustmentsDAL.GetStockAlerts()) ?? new List<vw_StockAlert>();
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allStockAlerts == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Keyword search filter
            IEnumerable<vw_StockAlert> query = _allStockAlerts;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(a =>
                    (a.ProductName != null && a.ProductName.ToLower().Contains(keyword)) ||
                    (a.Barcode != null && a.Barcode.ToLower().Contains(keyword)) ||
                    (a.CategoryName != null && a.CategoryName.ToLower().Contains(keyword)) ||
                    (a.StatusText != null && a.StatusText.ToLower().Contains(keyword)) ||
                    (a.LastRestocked != null && a.LastRestocked.ToLower().Contains(keyword)) ||
                    a.PartID.ToString().Contains(keyword) ||
                    a.CurrentStock.ToString().Contains(keyword) ||
                    a.AlertQty.ToString().Contains(keyword)
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Current Stock";
            bool isDescending = btnSort.Checked; // Checked = Descending, Unchecked = Ascending

            switch (selectedCol)
            {
                case "Product Name":
                    query = isDescending ? query.OrderByDescending(a => a.ProductName) : query.OrderBy(a => a.ProductName);
                    break;
                case "Category":
                    query = isDescending ? query.OrderByDescending(a => a.CategoryName) : query.OrderBy(a => a.CategoryName);
                    break;
                case "Alert Quantity":
                    query = isDescending ? query.OrderByDescending(a => a.AlertQty) : query.OrderBy(a => a.AlertQty);
                    break;
                case "Barcode":
                    query = isDescending ? query.OrderByDescending(a => a.Barcode) : query.OrderBy(a => a.Barcode);
                    break;
                case "Last Restocked":
                    query = isDescending ? query.OrderByDescending(a => a.LastRestocked) : query.OrderBy(a => a.LastRestocked);
                    break;
                case "Status":
                    query = isDescending ? query.OrderByDescending(a => a.StatusText) : query.OrderBy(a => a.StatusText);
                    break;
                case "ID":
                    query = isDescending ? query.OrderByDescending(a => a.PartID) : query.OrderBy(a => a.PartID);
                    break;
                case "Current Stock":
                default:
                    query = isDescending ? query.OrderByDescending(a => a.CurrentStock) : query.OrderBy(a => a.CurrentStock);
                    break;
            }

            displayStockAlert.DataSource = null;
            displayStockAlert.DataSource = query.ToList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private async void btnRefesh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            btnSort.Checked = false;
            if (cmbSortColumn.Items.Count > 0)
            {
                cmbSortColumn.SelectedIndex = 0;
            }
            await LoadStockAlertsAsync();
        }

        private void displayStockAlert_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayStockAlert.Columns[e.ColumnIndex].Name;

            // Format Current Stock column
            if (colName == "colCurrentStock")
            {
                if (int.TryParse(e.Value.ToString(), out int stock))
                {
                    e.Value = stock.ToString("N0");
                    if (stock == 0)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69); // Crimson Red
                        e.CellStyle.SelectionForeColor = Color.FromArgb(220, 53, 69);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34); // Amber / Orange
                        e.CellStyle.SelectionForeColor = Color.FromArgb(230, 126, 34);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                }
            }
            // Format Alert Quantity column
            else if (colName == "colAlertQty")
            {
                if (int.TryParse(e.Value.ToString(), out int alertQty))
                {
                    e.Value = alertQty.ToString("N0");
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
            // Format Status column
            else if (colName == "colStatusText")
            {
                string status = e.Value.ToString().Trim().ToLower();
                if (status.Contains("out"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69); // Red for Out of Stock
                    e.CellStyle.SelectionForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else if (status.Contains("low"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34); // Orange / Amber for Low Stock
                    e.CellStyle.SelectionForeColor = Color.FromArgb(230, 126, 34);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(46, 139, 87); // Green for Normal
                    e.CellStyle.SelectionForeColor = Color.FromArgb(46, 139, 87);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
        }
    }
}


