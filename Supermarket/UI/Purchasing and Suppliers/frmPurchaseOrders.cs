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
    public partial class frmPurchaseOrders : Form
    {
        private readonly PurchaseOrdersDAL _purchaseOrdersDAL = new PurchaseOrdersDAL();
        private List<vw_PurchasesOrder> _allOrders = new List<vw_PurchasesOrder>();

        public frmPurchaseOrders()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayPurchaseOrders);
            displayPurchaseOrders.AutoGenerateColumns = false;
            displayPurchaseOrders.RowTemplate.Height = 45;
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Date");
            cmbSortColumn.Items.Add("Purchase #");
            cmbSortColumn.Items.Add("Supplier");
            cmbSortColumn.Items.Add("Product");
            cmbSortColumn.Items.Add("Barcode");
            cmbSortColumn.Items.Add("Quantity");
            cmbSortColumn.Items.Add("Unit Cost");
            cmbSortColumn.Items.Add("Subtotal");
            cmbSortColumn.Items.Add("Total");
            cmbSortColumn.Items.Add("Status");
            cmbSortColumn.Items.Add("Id");

            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmPurchaseOrders_Load(object sender, EventArgs e)
        {
            PopulateSortColumns();
            displayPurchaseOrders.AutoGenerateColumns = false;
            txtSearch.PlaceholderForeColor = Color.Gray;
            await LoadPurchaseOrdersAsync();
        }

        private async Task LoadPurchaseOrdersAsync()
        {
            _allOrders = await Task.Run(() => _purchaseOrdersDAL.GetAllPurchaseOrders());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allOrders == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<vw_PurchasesOrder> query = _allOrders;

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

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Date";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "Purchase #":
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
                case "Unit Cost":
                    query = isDescending ? query.OrderByDescending(p => p.UnitCost) : query.OrderBy(p => p.UnitCost);
                    break;
                case "Subtotal":
                    query = isDescending ? query.OrderByDescending(p => p.Subtotal) : query.OrderBy(p => p.Subtotal);
                    break;
                case "Total":
                    query = isDescending ? query.OrderByDescending(p => p.TotalAmount) : query.OrderBy(p => p.TotalAmount);
                    break;
                case "Status":
                    query = isDescending ? query.OrderByDescending(p => p.Status) : query.OrderBy(p => p.Status);
                    break;
                case "Id":
                    query = isDescending ? query.OrderByDescending(p => p.PurchaseDetailID) : query.OrderBy(p => p.PurchaseDetailID);
                    break;
                case "Date":
                default:
                    query = isDescending ? query.OrderBy(p => p.PurchaseDate) : query.OrderByDescending(p => p.PurchaseDate);
                    break;
            }

            displayPurchaseOrders.AutoGenerateColumns = false;
            displayPurchaseOrders.DataSource = null;
            displayPurchaseOrders.DataSource = query.ToList();
        }

        private void displayPurchaseOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayPurchaseOrders.Columns[e.ColumnIndex].Name;

            if (colName == "colUnitCost" || colName == "colSubtotal" || colName == "colTotalAmount")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = amount.ToString("$#,##0.00");
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colPurchaseDate")
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
                if (decimal.TryParse(e.Value?.ToString(), out decimal amount))
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

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddPurchaseOrder())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadPurchaseOrdersAsync();
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            btnSort.Checked = false;
            await LoadPurchaseOrdersAsync();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }
    }
}


