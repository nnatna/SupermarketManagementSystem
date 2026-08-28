using System;
using System.Windows.Forms;
using Supermarket.DAL;
using Supermarket.Model;

namespace Supermarket.UI.Settings
{
    public partial class frmAddEditRole : Form
    {
        private readonly UsersDAL _usersDAL = new UsersDAL();
        private readonly int _roleId = 0;

        public frmAddEditRole(int roleId = 0)
        {
            InitializeComponent();
            _roleId = roleId;
        }

        private void frmAddEditRole_Load(object sender, EventArgs e)
        {
            if (_roleId > 0)
            {
                lblTitle.Text = "Edit Role";
                LoadRoleData(_roleId);
            }
            else
            {
                lblTitle.Text = "Add Role";
            }
        }

        private void LoadRoleData(int id)
        {
            var role = _usersDAL.GetRoleById(id);
            if (role != null)
            {
                txtRoleName.Text = role.Name ?? "";
                txtDescription.Text = role.Description ?? "";

                // Disable editing name for Admin role
                if (string.Equals(role.Name, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    txtRoleName.Enabled = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Please enter a role name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoleName.Focus();
                return;
            }

            Roles role = new Roles
            {
                Id = _roleId,
                Name = roleName,
                Description = description
            };

            bool success;
            string errorMessage;

            if (_roleId > 0)
            {
                success = _usersDAL.UpdateRole(role, out errorMessage);
            }
            else
            {
                success = _usersDAL.AddRole(role, out errorMessage);
            }

            if (success)
            {
                MessageBox.Show(_roleId > 0 ? "Role updated successfully!" : "Role created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error saving role: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
