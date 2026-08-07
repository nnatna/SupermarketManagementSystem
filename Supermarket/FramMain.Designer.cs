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
            this.inventoryTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuTimer = new System.Windows.Forms.Timer(this.components);
            this.salesTimer = new System.Windows.Forms.Timer(this.components);
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.pnlInventoryContainer = new System.Windows.Forms.Panel();
            this.btnStoct = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnImport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSalesContainer = new System.Windows.Forms.Panel();
            this.btnPayment = new Guna.UI2.WinForms.Guna2Button();
            this.btnSales = new Guna.UI2.WinForms.Guna2Button();
            this.btnSale = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlInventoryContainer.SuspendLayout();
            this.pnlSalesContainer.SuspendLayout();
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
            // salesTimer
            // 
            this.salesTimer.Interval = 25;
            this.salesTimer.Tick += new System.EventHandler(this.salesTimer_Tick);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1163, 585);
            this.panel3.TabIndex = 3;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.AllowDrop = true;
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.panel2);
            this.pnlSidebar.Controls.Add(this.pnlInventoryContainer);
            this.pnlSidebar.Controls.Add(this.pnlSalesContainer);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 54);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 585);
            this.pnlSidebar.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 45);
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
            this.btnDashboard.Size = new System.Drawing.Size(200, 45);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.TabStop = false;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.UseTransparentBackground = true;
            this.btnDashboard.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlInventoryContainer
            // 
            this.pnlInventoryContainer.Controls.Add(this.btnStoct);
            this.pnlInventoryContainer.Controls.Add(this.btnInventory);
            this.pnlInventoryContainer.Controls.Add(this.btnImport);
            this.pnlInventoryContainer.Location = new System.Drawing.Point(3, 54);
            this.pnlInventoryContainer.Name = "pnlInventoryContainer";
            this.pnlInventoryContainer.Size = new System.Drawing.Size(200, 45);
            this.pnlInventoryContainer.TabIndex = 5;
            // 
            // btnStoct
            // 
            this.btnStoct.Animated = true;
            this.btnStoct.BackColor = System.Drawing.Color.Transparent;
            this.btnStoct.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnStoct.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnStoct.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStoct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStoct.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnStoct.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnStoct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStoct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStoct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStoct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStoct.FillColor = System.Drawing.Color.White;
            this.btnStoct.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnStoct.ForeColor = System.Drawing.Color.Black;
            this.btnStoct.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnStoct.Image = global::Supermarket.Properties.Resources.stock2;
            this.btnStoct.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStoct.IndicateFocus = true;
            this.btnStoct.Location = new System.Drawing.Point(40, 102);
            this.btnStoct.Name = "btnStoct";
            this.btnStoct.Size = new System.Drawing.Size(160, 45);
            this.btnStoct.TabIndex = 6;
            this.btnStoct.TabStop = false;
            this.btnStoct.Text = "Stock";
            this.btnStoct.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStoct.UseTransparentBackground = true;
            this.btnStoct.Click += new System.EventHandler(this.NavigationButton_Click);
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
            this.btnInventory.Size = new System.Drawing.Size(200, 45);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.TabStop = false;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventory.UseTransparentBackground = true;
            this.btnInventory.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnImport
            // 
            this.btnImport.Animated = true;
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnImport.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnImport.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnImport.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnImport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImport.FillColor = System.Drawing.Color.White;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnImport.Image = global::Supermarket.Properties.Resources.import1;
            this.btnImport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnImport.IndicateFocus = true;
            this.btnImport.Location = new System.Drawing.Point(40, 51);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(160, 45);
            this.btnImport.TabIndex = 7;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnImport.UseTransparentBackground = true;
            this.btnImport.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // pnlSalesContainer
            // 
            this.pnlSalesContainer.Controls.Add(this.btnPayment);
            this.pnlSalesContainer.Controls.Add(this.btnSales);
            this.pnlSalesContainer.Controls.Add(this.btnSale);
            this.pnlSalesContainer.Location = new System.Drawing.Point(3, 105);
            this.pnlSalesContainer.Name = "pnlSalesContainer";
            this.pnlSalesContainer.Size = new System.Drawing.Size(200, 45);
            this.pnlSalesContainer.TabIndex = 6;
            // 
            // btnPayment
            // 
            this.btnPayment.Animated = true;
            this.btnPayment.BackColor = System.Drawing.Color.Transparent;
            this.btnPayment.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnPayment.Checked = true;
            this.btnPayment.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnPayment.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnPayment.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayment.FillColor = System.Drawing.Color.White;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPayment.ForeColor = System.Drawing.Color.Black;
            this.btnPayment.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPayment.Image = global::Supermarket.Properties.Resources.payment;
            this.btnPayment.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPayment.IndicateFocus = true;
            this.btnPayment.Location = new System.Drawing.Point(40, 102);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(160, 45);
            this.btnPayment.TabIndex = 6;
            this.btnPayment.TabStop = false;
            this.btnPayment.Text = "Payment";
            this.btnPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPayment.UseTransparentBackground = true;
            this.btnPayment.CheckedChanged += new System.EventHandler(this.NavigationButton_Click);
            // 
            // btnSales
            // 
            this.btnSales.Animated = true;
            this.btnSales.BackColor = System.Drawing.Color.Transparent;
            this.btnSales.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSales.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSales.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSales.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSales.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSales.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSales.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSales.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSales.FillColor = System.Drawing.Color.White;
            this.btnSales.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSales.ForeColor = System.Drawing.Color.Black;
            this.btnSales.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSales.Image = global::Supermarket.Properties.Resources.sales;
            this.btnSales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSales.IndicateFocus = true;
            this.btnSales.Location = new System.Drawing.Point(0, 0);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(200, 45);
            this.btnSales.TabIndex = 3;
            this.btnSales.TabStop = false;
            this.btnSales.Text = "Sales";
            this.btnSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSales.UseTransparentBackground = true;
            this.btnSales.Click += new System.EventHandler(this.NavigationButton_Click);
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
            this.btnSale.Size = new System.Drawing.Size(160, 45);
            this.btnSale.TabIndex = 7;
            this.btnSale.TabStop = false;
            this.btnSale.Text = "Sale";
            this.btnSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSale.UseTransparentBackground = true;
            this.btnSale.Click += new System.EventHandler(this.NavigationButton_Click);
            // 
            // FramMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 639);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FramMain";
            this.Text = "Supermarket Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FramMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlInventoryContainer.ResumeLayout(false);
            this.pnlSalesContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer inventoryTimer;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private System.Windows.Forms.Timer MenuTimer;
        private System.Windows.Forms.Timer salesTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel pnlSidebar;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private System.Windows.Forms.Panel pnlInventoryContainer;
        private Guna.UI2.WinForms.Guna2Button btnStoct;
        private Guna.UI2.WinForms.Guna2Button btnInventory;
        private Guna.UI2.WinForms.Guna2Button btnImport;
        private System.Windows.Forms.Panel pnlSalesContainer;
        private Guna.UI2.WinForms.Guna2Button btnPayment;
        private Guna.UI2.WinForms.Guna2Button btnSales;
        private Guna.UI2.WinForms.Guna2Button btnSale;
    }
}

