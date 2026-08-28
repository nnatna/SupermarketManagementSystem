using Supermarket.Utils;
using Guna.UI2.WinForms;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserModel = Supermarket.Model.Users;

namespace Supermarket.UI.Settings
{
    public partial class frmUsers : Form
    {
        private readonly UsersDAL _usersDAL = new UsersDAL();
        private List<UserModel> _allUsers = new List<UserModel>();

        public frmUsers()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayUsers);
        }

        private void cmbFilter()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.Items.Add("Username");
            cmbSortColumn.Items.Add("Role");
            cmbSortColumn.Items.Add("Employee");
            cmbSortColumn.Items.Add("Status");
            cmbSortColumn.Items.Add("Created Date");
            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            cmbFilter();
            displayUsers.AutoGenerateColumns = false;
            await LoadUsersAsync();
            txtSearch.PlaceholderForeColor = Color.Gray;
        }

        private async Task LoadUsersAsync()
        {
            _allUsers = await Task.Run(() => _usersDAL.GetAllUsers());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allUsers == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<UserModel> query = _allUsers;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(u =>
                    (u.Username != null && u.Username.ToLower().Contains(keyword)) ||
                    (u.RoleName != null && u.RoleName.ToLower().Contains(keyword)) ||
                    (u.EmployeeName != null && u.EmployeeName.ToLower().Contains(keyword)) ||
                    (u.Status != null && u.Status.ToLower().Contains(keyword)) ||
                    u.Id.ToString().Contains(keyword)
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Id";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "Username":
                    query = isDescending ? query.OrderByDescending(u => u.Username) : query.OrderBy(u => u.Username);
                    break;
                case "Role":
                    query = isDescending ? query.OrderByDescending(u => u.RoleName) : query.OrderBy(u => u.RoleName);
                    break;
                case "Employee":
                    query = isDescending ? query.OrderByDescending(u => u.EmployeeName) : query.OrderBy(u => u.EmployeeName);
                    break;
                case "Status":
                    query = isDescending ? query.OrderByDescending(u => u.Status) : query.OrderBy(u => u.Status);
                    break;
                case "Created Date":
                    query = isDescending ? query.OrderBy(u => u.CreatedAt) : query.OrderByDescending(u => u.CreatedAt);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(u => u.Id) : query.OrderBy(u => u.Id);
                    break;
            }

            displayUsers.AutoGenerateColumns = false;
            displayUsers.DataSource = null;
            displayUsers.DataSource = query.ToList();
            ApplyColumnOrder();
        }

        private void ApplyColumnOrder()
        {
            string[] columnNames = new string[]
            {
                "Id",
                "UserImage",
                "colUsername",
                "colRole",
                "colEmployee",
                "colStatus",
                "colCreatedAt"
            };

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (displayUsers.Columns.Contains(columnNames[i]))
                {
                    displayUsers.Columns[columnNames[i]].DisplayIndex = i;
                }
            }
        }

        private void displayUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayUsers.Columns[e.ColumnIndex].Name;

            if (colName == "colStatus")
            {
                string status = e.Value.ToString();
                if (status == "Active")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(30, 126, 52); // Dark Green
                    e.CellStyle.SelectionForeColor = Color.FromArgb(30, 126, 52);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(197, 48, 48); // Dark Red
                    e.CellStyle.SelectionForeColor = Color.FromArgb(197, 48, 48);
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
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

        private long GetSelectedUserId()
        {
            if (displayUsers.CurrentRow != null)
            {
                if (displayUsers.CurrentRow.DataBoundItem is UserModel user)
                {
                    return user.Id;
                }
                else if (displayUsers.CurrentRow.Cells["Id"].Value != null &&
                         long.TryParse(displayUsers.CurrentRow.Cells["Id"].Value.ToString(), out long id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedUsername()
        {
            if (displayUsers.CurrentRow != null)
            {
                if (displayUsers.CurrentRow.DataBoundItem is UserModel user)
                {
                    return user.Username;
                }
                else if (displayUsers.CurrentRow.Cells["colUsername"].Value != null)
                {
                    return displayUsers.CurrentRow.Cells["colUsername"].Value.ToString();
                }
            }
            return "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsersAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            long selectedUserId = GetSelectedUserId();
            if (selectedUserId <= 0)
            {
                MessageBox.Show("Please select a user from the table to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddEditUser frm = new frmAddEditUser(selectedUserId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsersAsync();
            }
        }

        private async void displayUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long selectedUserId = GetSelectedUserId();
            if (selectedUserId <= 0) return;

            frmAddEditUser frm = new frmAddEditUser(selectedUserId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsersAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            long selectedUserId = GetSelectedUserId();
            if (selectedUserId <= 0)
            {
                MessageBox.Show("Please select a user from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = GetSelectedUsername();
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete user '{username}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var result = await Task.Run(() =>
                {
                    bool ok = _usersDAL.DeleteUser(selectedUserId, out string error);
                    return new { Success = ok, Error = error };
                });

                if (result.Success)
                {
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to delete user: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            await LoadUsersAsync();
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


