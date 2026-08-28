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

namespace Supermarket.UI.Purchasing_and_Suppliers
{
    public partial class frmGoodsReceive : Form
    {
        private readonly PurchaseOrdersDAL _purchaseOrdersDAL = new PurchaseOrdersDAL();
        private List<vw_PurchasesOrder> _allGoodsReceive = new List<vw_PurchasesOrder>();

        public frmGoodsReceive()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayGoodsReceive);
            displayGoodsReceive.AutoGenerateColumns = false;
            displayGoodsReceive.RowTemplate.Height = 45;
        }

        private void PopulateFiltersAndSort()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Status");
            cmbStatusFilter.Items.Add("Received");
            cmbStatusFilter.Items.Add("Pending");
            cmbStatusFilter.Items.Add("Cancelled");
            cmbStatusFilter.SelectedIndex = 0;

            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Date");
            cmbSortColumn.Items.Add("GRN / PO #");
            cmbSortColumn.Items.Add("Supplier");
            cmbSortColumn.Items.Add("Product");
            cmbSortColumn.Items.Add("Barcode");
            cmbSortColumn.Items.Add("Quantity");
            cmbSortColumn.Items.Add("Status");
            cmbSortColumn.Items.Add("Received By");
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmGoodsReceive_Load(object sender, EventArgs e)
        {
            PopulateFiltersAndSort();
            displayGoodsReceive.AutoGenerateColumns = false;
            txtSearch.PlaceholderForeColor = Color.Gray;
            await LoadGoodsReceiveAsync();
        }

        private async Task LoadGoodsReceiveAsync()
        {
            _allGoodsReceive = await Task.Run(() => _purchaseOrdersDAL.GetAllPurchaseOrders());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allGoodsReceive == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();
            string statusFilter = cmbStatusFilter.SelectedItem != null ? cmbStatusFilter.SelectedItem.ToString() : "All Status";

            // 1. Status Filter
            IEnumerable<vw_PurchasesOrder> query = _allGoodsReceive;
            if (statusFilter == "Received")
            {
                query = query.Where(p => p.Status != null && p.Status.ToLower() == "received");
            }
            else if (statusFilter == "Pending")
            {
                query = query.Where(p => p.Status != null && p.Status.ToLower() == "pending");
            }
            else if (statusFilter == "Cancelled" || statusFilter == "Canceled")
            {
                query = query.Where(p => p.Status != null && (p.Status.ToLower() == "canceled" || p.Status.ToLower() == "cancelled"));
            }

            // 2. Search Filter
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p =>
                    (p.PurchaseNumber != null && p.PurchaseNumber.ToLower().Contains(keyword)) ||
                    (p.SupplierName != null && p.SupplierName.ToLower().Contains(keyword)) ||
                    (p.ProductName != null && p.ProductName.ToLower().Contains(keyword)) ||
                    (p.Barcode != null && p.Barcode.ToLower().Contains(keyword)) ||
                    (p.ContactName != null && p.ContactName.ToLower().Contains(keyword)) ||
                    (p.SupplierPhone != null && p.SupplierPhone.ToLower().Contains(keyword)) ||
                    (p.Status != null && p.Status.ToLower().Contains(keyword)) ||
                    (p.Username != null && p.Username.ToLower().Contains(keyword)) ||
                    p.PurchaseDetailID.ToString().Contains(keyword) ||
                    p.PurchaseId.ToString().Contains(keyword)
                );
            }

            // 3. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Date";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "GRN / PO #":
                    query = isDescending ? query.OrderByDescending(p => p.PurchaseNumber) : query.OrderBy(p => p.PurchaseNumber);
                    break;
                case "Supplier":
                    query = isDescending ? query.OrderByDescending(p => p.SupplierName) : query.OrderBy(p => p.SupplierName);
                    break;
                case "Product":
                    query = isDescending ? query.OrderByDescending(p => p.ProductName) : query.OrderBy(p => p.ProductName);
                    break;
                case "Barcode":
                    query = isDescending ? query.OrderByDescending(p => p.Barcode) : query.OrderBy(p => p.Barcode);
                    break;
                case "Quantity":
                    query = isDescending ? query.OrderByDescending(p => p.Quantity) : query.OrderBy(p => p.Quantity);
                    break;
                case "Status":
                    query = isDescending ? query.OrderByDescending(p => p.Status) : query.OrderBy(p => p.Status);
                    break;
                case "Received By":
                    query = isDescending ? query.OrderByDescending(p => p.Username) : query.OrderBy(p => p.Username);
                    break;
                case "Id":
                    query = isDescending ? query.OrderByDescending(p => p.PurchaseDetailID) : query.OrderBy(p => p.PurchaseDetailID);
                    break;
                case "Date":
                default:
                    query = isDescending ? query.OrderBy(p => p.PurchaseDate) : query.OrderByDescending(p => p.PurchaseDate);
                    break;
            }

            displayGoodsReceive.AutoGenerateColumns = false;
            displayGoodsReceive.DataSource = null;
            displayGoodsReceive.DataSource = query.ToList();
        }

        private void displayGoodsReceive_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayGoodsReceive.Columns[e.ColumnIndex].Name;

            if (colName == "colPurchaseDate")
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("yyyy-MM-dd HH:mm");
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colStatus")
            {
                string status = e.Value.ToString().Trim().ToLower();
                if (status == "received" || status == "completed")
                {
                    e.Value = "Received";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Color.SeaGreen;
                    e.CellStyle.SelectionForeColor = Color.SeaGreen;
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else if (status == "pending")
                {
                    e.Value = "Pending";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.SelectionForeColor = Color.DarkOrange;
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else if (status == "canceled" || status == "cancelled")
                {
                    e.Value = "Canceled";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.SelectionForeColor = Color.Crimson;
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
            }
            else if (colName == "colUnitCost" || colName == "colSubtotal" || colName == "colTotalAmount")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = $"${amount:N2}";
                    if (colName == "colTotalAmount")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(13, 110, 253);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(13, 110, 253);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    e.FormattingApplied = true;
                }
            }
        }

        private async void btnConfirmReceived_Click(object sender, EventArgs e)
        {
            if (displayGoodsReceive.CurrentRow == null || displayGoodsReceive.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a goods receive record from the table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = displayGoodsReceive.CurrentRow.DataBoundItem as vw_PurchasesOrder;
            if (selectedItem == null) return;

            if (selectedItem.Status != null && selectedItem.Status.Trim().ToLower() == "received")
            {
                MessageBox.Show($"Purchase Order #{selectedItem.PurchaseNumber} is already received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to confirm receipt for Purchase Order #{selectedItem.PurchaseNumber}?\nThis will automatically update the product inventory stock.",
                "Confirm Receipt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var result = await Task.Run(() =>
                {
                    bool ok = _purchaseOrdersDAL.MarkPurchaseAsReceived(selectedItem.PurchaseId, out string error);
                    return new { Success = ok, Error = error };
                });

                if (result.Success)
                {
                    MessageBox.Show($"Purchase Order #{selectedItem.PurchaseNumber} marked as Received and stock has been updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadGoodsReceiveAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to confirm receipt: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (displayGoodsReceive.CurrentRow == null || displayGoodsReceive.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a goods receive record from the table to cancel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = displayGoodsReceive.CurrentRow.DataBoundItem as vw_PurchasesOrder;
            if (selectedItem == null) return;

            if (selectedItem.Status != null && (selectedItem.Status.Trim().ToLower() == "canceled" || selectedItem.Status.Trim().ToLower() == "cancelled"))
            {
                MessageBox.Show($"Purchase Order #{selectedItem.PurchaseNumber} has already been cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string warningMsg = selectedItem.Status != null && selectedItem.Status.Trim().ToLower() == "received"
                ? $"Purchase Order #{selectedItem.PurchaseNumber} was already marked as Received.\nCancelling will automatically deduct the received quantities from the inventory stock.\n\nAre you sure you want to cancel this order?"
                : $"Are you sure you want to cancel Purchase Order #{selectedItem.PurchaseNumber}?";

            var confirmResult = MessageBox.Show(
                warningMsg,
                "Cancel Purchase Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                var result = await Task.Run(() =>
                {
                    bool ok = _purchaseOrdersDAL.CancelPurchaseOrder(selectedItem.PurchaseId, out string error);
                    return new { Success = ok, Error = error };
                });

                if (result.Success)
                {
                    MessageBox.Show($"Purchase Order #{selectedItem.PurchaseNumber} has been successfully cancelled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadGoodsReceiveAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to cancel purchase order: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbStatusFilter.SelectedIndex = 0;
            cmbSortColumn.SelectedIndex = 0;
            btnSort.Checked = false;
            await LoadGoodsReceiveAsync();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void pnlButton_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


