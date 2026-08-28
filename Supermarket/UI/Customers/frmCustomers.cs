using Supermarket.Utils;
using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Customers
{
    public partial class frmCustomers : Form
    {
        private readonly CustomersDAL _customersDAL = new CustomersDAL();
        private List<Model.Customers> _allCustomers = new List<Model.Customers>();

        public frmCustomers()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayCustomers);
            displayCustomers.AutoGenerateColumns = false;
            displayCustomers.RowTemplate.Height = 45;
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Name");
            cmbSortColumn.Items.Add("Phone");
            cmbSortColumn.Items.Add("Email");
            cmbSortColumn.Items.Add("Address");
            cmbSortColumn.Items.Add("Points");
            cmbSortColumn.Items.Add("Date");
            cmbSortColumn.Items.Add("ID");
            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmCustomers_Load(object sender, EventArgs e)
        {
            PopulateSortColumns();
            displayCustomers.AutoGenerateColumns = false;
            txtSearch.PlaceholderForeColor = Color.Gray;
            await LoadCustomersAsync();
        }

        private async Task LoadCustomersAsync()
        {
            _allCustomers = await Task.Run(() => _customersDAL.GetAllCustomers());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allCustomers == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Search Filter
            IEnumerable<Model.Customers> query = _allCustomers;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c =>
                    (c.Name != null && c.Name.ToLower().Contains(keyword)) ||
                    (c.Phone != null && c.Phone.ToLower().Contains(keyword)) ||
                    (c.Email != null && c.Email.ToLower().Contains(keyword)) ||
                    (c.Address != null && c.Address.ToLower().Contains(keyword)) ||
                    c.Points.ToString().Contains(keyword) ||
                    c.Id.ToString().Contains(keyword)
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Name";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "Phone":
                    query = isDescending ? query.OrderByDescending(c => c.Phone) : query.OrderBy(c => c.Phone);
                    break;
                case "Email":
                    query = isDescending ? query.OrderByDescending(c => c.Email) : query.OrderBy(c => c.Email);
                    break;
                case "Address":
                    query = isDescending ? query.OrderByDescending(c => c.Address) : query.OrderBy(c => c.Address);
                    break;
                case "Points":
                    query = isDescending ? query.OrderByDescending(c => c.Points) : query.OrderBy(c => c.Points);
                    break;
                case "Date":
                    query = isDescending ? query.OrderBy(c => c.CreatedAt) : query.OrderByDescending(c => c.CreatedAt);
                    break;
                case "ID":
                    query = isDescending ? query.OrderByDescending(c => c.Id) : query.OrderBy(c => c.Id);
                    break;
                case "Name":
                default:
                    query = isDescending ? query.OrderByDescending(c => c.Name) : query.OrderBy(c => c.Name);
                    break;
            }

            displayCustomers.AutoGenerateColumns = false;
            displayCustomers.DataSource = null;
            displayCustomers.DataSource = query.ToList();
        }

        private void displayCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayCustomers.Columns[e.ColumnIndex].Name;
            if (colName == "colLoyaltyPoints")
            {
                if (int.TryParse(e.Value.ToString(), out int points))
                {
                    e.Value = points.ToString("N0");
                    if (points > 0)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(13, 110, 253);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(13, 110, 253);
                        e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    }
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colCreatedAt")
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("yyyy-MM-dd HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditCustomer())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadCustomersAsync();
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (displayCustomers.CurrentRow == null || displayCustomers.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a customer from the table to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var customer = displayCustomers.CurrentRow.DataBoundItem as Model.Customers;
            if (customer == null) return;

            using (var frm = new frmAddEditCustomer(customer.Id))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadCustomersAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (displayCustomers.CurrentRow == null || displayCustomers.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a customer from the table to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var customer = displayCustomers.CurrentRow.DataBoundItem as Model.Customers;
            if (customer == null) return;

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete customer '{customer.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var result = await Task.Run(() =>
                {
                    bool ok = _customersDAL.DeleteCustomer(customer.Id, out string error);
                    return new { Success = ok, Error = error };
                });

                if (result.Success)
                {
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomersAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to delete customer: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            btnSort.Checked = false;
            await LoadCustomersAsync();
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


