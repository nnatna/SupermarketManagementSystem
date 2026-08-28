using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.Utils;
using UnitModel = Supermarket.Model.Units;
using UserModel = Supermarket.Model.Users;

namespace Supermarket.UI.Settings
{
    public partial class frmGeneralSettings : Form
    {
        private readonly UnitsDAL _unitsDAL = new UnitsDAL();
        private readonly UsersDAL _usersDAL = new UsersDAL();
        private readonly EmployeesDAL _employeesDAL = new EmployeesDAL();
        private List<UnitModel> _allUnits = new List<UnitModel>();
        private List<UserModel> _allUsers = new List<UserModel>();
        private UserModel _selectedUser = null;
        private string _activeTab = "Account";

        public frmGeneralSettings(string initialTab = "Account")
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(dgvUnits);
            UIThemeHelper.ApplyModernGridStyle(dgvRoles);
            _activeTab = string.IsNullOrWhiteSpace(initialTab) ? "Account" : initialTab;
        }

        private async void frmGeneralSettings_Load(object sender, EventArgs e)
        {
            PopulateUnitsSortColumns();
            dgvUnits.AutoGenerateColumns = false;
            txtSearchUnits.PlaceholderForeColor = Color.Gray;

            // Load initial tab
            SwitchTab(_activeTab);

            // Load data asynchronously
            await LoadAccountDataAsync();
            await LoadUnitsDataAsync();
            await LoadRolesDataAsync();
            LoadStoreInfo();
            LoadSystemPreferences();
        }

        #region Tab Switching

        private void TabButton_Click(object sender, EventArgs e)
        {
            if (sender == btnTabAccount)
            {
                SwitchTab("Account");
            }
            else if (sender == btnTabStoreInfo)
            {
                SwitchTab("StoreInfo");
            }
            else if (sender == btnTabUnits)
            {
                SwitchTab("Units");
            }
            else if (sender == btnTabSystem)
            {
                SwitchTab("System");
            }
        }

        public void SwitchTab(string tabName)
        {
            _activeTab = tabName;

            // Reset all panels
            pnlAccount.Visible = false;
            pnlStoreInfo.Visible = false;
            pnlUnits.Visible = false;
            pnlSystem.Visible = false;

            // Reset button checks
            btnTabAccount.Checked = false;
            btnTabStoreInfo.Checked = false;
            btnTabUnits.Checked = false;
            btnTabSystem.Checked = false;

            switch (tabName.ToLower())
            {
                case "storeinfo":
                case "store_info":
                case "store":
                    btnTabStoreInfo.Checked = true;
                    pnlStoreInfo.Visible = true;
                    pnlStoreInfo.BringToFront();
                    break;

                case "units":
                case "unit":
                    btnTabUnits.Checked = true;
                    pnlUnits.Visible = true;
                    pnlUnits.BringToFront();
                    break;

                case "system":
                case "preferences":
                case "pref":
                    btnTabSystem.Checked = true;
                    pnlSystem.Visible = true;
                    pnlSystem.BringToFront();
                    break;

                case "account":
                default:
                    btnTabAccount.Checked = true;
                    pnlAccount.Visible = true;
                    pnlAccount.BringToFront();
                    break;
            }
        }

        #endregion

        #region Account Tab Logic

