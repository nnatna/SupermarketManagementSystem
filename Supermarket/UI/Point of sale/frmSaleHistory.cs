using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Point_of_sale
{
    public partial class frmSaleHistory : Form
    {
        private readonly SaleDetailDAL _saleDetailDAL = new SaleDetailDAL();
        private readonly SalesDAL _salesDAL = new SalesDAL();
        private List<vw_SaleHistory> _allSaleHistory = new List<vw_SaleHistory>();

        public frmSaleHistory()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Load += frmSaleHistory_Load;
            this.txtSearch.TextChanged += txtSearch_TextChanged;
            this.btnSort.Click += btnSort_Click;
            this.cmbSortColumn.SelectedIndexChanged += cmbSortColumn_SelectedIndexChanged;
            this.btnRefesh.Click += btnRefesh_Click;
            this.btnEdit.Click += btnEdit_Click;
            this.dtpStartDate.ValueChanged += dtpDateFilter_ValueChanged;
            this.dtpEndDate.ValueChanged += dtpDateFilter_ValueChanged;
            this.displayProducts.CellFormatting += displayProducts_CellFormatting;
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Date");
            cmbSortColumn.Items.Add("Invoice Number");
            cmbSortColumn.Items.Add("Product");
            cmbSortColumn.Items.Add("Quantity");
            cmbSortColumn.Items.Add("Unit Price");
            cmbSortColumn.Items.Add("Subtotal");
            cmbSortColumn.Items.Add("Status");
            cmbSortColumn.Items.Add("ID");

            cmbSortColumn.SelectedIndex = 0;
        }

        private void ConfigureColumns()
        {
            displayProducts.AutoGenerateColumns = false;
            displayProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            displayProducts.RowTemplate.Height = 45;
            displayProducts.ThemeStyle.RowsStyle.Height = 45;

            this.Id.DataPropertyName = "SaleHistoryID";
            this.Invoice_Number.DataPropertyName = "invoice_number";
            this.SaleDate.DataPropertyName = "sale_date";
            this.ProductName.DataPropertyName = "product_name";
            this.Quatity.DataPropertyName = "quantity";
            this.Unit_Price.DataPropertyName = "unit_price";
            this.Subtotal.DataPropertyName = "subtotal";
            this.Discount.DataPropertyName = "Discount";
            this.Total.DataPropertyName = "subtotal";
            this.Status.DataPropertyName = "status";
        }

        private async void frmSaleHistory_Load(object sender, EventArgs e)
        {
            ConfigureColumns();
            PopulateSortColumns();

            txtSearch.PlaceholderText = "Search by Invoice, Product, Status...";
            txtSearch.PlaceholderForeColor = Color.Gray;

            dtpStartDate.FillColor = Color.White;
            dtpStartDate.CheckedState.FillColor = Color.White;
            dtpStartDate.HoverState.FillColor = Color.White;

            dtpEndDate.FillColor = Color.White;
            dtpEndDate.CheckedState.FillColor = Color.White;
            dtpEndDate.HoverState.FillColor = Color.White;

            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            await LoadSaleHistoryAsync();
        }

        private async Task LoadSaleHistoryAsync()
        {
            _allSaleHistory = await Task.Run(() => _saleDetailDAL.Getvw_SaleHistory());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allSaleHistory == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<vw_SaleHistory> query = _allSaleHistory;

            // Date Range Filter (Start Date to End Date)
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate > endDate)
            {
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;
            }

            query = query.Where(s => s.sale_date.HasValue &&
                                     s.sale_date.Value.Date >= startDate &&
                                     s.sale_date.Value.Date <= endDate);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(s =>
                    (s.invoice_number != null && s.invoice_number.ToLower().Contains(keyword)) ||
                    (s.product_name != null && s.product_name.ToLower().Contains(keyword)) ||
                    (s.status != null && s.status.ToLower().Contains(keyword)) ||
                    (s.payment_method != null && s.payment_method.ToLower().Contains(keyword)) ||
                    s.SaleHistoryID.ToString().Contains(keyword)
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Date";
            bool isDescending = !btnSort.Checked; // Default to Descending (newest first)

            switch (selectedCol)
            {
                case "Invoice Number":
                    query = isDescending ? query.OrderByDescending(s => s.invoice_number) : query.OrderBy(s => s.invoice_number);
                    break;
                case "Product":
                    query = isDescending ? query.OrderByDescending(s => s.product_name) : query.OrderBy(s => s.product_name);
                    break;
                case "Quantity":
                    query = isDescending ? query.OrderByDescending(s => s.quantity) : query.OrderBy(s => s.quantity);
                    break;
                case "Unit Price":
                    query = isDescending ? query.OrderByDescending(s => s.unit_price) : query.OrderBy(s => s.unit_price);
                    break;
                case "Subtotal":
                    query = isDescending ? query.OrderByDescending(s => s.subtotal) : query.OrderBy(s => s.subtotal);
                    break;
                case "Status":
                    query = isDescending ? query.OrderByDescending(s => s.status) : query.OrderBy(s => s.status);
                    break;
                case "ID":
                    query = isDescending ? query.OrderByDescending(s => s.SaleHistoryID) : query.OrderBy(s => s.SaleHistoryID);
                    break;
                case "Date":
                default:
                    query = isDescending ? query.OrderByDescending(s => s.sale_date) : query.OrderBy(s => s.sale_date);
                    break;
            }

            displayProducts.DataSource = null;
            displayProducts.DataSource = query.ToList();
        }

        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
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
            txtSearch.Clear();
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            await LoadSaleHistoryAsync();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedSale();
            if (selected == null)
            {
                MessageBox.Show("Please select a sale record first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmEditSaleHistory frm = new frmEditSaleHistory(selected))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadSaleHistoryAsync();
                }
            }
        }

        private vw_SaleHistory GetSelectedSale()
        {
            if (displayProducts.CurrentRow != null && displayProducts.CurrentRow.DataBoundItem is vw_SaleHistory sale)
            {
                return sale;
            }
            return null;
        }

        private void displayProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = displayProducts.Columns[e.ColumnIndex].Name;

            if (colName == "Unit_Price" || colName == "Subtotal" || colName == "Discount" || colName == "Total")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val.ToString("$#,##0.00");
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "SaleDate")
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = "Cancelled";
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Red
                    }
                    else if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = "Completed";
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); // Green
                    }
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
