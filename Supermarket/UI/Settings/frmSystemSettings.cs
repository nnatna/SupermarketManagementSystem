using Supermarket.Utils;
using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Settings
{
    public partial class frmSystemSettings : Form
    {
        private readonly UsersDAL _usersDAL = new UsersDAL();
        private List<Roles> _allRoles = new List<Roles>();

        public frmSystemSettings()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(dgvRoles);
        }

        private async void frmSystemSettings_Load(object sender, EventArgs e)
        {
            LoadSystemPreferences();
            await LoadRolesDataAsync();
        }

        private void LoadSystemPreferences()
        {
            numLowStock.Value = Properties.Settings.Default.LowStockThreshold;
            swAutoPrint.Checked = Properties.Settings.Default.AutoPrintReceipt;
        }

        private void btnSaveSystemSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.LowStockThreshold = (int)numLowStock.Value;
                Properties.Settings.Default.AutoPrintReceipt = swAutoPrint.Checked;
                Properties.Settings.Default.Save();

                MessageBox.Show("System preferences saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving system preferences: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTestDbConnection_Click(object sender, EventArgs e)
        {
            lblDbStatus.Text = "Status: Testing connection...";
            lblDbStatus.ForeColor = Color.DarkOrange;

            bool isConnected = await Task.Run(() =>
            {
                try
                {
                    using (var db = new SupermarketContext())
                    {
                        return db.Database.Exists();
                    }
                }
                catch
                {
                    return false;
                }
            });

            if (isConnected)
            {
                lblDbStatus.Text = "Status: Connected successfully (SQL Server)";
                lblDbStatus.ForeColor = Color.Green;
            }
            else
            {
                lblDbStatus.Text = "Status: Connection failed. Check SQL Server settings.";
                lblDbStatus.ForeColor = Color.Red;
            }
        }

        #region Roles Logic

        private async Task LoadRolesDataAsync()
        {
            try
            {
                _allRoles = await Task.Run(() => _usersDAL.GetAllRoles());
                dgvRoles.AutoGenerateColumns = false;
                dgvRoles.DataSource = null;
                dgvRoles.DataSource = _allRoles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddRole_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditRole())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadRolesDataAsync();
                }
            }
        }

        private async void btnEditRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null || dgvRoles.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Please select a role to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRole = dgvRoles.CurrentRow.DataBoundItem as Roles;
            if (selectedRole == null) return;

            using (var frm = new frmAddEditRole(selectedRole.Id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadRolesDataAsync();
                }
            }
        }

        private async void btnDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null || dgvRoles.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Please select a role to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRole = dgvRoles.CurrentRow.DataBoundItem as Roles;
            if (selectedRole == null) return;

            if (string.Equals(selectedRole.Name, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The default 'Admin' role cannot be deleted.", "Action Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the role '{selectedRole.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string errorMsg;
                bool deleted = _usersDAL.DeleteRole(selectedRole.Id, out errorMsg);
                if (deleted)
                {
                    MessageBox.Show("Role deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadRolesDataAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete role: " + errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRefreshRoles_Click(object sender, EventArgs e)
        {
            await LoadRolesDataAsync();
        }

        #endregion
    }
}

