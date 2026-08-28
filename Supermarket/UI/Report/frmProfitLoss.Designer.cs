namespace Supermarket.UI.Report
{
    partial class frmProfitLoss
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvProfitLoss = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtySold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrossProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarginPct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCardsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.cardRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRevenueTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRevenueVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardCogs = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCogsTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCogsVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardProfit = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProfitTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProfitVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardMargin = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMarginTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMarginVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrintReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitLoss)).BeginInit();
            this.pnlCardsContainer.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardCogs.SuspendLayout();
            this.cardProfit.SuspendLayout();
            this.cardMargin.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlCardsContainer);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(18, 14, 18, 20);
            this.pnlMain.Size = new System.Drawing.Size(1260, 750);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlGrid.BorderRadius = 12;
            this.pnlGrid.BorderThickness = 1;
            this.pnlGrid.Controls.Add(this.dgvProfitLoss);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.FillColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(18, 199);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGrid.Size = new System.Drawing.Size(1224, 531);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvProfitLoss
            // 
            this.dgvProfitLoss.AllowUserToAddRows = false;
            this.dgvProfitLoss.AllowUserToDeleteRows = false;
            this.dgvProfitLoss.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvProfitLoss.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfitLoss.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProfitLoss.ColumnHeadersHeight = 38;
            this.dgvProfitLoss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvProfitLoss.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProdName,
            this.colCatName,
            this.colQtySold,
            this.colRev,
            this.colCost,
            this.colGrossProfit,
            this.colMarginPct});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProfitLoss.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProfitLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProfitLoss.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvProfitLoss.Location = new System.Drawing.Point(12, 12);
            this.dgvProfitLoss.Name = "dgvProfitLoss";
            this.dgvProfitLoss.ReadOnly = true;
            this.dgvProfitLoss.RowHeadersVisible = false;
            this.dgvProfitLoss.RowTemplate.Height = 38;
            this.dgvProfitLoss.Size = new System.Drawing.Size(1200, 507);
            this.dgvProfitLoss.TabIndex = 0;
            this.dgvProfitLoss.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvProfitLoss.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvProfitLoss.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvProfitLoss.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvProfitLoss.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvProfitLoss.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvProfitLoss.ThemeStyle.ReadOnly = true;
            this.dgvProfitLoss.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvProfitLoss.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvProfitLoss.ThemeStyle.RowsStyle.Height = 38;
            this.dgvProfitLoss.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dgvProfitLoss.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvProfitLoss.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProfitLoss_CellFormatting);
            // 
            // colProdName
            // 
            this.colProdName.DataPropertyName = "ProductName";
            this.colProdName.FillWeight = 140F;
            this.colProdName.HeaderText = "Product Name";
            this.colProdName.Name = "colProdName";
            this.colProdName.ReadOnly = true;
            // 
            // colCatName
            // 
            this.colCatName.DataPropertyName = "CategoryName";
            this.colCatName.FillWeight = 95F;
            this.colCatName.HeaderText = "Category";
            this.colCatName.Name = "colCatName";
            this.colCatName.ReadOnly = true;
            // 
            // colQtySold
            // 
            this.colQtySold.DataPropertyName = "QuantitySold";
            this.colQtySold.FillWeight = 60F;
            this.colQtySold.HeaderText = "Units Sold";
            this.colQtySold.Name = "colQtySold";
            this.colQtySold.ReadOnly = true;
            // 
            // colRev
            // 
            this.colRev.DataPropertyName = "TotalRevenue";
            this.colRev.FillWeight = 85F;
            this.colRev.HeaderText = "Total Revenue";
            this.colRev.Name = "colRev";
            this.colRev.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "TotalCost";
            this.colCost.FillWeight = 80F;
            this.colCost.HeaderText = "Total COGS";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colGrossProfit
            // 
            this.colGrossProfit.DataPropertyName = "GrossProfit";
            this.colGrossProfit.FillWeight = 85F;
            this.colGrossProfit.HeaderText = "Gross Profit";
            this.colGrossProfit.Name = "colGrossProfit";
            this.colGrossProfit.ReadOnly = true;
            // 
            // colMarginPct
            // 
            this.colMarginPct.DataPropertyName = "MarginPercent";
            this.colMarginPct.FillWeight = 65F;
            this.colMarginPct.HeaderText = "Margin %";
            this.colMarginPct.Name = "colMarginPct";
            this.colMarginPct.ReadOnly = true;
            // 
            // pnlCardsContainer
            // 
            this.pnlCardsContainer.ColumnCount = 4;
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.Controls.Add(this.cardRevenue, 0, 0);
            this.pnlCardsContainer.Controls.Add(this.cardCogs, 1, 0);
            this.pnlCardsContainer.Controls.Add(this.cardProfit, 2, 0);
            this.pnlCardsContainer.Controls.Add(this.cardMargin, 3, 0);
            this.pnlCardsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardsContainer.Location = new System.Drawing.Point(18, 99);
            this.pnlCardsContainer.Name = "pnlCardsContainer";
            this.pnlCardsContainer.RowCount = 1;
            this.pnlCardsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCardsContainer.Size = new System.Drawing.Size(1224, 100);
            this.pnlCardsContainer.TabIndex = 1;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardRevenue.BorderRadius = 10;
            this.cardRevenue.BorderThickness = 1;
            this.cardRevenue.Controls.Add(this.lblRevenueTitle);
            this.cardRevenue.Controls.Add(this.lblRevenueVal);
            this.cardRevenue.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.cardRevenue.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardRevenue.FillColor = System.Drawing.Color.White;
            this.cardRevenue.Location = new System.Drawing.Point(3, 3);
            this.cardRevenue.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Padding = new System.Windows.Forms.Padding(14);
            this.cardRevenue.Size = new System.Drawing.Size(295, 94);
            this.cardRevenue.TabIndex = 0;
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRevenueTitle.Location = new System.Drawing.Point(14, 12);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(93, 17);
            this.lblRevenueTitle.TabIndex = 0;
            this.lblRevenueTitle.Text = "TOTAL REVENUE";
            // 
            // lblRevenueVal
            // 
            this.lblRevenueVal.BackColor = System.Drawing.Color.Transparent;
            this.lblRevenueVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRevenueVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblRevenueVal.Location = new System.Drawing.Point(14, 36);
            this.lblRevenueVal.Name = "lblRevenueVal";
            this.lblRevenueVal.Size = new System.Drawing.Size(57, 32);
            this.lblRevenueVal.TabIndex = 1;
            this.lblRevenueVal.Text = "$0.00";
            // 
            // cardCogs
            // 
            this.cardCogs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardCogs.BorderRadius = 10;
            this.cardCogs.BorderThickness = 1;
            this.cardCogs.Controls.Add(this.lblCogsTitle);
            this.cardCogs.Controls.Add(this.lblCogsVal);
            this.cardCogs.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cardCogs.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardCogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardCogs.FillColor = System.Drawing.Color.White;
            this.cardCogs.Location = new System.Drawing.Point(309, 3);
            this.cardCogs.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardCogs.Name = "cardCogs";
            this.cardCogs.Padding = new System.Windows.Forms.Padding(14);
            this.cardCogs.Size = new System.Drawing.Size(295, 94);
            this.cardCogs.TabIndex = 1;
            // 
            // lblCogsTitle
            // 
            this.lblCogsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCogsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCogsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCogsTitle.Location = new System.Drawing.Point(14, 12);
            this.lblCogsTitle.Name = "lblCogsTitle";
            this.lblCogsTitle.Size = new System.Drawing.Size(138, 17);
            this.lblCogsTitle.TabIndex = 0;
            this.lblCogsTitle.Text = "COST OF GOODS (COGS)";
            // 
            // lblCogsVal
            // 
            this.lblCogsVal.BackColor = System.Drawing.Color.Transparent;
            this.lblCogsVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCogsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblCogsVal.Location = new System.Drawing.Point(14, 36);
            this.lblCogsVal.Name = "lblCogsVal";
            this.lblCogsVal.Size = new System.Drawing.Size(57, 32);
            this.lblCogsVal.TabIndex = 1;
            this.lblCogsVal.Text = "$0.00";
            // 
            // cardProfit
            // 
            this.cardProfit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardProfit.BorderRadius = 10;
            this.cardProfit.BorderThickness = 1;
            this.cardProfit.Controls.Add(this.lblProfitTitle);
            this.cardProfit.Controls.Add(this.lblProfitVal);
            this.cardProfit.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.cardProfit.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardProfit.FillColor = System.Drawing.Color.White;
            this.cardProfit.Location = new System.Drawing.Point(615, 3);
            this.cardProfit.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardProfit.Name = "cardProfit";
            this.cardProfit.Padding = new System.Windows.Forms.Padding(14);
            this.cardProfit.Size = new System.Drawing.Size(295, 94);
            this.cardProfit.TabIndex = 2;
            // 
            // lblProfitTitle
            // 
            this.lblProfitTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblProfitTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfitTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblProfitTitle.Location = new System.Drawing.Point(14, 12);
            this.lblProfitTitle.Name = "lblProfitTitle";
            this.lblProfitTitle.Size = new System.Drawing.Size(84, 17);
            this.lblProfitTitle.TabIndex = 0;
            this.lblProfitTitle.Text = "GROSS PROFIT";
            // 
            // lblProfitVal
            // 
            this.lblProfitVal.BackColor = System.Drawing.Color.Transparent;
            this.lblProfitVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblProfitVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblProfitVal.Location = new System.Drawing.Point(14, 36);
            this.lblProfitVal.Name = "lblProfitVal";
            this.lblProfitVal.Size = new System.Drawing.Size(57, 32);
            this.lblProfitVal.TabIndex = 1;
            this.lblProfitVal.Text = "$0.00";
            // 
            // cardMargin
            // 
            this.cardMargin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardMargin.BorderRadius = 10;
            this.cardMargin.BorderThickness = 1;
            this.cardMargin.Controls.Add(this.lblMarginTitle);
            this.cardMargin.Controls.Add(this.lblMarginVal);
            this.cardMargin.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.cardMargin.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMargin.FillColor = System.Drawing.Color.White;
            this.cardMargin.Location = new System.Drawing.Point(921, 3);
            this.cardMargin.Name = "cardMargin";
            this.cardMargin.Padding = new System.Windows.Forms.Padding(14);
            this.cardMargin.Size = new System.Drawing.Size(300, 94);
            this.cardMargin.TabIndex = 3;
            // 
            // lblMarginTitle
            // 
            this.lblMarginTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMarginTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarginTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMarginTitle.Location = new System.Drawing.Point(14, 12);
            this.lblMarginTitle.Name = "lblMarginTitle";
            this.lblMarginTitle.Size = new System.Drawing.Size(93, 17);
            this.lblMarginTitle.TabIndex = 0;
            this.lblMarginTitle.Text = "PROFIT MARGIN";
            // 
            // lblMarginVal
            // 
            this.lblMarginVal.BackColor = System.Drawing.Color.Transparent;
            this.lblMarginVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMarginVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.lblMarginVal.Location = new System.Drawing.Point(14, 36);
            this.lblMarginVal.Name = "lblMarginVal";
            this.lblMarginVal.Size = new System.Drawing.Size(51, 32);
            this.lblMarginVal.TabIndex = 1;
            this.lblMarginVal.Text = "0.0%";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.dtpStartDate);
            this.pnlHeader.Controls.Add(this.dtpEndDate);
            this.pnlHeader.Controls.Add(this.btnFilter);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnPrintReport);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(18, 14);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1224, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(2, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PROFIT & LOSS STATEMENT";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(4, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(369, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Comprehensive profit breakdown, revenue, COGS and margins";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.BorderRadius = 8;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(582, 16);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(130, 42);
            this.dtpStartDate.TabIndex = 2;
            this.dtpStartDate.Value = new System.DateTime(2026, 8, 1, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.BorderRadius = 8;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(722, 16);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(130, 42);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.Value = new System.DateTime(2026, 8, 25, 0, 0, 0, 0);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Animated = true;
            this.btnFilter.BorderRadius = 8;
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(862, 16);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 42);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Animated = true;
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnRefresh.Location = new System.Drawing.Point(962, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 42);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintReport.Animated = true;
            this.btnPrintReport.BorderRadius = 8;
            this.btnPrintReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPrintReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintReport.Location = new System.Drawing.Point(1067, 16);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(155, 42);
            this.btnPrintReport.TabIndex = 6;
            this.btnPrintReport.Text = "Print RDLC";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // frmProfitLoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProfitLoss";
            this.Text = "Profit & Loss";
            this.Load += new System.EventHandler(this.frmProfitLoss_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitLoss)).EndInit();
            this.pnlCardsContainer.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            this.cardRevenue.PerformLayout();
            this.cardCogs.ResumeLayout(false);
            this.cardCogs.PerformLayout();
            this.cardProfit.ResumeLayout(false);
            this.cardProfit.PerformLayout();
            this.cardMargin.ResumeLayout(false);
            this.cardMargin.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtitle;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnPrintReport;

        private System.Windows.Forms.TableLayoutPanel pnlCardsContainer;
        private Guna.UI2.WinForms.Guna2Panel cardRevenue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRevenueTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRevenueVal;

        private Guna.UI2.WinForms.Guna2Panel cardCogs;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCogsTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCogsVal;

        private Guna.UI2.WinForms.Guna2Panel cardProfit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProfitTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProfitVal;

        private Guna.UI2.WinForms.Guna2Panel cardMargin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMarginTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMarginVal;

        private Guna.UI2.WinForms.Guna2Panel pnlGrid;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProfitLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtySold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrossProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarginPct;
    }
}