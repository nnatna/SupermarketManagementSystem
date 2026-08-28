using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.UI.Settings
{
    public partial class frmAddEditUser : Form
    {
        private readonly UsersDAL _usersDAL = new UsersDAL();
        private readonly long _userId = 0;

        private class EmployeeComboItem
        {
            public long? Id { get; set; }
            public string DisplayName { get; set; }
            public override string ToString() => DisplayName;
        }

        private class RoleComboItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public frmAddEditUser(long userId = 0)
        {
            InitializeComponent();
            _userId = userId;

            this.Load += frmAddEditUser_Load;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            PopulateEmployees();
            PopulateRoles();
            PopulateStatuses();

            if (_userId > 0)
            {
                guna2HtmlLabel1.Text = "EDIT USER";
                lblPassword.Text = "Password";
                txtPassword.PlaceholderText = "Leave blank to keep current password";
                LoadUserData(_userId);
            }
            else
            {
                guna2HtmlLabel1.Text = "ADD USER";
                lblPassword.Text = "Password *";
                txtPassword.PlaceholderText = "Enter password";
            }
        }

        private void PopulateEmployees()
        {
            cmbEmployee.Items.Clear();
            cmbEmployee.Items.Add(new EmployeeComboItem { Id = null, DisplayName = "-- None (No Linked Employee) --" });

            var employees = _usersDAL.GetAllEmployees();
            foreach (var emp in employees)
            {
                string info = $"{emp.FullName} ({emp.Position})";
                cmbEmployee.Items.Add(new EmployeeComboItem { Id = emp.Id, DisplayName = info });
            }

            cmbEmployee.SelectedIndex = 0;
        }

        private void PopulateRoles()
        {
            cmbRole.Items.Clear();
            var roles = _usersDAL.GetAllRoles();
            foreach (var role in roles)
            {
                cmbRole.Items.Add(new RoleComboItem { Id = role.Id, Name = role.Name });
            }

            if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }
        }

        private void PopulateStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadUserData(long id)
        {
            var user = _usersDAL.GetUserById(id);
            if (user != null)
            {
                txtUsername.Text = user.Username ?? "";

                // Select Employee
                if (user.EmployeeId.HasValue)
                {
                    for (int i = 0; i < cmbEmployee.Items.Count; i++)
                    {
                        if (cmbEmployee.Items[i] is EmployeeComboItem item && item.Id == user.EmployeeId.Value)
                        {
                            cmbEmployee.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cmbEmployee.SelectedIndex = 0;
                }

                // Select Role
                for (int i = 0; i < cmbRole.Items.Count; i++)
                {
                    if (cmbRole.Items[i] is RoleComboItem item && item.Id == user.RoleId)
                    {
                        cmbRole.SelectedIndex = i;
                        break;
                    }
                }

                // Select Status
                if (!string.IsNullOrWhiteSpace(user.Status))
                {
                    int statusIdx = cmbStatus.FindStringExact(user.Status.ToLower());
                    if (statusIdx >= 0)
                        cmbStatus.SelectedIndex = statusIdx;
                    else
                        cmbStatus.Text = user.Status;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string status = cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : cmbStatus.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (cmbRole.SelectedItem == null || !(cmbRole.SelectedItem is RoleComboItem selectedRole))
            {
                MessageBox.Show("Please select a valid role for this user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return;
            }

            if (_userId == 0 && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password for the new user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            long? employeeId = null;
            if (cmbEmployee.SelectedItem is EmployeeComboItem selectedEmp && selectedEmp.Id.HasValue)
            {
                employeeId = selectedEmp.Id.Value;
            }

            Users user = new Users
            {
                Id = _userId,
                Username = username,
                Password = password,
                RoleId = selectedRole.Id,
                EmployeeId = employeeId,
                Status = string.IsNullOrWhiteSpace(status) ? "active" : status
            };

            bool success;
            string errorMessage;

            if (_userId > 0)
            {
                success = _usersDAL.UpdateUser(user, out errorMessage);
            }
            else
            {
                user.CreatedAt = DateTime.Now;
                success = _usersDAL.AddUser(user, out errorMessage);
            }

            if (success)
            {
                MessageBox.Show(_userId > 0 ? "User updated successfully!" : "User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
