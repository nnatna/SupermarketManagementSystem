namespace Supermarket.UI.Settings
{
    partial class frmSystemSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblSystemTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlSystemCard = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTestDbConnection = new Guna.UI2.WinForms.Guna2Button();
            this.lblDbStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDbConnection = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSaveSystemSettings = new Guna.UI2.WinForms.Guna2Button();
            this.swAutoPrint = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lblAutoPrint = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numLowStock = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblLowStock = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSystemCardTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlRolesCard = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvRoles = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlRolesToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRole = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditRole = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteRole = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefreshRoles = new Guna.UI2.WinForms.Guna2Button();
            this.lblRolesCardTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.colRoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleCreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTopHeader.SuspendLayout();
            this.pnlSystemCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStock)).BeginInit();
            this.pnlRolesCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.pnlRolesToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.Controls.Add(this.lblSystemTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1232, 50);
            this.pnlTopHeader.TabIndex = 0;
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblSystemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSystemTitle.Location = new System.Drawing.Point(18, 12);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(242, 32);
            this.lblSystemTitle.TabIndex = 0;
            this.lblSystemTitle.Text = "System & Roles Settings";
            // 
            // pnlSystemCard
            // 
            this.pnlSystemCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlSystemCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlSystemCard.BorderRadius = 12;
            this.pnlSystemCard.BorderThickness = 1;
            this.pnlSystemCard.Controls.Add(this.btnTestDbConnection);
            this.pnlSystemCard.Controls.Add(this.lblDbStatus);
            this.pnlSystemCard.Controls.Add(this.lblDbConnection);
            this.pnlSystemCard.Controls.Add(this.btnSaveSystemSettings);
            this.pnlSystemCard.Controls.Add(this.swAutoPrint);
            this.pnlSystemCard.Controls.Add(this.lblAutoPrint);
            this.pnlSystemCard.Controls.Add(this.numLowStock);
            this.pnlSystemCard.Controls.Add(this.lblLowStock);
            this.pnlSystemCard.Controls.Add(this.lblSystemCardTitle);
            this.pnlSystemCard.FillColor = System.Drawing.Color.White;
            this.pnlSystemCard.Location = new System.Drawing.Point(18, 60);
            this.pnlSystemCard.Name = "pnlSystemCard";
            this.pnlSystemCard.Size = new System.Drawing.Size(580, 480);
            this.pnlSystemCard.TabIndex = 1;
            // 
            // btnTestDbConnection
            // 
            this.btnTestDbConnection.Animated = true;
            this.btnTestDbConnection.BorderRadius = 6;
            this.btnTestDbConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestDbConnection.FillColor = System.Drawing.Color.SteelBlue;
            this.btnTestDbConnection.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnTestDbConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestDbConnection.Location = new System.Drawing.Point(20, 245);
            this.btnTestDbConnection.Name = "btnTestDbConnection";
            this.btnTestDbConnection.Size = new System.Drawing.Size(180, 38);
            this.btnTestDbConnection.TabIndex = 8;
            this.btnTestDbConnection.Text = "Test Connection";
            this.btnTestDbConnection.Click += new System.EventHandler(this.btnTestDbConnection_Click);
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblDbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblDbStatus.Location = new System.Drawing.Point(215, 255);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(118, 19);
            this.lblDbStatus.TabIndex = 7;
            this.lblDbStatus.Text = "Status: Not checked";
            // 
            // lblDbConnection
            // 
            this.lblDbConnection.BackColor = System.Drawing.Color.Transparent;
            this.lblDbConnection.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDbConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDbConnection.Location = new System.Drawing.Point(20, 215);
            this.lblDbConnection.Name = "lblDbConnection";
            this.lblDbConnection.Size = new System.Drawing.Size(168, 21);
            this.lblDbConnection.TabIndex = 6;
            this.lblDbConnection.Text = "Database Connection Info:";
            // 
            // btnSaveSystemSettings
            // 
            this.btnSaveSystemSettings.Animated = true;
            this.btnSaveSystemSettings.BorderRadius = 8;
            this.btnSaveSystemSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveSystemSettings.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveSystemSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveSystemSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSystemSettings.Location = new System.Drawing.Point(20, 365);
            this.btnSaveSystemSettings.Name = "btnSaveSystemSettings";
            this.btnSaveSystemSettings.Size = new System.Drawing.Size(180, 45);
            this.btnSaveSystemSettings.TabIndex = 5;
            this.btnSaveSystemSettings.Text = "Save Preferences";
            this.btnSaveSystemSettings.Click += new System.EventHandler(this.btnSaveSystemSettings_Click);
            // 
            // swAutoPrint
            // 
            this.swAutoPrint.Checked = true;
            this.swAutoPrint.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.swAutoPrint.CheckedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.swAutoPrint.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.swAutoPrint.CheckedState.InnerColor = System.Drawing.Color.White;
            this.swAutoPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swAutoPrint.Location = new System.Drawing.Point(20, 165);
            this.swAutoPrint.Name = "swAutoPrint";
            this.swAutoPrint.Size = new System.Drawing.Size(50, 26);
            this.swAutoPrint.TabIndex = 4;
            this.swAutoPrint.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.swAutoPrint.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.swAutoPrint.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.swAutoPrint.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // lblAutoPrint
            // 
            this.lblAutoPrint.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblAutoPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAutoPrint.Location = new System.Drawing.Point(20, 135);
            this.lblAutoPrint.Name = "lblAutoPrint";
            this.lblAutoPrint.Size = new System.Drawing.Size(186, 21);
            this.lblAutoPrint.TabIndex = 3;
            this.lblAutoPrint.Text = "Auto-Print Receipt after Sale:";
            // 
            // numLowStock
            // 
            this.numLowStock.BackColor = System.Drawing.Color.Transparent;
            this.numLowStock.BorderRadius = 6;
            this.numLowStock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numLowStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numLowStock.Location = new System.Drawing.Point(20, 85);
            this.numLowStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLowStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowStock.Name = "numLowStock";
            this.numLowStock.Size = new System.Drawing.Size(180, 36);
            this.numLowStock.TabIndex = 2;
            this.numLowStock.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblLowStock
            // 
            this.lblLowStock.BackColor = System.Drawing.Color.Transparent;
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLowStock.Location = new System.Drawing.Point(20, 60);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(171, 21);
            this.lblLowStock.TabIndex = 1;
            this.lblLowStock.Text = "Low Stock Alert Threshold:";
            // 
            // lblSystemCardTitle
            // 
            this.lblSystemCardTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemCardTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSystemCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSystemCardTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSystemCardTitle.Name = "lblSystemCardTitle";
            this.lblSystemCardTitle.Size = new System.Drawing.Size(228, 23);
            this.lblSystemCardTitle.TabIndex = 0;
            this.lblSystemCardTitle.Text = "Preferences & Configurations";
            // 
            // pnlRolesCard
            // 
            this.pnlRolesCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlRolesCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlRolesCard.BorderRadius = 12;
            this.pnlRolesCard.BorderThickness = 1;
            this.pnlRolesCard.Controls.Add(this.dgvRoles);
            this.pnlRolesCard.Controls.Add(this.pnlRolesToolbar);
            this.pnlRolesCard.Controls.Add(this.lblRolesCardTitle);
            this.pnlRolesCard.FillColor = System.Drawing.Color.White;
            this.pnlRolesCard.Location = new System.Drawing.Point(615, 60);
            this.pnlRolesCard.Name = "pnlRolesCard";
            this.pnlRolesCard.Size = new System.Drawing.Size(595, 480);
            this.pnlRolesCard.TabIndex = 2;
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoles.ColumnHeadersHeight = 36;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoleId,
            this.colRoleName,
            this.colRoleDescription,
            this.colRoleCreatedAt});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRoles.Location = new System.Drawing.Point(20, 95);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.RowTemplate.Height = 34;
            this.dgvRoles.Size = new System.Drawing.Size(555, 365);
            this.dgvRoles.TabIndex = 2;
            this.dgvRoles.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRoles.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRoles.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvRoles.ThemeStyle.ReadOnly = true;
            this.dgvRoles.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRoles.ThemeStyle.RowsStyle.Height = 34;
            this.dgvRoles.DoubleClick += new System.EventHandler(this.btnEditRole_Click);
            // 
            // pnlRolesToolbar
            // 
            this.pnlRolesToolbar.Controls.Add(this.btnAddRole);
            this.pnlRolesToolbar.Controls.Add(this.btnEditRole);
            this.pnlRolesToolbar.Controls.Add(this.btnDeleteRole);
            this.pnlRolesToolbar.Controls.Add(this.btnRefreshRoles);
            this.pnlRolesToolbar.Location = new System.Drawing.Point(20, 48);
            this.pnlRolesToolbar.Name = "pnlRolesToolbar";
            this.pnlRolesToolbar.Size = new System.Drawing.Size(555, 46);
            this.pnlRolesToolbar.TabIndex = 1;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Animated = true;
            this.btnAddRole.BackColor = System.Drawing.Color.Transparent;
            this.btnAddRole.BorderColor = System.Drawing.Color.LightGray;
            this.btnAddRole.BorderRadius = 8;
            this.btnAddRole.BorderThickness = 1;
            this.btnAddRole.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddRole.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnAddRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRole.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnAddRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddRole.FillColor = System.Drawing.Color.White;
            this.btnAddRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnAddRole.ForeColor = System.Drawing.Color.Black;
            this.btnAddRole.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnAddRole.Image = global::Supermarket.Properties.Resources.plus;
            this.btnAddRole.IndicateFocus = true;
            this.btnAddRole.Location = new System.Drawing.Point(3, 3);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(100, 38);
            this.btnAddRole.TabIndex = 0;
            this.btnAddRole.TabStop = false;
            this.btnAddRole.Text = "Add";
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.Animated = true;
            this.btnEditRole.BackColor = System.Drawing.Color.Transparent;
            this.btnEditRole.BorderColor = System.Drawing.Color.LightGray;
            this.btnEditRole.BorderRadius = 8;
            this.btnEditRole.BorderThickness = 1;
            this.btnEditRole.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnEditRole.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnEditRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditRole.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnEditRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditRole.FillColor = System.Drawing.Color.White;
            this.btnEditRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnEditRole.ForeColor = System.Drawing.Color.Black;
            this.btnEditRole.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEditRole.Image = global::Supermarket.Properties.Resources.edit;
            this.btnEditRole.IndicateFocus = true;
            this.btnEditRole.Location = new System.Drawing.Point(109, 3);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(95, 38);
            this.btnEditRole.TabIndex = 1;
            this.btnEditRole.TabStop = false;
            this.btnEditRole.Text = "Edit";
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Animated = true;
            this.btnDeleteRole.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteRole.BorderColor = System.Drawing.Color.LightGray;
            this.btnDeleteRole.BorderRadius = 8;
            this.btnDeleteRole.BorderThickness = 1;
            this.btnDeleteRole.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteRole.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnDeleteRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRole.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnDeleteRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteRole.FillColor = System.Drawing.Color.White;
            this.btnDeleteRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDeleteRole.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteRole.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteRole.Image = global::Supermarket.Properties.Resources.delete;
            this.btnDeleteRole.IndicateFocus = true;
            this.btnDeleteRole.Location = new System.Drawing.Point(210, 3);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(95, 38);
            this.btnDeleteRole.TabIndex = 2;
            this.btnDeleteRole.TabStop = false;
            this.btnDeleteRole.Text = "Delete";
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnRefreshRoles
            // 
            this.btnRefreshRoles.Animated = true;
            this.btnRefreshRoles.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshRoles.BorderColor = System.Drawing.Color.LightGray;
            this.btnRefreshRoles.BorderRadius = 8;
            this.btnRefreshRoles.BorderThickness = 1;
            this.btnRefreshRoles.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRefreshRoles.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnRefreshRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshRoles.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnRefreshRoles.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshRoles.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshRoles.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefreshRoles.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefreshRoles.FillColor = System.Drawing.Color.White;
            this.btnRefreshRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnRefreshRoles.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshRoles.HoverState.FillColor = System.Drawing.Color.DarkGray;
            this.btnRefreshRoles.Image = global::Supermarket.Properties.Resources.refresh;
            this.btnRefreshRoles.IndicateFocus = true;
            this.btnRefreshRoles.Location = new System.Drawing.Point(311, 3);
            this.btnRefreshRoles.Name = "btnRefreshRoles";
            this.btnRefreshRoles.Size = new System.Drawing.Size(105, 38);
            this.btnRefreshRoles.TabIndex = 3;
            this.btnRefreshRoles.TabStop = false;
            this.btnRefreshRoles.Text = "Refresh";
            this.btnRefreshRoles.Click += new System.EventHandler(this.btnRefreshRoles_Click);
            // 
            // lblRolesCardTitle
            // 
            this.lblRolesCardTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRolesCardTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRolesCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblRolesCardTitle.Location = new System.Drawing.Point(20, 16);
            this.lblRolesCardTitle.Name = "lblRolesCardTitle";
            this.lblRolesCardTitle.Size = new System.Drawing.Size(141, 23);
            this.lblRolesCardTitle.TabIndex = 0;
            this.lblRolesCardTitle.Text = "System User Roles";
            // 
            // colRoleId
            // 
            this.colRoleId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRoleId.DataPropertyName = "Id";
            this.colRoleId.FillWeight = 40F;
            this.colRoleId.HeaderText = "ID";
            this.colRoleId.MinimumWidth = 35;
            this.colRoleId.Name = "colRoleId";
            this.colRoleId.ReadOnly = true;
            this.colRoleId.Width = 50;
            // 
            // colRoleName
            // 
            this.colRoleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRoleName.DataPropertyName = "Name";
            this.colRoleName.FillWeight = 110F;
            this.colRoleName.HeaderText = "Role Name";
            this.colRoleName.MinimumWidth = 90;
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            this.colRoleName.Width = 120;
            // 
            // colRoleDescription
            // 
            this.colRoleDescription.DataPropertyName = "Description";
            this.colRoleDescription.FillWeight = 180F;
            this.colRoleDescription.HeaderText = "Description";
            this.colRoleDescription.MinimumWidth = 120;
            this.colRoleDescription.Name = "colRoleDescription";
            this.colRoleDescription.ReadOnly = true;
            // 
            // colRoleCreatedAt
            // 
            this.colRoleCreatedAt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRoleCreatedAt.DataPropertyName = "CreatedAt";
            this.colRoleCreatedAt.HeaderText = "Created At";
            this.colRoleCreatedAt.MinimumWidth = 80;
            this.colRoleCreatedAt.Name = "colRoleCreatedAt";
            this.colRoleCreatedAt.ReadOnly = true;
            this.colRoleCreatedAt.Width = 140;
            // 
            // frmSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1232, 560);
            this.Controls.Add(this.pnlRolesCard);
            this.Controls.Add(this.pnlSystemCard);
            this.Controls.Add(this.pnlTopHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSystemSettings";
            this.Text = "System Settings";
            this.Load += new System.EventHandler(this.frmSystemSettings_Load);
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlSystemCard.ResumeLayout(false);
            this.pnlSystemCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStock)).EndInit();
            this.pnlRolesCard.ResumeLayout(false);
            this.pnlRolesCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.pnlRolesToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSystemTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlSystemCard;
        private Guna.UI2.WinForms.Guna2Button btnTestDbConnection;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDbStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDbConnection;
        private Guna.UI2.WinForms.Guna2Button btnSaveSystemSettings;
        private Guna.UI2.WinForms.Guna2ToggleSwitch swAutoPrint;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAutoPrint;
        private Guna.UI2.WinForms.Guna2NumericUpDown numLowStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLowStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSystemCardTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlRolesCard;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRoles;
        private System.Windows.Forms.FlowLayoutPanel pnlRolesToolbar;
        private Guna.UI2.WinForms.Guna2Button btnAddRole;
        private Guna.UI2.WinForms.Guna2Button btnEditRole;
        private Guna.UI2.WinForms.Guna2Button btnDeleteRole;
        private Guna.UI2.WinForms.Guna2Button btnRefreshRoles;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRolesCardTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleCreatedAt;
    }
}
