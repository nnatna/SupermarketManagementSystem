using Supermarket.Utils;
using Guna.UI2.WinForms;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeModel = Supermarket.Model.Employees;

namespace Supermarket.UI.Settings
{
    public partial class frmEmployees : Form
    {
        private readonly EmployeesDAL _employeesDAL = new EmployeesDAL();
        private List<EmployeeModel> _allEmployees = new List<EmployeeModel>();

        public frmEmployees()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayEmployees);
        }

        private void cmbFilter()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.Items.Add("Name");
            cmbSortColumn.Items.Add("Position");
            cmbSortColumn.Items.Add("Gender");
            cmbSortColumn.Items.Add("Salary");
            cmbSortColumn.Items.Add("Hire Date");
            cmbSortColumn.Items.Add("Phone");
            cmbSortColumn.Items.Add("Email");
            cmbSortColumn.Items.Add("Created Date");
            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmEmployees_Load(object sender, EventArgs e)
        {
            cmbFilter();
            displayEmployees.AutoGenerateColumns = false;
            await LoadEmployeesAsync();
            txtSearch.PlaceholderForeColor = Color.Gray;
        }

        private async Task LoadEmployeesAsync()
        {
            _allEmployees = await Task.Run(() => _employeesDAL.GetAllEmployees());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allEmployees == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<EmployeeModel> query = _allEmployees;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(e =>
                    (e.FullName != null && e.FullName.ToLower().Contains(keyword)) ||
                    (e.Position != null && e.Position.ToLower().Contains(keyword)) ||
                    (e.Gender != null && e.Gender.ToLower().Contains(keyword)) ||
                    (e.Phone != null && e.Phone.ToLower().Contains(keyword)) ||
                    (e.Email != null && e.Email.ToLower().Contains(keyword)) ||
                    (e.Salary.HasValue && e.Salary.Value.ToString().Contains(keyword)) ||
                    e.Id.ToString().Contains(keyword)
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Id";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "Name":
                    query = isDescending ? query.OrderByDescending(e => e.FullName) : query.OrderBy(e => e.FullName);
                    break;
                case "Position":
                    query = isDescending ? query.OrderByDescending(e => e.Position) : query.OrderBy(e => e.Position);
                    break;
                case "Gender":
                    query = isDescending ? query.OrderByDescending(e => e.Gender) : query.OrderBy(e => e.Gender);
                    break;
                case "Salary":
                    query = isDescending ? query.OrderByDescending(e => e.Salary ?? 0) : query.OrderBy(e => e.Salary ?? 0);
                    break;
                case "Hire Date":
                    query = isDescending ? query.OrderByDescending(e => e.HireDate ?? DateTime.MinValue) : query.OrderBy(e => e.HireDate ?? DateTime.MinValue);
                    break;
                case "Phone":
                    query = isDescending ? query.OrderByDescending(e => e.Phone) : query.OrderBy(e => e.Phone);
                    break;
                case "Email":
                    query = isDescending ? query.OrderByDescending(e => e.Email) : query.OrderBy(e => e.Email);
                    break;
                case "Created Date":
                    query = isDescending ? query.OrderBy(e => e.CreatedAt) : query.OrderByDescending(e => e.CreatedAt);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(e => e.Id) : query.OrderBy(e => e.Id);
                    break;
            }

            displayEmployees.AutoGenerateColumns = false;
            displayEmployees.DataSource = null;
            displayEmployees.DataSource = query.ToList();
            ApplyColumnOrder();
        }

        private void ApplyColumnOrder()
        {
            string[] columnNames = new string[]
            {
                "Id",
                "EmployeeImage",
                "colFullName",
                "colGender",
                "colPosition",
                "colPhone",
                "colEmail",
                "colSalary",
                "colHireDate",
                "colCreatedAt"
            };

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (displayEmployees.Columns.Contains(columnNames[i]))
                {
                    displayEmployees.Columns[columnNames[i]].DisplayIndex = i;
                }
            }
        }

        private void displayEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayEmployees.Columns[e.ColumnIndex].Name;

            if (colName == "colSalary")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal salary))
                {
                    e.Value = $"${salary:N2}";
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(22, 163, 74);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
            }
            else if (colName == "colHireDate")
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("yyyy-MM-dd");
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

        private long GetSelectedEmployeeId()
        {
            if (displayEmployees.CurrentRow != null)
            {
                if (displayEmployees.CurrentRow.DataBoundItem is EmployeeModel employee)
                {
                    return employee.Id;
                }
                else if (displayEmployees.CurrentRow.Cells["Id"].Value != null &&
                         long.TryParse(displayEmployees.CurrentRow.Cells["Id"].Value.ToString(), out long id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedEmployeeName()
        {
            if (displayEmployees.CurrentRow != null)
            {
                if (displayEmployees.CurrentRow.DataBoundItem is EmployeeModel employee)
                {
                    return employee.FullName;
                }
                else if (displayEmployees.CurrentRow.Cells["colFullName"].Value != null)
                {
                    return displayEmployees.CurrentRow.Cells["colFullName"].Value.ToString();
                }
            }
            return "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddeditEmployee frm = new frmAddeditEmployee();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadEmployeesAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            long selectedEmployeeId = GetSelectedEmployeeId();
            if (selectedEmployeeId <= 0)
            {
                MessageBox.Show("Please select an employee from the table to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddeditEmployee frm = new frmAddeditEmployee(selectedEmployeeId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadEmployeesAsync();
            }
        }

        private async void displayEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long selectedEmployeeId = GetSelectedEmployeeId();
            if (selectedEmployeeId <= 0) return;

            frmAddeditEmployee frm = new frmAddeditEmployee(selectedEmployeeId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadEmployeesAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            long selectedEmployeeId = GetSelectedEmployeeId();
            if (selectedEmployeeId <= 0)
            {
                MessageBox.Show("Please select an employee from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string employeeName = GetSelectedEmployeeName();
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete employee '{employeeName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var result = await Task.Run(() =>
                {
                    bool ok = _employeesDAL.DeleteEmployee(selectedEmployeeId, out string error);
                    return new { Success = ok, Error = error };
                });

                if (result.Success)
                {
                    MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEmployeesAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to delete employee: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            if (cmbSortColumn.Items.Count > 0)
            {
                cmbSortColumn.SelectedIndex = 0;
            }
            btnSort.Checked = false;
            await LoadEmployeesAsync();
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


