using Supermarket.DAL;
using Supermarket.Model;
using Supermarket.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserModel = Supermarket.Model.Users;

namespace Supermarket.UI.Settings
{
    public partial class frmAccountSettings : Form
    {
        private readonly UsersDAL _usersDAL = new UsersDAL();
        private readonly EmployeesDAL _employeesDAL = new EmployeesDAL();
        private UserModel _currentUser = null;

        public frmAccountSettings()
        {
            InitializeComponent();
        }

        private async void frmAccountSettings_Load(object sender, EventArgs e)
        {
            await LoadAccountProfileAsync();
        }

        private async Task LoadAccountProfileAsync()
        {
            try
            {
                UserModel user = null;
                if (UserSession.IsLoggedIn && UserSession.UserId > 0)
                {
                    user = await Task.Run(() => _usersDAL.GetUserById(UserSession.UserId));
                }

                if (user == null)
                {
                    var allUsers = await Task.Run(() => _usersDAL.GetAllUsers());
                    user = allUsers.FirstOrDefault();
                }

                _currentUser = user;
                DisplayUserInfo(_currentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading account profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayUserInfo(UserModel user)
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
            if (_currentUser == null)
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
            bool isCurrentMatch = string.Equals(_currentUser.Password, hashedCurrent, StringComparison.OrdinalIgnoreCase)
                               || string.Equals(_currentUser.Password, currentPass);

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

            // Update in DB
            _currentUser.Password = newPass;
            string errorMsg;
            bool updated = _usersDAL.UpdateUser(_currentUser, out errorMsg);
            if (updated)
            {
                _currentUser.Password = UsersDAL.HashPassword(newPass);
                if (UserSession.CurrentUser != null && UserSession.CurrentUser.Id == _currentUser.Id)
                {
                    UserSession.CurrentUser.Password = _currentUser.Password;
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
            if (_currentUser == null)
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
                            return;

                        bool updated = false;
                        string errorMsg = "";

                        if (_currentUser.EmployeeId.HasValue && _currentUser.EmployeeId.Value > 0)
                        {
                            updated = _employeesDAL.UpdateEmployeePhoto(_currentUser.EmployeeId.Value, savedRelPath, out errorMsg);
                        }
                        else
                        {
                            var newEmp = new Model.Employees
                            {
                                FullName = _currentUser.Username,
                                Gender = "Male",
                                Position = _currentUser.RoleName ?? "Staff",
                                HireDate = DateTime.Now,
                                Photo_path = savedRelPath
                            };
                            if (_employeesDAL.AddEmployee(newEmp, out errorMsg))
                            {
                                _currentUser.EmployeeId = newEmp.Id;
                                _usersDAL.UpdateUser(_currentUser, out errorMsg);
                                updated = true;
                            }
                        }

                        if (updated)
                        {
                            var refreshedUser = _usersDAL.GetUserById(_currentUser.Id);
                            if (refreshedUser != null)
                            {
                                _currentUser = refreshedUser;
                                if (UserSession.IsLoggedIn && UserSession.UserId == _currentUser.Id)
                                {
                                    UserSession.CurrentUser = refreshedUser;
                                }
                            }

                            DisplayUserInfo(_currentUser);

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
    }
}
