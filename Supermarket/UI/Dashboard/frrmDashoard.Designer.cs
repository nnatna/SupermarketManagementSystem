namespace Supermarket.UI.Dashboard
{
    partial class frrmDashoard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLastUpdated = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            
            // Cards
            this.pnlCardsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.cardTodaySales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTodaySalesTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTodaySalesVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTodayOrdersSub = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIcon1 = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.cardMonthSales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMonthSalesTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMonthSalesVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMonthOrdersSub = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIcon2 = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.cardProducts = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProductsTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProductsVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblInventoryValSub = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIcon3 = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.cardStockAlert = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStockAlertTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStockAlertVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblOutOfStockSub = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIcon4 = new Guna.UI2.WinForms.Guna2HtmlLabel();

            // Charts container
            this.pnlChartsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChart1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChart1Title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chartSalesTrend = new Guna.Charts.WinForms.GunaChart();

            this.pnlChart2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChart2Title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chartCategories = new Guna.Charts.WinForms.GunaChart();

            // Tables container
            this.pnlGridsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGridSales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGridSalesTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvRecentSales = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colInv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlGridStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGridStockTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvStockAlerts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlCardsContainer.SuspendLayout();
            this.cardTodaySales.SuspendLayout();
            this.cardMonthSales.SuspendLayout();
            this.cardProducts.SuspendLayout();
            this.cardStockAlert.SuspendLayout();
            this.pnlChartsContainer.SuspendLayout();
            this.pnlChart1.SuspendLayout();
            this.pnlChart2.SuspendLayout();
            this.pnlGridsContainer.SuspendLayout();
            this.pnlGridSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentSales)).BeginInit();
            this.pnlGridStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockAlerts)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.pnlGridsContainer);
            this.pnlMain.Controls.Add(this.pnlChartsContainer);
            this.pnlMain.Controls.Add(this.pnlCardsContainer);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(18, 14, 18, 20);
            this.pnlMain.Size = new System.Drawing.Size(1260, 750);
            this.pnlMain.TabIndex = 0;

            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblLastUpdated);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(18, 14);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1224, 62);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(2, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DASHBOARD OVERVIEW";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(4, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(342, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Real-time supermarket metrics, sales analysis, and stock levels";

            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.BackColor = System.Drawing.Color.Transparent;
            this.lblLastUpdated.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLastUpdated.Location = new System.Drawing.Point(920, 18);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(148, 19);
            this.lblLastUpdated.TabIndex = 2;
            this.lblLastUpdated.Text = "Last updated: Just now";
            this.lblLastUpdated.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Animated = true;
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnRefresh.Location = new System.Drawing.Point(1090, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 42);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // pnlCardsContainer
            // 
            this.pnlCardsContainer.ColumnCount = 4;
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.Controls.Add(this.cardTodaySales, 0, 0);
            this.pnlCardsContainer.Controls.Add(this.cardMonthSales, 1, 0);
            this.pnlCardsContainer.Controls.Add(this.cardProducts, 2, 0);
            this.pnlCardsContainer.Controls.Add(this.cardStockAlert, 3, 0);
            this.pnlCardsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardsContainer.Location = new System.Drawing.Point(18, 76);
            this.pnlCardsContainer.Name = "pnlCardsContainer";
            this.pnlCardsContainer.RowCount = 1;
            this.pnlCardsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCardsContainer.Size = new System.Drawing.Size(1224, 120);
            this.pnlCardsContainer.TabIndex = 1;

            // 
            // cardTodaySales
            // 
            this.cardTodaySales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardTodaySales.BorderRadius = 12;
            this.cardTodaySales.BorderThickness = 1;
            this.cardTodaySales.Controls.Add(this.lblIcon1);
            this.cardTodaySales.Controls.Add(this.lblTodaySalesTitle);
            this.cardTodaySales.Controls.Add(this.lblTodaySalesVal);
            this.cardTodaySales.Controls.Add(this.lblTodayOrdersSub);
            this.cardTodaySales.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.cardTodaySales.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardTodaySales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTodaySales.FillColor = System.Drawing.Color.White;
            this.cardTodaySales.Location = new System.Drawing.Point(3, 3);
            this.cardTodaySales.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardTodaySales.Name = "cardTodaySales";
            this.cardTodaySales.Padding = new System.Windows.Forms.Padding(14);
            this.cardTodaySales.Size = new System.Drawing.Size(295, 114);
            this.cardTodaySales.TabIndex = 0;

            this.lblTodaySalesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTodaySalesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTodaySalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTodaySalesTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTodaySalesTitle.Name = "lblTodaySalesTitle";
            this.lblTodaySalesTitle.Size = new System.Drawing.Size(91, 19);
            this.lblTodaySalesTitle.TabIndex = 0;
            this.lblTodaySalesTitle.Text = "TODAY SALES";

            this.lblTodaySalesVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTodaySalesVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTodaySalesVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTodaySalesVal.Location = new System.Drawing.Point(16, 36);
            this.lblTodaySalesVal.Name = "lblTodaySalesVal";
            this.lblTodaySalesVal.Size = new System.Drawing.Size(73, 34);
            this.lblTodaySalesVal.TabIndex = 1;
            this.lblTodaySalesVal.Text = "$0.00";

            this.lblTodayOrdersSub.BackColor = System.Drawing.Color.Transparent;
            this.lblTodayOrdersSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTodayOrdersSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblTodayOrdersSub.Location = new System.Drawing.Point(16, 78);
            this.lblTodayOrdersSub.Name = "lblTodayOrdersSub";
            this.lblTodayOrdersSub.Size = new System.Drawing.Size(112, 17);
            this.lblTodayOrdersSub.TabIndex = 2;
            this.lblTodayOrdersSub.Text = "0 orders completed";

            this.lblIcon1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIcon1.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblIcon1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.lblIcon1.Location = new System.Drawing.Point(245, 8);
            this.lblIcon1.Name = "lblIcon1";
            this.lblIcon1.Size = new System.Drawing.Size(20, 47);
            this.lblIcon1.TabIndex = 3;
            this.lblIcon1.Text = "$";

            // 
            // cardMonthSales
            // 
            this.cardMonthSales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardMonthSales.BorderRadius = 12;
            this.cardMonthSales.BorderThickness = 1;
            this.cardMonthSales.Controls.Add(this.lblIcon2);
            this.cardMonthSales.Controls.Add(this.lblMonthSalesTitle);
            this.cardMonthSales.Controls.Add(this.lblMonthSalesVal);
            this.cardMonthSales.Controls.Add(this.lblMonthOrdersSub);
            this.cardMonthSales.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.cardMonthSales.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardMonthSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMonthSales.FillColor = System.Drawing.Color.White;
            this.cardMonthSales.Location = new System.Drawing.Point(309, 3);
            this.cardMonthSales.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardMonthSales.Name = "cardMonthSales";
            this.cardMonthSales.Padding = new System.Windows.Forms.Padding(14);
            this.cardMonthSales.Size = new System.Drawing.Size(295, 114);
            this.cardMonthSales.TabIndex = 1;

            this.lblMonthSalesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthSalesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMonthSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMonthSalesTitle.Location = new System.Drawing.Point(16, 12);
            this.lblMonthSalesTitle.Name = "lblMonthSalesTitle";
            this.lblMonthSalesTitle.Size = new System.Drawing.Size(130, 19);
            this.lblMonthSalesTitle.TabIndex = 0;
            this.lblMonthSalesTitle.Text = "THIS MONTH SALES";

            this.lblMonthSalesVal.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthSalesVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMonthSalesVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblMonthSalesVal.Location = new System.Drawing.Point(16, 36);
            this.lblMonthSalesVal.Name = "lblMonthSalesVal";
            this.lblMonthSalesVal.Size = new System.Drawing.Size(73, 34);
            this.lblMonthSalesVal.TabIndex = 1;
            this.lblMonthSalesVal.Text = "$0.00";

            this.lblMonthOrdersSub.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthOrdersSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonthOrdersSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblMonthOrdersSub.Location = new System.Drawing.Point(16, 78);
            this.lblMonthOrdersSub.Name = "lblMonthOrdersSub";
            this.lblMonthOrdersSub.Size = new System.Drawing.Size(117, 17);
            this.lblMonthOrdersSub.TabIndex = 2;
            this.lblMonthOrdersSub.Text = "0 orders this month";

            this.lblIcon2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIcon2.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblIcon2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(250)))), ((int)(((byte)(229)))));
            this.lblIcon2.Location = new System.Drawing.Point(245, 8);
            this.lblIcon2.Name = "lblIcon2";
            this.lblIcon2.Size = new System.Drawing.Size(26, 47);
            this.lblIcon2.TabIndex = 3;
            this.lblIcon2.Text = "%";

            // 
            // cardProducts
            // 
            this.cardProducts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardProducts.BorderRadius = 12;
            this.cardProducts.BorderThickness = 1;
            this.cardProducts.Controls.Add(this.lblIcon3);
            this.cardProducts.Controls.Add(this.lblProductsTitle);
            this.cardProducts.Controls.Add(this.lblProductsVal);
            this.cardProducts.Controls.Add(this.lblInventoryValSub);
            this.cardProducts.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.cardProducts.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardProducts.FillColor = System.Drawing.Color.White;
            this.cardProducts.Location = new System.Drawing.Point(615, 3);
            this.cardProducts.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardProducts.Name = "cardProducts";
            this.cardProducts.Padding = new System.Windows.Forms.Padding(14);
            this.cardProducts.Size = new System.Drawing.Size(295, 114);
            this.cardProducts.TabIndex = 2;

            this.lblProductsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblProductsTitle.Location = new System.Drawing.Point(16, 12);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Size = new System.Drawing.Size(121, 19);
            this.lblProductsTitle.TabIndex = 0;
            this.lblProductsTitle.Text = "TOTAL PRODUCTS";

            this.lblProductsVal.BackColor = System.Drawing.Color.Transparent;
            this.lblProductsVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblProductsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblProductsVal.Location = new System.Drawing.Point(16, 36);
            this.lblProductsVal.Name = "lblProductsVal";
            this.lblProductsVal.Size = new System.Drawing.Size(65, 34);
            this.lblProductsVal.TabIndex = 1;
            this.lblProductsVal.Text = "0 Items";

            this.lblInventoryValSub.BackColor = System.Drawing.Color.Transparent;
            this.lblInventoryValSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInventoryValSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblInventoryValSub.Location = new System.Drawing.Point(16, 78);
            this.lblInventoryValSub.Name = "lblInventoryValSub";
            this.lblInventoryValSub.Size = new System.Drawing.Size(126, 17);
            this.lblInventoryValSub.TabIndex = 2;
            this.lblInventoryValSub.Text = "Inventory Value: $0.00";

            this.lblIcon3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIcon3.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblIcon3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblIcon3.Location = new System.Drawing.Point(245, 8);
            this.lblIcon3.Name = "lblIcon3";
            this.lblIcon3.Size = new System.Drawing.Size(24, 47);
            this.lblIcon3.TabIndex = 3;
            this.lblIcon3.Text = "#";

            // 
            // cardStockAlert
            // 
            this.cardStockAlert.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardStockAlert.BorderRadius = 12;
            this.cardStockAlert.BorderThickness = 1;
            this.cardStockAlert.Controls.Add(this.lblIcon4);
            this.cardStockAlert.Controls.Add(this.lblStockAlertTitle);
            this.cardStockAlert.Controls.Add(this.lblStockAlertVal);
            this.cardStockAlert.Controls.Add(this.lblOutOfStockSub);
            this.cardStockAlert.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cardStockAlert.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardStockAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardStockAlert.FillColor = System.Drawing.Color.White;
            this.cardStockAlert.Location = new System.Drawing.Point(921, 3);
            this.cardStockAlert.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.cardStockAlert.Name = "cardStockAlert";
            this.cardStockAlert.Padding = new System.Windows.Forms.Padding(14);
            this.cardStockAlert.Size = new System.Drawing.Size(300, 114);
            this.cardStockAlert.TabIndex = 3;

            this.lblStockAlertTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStockAlertTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStockAlertTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStockAlertTitle.Location = new System.Drawing.Point(16, 12);
            this.lblStockAlertTitle.Name = "lblStockAlertTitle";
            this.lblStockAlertTitle.Size = new System.Drawing.Size(95, 19);
            this.lblStockAlertTitle.TabIndex = 0;
            this.lblStockAlertTitle.Text = "STOCK ALERTS";

            this.lblStockAlertVal.BackColor = System.Drawing.Color.Transparent;
            this.lblStockAlertVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockAlertVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblStockAlertVal.Location = new System.Drawing.Point(16, 36);
            this.lblStockAlertVal.Name = "lblStockAlertVal";
            this.lblStockAlertVal.Size = new System.Drawing.Size(78, 34);
            this.lblStockAlertVal.TabIndex = 1;
            this.lblStockAlertVal.Text = "0 Low";

            this.lblOutOfStockSub.BackColor = System.Drawing.Color.Transparent;
            this.lblOutOfStockSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOutOfStockSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblOutOfStockSub.Location = new System.Drawing.Point(16, 78);
            this.lblOutOfStockSub.Name = "lblOutOfStockSub";
            this.lblOutOfStockSub.Size = new System.Drawing.Size(97, 17);
            this.lblOutOfStockSub.TabIndex = 2;
            this.lblOutOfStockSub.Text = "0 Out of stock";

            this.lblIcon4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIcon4.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblIcon4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lblIcon4.Location = new System.Drawing.Point(250, 8);
            this.lblIcon4.Name = "lblIcon4";
            this.lblIcon4.Size = new System.Drawing.Size(15, 47);
            this.lblIcon4.TabIndex = 3;
            this.lblIcon4.Text = "!";

            // 
            // pnlChartsContainer
            // 
            this.pnlChartsContainer.ColumnCount = 2;
            this.pnlChartsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.pnlChartsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.pnlChartsContainer.Controls.Add(this.pnlChart1, 0, 0);
            this.pnlChartsContainer.Controls.Add(this.pnlChart2, 1, 0);
            this.pnlChartsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChartsContainer.Location = new System.Drawing.Point(18, 206);
            this.pnlChartsContainer.Name = "pnlChartsContainer";
            this.pnlChartsContainer.RowCount = 1;
            this.pnlChartsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlChartsContainer.Size = new System.Drawing.Size(1224, 300);
            this.pnlChartsContainer.TabIndex = 2;

            // 
            // pnlChart1
            // 
            this.pnlChart1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlChart1.BorderRadius = 12;
            this.pnlChart1.BorderThickness = 1;
            this.pnlChart1.Controls.Add(this.chartSalesTrend);
            this.pnlChart1.Controls.Add(this.lblChart1Title);
            this.pnlChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart1.FillColor = System.Drawing.Color.White;
            this.pnlChart1.Location = new System.Drawing.Point(3, 10);
            this.pnlChart1.Margin = new System.Windows.Forms.Padding(3, 10, 8, 3);
            this.pnlChart1.Name = "pnlChart1";
            this.pnlChart1.Padding = new System.Windows.Forms.Padding(12);
            this.pnlChart1.Size = new System.Drawing.Size(723, 287);
            this.pnlChart1.TabIndex = 0;

            this.lblChart1Title.BackColor = System.Drawing.Color.Transparent;
            this.lblChart1Title.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblChart1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChart1Title.Location = new System.Drawing.Point(16, 12);
            this.lblChart1Title.Name = "lblChart1Title";
            this.lblChart1Title.Size = new System.Drawing.Size(193, 23);
            this.lblChart1Title.TabIndex = 0;
            this.lblChart1Title.Text = "Sales Trend (Last 7 Days)";

            this.chartSalesTrend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartSalesTrend.Location = new System.Drawing.Point(12, 40);
            this.chartSalesTrend.Name = "chartSalesTrend";
            this.chartSalesTrend.Size = new System.Drawing.Size(699, 235);
            this.chartSalesTrend.TabIndex = 1;

            // 
            // pnlChart2
            // 
            this.pnlChart2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlChart2.BorderRadius = 12;
            this.pnlChart2.BorderThickness = 1;
            this.pnlChart2.Controls.Add(this.chartCategories);
            this.pnlChart2.Controls.Add(this.lblChart2Title);
            this.pnlChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart2.FillColor = System.Drawing.Color.White;
            this.pnlChart2.Location = new System.Drawing.Point(737, 10);
            this.pnlChart2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlChart2.Name = "pnlChart2";
            this.pnlChart2.Padding = new System.Windows.Forms.Padding(12);
            this.pnlChart2.Size = new System.Drawing.Size(484, 287);
            this.pnlChart2.TabIndex = 1;

            this.lblChart2Title.BackColor = System.Drawing.Color.Transparent;
            this.lblChart2Title.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblChart2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChart2Title.Location = new System.Drawing.Point(16, 12);
            this.lblChart2Title.Name = "lblChart2Title";
            this.lblChart2Title.Size = new System.Drawing.Size(199, 23);
            this.lblChart2Title.TabIndex = 0;
            this.lblChart2Title.Text = "Product Categories Share";

            this.chartCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartCategories.Location = new System.Drawing.Point(12, 40);
            this.chartCategories.Name = "chartCategories";
            this.chartCategories.Size = new System.Drawing.Size(460, 235);
            this.chartCategories.TabIndex = 1;

            // 
            // pnlGridsContainer
            // 
            this.pnlGridsContainer.ColumnCount = 2;
            this.pnlGridsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.pnlGridsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlGridsContainer.Controls.Add(this.pnlGridSales, 0, 0);
            this.pnlGridsContainer.Controls.Add(this.pnlGridStock, 1, 0);
            this.pnlGridsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridsContainer.Location = new System.Drawing.Point(18, 516);
            this.pnlGridsContainer.Name = "pnlGridsContainer";
            this.pnlGridsContainer.RowCount = 1;
            this.pnlGridsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlGridsContainer.Size = new System.Drawing.Size(1224, 340);
            this.pnlGridsContainer.TabIndex = 3;

            // 
            // pnlGridSales
            // 
            this.pnlGridSales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlGridSales.BorderRadius = 12;
            this.pnlGridSales.BorderThickness = 1;
            this.pnlGridSales.Controls.Add(this.dgvRecentSales);
            this.pnlGridSales.Controls.Add(this.lblGridSalesTitle);
            this.pnlGridSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridSales.FillColor = System.Drawing.Color.White;
            this.pnlGridSales.Location = new System.Drawing.Point(3, 10);
            this.pnlGridSales.Margin = new System.Windows.Forms.Padding(3, 10, 8, 3);
            this.pnlGridSales.Name = "pnlGridSales";
            this.pnlGridSales.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGridSales.Size = new System.Drawing.Size(662, 327);
            this.pnlGridSales.TabIndex = 0;

            this.lblGridSalesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGridSalesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblGridSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGridSalesTitle.Location = new System.Drawing.Point(16, 12);
            this.lblGridSalesTitle.Name = "lblGridSalesTitle";
            this.lblGridSalesTitle.Size = new System.Drawing.Size(155, 23);
            this.lblGridSalesTitle.TabIndex = 0;
            this.lblGridSalesTitle.Text = "Recent Transactions";

            // 
            // dgvRecentSales
            // 
            this.dgvRecentSales.AllowUserToAddRows = false;
            this.dgvRecentSales.AllowUserToDeleteRows = false;
            this.dgvRecentSales.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvRecentSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecentSales.ColumnHeadersHeight = 36;
            this.dgvRecentSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInv,
            this.colCust,
            this.colDate,
            this.colAmt,
            this.colMethod,
            this.colStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentSales.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecentSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvRecentSales.Location = new System.Drawing.Point(12, 42);
            this.dgvRecentSales.Name = "dgvRecentSales";
            this.dgvRecentSales.ReadOnly = true;
            this.dgvRecentSales.RowHeadersVisible = false;
            this.dgvRecentSales.RowTemplate.Height = 36;
            this.dgvRecentSales.Size = new System.Drawing.Size(638, 273);
            this.dgvRecentSales.TabIndex = 1;
            this.dgvRecentSales.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvRecentSales.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentSales.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvRecentSales.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvRecentSales.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentSales.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvRecentSales.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvRecentSales.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvRecentSales.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentSales.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentSales.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvRecentSales.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvRecentSales.ThemeStyle.RowsStyle.Height = 36;
            this.dgvRecentSales.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dgvRecentSales.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvRecentSales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRecentSales_CellFormatting);

            this.colInv.DataPropertyName = "InvoiceNumber";
            this.colInv.FillWeight = 110F;
            this.colInv.HeaderText = "Invoice #";
            this.colInv.Name = "colInv";
            this.colInv.ReadOnly = true;

            this.colCust.DataPropertyName = "CustomerName";
            this.colCust.FillWeight = 110F;
            this.colCust.HeaderText = "Customer";
            this.colCust.Name = "colCust";
            this.colCust.ReadOnly = true;

            this.colDate.DataPropertyName = "SaleDate";
            this.colDate.FillWeight = 90F;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;

            this.colAmt.DataPropertyName = "Amount";
            this.colAmt.FillWeight = 75F;
            this.colAmt.HeaderText = "Total";
            this.colAmt.Name = "colAmt";
            this.colAmt.ReadOnly = true;

            this.colMethod.DataPropertyName = "PaymentMethod";
            this.colMethod.FillWeight = 70F;
            this.colMethod.HeaderText = "Method";
            this.colMethod.Name = "colMethod";
            this.colMethod.ReadOnly = true;

            this.colStatus.DataPropertyName = "Status";
            this.colStatus.FillWeight = 75F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;

            // 
            // pnlGridStock
            // 
            this.pnlGridStock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlGridStock.BorderRadius = 12;
            this.pnlGridStock.BorderThickness = 1;
            this.pnlGridStock.Controls.Add(this.dgvStockAlerts);
            this.pnlGridStock.Controls.Add(this.lblGridStockTitle);
            this.pnlGridStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridStock.FillColor = System.Drawing.Color.White;
            this.pnlGridStock.Location = new System.Drawing.Point(676, 10);
            this.pnlGridStock.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlGridStock.Name = "pnlGridStock";
            this.pnlGridStock.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGridStock.Size = new System.Drawing.Size(545, 327);
            this.pnlGridStock.TabIndex = 1;

            this.lblGridStockTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGridStockTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblGridStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGridStockTitle.Location = new System.Drawing.Point(16, 12);
            this.lblGridStockTitle.Name = "lblGridStockTitle";
            this.lblGridStockTitle.Size = new System.Drawing.Size(165, 23);
            this.lblGridStockTitle.TabIndex = 0;
            this.lblGridStockTitle.Text = "Low Stock Alert Items";

            // 
            // dgvStockAlerts
            // 
            this.dgvStockAlerts.AllowUserToAddRows = false;
            this.dgvStockAlerts.AllowUserToDeleteRows = false;
            this.dgvStockAlerts.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvStockAlerts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStockAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStockAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockAlerts.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStockAlerts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStockAlerts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockAlerts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStockAlerts.ColumnHeadersHeight = 36;
            this.dgvStockAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProd,
            this.colCat,
            this.colStock,
            this.colAlert,
            this.colStockStatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockAlerts.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStockAlerts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvStockAlerts.Location = new System.Drawing.Point(12, 42);
            this.dgvStockAlerts.Name = "dgvStockAlerts";
            this.dgvStockAlerts.ReadOnly = true;
            this.dgvStockAlerts.RowHeadersVisible = false;
            this.dgvStockAlerts.RowTemplate.Height = 36;
            this.dgvStockAlerts.Size = new System.Drawing.Size(521, 273);
            this.dgvStockAlerts.TabIndex = 1;
            this.dgvStockAlerts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvStockAlerts.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockAlerts.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvStockAlerts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvStockAlerts.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStockAlerts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvStockAlerts.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvStockAlerts.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvStockAlerts.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockAlerts.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStockAlerts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvStockAlerts.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvStockAlerts.ThemeStyle.RowsStyle.Height = 36;
            this.dgvStockAlerts.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dgvStockAlerts.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvStockAlerts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStockAlerts_CellFormatting);

            this.colProd.DataPropertyName = "ProductName";
            this.colProd.FillWeight = 120F;
            this.colProd.HeaderText = "Product Name";
            this.colProd.Name = "colProd";
            this.colProd.ReadOnly = true;

            this.colCat.DataPropertyName = "CategoryName";
            this.colCat.FillWeight = 90F;
            this.colCat.HeaderText = "Category";
            this.colCat.Name = "colCat";
            this.colCat.ReadOnly = true;

            this.colStock.DataPropertyName = "CurrentStock";
            this.colStock.FillWeight = 60F;
            this.colStock.HeaderText = "In Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;

            this.colAlert.DataPropertyName = "AlertLevel";
            this.colAlert.FillWeight = 60F;
            this.colAlert.HeaderText = "Alert Qty";
            this.colAlert.Name = "colAlert";
            this.colAlert.ReadOnly = true;

            this.colStockStatus.DataPropertyName = "Status";
            this.colStockStatus.FillWeight = 75F;
            this.colStockStatus.HeaderText = "Status";
            this.colStockStatus.Name = "colStockStatus";
            this.colStockStatus.ReadOnly = true;

            // 
            // frrmDashoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frrmDashoard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frrmDashoard_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCardsContainer.ResumeLayout(false);
            this.cardTodaySales.ResumeLayout(false);
            this.cardTodaySales.PerformLayout();
            this.cardMonthSales.ResumeLayout(false);
            this.cardMonthSales.PerformLayout();
            this.cardProducts.ResumeLayout(false);
            this.cardProducts.PerformLayout();
            this.cardStockAlert.ResumeLayout(false);
            this.cardStockAlert.PerformLayout();
            this.pnlChartsContainer.ResumeLayout(false);
            this.pnlChart1.ResumeLayout(false);
            this.pnlChart1.PerformLayout();
            this.pnlChart2.ResumeLayout(false);
            this.pnlChart2.PerformLayout();
            this.pnlGridsContainer.ResumeLayout(false);
            this.pnlGridSales.ResumeLayout(false);
            this.pnlGridSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentSales)).EndInit();
            this.pnlGridStock.ResumeLayout(false);
            this.pnlGridStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockAlerts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLastUpdated;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;

        private System.Windows.Forms.TableLayoutPanel pnlCardsContainer;
        private Guna.UI2.WinForms.Guna2Panel cardTodaySales;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTodaySalesTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTodaySalesVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTodayOrdersSub;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIcon1;

        private Guna.UI2.WinForms.Guna2Panel cardMonthSales;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMonthSalesTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMonthSalesVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMonthOrdersSub;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIcon2;

        private Guna.UI2.WinForms.Guna2Panel cardProducts;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProductsTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProductsVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblInventoryValSub;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIcon3;

        private Guna.UI2.WinForms.Guna2Panel cardStockAlert;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStockAlertTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStockAlertVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOutOfStockSub;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIcon4;

        private System.Windows.Forms.TableLayoutPanel pnlChartsContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlChart1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChart1Title;
        private Guna.Charts.WinForms.GunaChart chartSalesTrend;

        private Guna.UI2.WinForms.Guna2Panel pnlChart2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChart2Title;
        private Guna.Charts.WinForms.GunaChart chartCategories;

        private System.Windows.Forms.TableLayoutPanel pnlGridsContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlGridSales;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGridSalesTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRecentSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;

        private Guna.UI2.WinForms.Guna2Panel pnlGridStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGridStockTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStockAlerts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockStatus;
    }
}