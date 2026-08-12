namespace Supermarket
{
    partial class FramMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FramMain));
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.inventoryTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuTimer = new System.Windows.Forms.Timer(this.components);
            this.PointOfSalesTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlMenuAll = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSalesContainer = new System.Windows.Forms.Panel();
            this.btnSalesHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnCashier = new Guna.UI2.WinForms.Guna2Button();
            this.btnPointOfSales = new Guna.UI2.WinForms.Guna2Button();
            this.btnSale = new Guna.UI2.WinForms.Guna2Button();
            this.pnlProductsContainer = new System.Windows.Forms.Panel();
            this.btnUnits = new Guna.UI2.WinForms.Guna2Button();
            this.btnCategories = new Guna.UI2.WinForms.Guna2Button();
            this.btnProducts = new Guna.UI2.WinForms.Guna2Button();
            this.btnProductsList = new Guna.UI2.WinForms.Guna2Button();
            this.pnlInventoryContainer = new System.Windows.Forms.Panel();
            this.btnStockAdjustment = new Guna.UI2.WinForms.Guna2Button();
            this.btnStock = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPurchasingSuppliersContainer = new System.Windows.Forms.Panel();
            this.btnGoodsReceive = new Guna.UI2.WinForms.Guna2Button();
            this.btnPurchasing = new Guna.UI2.WinForms.Guna2Button();
            this.btnPurchasingSuppliers = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuppliers = new Guna.UI2.WinForms.Guna2Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCustomers = new Guna.UI2.WinForms.Guna2Button();
            this.pnlReportsContainer = new System.Windows.Forms.Panel();
            this.btnProfitLoss = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventoryReport = new Guna.UI2.WinForms.Guna2Button();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnSalesReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSettingsContainer = new System.Windows.Forms.Panel();
            this.btnGeneralSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btnStoreInfo = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnEmployees = new Guna.UI2.WinForms.Guna2Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.ProductsTimer = new System.Windows.Forms.Timer(this.components);
            this.PurchasingSuppliersTimer = new System.Windows.Forms.Timer(this.components);
            this.ReportsTimer = new System.Windows.Forms.Timer(this.components);
            this.SettingsTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlMenuAll.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlSalesContainer.SuspendLayout();
            this.pnlProductsContainer.SuspendLayout();
            this.pnlInventoryContainer.SuspendLayout();
            this.pnlPurchasingSuppliersContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlReportsContainer.SuspendLayout();
            this.pnlSettingsContainer.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 54);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(50, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Supermarket Management System ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMenu
            // 
            this.btnMenu.Animated = true;
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.BorderRadius = 3;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenu.FillColor = System.Drawing.Color.Transparent;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Image = global::Supermarket.Properties.Resources.menu1;
            this.btnMenu.IndicateFocus = true;
            this.btnMenu.Location = new System.Drawing.Point(12, 11);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(32, 32);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.UseTransparentBackground = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // inventoryTimer
            // 
            this.inventoryTimer.Interval = 25;
            this.inventoryTimer.Tick += new System.EventHandler(this.inventoryTimer_Tick);
            // 
            // MenuTimer
            // 
            this.MenuTimer.Interval = 25;
            this.MenuTimer.Tick += new System.EventHandler(this.MenuTimer_Tick);
            // 
            // PointOfSalesTimer
            // 
            this.PointOfSalesTimer.Interval = 25;
            this.PointOfSalesTimer.Tick += new System.EventHandler(this.salesTimer_Tick);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlContent.Controls.Add(this.pnlSidebar);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 54);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1163, 661);
            this.pnlContent.TabIndex = 3;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.pnlMenuAll);
            this.pnlSidebar.Controls.Add(this.panel5);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(265, 661);
            this.pnlSidebar.TabIndex = 12;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // pnlMenuAll
            // 
            this.pnlMenuAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenuAll.Controls.Add(this.panel2);
            this.pnlMenuAll.Controls.Add(this.pnlSalesContainer);
            this.pnlMenuAll.Controls.Add(this.pnlProductsContainer);
            this.pnlMenuAll.Controls.Add(this.pnlInventoryContainer);
            this.pnlMenuAll.Controls.Add(this.pnlPurchasingSuppliersContainer);
            this.pnlMenuAll.Controls.Add(this.panel4);
            this.pnlMenuAll.Controls.Add(this.pnlReportsContainer);
            this.pnlMenuAll.Controls.Add(this.pnlSettingsContainer);
            this.pnlMenuAll.Location = new System.Drawing.Point(2, 1);
            this.pnlMenuAll.Name = "pnlMenuAll";
            this.pnlMenuAll.Size = new System.Drawing.Size(260, 606);
            this.pnlMenuAll.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 45);
            this.panel2.TabIndex = 4;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Animated = true;
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnDashboard.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnDashboard.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.White;
            this.btnDashboard.FocusedColor = System.Drawing.Color.Silver;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnDashboard.Image = global::Supermarket.Properties.Resources.dashboard;
            this.btnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.IndicateFocus = true;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(260, 45);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.TabStop = false;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.UseTransparentBackground = true;
            this.btnDashboard.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlSalesContainer
            // 
            this.pnlSalesContainer.Controls.Add(this.btnSalesHistory);
            this.pnlSalesContainer.Controls.Add(this.btnCashier);
            this.pnlSalesContainer.Controls.Add(this.btnPointOfSales);
            this.pnlSalesContainer.Controls.Add(this.btnSale);
            this.pnlSalesContainer.Location = new System.Drawing.Point(3, 54);
            this.pnlSalesContainer.Name = "pnlSalesContainer";
            this.pnlSalesContainer.Size = new System.Drawing.Size(260, 45);
            this.pnlSalesContainer.TabIndex = 6;
            // 
            // btnSalesHistory
            // 
            this.btnSalesHistory.Animated = true;
            this.btnSalesHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnSalesHistory.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSalesHistory.Checked = true;
            this.btnSalesHistory.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSalesHistory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSalesHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesHistory.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSalesHistory.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSalesHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSalesHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSalesHistory.FillColor = System.Drawing.Color.White;
            this.btnSalesHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSalesHistory.ForeColor = System.Drawing.Color.Black;
            this.btnSalesHistory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSalesHistory.Image = global::Supermarket.Properties.Resources.sales_history;
            this.btnSalesHistory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSalesHistory.IndicateFocus = true;
            this.btnSalesHistory.Location = new System.Drawing.Point(40, 102);
            this.btnSalesHistory.Name = "btnSalesHistory";
            this.btnSalesHistory.Size = new System.Drawing.Size(220, 45);
            this.btnSalesHistory.TabIndex = 13;
            this.btnSalesHistory.TabStop = false;
            this.btnSalesHistory.Text = "Sales History";
            this.btnSalesHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSalesHistory.UseTransparentBackground = true;
            this.btnSalesHistory.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.Animated = true;
            this.btnCashier.BackColor = System.Drawing.Color.Transparent;
            this.btnCashier.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnCashier.Checked = true;
            this.btnCashier.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCashier.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashier.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnCashier.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCashier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCashier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCashier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCashier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCashier.FillColor = System.Drawing.Color.White;
            this.btnCashier.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnCashier.ForeColor = System.Drawing.Color.Black;
            this.btnCashier.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnCashier.Image = global::Supermarket.Properties.Resources.chashier1;
            this.btnCashier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCashier.IndicateFocus = true;
            this.btnCashier.Location = new System.Drawing.Point(40, 153);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(220, 45);
            this.btnCashier.TabIndex = 6;
            this.btnCashier.TabStop = false;
            this.btnCashier.Text = "Cashier ";
            this.btnCashier.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCashier.UseTransparentBackground = true;
            this.btnCashier.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnPointOfSales
            // 
            this.btnPointOfSales.Animated = true;
            this.btnPointOfSales.BackColor = System.Drawing.Color.Transparent;
            this.btnPointOfSales.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnPointOfSales.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnPointOfSales.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPointOfSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPointOfSales.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnPointOfSales.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnPointOfSales.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPointOfSales.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPointOfSales.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPointOfSales.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPointOfSales.FillColor = System.Drawing.Color.White;
            this.btnPointOfSales.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPointOfSales.ForeColor = System.Drawing.Color.Black;
            this.btnPointOfSales.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPointOfSales.Image = global::Supermarket.Properties.Resources.sales;
            this.btnPointOfSales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPointOfSales.IndicateFocus = true;
            this.btnPointOfSales.Location = new System.Drawing.Point(0, 0);
            this.btnPointOfSales.Name = "btnPointOfSales";
            this.btnPointOfSales.Size = new System.Drawing.Size(260, 45);
            this.btnPointOfSales.TabIndex = 3;
            this.btnPointOfSales.TabStop = false;
            this.btnPointOfSales.Text = "Point of Sale";
            this.btnPointOfSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPointOfSales.UseTransparentBackground = true;
            this.btnPointOfSales.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnSale
            // 
            this.btnSale.Animated = true;
            this.btnSale.BackColor = System.Drawing.Color.Transparent;
            this.btnSale.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSale.Checked = true;
            this.btnSale.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSale.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSale.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSale.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSale.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSale.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSale.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSale.FillColor = System.Drawing.Color.White;
            this.btnSale.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSale.ForeColor = System.Drawing.Color.Black;
            this.btnSale.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSale.Image = global::Supermarket.Properties.Resources.sale;
            this.btnSale.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSale.IndicateFocus = true;
            this.btnSale.Location = new System.Drawing.Point(40, 51);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(220, 45);
            this.btnSale.TabIndex = 7;
            this.btnSale.TabStop = false;
            this.btnSale.Text = "Sales";
            this.btnSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSale.UseTransparentBackground = true;
            this.btnSale.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlProductsContainer
            // 
            this.pnlProductsContainer.Controls.Add(this.btnUnits);
            this.pnlProductsContainer.Controls.Add(this.btnCategories);
            this.pnlProductsContainer.Controls.Add(this.btnProducts);
            this.pnlProductsContainer.Controls.Add(this.btnProductsList);
            this.pnlProductsContainer.Location = new System.Drawing.Point(3, 105);
            this.pnlProductsContainer.Name = "pnlProductsContainer";
            this.pnlProductsContainer.Size = new System.Drawing.Size(260, 45);
            this.pnlProductsContainer.TabIndex = 7;
            // 
            // btnUnits
            // 
            this.btnUnits.Animated = true;
            this.btnUnits.BackColor = System.Drawing.Color.Transparent;
            this.btnUnits.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnUnits.Checked = true;
            this.btnUnits.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUnits.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnUnits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnits.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnUnits.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnUnits.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUnits.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUnits.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUnits.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUnits.FillColor = System.Drawing.Color.White;
            this.btnUnits.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnUnits.ForeColor = System.Drawing.Color.Black;
            this.btnUnits.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnUnits.Image = global::Supermarket.Properties.Resources.unit;
            this.btnUnits.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUnits.IndicateFocus = true;
            this.btnUnits.Location = new System.Drawing.Point(40, 153);
            this.btnUnits.Name = "btnUnits";
            this.btnUnits.Size = new System.Drawing.Size(220, 45);
            this.btnUnits.TabIndex = 8;
            this.btnUnits.TabStop = false;
            this.btnUnits.Text = "Units";
            this.btnUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUnits.UseTransparentBackground = true;
            this.btnUnits.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Animated = true;
            this.btnCategories.BackColor = System.Drawing.Color.Transparent;
            this.btnCategories.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnCategories.Checked = true;
            this.btnCategories.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCategories.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnCategories.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCategories.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCategories.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCategories.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCategories.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCategories.FillColor = System.Drawing.Color.White;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnCategories.ForeColor = System.Drawing.Color.Black;
            this.btnCategories.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnCategories.Image = global::Supermarket.Properties.Resources.categories;
            this.btnCategories.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategories.IndicateFocus = true;
            this.btnCategories.Location = new System.Drawing.Point(40, 102);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(220, 45);
            this.btnCategories.TabIndex = 6;
            this.btnCategories.TabStop = false;
            this.btnCategories.Text = "Categories";
            this.btnCategories.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategories.UseTransparentBackground = true;
            this.btnCategories.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Animated = true;
            this.btnProducts.BackColor = System.Drawing.Color.Transparent;
            this.btnProducts.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnProducts.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnProducts.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProducts.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnProducts.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnProducts.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProducts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProducts.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProducts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProducts.FillColor = System.Drawing.Color.White;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnProducts.ForeColor = System.Drawing.Color.Black;
            this.btnProducts.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnProducts.Image = global::Supermarket.Properties.Resources.products;
            this.btnProducts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProducts.IndicateFocus = true;
            this.btnProducts.Location = new System.Drawing.Point(0, 0);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(260, 45);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.TabStop = false;
            this.btnProducts.Text = "Products";
            this.btnProducts.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProducts.UseTransparentBackground = true;
            this.btnProducts.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnProductsList
            // 
            this.btnProductsList.Animated = true;
            this.btnProductsList.BackColor = System.Drawing.Color.Transparent;
            this.btnProductsList.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnProductsList.Checked = true;
            this.btnProductsList.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnProductsList.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnProductsList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductsList.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnProductsList.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnProductsList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProductsList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProductsList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProductsList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProductsList.FillColor = System.Drawing.Color.White;
            this.btnProductsList.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnProductsList.ForeColor = System.Drawing.Color.Black;
            this.btnProductsList.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnProductsList.Image = global::Supermarket.Properties.Resources.products_list;
            this.btnProductsList.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProductsList.IndicateFocus = true;
            this.btnProductsList.Location = new System.Drawing.Point(40, 51);
            this.btnProductsList.Name = "btnProductsList";
            this.btnProductsList.Size = new System.Drawing.Size(220, 45);
            this.btnProductsList.TabIndex = 7;
            this.btnProductsList.TabStop = false;
            this.btnProductsList.Text = "Products List";
            this.btnProductsList.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProductsList.UseTransparentBackground = true;
            this.btnProductsList.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlInventoryContainer
            // 
            this.pnlInventoryContainer.Controls.Add(this.btnStockAdjustment);
            this.pnlInventoryContainer.Controls.Add(this.btnStock);
            this.pnlInventoryContainer.Controls.Add(this.btnInventory);
            this.pnlInventoryContainer.Location = new System.Drawing.Point(3, 156);
            this.pnlInventoryContainer.Name = "pnlInventoryContainer";
            this.pnlInventoryContainer.Size = new System.Drawing.Size(260, 45);
            this.pnlInventoryContainer.TabIndex = 5;
            // 
            // btnStockAdjustment
            // 
            this.btnStockAdjustment.Animated = true;
            this.btnStockAdjustment.BackColor = System.Drawing.Color.Transparent;
            this.btnStockAdjustment.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnStockAdjustment.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnStockAdjustment.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStockAdjustment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockAdjustment.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnStockAdjustment.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnStockAdjustment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStockAdjustment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStockAdjustment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStockAdjustment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStockAdjustment.FillColor = System.Drawing.Color.White;
            this.btnStockAdjustment.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnStockAdjustment.ForeColor = System.Drawing.Color.Black;
            this.btnStockAdjustment.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStockAdjustment.Image = global::Supermarket.Properties.Resources.stock2;
            this.btnStockAdjustment.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStockAdjustment.IndicateFocus = true;
            this.btnStockAdjustment.Location = new System.Drawing.Point(40, 102);
            this.btnStockAdjustment.Name = "btnStockAdjustment";
            this.btnStockAdjustment.Size = new System.Drawing.Size(220, 45);
            this.btnStockAdjustment.TabIndex = 7;
            this.btnStockAdjustment.TabStop = false;
            this.btnStockAdjustment.Text = "Stock Adjustment";
            this.btnStockAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStockAdjustment.UseTransparentBackground = true;
            this.btnStockAdjustment.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnStock
            // 
            this.btnStock.Animated = true;
            this.btnStock.BackColor = System.Drawing.Color.Transparent;
            this.btnStock.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnStock.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnStock.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStock.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnStock.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnStock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStock.FillColor = System.Drawing.Color.White;
            this.btnStock.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnStock.ForeColor = System.Drawing.Color.Black;
            this.btnStock.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStock.Image = global::Supermarket.Properties.Resources.stock_alert;
            this.btnStock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStock.IndicateFocus = true;
            this.btnStock.Location = new System.Drawing.Point(40, 51);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(220, 45);
            this.btnStock.TabIndex = 6;
            this.btnStock.TabStop = false;
            this.btnStock.Text = "Stock Alert";
            this.btnStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStock.UseTransparentBackground = true;
            this.btnStock.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Animated = true;
            this.btnInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnInventory.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnInventory.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnInventory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnInventory.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInventory.FillColor = System.Drawing.Color.White;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnInventory.ForeColor = System.Drawing.Color.Black;
            this.btnInventory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnInventory.Image = global::Supermarket.Properties.Resources.inventory3;
            this.btnInventory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventory.IndicateFocus = true;
            this.btnInventory.Location = new System.Drawing.Point(0, 0);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(260, 45);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.TabStop = false;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventory.UseTransparentBackground = true;
            this.btnInventory.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlPurchasingSuppliersContainer
            // 
            this.pnlPurchasingSuppliersContainer.Controls.Add(this.btnGoodsReceive);
            this.pnlPurchasingSuppliersContainer.Controls.Add(this.btnPurchasing);
            this.pnlPurchasingSuppliersContainer.Controls.Add(this.btnPurchasingSuppliers);
            this.pnlPurchasingSuppliersContainer.Controls.Add(this.btnSuppliers);
            this.pnlPurchasingSuppliersContainer.Location = new System.Drawing.Point(3, 207);
            this.pnlPurchasingSuppliersContainer.Name = "pnlPurchasingSuppliersContainer";
            this.pnlPurchasingSuppliersContainer.Size = new System.Drawing.Size(260, 45);
            this.pnlPurchasingSuppliersContainer.TabIndex = 8;
            // 
            // btnGoodsReceive
            // 
            this.btnGoodsReceive.Animated = true;
            this.btnGoodsReceive.BackColor = System.Drawing.Color.Transparent;
            this.btnGoodsReceive.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnGoodsReceive.Checked = true;
            this.btnGoodsReceive.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnGoodsReceive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnGoodsReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoodsReceive.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnGoodsReceive.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGoodsReceive.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGoodsReceive.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGoodsReceive.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGoodsReceive.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGoodsReceive.FillColor = System.Drawing.Color.White;
            this.btnGoodsReceive.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnGoodsReceive.ForeColor = System.Drawing.Color.Black;
            this.btnGoodsReceive.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnGoodsReceive.Image = global::Supermarket.Properties.Resources.goods_receive;
            this.btnGoodsReceive.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGoodsReceive.IndicateFocus = true;
            this.btnGoodsReceive.Location = new System.Drawing.Point(40, 153);
            this.btnGoodsReceive.Name = "btnGoodsReceive";
            this.btnGoodsReceive.Size = new System.Drawing.Size(220, 45);
            this.btnGoodsReceive.TabIndex = 9;
            this.btnGoodsReceive.TabStop = false;
            this.btnGoodsReceive.Text = "Goods Receive";
            this.btnGoodsReceive.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGoodsReceive.UseTransparentBackground = true;
            this.btnGoodsReceive.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnPurchasing
            // 
            this.btnPurchasing.Animated = true;
            this.btnPurchasing.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchasing.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnPurchasing.Checked = true;
            this.btnPurchasing.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnPurchasing.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPurchasing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchasing.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnPurchasing.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnPurchasing.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPurchasing.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPurchasing.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPurchasing.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPurchasing.FillColor = System.Drawing.Color.White;
            this.btnPurchasing.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPurchasing.ForeColor = System.Drawing.Color.Black;
            this.btnPurchasing.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPurchasing.Image = global::Supermarket.Properties.Resources.purchase;
            this.btnPurchasing.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPurchasing.IndicateFocus = true;
            this.btnPurchasing.Location = new System.Drawing.Point(40, 102);
            this.btnPurchasing.Name = "btnPurchasing";
            this.btnPurchasing.Size = new System.Drawing.Size(220, 45);
            this.btnPurchasing.TabIndex = 6;
            this.btnPurchasing.TabStop = false;
            this.btnPurchasing.Text = "Purchase Orders";
            this.btnPurchasing.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPurchasing.UseTransparentBackground = true;
            this.btnPurchasing.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnPurchasingSuppliers
            // 
            this.btnPurchasingSuppliers.Animated = true;
            this.btnPurchasingSuppliers.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchasingSuppliers.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnPurchasingSuppliers.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnPurchasingSuppliers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPurchasingSuppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchasingSuppliers.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnPurchasingSuppliers.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnPurchasingSuppliers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPurchasingSuppliers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPurchasingSuppliers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPurchasingSuppliers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPurchasingSuppliers.FillColor = System.Drawing.Color.White;
            this.btnPurchasingSuppliers.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPurchasingSuppliers.ForeColor = System.Drawing.Color.Black;
            this.btnPurchasingSuppliers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPurchasingSuppliers.Image = global::Supermarket.Properties.Resources.purchasing_suppliers;
            this.btnPurchasingSuppliers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPurchasingSuppliers.IndicateFocus = true;
            this.btnPurchasingSuppliers.Location = new System.Drawing.Point(0, 0);
            this.btnPurchasingSuppliers.Name = "btnPurchasingSuppliers";
            this.btnPurchasingSuppliers.Size = new System.Drawing.Size(260, 45);
            this.btnPurchasingSuppliers.TabIndex = 3;
            this.btnPurchasingSuppliers.TabStop = false;
            this.btnPurchasingSuppliers.Text = "Purchasing / Suppliers";
            this.btnPurchasingSuppliers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPurchasingSuppliers.UseTransparentBackground = true;
            this.btnPurchasingSuppliers.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Animated = true;
            this.btnSuppliers.BackColor = System.Drawing.Color.Transparent;
            this.btnSuppliers.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSuppliers.Checked = true;
            this.btnSuppliers.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSuppliers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSuppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuppliers.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSuppliers.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSuppliers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuppliers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuppliers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuppliers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuppliers.FillColor = System.Drawing.Color.White;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSuppliers.ForeColor = System.Drawing.Color.Black;
            this.btnSuppliers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSuppliers.Image = global::Supermarket.Properties.Resources.suppliers;
            this.btnSuppliers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSuppliers.IndicateFocus = true;
            this.btnSuppliers.Location = new System.Drawing.Point(40, 51);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(220, 45);
            this.btnSuppliers.TabIndex = 7;
            this.btnSuppliers.TabStop = false;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSuppliers.UseTransparentBackground = true;
            this.btnSuppliers.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCustomers);
            this.panel4.Location = new System.Drawing.Point(3, 258);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 45);
            this.panel4.TabIndex = 9;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Animated = true;
            this.btnCustomers.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomers.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnCustomers.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCustomers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnCustomers.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCustomers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomers.FillColor = System.Drawing.Color.White;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnCustomers.ForeColor = System.Drawing.Color.Black;
            this.btnCustomers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnCustomers.Image = global::Supermarket.Properties.Resources.cusrtomer;
            this.btnCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomers.IndicateFocus = true;
            this.btnCustomers.Location = new System.Drawing.Point(0, 0);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(260, 45);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.TabStop = false;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomers.UseTransparentBackground = true;
            this.btnCustomers.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlReportsContainer
            // 
            this.pnlReportsContainer.Controls.Add(this.btnProfitLoss);
            this.pnlReportsContainer.Controls.Add(this.btnInventoryReport);
            this.pnlReportsContainer.Controls.Add(this.btnReports);
            this.pnlReportsContainer.Controls.Add(this.btnSalesReport);
            this.pnlReportsContainer.Location = new System.Drawing.Point(3, 309);
            this.pnlReportsContainer.Name = "pnlReportsContainer";
            this.pnlReportsContainer.Size = new System.Drawing.Size(260, 45);
            this.pnlReportsContainer.TabIndex = 11;
            // 
            // btnProfitLoss
            // 
            this.btnProfitLoss.Animated = true;
            this.btnProfitLoss.BackColor = System.Drawing.Color.Transparent;
            this.btnProfitLoss.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnProfitLoss.Checked = true;
            this.btnProfitLoss.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnProfitLoss.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnProfitLoss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfitLoss.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnProfitLoss.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnProfitLoss.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProfitLoss.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProfitLoss.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProfitLoss.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProfitLoss.FillColor = System.Drawing.Color.White;
            this.btnProfitLoss.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnProfitLoss.ForeColor = System.Drawing.Color.Black;
            this.btnProfitLoss.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnProfitLoss.Image = global::Supermarket.Properties.Resources.profit_loss;
            this.btnProfitLoss.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfitLoss.IndicateFocus = true;
            this.btnProfitLoss.Location = new System.Drawing.Point(40, 153);
            this.btnProfitLoss.Name = "btnProfitLoss";
            this.btnProfitLoss.Size = new System.Drawing.Size(220, 45);
            this.btnProfitLoss.TabIndex = 9;
            this.btnProfitLoss.TabStop = false;
            this.btnProfitLoss.Text = "Profit / Loss";
            this.btnProfitLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfitLoss.UseTransparentBackground = true;
            this.btnProfitLoss.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.Animated = true;
            this.btnInventoryReport.BackColor = System.Drawing.Color.Transparent;
            this.btnInventoryReport.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnInventoryReport.Checked = true;
            this.btnInventoryReport.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnInventoryReport.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnInventoryReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryReport.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnInventoryReport.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnInventoryReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInventoryReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInventoryReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInventoryReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInventoryReport.FillColor = System.Drawing.Color.White;
            this.btnInventoryReport.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnInventoryReport.ForeColor = System.Drawing.Color.Black;
            this.btnInventoryReport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnInventoryReport.Image = global::Supermarket.Properties.Resources.inventory3;
            this.btnInventoryReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventoryReport.IndicateFocus = true;
            this.btnInventoryReport.Location = new System.Drawing.Point(40, 102);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(220, 45);
            this.btnInventoryReport.TabIndex = 6;
            this.btnInventoryReport.TabStop = false;
            this.btnInventoryReport.Text = "Inventory Report";
            this.btnInventoryReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventoryReport.UseTransparentBackground = true;
            this.btnInventoryReport.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnReports
            // 
            this.btnReports.Animated = true;
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnReports.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReports.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnReports.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReports.FillColor = System.Drawing.Color.White;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.Black;
            this.btnReports.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnReports.Image = global::Supermarket.Properties.Resources.reports;
            this.btnReports.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.IndicateFocus = true;
            this.btnReports.Location = new System.Drawing.Point(0, 0);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(260, 45);
            this.btnReports.TabIndex = 3;
            this.btnReports.TabStop = false;
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.UseTransparentBackground = true;
            this.btnReports.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.Animated = true;
            this.btnSalesReport.BackColor = System.Drawing.Color.Transparent;
            this.btnSalesReport.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSalesReport.Checked = true;
            this.btnSalesReport.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSalesReport.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSalesReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesReport.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSalesReport.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSalesReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSalesReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSalesReport.FillColor = System.Drawing.Color.White;
            this.btnSalesReport.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSalesReport.ForeColor = System.Drawing.Color.Black;
            this.btnSalesReport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSalesReport.Image = global::Supermarket.Properties.Resources.sales;
            this.btnSalesReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSalesReport.IndicateFocus = true;
            this.btnSalesReport.Location = new System.Drawing.Point(40, 51);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(220, 45);
            this.btnSalesReport.TabIndex = 7;
            this.btnSalesReport.TabStop = false;
            this.btnSalesReport.Text = "Sales Report";
            this.btnSalesReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSalesReport.UseTransparentBackground = true;
            this.btnSalesReport.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlSettingsContainer
            // 
            this.pnlSettingsContainer.Controls.Add(this.btnGeneralSetting);
            this.pnlSettingsContainer.Controls.Add(this.btnStoreInfo);
            this.pnlSettingsContainer.Controls.Add(this.btnSettings);
            this.pnlSettingsContainer.Controls.Add(this.btnUsers);
            this.pnlSettingsContainer.Controls.Add(this.btnEmployees);
            this.pnlSettingsContainer.Location = new System.Drawing.Point(3, 360);
            this.pnlSettingsContainer.Name = "pnlSettingsContainer";
            this.pnlSettingsContainer.Size = new System.Drawing.Size(260, 45);
            this.pnlSettingsContainer.TabIndex = 10;
            // 
            // btnGeneralSetting
            // 
            this.btnGeneralSetting.Animated = true;
            this.btnGeneralSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnGeneralSetting.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnGeneralSetting.Checked = true;
            this.btnGeneralSetting.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnGeneralSetting.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnGeneralSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneralSetting.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnGeneralSetting.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGeneralSetting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGeneralSetting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGeneralSetting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGeneralSetting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGeneralSetting.FillColor = System.Drawing.Color.White;
            this.btnGeneralSetting.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnGeneralSetting.ForeColor = System.Drawing.Color.Black;
            this.btnGeneralSetting.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnGeneralSetting.Image = global::Supermarket.Properties.Resources.general;
            this.btnGeneralSetting.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGeneralSetting.IndicateFocus = true;
            this.btnGeneralSetting.Location = new System.Drawing.Point(40, 204);
            this.btnGeneralSetting.Name = "btnGeneralSetting";
            this.btnGeneralSetting.Size = new System.Drawing.Size(220, 45);
            this.btnGeneralSetting.TabIndex = 11;
            this.btnGeneralSetting.TabStop = false;
            this.btnGeneralSetting.Text = "General Settings";
            this.btnGeneralSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGeneralSetting.UseTransparentBackground = true;
            this.btnGeneralSetting.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnStoreInfo
            // 
            this.btnStoreInfo.Animated = true;
            this.btnStoreInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnStoreInfo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnStoreInfo.Checked = true;
            this.btnStoreInfo.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnStoreInfo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStoreInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStoreInfo.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnStoreInfo.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnStoreInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStoreInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStoreInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStoreInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStoreInfo.FillColor = System.Drawing.Color.White;
            this.btnStoreInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnStoreInfo.ForeColor = System.Drawing.Color.Black;
            this.btnStoreInfo.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStoreInfo.Image = global::Supermarket.Properties.Resources.store;
            this.btnStoreInfo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStoreInfo.IndicateFocus = true;
            this.btnStoreInfo.Location = new System.Drawing.Point(40, 153);
            this.btnStoreInfo.Name = "btnStoreInfo";
            this.btnStoreInfo.Size = new System.Drawing.Size(220, 45);
            this.btnStoreInfo.TabIndex = 6;
            this.btnStoreInfo.TabStop = false;
            this.btnStoreInfo.Text = "Store Info";
            this.btnStoreInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStoreInfo.UseTransparentBackground = true;
            this.btnStoreInfo.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Animated = true;
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSettings.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSettings.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.FillColor = System.Drawing.Color.White;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSettings.Image = global::Supermarket.Properties.Resources.settings;
            this.btnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.IndicateFocus = true;
            this.btnSettings.Location = new System.Drawing.Point(0, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(260, 45);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.TabStop = false;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.UseTransparentBackground = true;
            this.btnSettings.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Animated = true;
            this.btnUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnUsers.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnUsers.Checked = true;
            this.btnUsers.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUsers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnUsers.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUsers.FillColor = System.Drawing.Color.White;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.Color.Black;
            this.btnUsers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnUsers.Image = global::Supermarket.Properties.Resources.users;
            this.btnUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.IndicateFocus = true;
            this.btnUsers.Location = new System.Drawing.Point(40, 102);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(220, 45);
            this.btnUsers.TabIndex = 9;
            this.btnUsers.TabStop = false;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.UseTransparentBackground = true;
            this.btnUsers.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Animated = true;
            this.btnEmployees.BackColor = System.Drawing.Color.Transparent;
            this.btnEmployees.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnEmployees.Checked = true;
            this.btnEmployees.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnEmployees.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployees.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnEmployees.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnEmployees.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEmployees.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEmployees.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEmployees.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEmployees.FillColor = System.Drawing.Color.White;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnEmployees.ForeColor = System.Drawing.Color.Black;
            this.btnEmployees.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnEmployees.Image = global::Supermarket.Properties.Resources.employees;
            this.btnEmployees.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEmployees.IndicateFocus = true;
            this.btnEmployees.Location = new System.Drawing.Point(40, 51);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(220, 45);
            this.btnEmployees.TabIndex = 7;
            this.btnEmployees.TabStop = false;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEmployees.UseTransparentBackground = true;
            this.btnEmployees.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.Controls.Add(this.btnLogout);
            this.panel5.Location = new System.Drawing.Point(5, 613);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(257, 45);
            this.panel5.TabIndex = 11;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Animated = true;
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BorderRadius = 5;
            this.btnLogout.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnLogout.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLogout.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnLogout.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.LightCoral;
            this.btnLogout.FocusedColor = System.Drawing.Color.Silver;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.RosyBrown;
            this.btnLogout.Image = global::Supermarket.Properties.Resources.log_out;
            this.btnLogout.IndicateFocus = true;
            this.btnLogout.Location = new System.Drawing.Point(0, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 45);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.TabStop = false;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseTransparentBackground = true;
            // 
            // ProductsTimer
            // 
            this.ProductsTimer.Interval = 25;
            this.ProductsTimer.Tick += new System.EventHandler(this.ProductsTimer_Tick);
            // 
            // PurchasingSuppliersTimer
            // 
            this.PurchasingSuppliersTimer.Interval = 25;
            this.PurchasingSuppliersTimer.Tick += new System.EventHandler(this.PurchasingSuppliersTimer_Tick);
            // 
            // ReportsTimer
            // 
            this.ReportsTimer.Interval = 25;
            this.ReportsTimer.Tick += new System.EventHandler(this.ReportsTimer_Tick);
            // 
            // SettingsTimer
            // 
            this.SettingsTimer.Interval = 25;
            this.SettingsTimer.Tick += new System.EventHandler(this.SettingsTimer_Tick);
            // 
            // FramMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 715);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FramMain";
            this.Text = "Supermarket Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FramMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMenuAll.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlSalesContainer.ResumeLayout(false);
            this.pnlProductsContainer.ResumeLayout(false);
            this.pnlInventoryContainer.ResumeLayout(false);
            this.pnlPurchasingSuppliersContainer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlReportsContainer.ResumeLayout(false);
            this.pnlSettingsContainer.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer inventoryTimer;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private System.Windows.Forms.Timer MenuTimer;
        private System.Windows.Forms.Timer PointOfSalesTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private System.Windows.Forms.Panel pnlInventoryContainer;
        private Guna.UI2.WinForms.Guna2Button btnStock;
        private Guna.UI2.WinForms.Guna2Button btnInventory;
        private Guna.UI2.WinForms.Guna2Button btnStockAdjustment;
        private System.Windows.Forms.Panel pnlSalesContainer;
        private Guna.UI2.WinForms.Guna2Button btnCashier;
        private Guna.UI2.WinForms.Guna2Button btnPointOfSales;
        private Guna.UI2.WinForms.Guna2Button btnSale;
        private System.Windows.Forms.Panel pnlProductsContainer;
        private Guna.UI2.WinForms.Guna2Button btnCategories;
        private Guna.UI2.WinForms.Guna2Button btnProducts;
        private Guna.UI2.WinForms.Guna2Button btnProductsList;
        private System.Windows.Forms.Timer ProductsTimer;
        private System.Windows.Forms.Panel pnlPurchasingSuppliersContainer;
        private Guna.UI2.WinForms.Guna2Button btnPurchasing;
        private Guna.UI2.WinForms.Guna2Button btnPurchasingSuppliers;
        private Guna.UI2.WinForms.Guna2Button btnSuppliers;
        private Guna.UI2.WinForms.Guna2Button btnGoodsReceive;
        private System.Windows.Forms.Timer PurchasingSuppliersTimer;
        private System.Windows.Forms.Panel pnlReportsContainer;
        private Guna.UI2.WinForms.Guna2Button btnProfitLoss;
        private Guna.UI2.WinForms.Guna2Button btnInventoryReport;
        private Guna.UI2.WinForms.Guna2Button btnReports;
        private Guna.UI2.WinForms.Guna2Button btnSalesReport;
        private System.Windows.Forms.Panel pnlSettingsContainer;
        private Guna.UI2.WinForms.Guna2Button btnUsers;
        private Guna.UI2.WinForms.Guna2Button btnStoreInfo;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnEmployees;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2Button btnCustomers;
        private System.Windows.Forms.Timer ReportsTimer;
        private Guna.UI2.WinForms.Guna2Button btnGeneralSetting;
        private System.Windows.Forms.Timer SettingsTimer;
        private System.Windows.Forms.FlowLayoutPanel pnlMenuAll;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private System.Windows.Forms.Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2Button btnSalesHistory;
        private Guna.UI2.WinForms.Guna2Button btnUnits;
    }
}

