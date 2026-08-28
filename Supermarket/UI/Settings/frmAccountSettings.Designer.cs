namespace Supermarket.UI.Settings
{
    partial class frmAccountSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblAccountTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlProfileCard = new Guna.UI2.WinForms.Guna2Panel();
            this.btnChangePhoto = new Guna.UI2.WinForms.Guna2Button();
            this.picAccountAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblCreatedDateVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCreatedDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatusVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRoleVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRole = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEmployeeVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEmployee = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUsernameVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProfileTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlSecurityCard = new Guna.UI2.WinForms.Guna2Panel();
            this.btnUpdatePassword = new Guna.UI2.WinForms.Guna2Button();
            this.chkShowPassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblConfirmPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCurrentPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSecurityTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlTopHeader.SuspendLayout();
            this.pnlProfileCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAccountAvatar)).BeginInit();
            this.pnlSecurityCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.Controls.Add(this.lblAccountTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1232, 50);
            this.pnlTopHeader.TabIndex = 0;
            // 
            // lblAccountTitle
            // 
            this.lblAccountTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblAccountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAccountTitle.Location = new System.Drawing.Point(18, 12);
            this.lblAccountTitle.Name = "lblAccountTitle";
            this.lblAccountTitle.Size = new System.Drawing.Size(262, 32);
            this.lblAccountTitle.TabIndex = 0;
            this.lblAccountTitle.Text = "Account & Security Settings";
            // 
            // pnlProfileCard
            // 
            this.pnlProfileCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlProfileCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlProfileCard.BorderRadius = 12;
            this.pnlProfileCard.BorderThickness = 1;
            this.pnlProfileCard.Controls.Add(this.btnChangePhoto);
            this.pnlProfileCard.Controls.Add(this.picAccountAvatar);
            this.pnlProfileCard.Controls.Add(this.lblCreatedDateVal);
            this.pnlProfileCard.Controls.Add(this.lblCreatedDate);
            this.pnlProfileCard.Controls.Add(this.lblStatusVal);
            this.pnlProfileCard.Controls.Add(this.lblStatus);
            this.pnlProfileCard.Controls.Add(this.lblRoleVal);
            this.pnlProfileCard.Controls.Add(this.lblRole);
            this.pnlProfileCard.Controls.Add(this.lblEmployeeVal);
            this.pnlProfileCard.Controls.Add(this.lblEmployee);
            this.pnlProfileCard.Controls.Add(this.lblUsernameVal);
            this.pnlProfileCard.Controls.Add(this.lblUsername);
            this.pnlProfileCard.Controls.Add(this.lblProfileTitle);
            this.pnlProfileCard.FillColor = System.Drawing.Color.White;
            this.pnlProfileCard.Location = new System.Drawing.Point(18, 60);
            this.pnlProfileCard.Name = "pnlProfileCard";
            this.pnlProfileCard.Size = new System.Drawing.Size(580, 435);
            this.pnlProfileCard.TabIndex = 1;
            // 
            // btnChangePhoto
            // 
            this.btnChangePhoto.Animated = true;
            this.btnChangePhoto.BorderRadius = 6;
            this.btnChangePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePhoto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnChangePhoto.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnChangePhoto.ForeColor = System.Drawing.Color.White;
            this.btnChangePhoto.Location = new System.Drawing.Point(435, 180);
            this.btnChangePhoto.Name = "btnChangePhoto";
            this.btnChangePhoto.Size = new System.Drawing.Size(110, 32);
            this.btnChangePhoto.TabIndex = 14;
            this.btnChangePhoto.Text = "Change Photo";
            this.btnChangePhoto.Click += new System.EventHandler(this.btnChangePhoto_Click);
            // 
            // picAccountAvatar
            // 
            this.picAccountAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAccountAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.picAccountAvatar.Image = global::Supermarket.Properties.Resources.users;
            this.picAccountAvatar.ImageRotate = 0F;
            this.picAccountAvatar.Location = new System.Drawing.Point(435, 60);
            this.picAccountAvatar.Name = "picAccountAvatar";
            this.picAccountAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAccountAvatar.Size = new System.Drawing.Size(110, 110);
            this.picAccountAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAccountAvatar.TabIndex = 13;
            this.picAccountAvatar.TabStop = false;
            // 
            // lblCreatedDateVal
            // 
            this.lblCreatedDateVal.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedDateVal.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblCreatedDateVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCreatedDateVal.Location = new System.Drawing.Point(160, 270);
            this.lblCreatedDateVal.Name = "lblCreatedDateVal";
            this.lblCreatedDateVal.Size = new System.Drawing.Size(10, 22);
            this.lblCreatedDateVal.TabIndex = 10;
            this.lblCreatedDateVal.Text = "-";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblCreatedDate.Location = new System.Drawing.Point(20, 270);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(89, 21);
            this.lblCreatedDate.TabIndex = 9;
            this.lblCreatedDate.Text = "Created Date:";
            // 
            // lblStatusVal
            // 
            this.lblStatusVal.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusVal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblStatusVal.ForeColor = System.Drawing.Color.Green;
            this.lblStatusVal.Location = new System.Drawing.Point(160, 220);
            this.lblStatusVal.Name = "lblStatusVal";
            this.lblStatusVal.Size = new System.Drawing.Size(43, 22);
            this.lblStatusVal.TabIndex = 8;
            this.lblStatusVal.Text = "Active";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 220);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 21);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // lblRoleVal
            // 
            this.lblRoleVal.BackColor = System.Drawing.Color.Transparent;
            this.lblRoleVal.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblRoleVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblRoleVal.Location = new System.Drawing.Point(160, 170);
            this.lblRoleVal.Name = "lblRoleVal";
            this.lblRoleVal.Size = new System.Drawing.Size(10, 22);
            this.lblRoleVal.TabIndex = 6;
            this.lblRoleVal.Text = "-";
            // 
            // lblRole
            // 
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblRole.Location = new System.Drawing.Point(20, 170);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(34, 21);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "Role:";
            // 
            // lblEmployeeVal
            // 
            this.lblEmployeeVal.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployeeVal.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblEmployeeVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblEmployeeVal.Location = new System.Drawing.Point(160, 120);
            this.lblEmployeeVal.Name = "lblEmployeeVal";
            this.lblEmployeeVal.Size = new System.Drawing.Size(10, 22);
            this.lblEmployeeVal.TabIndex = 4;
            this.lblEmployeeVal.Text = "-";
            // 
            // lblEmployee
            // 
            this.lblEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEmployee.Location = new System.Drawing.Point(20, 120);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(117, 21);
            this.lblEmployee.TabIndex = 3;
            this.lblEmployee.Text = "Linked Employee:";
            // 
            // lblUsernameVal
            // 
            this.lblUsernameVal.BackColor = System.Drawing.Color.Transparent;
            this.lblUsernameVal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblUsernameVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblUsernameVal.Location = new System.Drawing.Point(160, 70);
            this.lblUsernameVal.Name = "lblUsernameVal";
            this.lblUsernameVal.Size = new System.Drawing.Size(10, 22);
            this.lblUsernameVal.TabIndex = 2;
            this.lblUsernameVal.Text = "-";
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblUsername.Location = new System.Drawing.Point(20, 70);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 21);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // lblProfileTitle
            // 
            this.lblProfileTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblProfileTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProfileTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblProfileTitle.Location = new System.Drawing.Point(20, 20);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(121, 23);
            this.lblProfileTitle.TabIndex = 0;
            this.lblProfileTitle.Text = "Account Profile";
            // 
            // pnlSecurityCard
            // 
            this.pnlSecurityCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlSecurityCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlSecurityCard.BorderRadius = 12;
            this.pnlSecurityCard.BorderThickness = 1;
            this.pnlSecurityCard.Controls.Add(this.btnUpdatePassword);
            this.pnlSecurityCard.Controls.Add(this.chkShowPassword);
            this.pnlSecurityCard.Controls.Add(this.lblConfirmPassword);
            this.pnlSecurityCard.Controls.Add(this.txtConfirmPassword);
            this.pnlSecurityCard.Controls.Add(this.lblNewPassword);
            this.pnlSecurityCard.Controls.Add(this.txtNewPassword);
            this.pnlSecurityCard.Controls.Add(this.lblCurrentPassword);
            this.pnlSecurityCard.Controls.Add(this.txtCurrentPassword);
            this.pnlSecurityCard.Controls.Add(this.lblSecurityTitle);
            this.pnlSecurityCard.FillColor = System.Drawing.Color.White;
            this.pnlSecurityCard.Location = new System.Drawing.Point(615, 60);
            this.pnlSecurityCard.Name = "pnlSecurityCard";
            this.pnlSecurityCard.Size = new System.Drawing.Size(595, 435);
            this.pnlSecurityCard.TabIndex = 2;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Animated = true;
            this.btnUpdatePassword.BorderRadius = 8;
            this.btnUpdatePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdatePassword.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdatePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePassword.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePassword.Location = new System.Drawing.Point(20, 365);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(180, 45);
            this.btnUpdatePassword.TabIndex = 8;
            this.btnUpdatePassword.Text = "Update Password";
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowPassword.CheckedState.BorderRadius = 3;
            this.chkShowPassword.CheckedState.BorderThickness = 0;
            this.chkShowPassword.CheckedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkShowPassword.Location = new System.Drawing.Point(20, 325);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(108, 19);
            this.chkShowPassword.TabIndex = 7;
            this.chkShowPassword.Text = "Show Passwords";
            this.chkShowPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowPassword.UncheckedState.BorderRadius = 3;
            this.chkShowPassword.UncheckedState.BorderThickness = 1;
            this.chkShowPassword.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 235);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(147, 19);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Confirm New Password:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderRadius = 6;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(20, 260);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Re-enter new password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(550, 40);
            this.txtConfirmPassword.TabIndex = 6;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNewPassword.Location = new System.Drawing.Point(20, 145);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(97, 19);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderRadius = 6;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNewPassword.Location = new System.Drawing.Point(20, 170);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderText = "Enter new password (min 4 chars)";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(550, 40);
            this.txtNewPassword.TabIndex = 4;
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCurrentPassword.Location = new System.Drawing.Point(20, 60);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(114, 19);
            this.lblCurrentPassword.TabIndex = 1;
            this.lblCurrentPassword.Text = "Current Password:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BorderRadius = 6;
            this.txtCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentPassword.DefaultText = "";
            this.txtCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtCurrentPassword.Location = new System.Drawing.Point(20, 85);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '●';
            this.txtCurrentPassword.PlaceholderText = "Enter your current password";
            this.txtCurrentPassword.SelectedText = "";
            this.txtCurrentPassword.Size = new System.Drawing.Size(550, 40);
            this.txtCurrentPassword.TabIndex = 2;
            // 
            // lblSecurityTitle
            // 
            this.lblSecurityTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSecurityTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSecurityTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSecurityTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSecurityTitle.Name = "lblSecurityTitle";
            this.lblSecurityTitle.Size = new System.Drawing.Size(203, 23);
            this.lblSecurityTitle.TabIndex = 0;
            this.lblSecurityTitle.Text = "Change Account Password";
            // 
            // frmAccountSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1232, 560);
            this.Controls.Add(this.pnlSecurityCard);
            this.Controls.Add(this.pnlProfileCard);
            this.Controls.Add(this.pnlTopHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAccountSettings";
            this.Text = "Account Settings";
            this.Load += new System.EventHandler(this.frmAccountSettings_Load);
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlProfileCard.ResumeLayout(false);
            this.pnlProfileCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAccountAvatar)).EndInit();
            this.pnlSecurityCard.ResumeLayout(false);
            this.pnlSecurityCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAccountTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlProfileCard;
        private Guna.UI2.WinForms.Guna2Button btnChangePhoto;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAccountAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCreatedDateVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCreatedDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatusVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRoleVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRole;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmployeeVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmployee;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsernameVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProfileTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlSecurityCard;
        private Guna.UI2.WinForms.Guna2Button btnUpdatePassword;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNewPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCurrentPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSecurityTitle;
    }
}