        private async Task LoadAccountDataAsync()
        {
            try
            {
                UserModel currentUser = null;
                if (UserSession.IsLoggedIn && UserSession.UserId > 0)
                {
                    currentUser = await Task.Run(() => _usersDAL.GetUserById(UserSession.UserId));
                }

                if (currentUser == null)
                {
                    _allUsers = await Task.Run(() => _usersDAL.GetAllUsers());
                    currentUser = _allUsers.FirstOrDefault();
                }

                _selectedUser = currentUser;
                DisplaySelectedUserInfo(_selectedUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading account profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Maintained for compatibility if ever re-enabled
            if (_allUsers == null || cmbSelectUser.SelectedIndex < 0 || cmbSelectUser.SelectedIndex >= _allUsers.Count)
                return;

            _selectedUser = _allUsers[cmbSelectUser.SelectedIndex];
            DisplaySelectedUserInfo(_selectedUser);
        }

        private void DisplaySelectedUserInfo(UserModel user)
        {
            if (user == null) return;

            lblUsernameVal.Text = user.Username ?? "-";
            lblEmployeeVal.Text = !string.IsNullOrWhiteSpace(user.EmployeeName) ? user.EmployeeName : "N/A";
            lblRoleVal.Text = !string.IsNullOrWhiteSpace(user.RoleName) ? user.RoleName : "Standard";
            lblStatusVal.Text = user.Status ?? "Active";
            lblStatusVal.ForeColor = (user.Status != null && user.Status.ToLower() == "active") ? Color.Green : Color.DarkRed;
            lblCreatedDateVal.Text = user.CreatedAt.ToString("yyyy-MM-dd HH:mm");

            Image photo = user.UserImage;
            picAccountAvatar.Image = photo ?? global::Supermarket.Properties.Resources.users;

            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char passChar = chkShowPassword.Checked ? '\0' : '●';
            txtCurrentPassword.PasswordChar = passChar;
            txtNewPassword.PasswordChar = passChar;
            txtConfirmPassword.PasswordChar = passChar;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("No account profile found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentPass = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPass))
            {
                MessageBox.Show("Please enter your current password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return;
            }

            string hashedCurrent = UsersDAL.HashPassword(currentPass);
            bool isCurrentMatch = string.Equals(_selectedUser.Password, hashedCurrent, StringComparison.OrdinalIgnoreCase)
                               || string.Equals(_selectedUser.Password, currentPass);

            if (!isCurrentMatch)
            {
                MessageBox.Show("Current password is incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 4)
            {
                MessageBox.Show("New password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            // Update in DB (UpdateUser will automatically hash new password)
            _selectedUser.Password = newPass;
            string errorMsg;
            bool updated = _usersDAL.UpdateUser(_selectedUser, out errorMsg);
            if (updated)
            {
                _selectedUser.Password = UsersDAL.HashPassword(newPass);
                if (UserSession.CurrentUser != null && UserSession.CurrentUser.Id == _selectedUser.Id)
                {
                    UserSession.CurrentUser.Password = _selectedUser.Password;
                }

                MessageBox.Show("Your account password has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            else
            {
                MessageBox.Show("Failed to update password: " + errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("No active account profile found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Profile Photo";
                ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.webp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string savedRelPath = SaveProfileImageFile(ofd.FileName);
                        if (string.IsNullOrWhiteSpace(savedRelPath))
                        {
                            return;
                        }

                        bool updated = false;
                        string errorMsg = "";

                        // If user is linked to an existing employee record
                        if (_selectedUser.EmployeeId.HasValue && _selectedUser.EmployeeId.Value > 0)
                        {
                            updated = _employeesDAL.UpdateEmployeePhoto(_selectedUser.EmployeeId.Value, savedRelPath, out errorMsg);
                        }
                        else
                        {
                            // Create employee profile linked to user
                            var newEmp = new Model.Employees
                            {
                                FullName = _selectedUser.Username,
                                Gender = "Male",
                                Position = _selectedUser.RoleName ?? "Staff",
                                HireDate = DateTime.Now,
                                Photo_path = savedRelPath
                            };
                            if (_employeesDAL.AddEmployee(newEmp, out errorMsg))
                            {
                                _selectedUser.EmployeeId = newEmp.Id;
                                _usersDAL.UpdateUser(_selectedUser, out errorMsg);
                                updated = true;
                            }
                        }

                        if (updated)
                        {
                            // Reload updated user
                            var refreshedUser = _usersDAL.GetUserById(_selectedUser.Id);
                            if (refreshedUser != null)
                            {
                                _selectedUser = refreshedUser;
                                if (UserSession.IsLoggedIn && UserSession.UserId == _selectedUser.Id)
                                {
                                    UserSession.CurrentUser = refreshedUser;
                                }
                            }

                            DisplaySelectedUserInfo(_selectedUser);

                            // Also refresh FramMain top bar avatar
                            if (this.TopLevelControl is FramMain mainForm)
                            {
                                mainForm.RefreshProfileDisplay();
                            }
                            else if (Application.OpenForms.OfType<FramMain>().FirstOrDefault() is FramMain openMain)
                            {
                                openMain.RefreshProfileDisplay();
                            }

                            MessageBox.Show("Profile photo updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update profile photo: " + errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error processing photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string SaveProfileImageFile(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                return "";

            string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Employees");
            if (!Directory.Exists(imagesDir))
            {
                Directory.CreateDirectory(imagesDir);
            }

            string newFileName = $"emp_{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid().ToString("N").Substring(0, 6)}.png";
            string destPath = Path.Combine(imagesDir, newFileName);

            using (var fs = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var originalImg = Image.FromStream(fs))
            using (var squareImg = CropAndResizeToSquare(originalImg, 500))
            {
                squareImg.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
            }

            return Path.Combine("Images", "Employees", newFileName);
        }

        private Bitmap CropAndResizeToSquare(Image sourceImg, int targetSize = 500)
        {
            int minDim = Math.Min(sourceImg.Width, sourceImg.Height);
            int srcX = (sourceImg.Width - minDim) / 2;
            int srcY = (sourceImg.Height - minDim) / 2;

            int outputSize = targetSize > 0 ? targetSize : minDim;
            Bitmap squareBmp = new Bitmap(outputSize, outputSize);
            using (Graphics g = Graphics.FromImage(squareBmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(sourceImg,
                    new Rectangle(0, 0, outputSize, outputSize),
                    new Rectangle(srcX, srcY, minDim, minDim),
                    GraphicsUnit.Pixel);
            }
            return squareBmp;
        }

        #endregion

        #region Store Info Tab Logic

        private void LoadStoreInfo()
        {
            txtStoreName.Text = Properties.Settings.Default.StoreName ?? "Supermarket Management";
            txtStoreBranch.Text = Properties.Settings.Default.StoreBranch ?? "Main Branch - Fresh & Quality Goods";
            txtStorePhone.Text = Properties.Settings.Default.StorePhone ?? "+855 12 345 678";
            txtStoreEmail.Text = Properties.Settings.Default.StoreEmail ?? "info@supermarket.com";
            txtStoreAddress.Text = Properties.Settings.Default.StoreAddress ?? "Phnom Penh, Cambodia";
            txtTaxRate.Text = Properties.Settings.Default.TaxRate ?? "10.00";
            txtCurrency.Text = Properties.Settings.Default.CurrencySymbol ?? "$";
            txtExchangeRate.Text = Properties.Settings.Default.ExchangeRate ?? "4100";
            txtReceiptHeader.Text = Properties.Settings.Default.ReceiptHeader ?? "Thank you for shopping with us!";
            txtReceiptFooter.Text = Properties.Settings.Default.ReceiptFooter ?? "Goods sold are not returnable. Please keep your receipt.";
        }

        private void btnSaveStoreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.StoreName = txtStoreName.Text.Trim();
                Properties.Settings.Default.StoreBranch = txtStoreBranch.Text.Trim();
                Properties.Settings.Default.StorePhone = txtStorePhone.Text.Trim();
                Properties.Settings.Default.StoreEmail = txtStoreEmail.Text.Trim();
                Properties.Settings.Default.StoreAddress = txtStoreAddress.Text.Trim();
                Properties.Settings.Default.TaxRate = txtTaxRate.Text.Trim();
                Properties.Settings.Default.CurrencySymbol = txtCurrency.Text.Trim();
                Properties.Settings.Default.ExchangeRate = txtExchangeRate.Text.Trim();
                Properties.Settings.Default.ReceiptHeader = txtReceiptHeader.Text.Trim();
                Properties.Settings.Default.ReceiptFooter = txtReceiptFooter.Text.Trim();

                Properties.Settings.Default.Save();
                MessageBox.Show("Store information saved successfully!", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving store info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetStoreInfo_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to reset Store Information to defaults?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                txtStoreName.Text = "Supermarket Management";
                txtStoreBranch.Text = "Main Branch - Fresh & Quality Goods";
                txtStorePhone.Text = "+855 12 345 678";
                txtStoreEmail.Text = "info@supermarket.com";
                txtStoreAddress.Text = "Phnom Penh, Cambodia";
                txtTaxRate.Text = "10.00";
                txtCurrency.Text = "$";
                txtExchangeRate.Text = "4100";
                txtReceiptHeader.Text = "Thank you for shopping with us!";
                txtReceiptFooter.Text = "Goods sold are not returnable. Please keep your receipt.";
            }
        }

        #endregion

        #region Units Tab Logic

        private void PopulateUnitsSortColumns()
        {
            cmbSortUnits.Items.Clear();
            cmbSortUnits.Items.Add("Id");
            cmbSortUnits.Items.Add("Name");
            cmbSortUnits.Items.Add("Short Name");
            cmbSortUnits.SelectedIndex = 0;
        }

        private async Task LoadUnitsDataAsync()
        {
            try
            {
                _allUnits = await Task.Run(() => _unitsDAL.GetAllUnits());
                ApplyUnitsFilterAndSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading units: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyUnitsFilterAndSort()
        {
            if (_allUnits == null) return;

            string keyword = txtSearchUnits.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<UnitModel> query = _allUnits;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(u =>
                    u.UnitId.ToString().Contains(keyword) ||
                    (!string.IsNullOrEmpty(u.UnitName) && u.UnitName.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(u.ShortName) && u.ShortName.ToLower().Contains(keyword))
                );
            }

            // 2. Sort
            string selectedCol = cmbSortUnits.SelectedItem != null ? cmbSortUnits.SelectedItem.ToString() : "Id";
            bool isDescending = btnSortUnits.Checked;

            switch (selectedCol)
            {
                case "Name":
                    query = isDescending ? query.OrderByDescending(u => u.UnitName) : query.OrderBy(u => u.UnitName);
                    break;
                case "Short Name":
                    query = isDescending ? query.OrderByDescending(u => u.ShortName) : query.OrderBy(u => u.ShortName);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(u => u.UnitId) : query.OrderBy(u => u.UnitId);
                    break;
            }

            dgvUnits.DataSource = null;
            dgvUnits.DataSource = query.ToList();
        }

        private int GetSelectedUnitId()
        {
            if (dgvUnits.CurrentRow != null)
            {
                if (dgvUnits.CurrentRow.DataBoundItem is UnitModel unit)
                {
                    return unit.UnitId;
                }
                else if (dgvUnits.CurrentRow.Cells["colUnitId"].Value != null &&
                         int.TryParse(dgvUnits.CurrentRow.Cells["colUnitId"].Value.ToString(), out int id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedUnitName()
        {
            if (dgvUnits.CurrentRow != null)
            {
                if (dgvUnits.CurrentRow.DataBoundItem is UnitModel unit)
                {
                    return unit.UnitName;
                }
                else if (dgvUnits.CurrentRow.Cells["colUnitName"].Value != null)
                {
                    return dgvUnits.CurrentRow.Cells["colUnitName"].Value.ToString();
                }
            }
            return "selected unit";
        }

        private void txtSearchUnits_TextChanged(object sender, EventArgs e)
        {
            ApplyUnitsFilterAndSort();
        }

        private void cmbSortUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyUnitsFilterAndSort();
        }

        private void btnSortUnits_Click(object sender, EventArgs e)
        {
            ApplyUnitsFilterAndSort();
        }

        private async void btnRefreshUnits_Click(object sender, EventArgs e)
        {
            txtSearchUnits.Clear();
            btnSortUnits.Checked = false;
            cmbSortUnits.SelectedIndex = 0;
            await LoadUnitsDataAsync();
        }

        private async void btnAddUnit_Click(object sender, EventArgs e)
        {
            using (var dialog = new frmAddEditUnit(0))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await LoadUnitsDataAsync();
                }
            }
        }

        private async void btnEditUnit_Click(object sender, EventArgs e)
        {
            int selectedId = GetSelectedUnitId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a unit to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new frmAddEditUnit(selectedId))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await LoadUnitsDataAsync();
                }
            }
        }

        private async void btnDeleteUnit_Click(object sender, EventArgs e)
        {
            int selectedId = GetSelectedUnitId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a unit to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string unitName = GetSelectedUnitName();
            var confirm = MessageBox.Show($"Are you sure you want to delete the unit '{unitName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool deleted = _unitsDAL.DeleteUnit(selectedId);
                if (deleted)
                {
                    MessageBox.Show("Unit deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUnitsDataAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete unit. It may be in use by other products.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region System Preferences Tab Logic

        private void LoadSystemPreferences()
        {
            numLowStock.Value = Properties.Settings.Default.LowStockThreshold > 0 ? Properties.Settings.Default.LowStockThreshold : 10;
            swAutoPrint.Checked = Properties.Settings.Default.AutoPrintReceipt;
        }

        private void btnSaveSystemSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.LowStockThreshold = (int)numLowStock.Value;
                Properties.Settings.Default.AutoPrintReceipt = swAutoPrint.Checked;
                Properties.Settings.Default.Save();

                MessageBox.Show("System preferences saved successfully!", "Preferences Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving system settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion

        #region Roles Management Logic

        private List<Roles> _allRoles = new List<Roles>();

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

