using Supermarket.Utils;
using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Inventory
{
    public partial class frmStockAdjustment : Form
    {
        private readonly StockAdjustmentsDAL _stockAdjustmentsDAL = new StockAdjustmentsDAL();
        private List<vw_Stock_adjustments> _allAdjustments = new List<vw_Stock_adjustments>();

        public frmStockAdjustment()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayStockAdjustments);
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Date");
            cmbSortColumn.Items.Add("Product");
            cmbSortColumn.Items.Add("Type");
            cmbSortColumn.Items.Add("Current Stock");
            cmbSortColumn.Items.Add("Quantity");
            cmbSortColumn.Items.Add("User");
            cmbSortColumn.Items.Add("ID");
            cmbSortColumn.Items.Add("Status");

            cmbSortColumn.SelectedIndex = 0;
        }

        private void ConfigureColumns()
        {
            displayStockAdjustments.AutoGenerateColumns = false;
            displayStockAdjustments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            displayStockAdjustments.RowTemplate.Height = 45;
            displayStockAdjustments.ThemeStyle.RowsStyle.Height = 45;

            this.colStockId.DataPropertyName = "StockId";
            this.colProductName.DataPropertyName = "product_name";
            this.colType.DataPropertyName = "type";
            this.colCurrentStock.DataPropertyName = "current_stock";
            this.colQuantity.DataPropertyName = "quantity";
            this.colReason.DataPropertyName = "reason";
            this.colUsername.DataPropertyName = "username";
            this.colAdjustedAt.DataPropertyName = "adjusted_at";
            this.colStatus.DataPropertyName = "status";
        }

        private async void frmStockAdjustment_Load(object sender, EventArgs e)
        {
            ConfigureColumns();
            PopulateSortColumns();

            txtSearch.PlaceholderText = "Search by Product, Type, Reason...";
            txtSearch.PlaceholderForeColor = Color.Gray;

            dtpStartDate.FillColor = Color.White;
            dtpStartDate.CheckedState.FillColor = Color.White;
            dtpStartDate.HoverState.FillColor = Color.White;

            dtpEndDate.FillColor = Color.White;
            dtpEndDate.CheckedState.FillColor = Color.White;
            dtpEndDate.HoverState.FillColor = Color.White;

            // Default to last 30 days
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Today;

            await LoadAdjustmentsAsync();
        }

        private async Task LoadAdjustmentsAsync()
        {
            _allAdjustments = await Task.Run(() => _stockAdjustmentsDAL.Getvw_StockAdjustments());
            ApplyFilterAndSort();
        }

        //Apply Filter & Sort
        private void ApplyFilterAndSort()
        {
            if (_allAdjustments == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

            // 1. Date filter & Keyword filter
            IEnumerable<vw_Stock_adjustments> query = _allAdjustments.Where(a =>
            {
                // Date filter
                if (a.AdjustedAt.HasValue)
                {
                    if (a.AdjustedAt.Value < startDate || a.AdjustedAt.Value > endDate)
                        return false;
                }

                // Keyword search
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    bool matchId = a.StockId.ToString().Contains(keyword);
                    bool matchProduct = a.ProductName != null && a.ProductName.ToLower().Contains(keyword);
                    bool matchUser = a.Username != null && a.Username.ToLower().Contains(keyword);
                    bool matchReason = a.Reason != null && a.Reason.ToLower().Contains(keyword);
                    bool matchType = a.Type != null && a.Type.ToLower().Contains(keyword);
                    bool matchStatus = a.Status != null && a.Status.ToLower().Contains(keyword);
                    bool matchCurrentStock = a.CurrentStock.HasValue && a.CurrentStock.Value.ToString().Contains(keyword);

                    return matchId || matchProduct || matchUser || matchReason || matchType || matchStatus || matchCurrentStock;
                }

                return true;
            });

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Date";
            bool isDescending = !btnSort.Checked; // Default unchecked = Descending (newest first)

            switch (selectedCol)
            {
                case "Product":
                    query = isDescending ? query.OrderByDescending(a => a.ProductName) : query.OrderBy(a => a.ProductName);
                    break;
                case "Type":
                    query = isDescending ? query.OrderByDescending(a => a.Type) : query.OrderBy(a => a.Type);
                    break;
                case "Current Stock":
                    query = isDescending ? query.OrderByDescending(a => a.CurrentStock ?? 0) : query.OrderBy(a => a.CurrentStock ?? 0);
                    break;
                case "Quantity":
                    query = isDescending ? query.OrderByDescending(a => a.Quantity ?? 0) : query.OrderBy(a => a.Quantity ?? 0);
                    break;
                case "User":
                    query = isDescending ? query.OrderByDescending(a => a.Username) : query.OrderBy(a => a.Username);
                    break;
                case "ID":
                    query = isDescending ? query.OrderByDescending(a => a.StockId) : query.OrderBy(a => a.StockId);
                    break;
                case "Status":
                    query = isDescending ? query.OrderByDescending(a => a.Status) : query.OrderBy(a => a.Status);
                    break;
                case "Date":
                default:
                    query = isDescending ? query.OrderByDescending(a => a.AdjustedAt) : query.OrderBy(a => a.AdjustedAt);
                    break;
            }

            displayStockAdjustments.DataSource = null;
            displayStockAdjustments.DataSource = query.ToList();
        }

        private long GetSelectedStockAdjustmentId()
        {
            if (displayStockAdjustments.CurrentRow != null)
            {
                if (displayStockAdjustments.CurrentRow.DataBoundItem is vw_Stock_adjustments item)
                {
                    return item.StockId;
                }
                else if (displayStockAdjustments.CurrentRow.Cells["colStockId"].Value != null &&
                         long.TryParse(displayStockAdjustments.CurrentRow.Cells["colStockId"].Value.ToString(), out long id))
                {
                    return id;
                }
            }
            return 0;
        }

        //btnAdd
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddStockAdjustment frm = new frmAddStockAdjustment();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadAdjustmentsAsync();
            }
        }

        //btnCompleted
        private async void btnCompleted_Click(object sender, EventArgs e)
        {
            long selectedId = GetSelectedStockAdjustmentId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a stock adjustment record to mark as completed.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rowItem = displayStockAdjustments.CurrentRow?.DataBoundItem as vw_Stock_adjustments;
            string currentStatus = rowItem?.Status ?? "";
            if (currentStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Stock adjustment ID #{selectedId} is already marked as Completed.", "Already Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string productName = rowItem?.ProductName ?? "this product";
            string typeStr = rowItem?.Type ?? "adjustment";
            int qty = rowItem?.Quantity ?? 0;

            var dialogResult = MessageBox.Show(
                $"Are you sure you want to approve and complete stock adjustment ID #{selectedId}?\n\nProduct: {productName}\nType: {typeStr}\nQuantity: {qty}\n\nThis will apply the quantity change to current product inventory.",
                "Confirm Stock Adjustment Completion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                var result = await Task.Run(() =>
                {
                    bool ok = _stockAdjustmentsDAL.CompleteStockAdjustment(selectedId, out string err);
                    return new { Success = ok, ErrorMessage = err };
                });

                if (result.Success)
                {
                    MessageBox.Show($"Stock adjustment ID #{selectedId} completed successfully! Product stock has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadAdjustmentsAsync();
                }
                else
                {
                    MessageBox.Show("Failed to complete stock adjustment: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //btnDelete
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            long selectedId = GetSelectedStockAdjustmentId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a stock adjustment record to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialogResult = MessageBox.Show($"Are you sure you want to delete stock adjustment ID #{selectedId}?\nNote: Deleting history does not revert product inventory automatically.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool deleted = await Task.Run(() => _stockAdjustmentsDAL.DeleteStockAdjustment(selectedId));
                if (deleted)
                {
                    MessageBox.Show("Stock adjustment record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadAdjustmentsAsync();
                }
            }
        }

        private async void btnRefesh_Click(object sender, EventArgs e)
        {
            await LoadAdjustmentsAsync();
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

        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void displayStockAdjustments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayStockAdjustments.Columns[e.ColumnIndex].Name;

            // Format Type column with clear indicator & colors
            if (colName == "colType")
            {
                string val = e.Value.ToString().Trim().ToLower();
                if (val == "addition" || val == "add" || val == "+")
                {
                    e.Value = "+ Addition";
                    e.CellStyle.ForeColor = Color.FromArgb(46, 139, 87); // SeaGreen
                    e.CellStyle.SelectionForeColor = Color.FromArgb(46, 139, 87);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else if (val == "subtraction" || val == "subtract" || val == "-")
                {
                    e.Value = "- Subtraction";
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69); // Crimson Red
                    e.CellStyle.SelectionForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
            // Format Quantity column
            else if (colName == "colQuantity")
            {
                if (int.TryParse(e.Value.ToString(), out int qty))
                {
                    var rowItem = displayStockAdjustments.Rows[e.RowIndex].DataBoundItem as vw_Stock_adjustments;
                    string type = rowItem?.Type?.ToLower() ?? "";
                    if (type == "addition" || type == "+")
                    {
                        e.Value = "+" + qty.ToString("N0");
                        e.CellStyle.ForeColor = Color.FromArgb(46, 139, 87);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(46, 139, 87);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else if (type == "subtraction" || type == "-")
                    {
                        e.Value = "-" + qty.ToString("N0");
                        e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(220, 53, 69);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.Value = qty.ToString("N0");
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                }
            }
            // Format Current Stock column
            else if (colName == "colCurrentStock")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int stock))
                {
                    e.Value = stock.ToString("N0");
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
            // Format Date column
            else if (colName == "colAdjustedAt")
            {
                if (e.Value is DateTime dt)
                {
                    e.Value = dt.ToString("dd/MM/yyyy hh:mm tt");
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
            // Format Status column
            else if (colName == "colStatus")
            {
                string statusVal = e.Value?.ToString()?.Trim() ?? "";
                if (statusVal.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(46, 139, 87); // SeaGreen
                    e.CellStyle.SelectionForeColor = Color.FromArgb(46, 139, 87);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else if (statusVal.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34); // Amber / Orange
                    e.CellStyle.SelectionForeColor = Color.FromArgb(230, 126, 34);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(30, 144, 255); // Dodger Blue
                    e.CellStyle.SelectionForeColor = Color.FromArgb(30, 144, 255);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
        }
    }
}


