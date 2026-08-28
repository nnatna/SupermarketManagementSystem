using Supermarket.DAL;
using Supermarket.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmLogin : Form
    {
        private readonly UsersDAL _usersDAL = new UsersDAL();
        private static string _savedRememberedUsername = "";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "";

            // Restore remembered username if available
            if (!string.IsNullOrWhiteSpace(_savedRememberedUsername))
            {
                txtUsername.Text = _savedRememberedUsername;
                chkRememberMe.Checked = true;
                this.ActiveControl = txtPassword;
            }
            else
            {
                this.ActiveControl = txtUsername;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            lblError.Visible = false;
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowError("Please enter your username.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter your password.");
                txtPassword.Focus();
                return;
            }

            // Set loading state
            btnLogin.Enabled = false;
            btnLogin.Text = "SIGNING IN...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string errorMessage;
                var user = _usersDAL.Authenticate(username, password, out errorMessage);

                if (user != null)
                {
                    // Save remembered username
                    if (chkRememberMe.Checked)
                    {
                        _savedRememberedUsername = username;
                    }
                    else
                    {
                        _savedRememberedUsername = "";
                    }

                    UserSession.Login(user);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError(string.IsNullOrWhiteSpace(errorMessage) ? "Invalid username or password." : errorMessage);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError("Login error: " + ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "SIGN IN";
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '●';
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformLogin();
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
