namespace Supermarket.UI.Report
{
    partial class frminventoryReport
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
            this.dgvInventory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMargin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCardsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.cardTotalSkus = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalSkusTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalSkusVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardTotalQty = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalQtyTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalQtyVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardCostVal = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCostValTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCostValVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardRetailVal = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRetailValTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRetailValVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbStockStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrintReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.pnlCardsContainer.SuspendLayout();
            this.cardTotalSkus.SuspendLayout();
            this.cardTotalQty.SuspendLayout();
            this.cardCostVal.SuspendLayout();
            this.cardRetailVal.SuspendLayout();
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
            this.pnlGrid.Controls.Add(this.dgvInventory);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.FillColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(18, 199);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGrid.Size = new System.Drawing.Size(1224, 531);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventory.ColumnHeadersHeight = 38;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcode,
            this.colName,
            this.colCat,
            this.colCost,
            this.colPrice,
            this.colQty,
            this.colTotalCost,
            this.colTotalValue,
            this.colMargin,
            this.colStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvInventory.Location = new System.Drawing.Point(12, 12);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowTemplate.Height = 38;
            this.dgvInventory.Size = new System.Drawing.Size(1200, 507);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvInventory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvInventory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvInventory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvInventory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvInventory.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvInventory.ThemeStyle.ReadOnly = true;
            this.dgvInventory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvInventory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvInventory.ThemeStyle.RowsStyle.Height = 38;
            this.dgvInventory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dgvInventory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvInventory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInventory_CellFormatting);
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.FillWeight = 85F;
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ProductName";
            this.colName.FillWeight = 130F;
            this.colName.HeaderText = "Product Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCat
            // 
            this.colCat.DataPropertyName = "CategoryName";
            this.colCat.FillWeight = 90F;
            this.colCat.HeaderText = "Category";
            this.colCat.Name = "colCat";
            this.colCat.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "CostPrice";
            this.colCost.FillWeight = 65F;
            this.colCost.HeaderText = "Cost Price";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "SellingPrice";
            this.colPrice.FillWeight = 65F;
            this.colPrice.HeaderText = "Sell Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "StockQuantity";
            this.colQty.FillWeight = 55F;
            this.colQty.HeaderText = "Stock Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colTotalCost
            // 
            this.colTotalCost.DataPropertyName = "TotalCost";
            this.colTotalCost.FillWeight = 75F;
            this.colTotalCost.HeaderText = "Total Cost";
            this.colTotalCost.Name = "colTotalCost";
            this.colTotalCost.ReadOnly = true;
            // 
            // colTotalValue
            // 
            this.colTotalValue.DataPropertyName = "TotalValue";
            this.colTotalValue.FillWeight = 75F;
            this.colTotalValue.HeaderText = "Total Value";
            this.colTotalValue.Name = "colTotalValue";
            this.colTotalValue.ReadOnly = true;
            // 
            // colMargin
            // 
            this.colMargin.DataPropertyName = "Margin";
            this.colMargin.FillWeight = 60F;
            this.colMargin.HeaderText = "Margin %";
            this.colMargin.Name = "colMargin";
            this.colMargin.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.FillWeight = 75F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // pnlCardsContainer
            // 
            this.pnlCardsContainer.ColumnCount = 4;
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCardsContainer.Controls.Add(this.cardTotalSkus, 0, 0);
            this.pnlCardsContainer.Controls.Add(this.cardTotalQty, 1, 0);
            this.pnlCardsContainer.Controls.Add(this.cardCostVal, 2, 0);
            this.pnlCardsContainer.Controls.Add(this.cardRetailVal, 3, 0);
            this.pnlCardsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardsContainer.Location = new System.Drawing.Point(18, 99);
            this.pnlCardsContainer.Name = "pnlCardsContainer";
            this.pnlCardsContainer.RowCount = 1;
            this.pnlCardsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCardsContainer.Size = new System.Drawing.Size(1224, 100);
            this.pnlCardsContainer.TabIndex = 1;
            // 
            // cardTotalSkus
            // 
            this.cardTotalSkus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardTotalSkus.BorderRadius = 10;
            this.cardTotalSkus.BorderThickness = 1;
            this.cardTotalSkus.Controls.Add(this.lblTotalSkusTitle);
            this.cardTotalSkus.Controls.Add(this.lblTotalSkusVal);
            this.cardTotalSkus.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.cardTotalSkus.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardTotalSkus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalSkus.FillColor = System.Drawing.Color.White;
            this.cardTotalSkus.Location = new System.Drawing.Point(3, 3);
            this.cardTotalSkus.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardTotalSkus.Name = "cardTotalSkus";
            this.cardTotalSkus.Padding = new System.Windows.Forms.Padding(14);
            this.cardTotalSkus.Size = new System.Drawing.Size(295, 94);
            this.cardTotalSkus.TabIndex = 0;
            // 
            // lblTotalSkusTitle
            // 
            this.lblTotalSkusTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSkusTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalSkusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalSkusTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTotalSkusTitle.Name = "lblTotalSkusTitle";
            this.lblTotalSkusTitle.Size = new System.Drawing.Size(78, 17);
            this.lblTotalSkusTitle.TabIndex = 0;
            this.lblTotalSkusTitle.Text = "TOTAL ITEMS";
            // 
            // lblTotalSkusVal
            // 
            this.lblTotalSkusVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSkusVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalSkusVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTotalSkusVal.Location = new System.Drawing.Point(14, 36);
            this.lblTotalSkusVal.Name = "lblTotalSkusVal";
            this.lblTotalSkusVal.Size = new System.Drawing.Size(71, 32);
            this.lblTotalSkusVal.TabIndex = 1;
            this.lblTotalSkusVal.Text = "0 SKUs";
            // 
            // cardTotalQty
            // 
            this.cardTotalQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardTotalQty.BorderRadius = 10;
            this.cardTotalQty.BorderThickness = 1;
            this.cardTotalQty.Controls.Add(this.lblTotalQtyTitle);
            this.cardTotalQty.Controls.Add(this.lblTotalQtyVal);
            this.cardTotalQty.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.cardTotalQty.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardTotalQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalQty.FillColor = System.Drawing.Color.White;
            this.cardTotalQty.Location = new System.Drawing.Point(309, 3);
            this.cardTotalQty.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardTotalQty.Name = "cardTotalQty";
            this.cardTotalQty.Padding = new System.Windows.Forms.Padding(14);
            this.cardTotalQty.Size = new System.Drawing.Size(295, 94);
            this.cardTotalQty.TabIndex = 1;
            // 
            // lblTotalQtyTitle
            // 
            this.lblTotalQtyTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalQtyTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalQtyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalQtyTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTotalQtyTitle.Name = "lblTotalQtyTitle";
            this.lblTotalQtyTitle.Size = new System.Drawing.Size(104, 17);
            this.lblTotalQtyTitle.TabIndex = 0;
            this.lblTotalQtyTitle.Text = "TOTAL UNITS QTY";
            // 
            // lblTotalQtyVal
            // 
            this.lblTotalQtyVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalQtyVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalQtyVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTotalQtyVal.Location = new System.Drawing.Point(14, 36);
            this.lblTotalQtyVal.Name = "lblTotalQtyVal";
            this.lblTotalQtyVal.Size = new System.Drawing.Size(72, 32);
            this.lblTotalQtyVal.TabIndex = 1;
            this.lblTotalQtyVal.Text = "0 Units";
            // 
            // cardCostVal
            // 
            this.cardCostVal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardCostVal.BorderRadius = 10;
            this.cardCostVal.BorderThickness = 1;
            this.cardCostVal.Controls.Add(this.lblCostValTitle);
            this.cardCostVal.Controls.Add(this.lblCostValVal);
            this.cardCostVal.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.cardCostVal.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardCostVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardCostVal.FillColor = System.Drawing.Color.White;
            this.cardCostVal.Location = new System.Drawing.Point(615, 3);
            this.cardCostVal.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardCostVal.Name = "cardCostVal";
            this.cardCostVal.Padding = new System.Windows.Forms.Padding(14);
            this.cardCostVal.Size = new System.Drawing.Size(295, 94);
            this.cardCostVal.TabIndex = 2;
            // 
            // lblCostValTitle
            // 
            this.lblCostValTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCostValTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCostValTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCostValTitle.Location = new System.Drawing.Point(14, 12);
            this.lblCostValTitle.Name = "lblCostValTitle";
            this.lblCostValTitle.Size = new System.Drawing.Size(112, 17);
            this.lblCostValTitle.TabIndex = 0;
            this.lblCostValTitle.Text = "TOTAL COST VALUE";
            // 
            // lblCostValVal
            // 
            this.lblCostValVal.BackColor = System.Drawing.Color.Transparent;
            this.lblCostValVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCostValVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblCostValVal.Location = new System.Drawing.Point(14, 36);
            this.lblCostValVal.Name = "lblCostValVal";
            this.lblCostValVal.Size = new System.Drawing.Size(57, 32);
            this.lblCostValVal.TabIndex = 1;
            this.lblCostValVal.Text = "$0.00";
            // 
            // cardRetailVal
            // 
            this.cardRetailVal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardRetailVal.BorderRadius = 10;
            this.cardRetailVal.BorderThickness = 1;
            this.cardRetailVal.Controls.Add(this.lblRetailValTitle);
            this.cardRetailVal.Controls.Add(this.lblRetailValVal);
            this.cardRetailVal.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.cardRetailVal.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardRetailVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardRetailVal.FillColor = System.Drawing.Color.White;
            this.cardRetailVal.Location = new System.Drawing.Point(921, 3);
            this.cardRetailVal.Name = "cardRetailVal";
            this.cardRetailVal.Padding = new System.Windows.Forms.Padding(14);
            this.cardRetailVal.Size = new System.Drawing.Size(300, 94);
            this.cardRetailVal.TabIndex = 3;
            // 
            // lblRetailValTitle
            // 
            this.lblRetailValTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRetailValTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblRetailValTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRetailValTitle.Location = new System.Drawing.Point(14, 12);
            this.lblRetailValTitle.Name = "lblRetailValTitle";
            this.lblRetailValTitle.Size = new System.Drawing.Size(120, 17);
            this.lblRetailValTitle.TabIndex = 0;
            this.lblRetailValTitle.Text = "TOTAL RETAIL VALUE";
            // 
            // lblRetailValVal
            // 
            this.lblRetailValVal.BackColor = System.Drawing.Color.Transparent;
            this.lblRetailValVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRetailValVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblRetailValVal.Location = new System.Drawing.Point(14, 36);
            this.lblRetailValVal.Name = "lblRetailValVal";
            this.lblRetailValVal.Size = new System.Drawing.Size(57, 32);
            this.lblRetailValVal.TabIndex = 1;
            this.lblRetailValVal.Text = "$0.00";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.cmbCategory);
            this.pnlHeader.Controls.Add(this.cmbStockStatus);
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
            this.lblTitle.Size = new System.Drawing.Size(283, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "INVENTORY STOCK REPORT";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(4, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(361, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Live product stock levels, inventory costs and asset valuations";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategory.BorderRadius = 8;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCategory.ItemHeight = 36;
            this.cmbCategory.Location = new System.Drawing.Point(566, 16);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(160, 42);
            this.cmbCategory.TabIndex = 2;
            // 
            // cmbStockStatus
            // 
            this.cmbStockStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStockStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStockStatus.BorderRadius = 8;
            this.cmbStockStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStockStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStockStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbStockStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStockStatus.ItemHeight = 36;
            this.cmbStockStatus.Items.AddRange(new object[] {
            "All",
            "Normal",
            "Low Stock",
            "Out of Stock"});
            this.cmbStockStatus.Location = new System.Drawing.Point(736, 16);
            this.cmbStockStatus.Name = "cmbStockStatus";
            this.cmbStockStatus.Size = new System.Drawing.Size(120, 42);
            this.cmbStockStatus.StartIndex = 0;
            this.cmbStockStatus.TabIndex = 3;
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
            this.btnFilter.Location = new System.Drawing.Point(866, 16);
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
            this.btnRefresh.Location = new System.Drawing.Point(964, 16);
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
            this.btnPrintReport.Location = new System.Drawing.Point(1066, 16);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(155, 42);
            this.btnPrintReport.TabIndex = 6;
            this.btnPrintReport.Text = "Print RDLC";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // frminventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frminventoryReport";
            this.Text = "Inventory Report";
            this.Load += new System.EventHandler(this.frminventoryReport_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.pnlCardsContainer.ResumeLayout(false);
            this.cardTotalSkus.ResumeLayout(false);
            this.cardTotalSkus.PerformLayout();
            this.cardTotalQty.ResumeLayout(false);
            this.cardTotalQty.PerformLayout();
            this.cardCostVal.ResumeLayout(false);
            this.cardCostVal.PerformLayout();
            this.cardRetailVal.ResumeLayout(false);
            this.cardRetailVal.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtitle;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStockStatus;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnPrintReport;

        private System.Windows.Forms.TableLayoutPanel pnlCardsContainer;
        private Guna.UI2.WinForms.Guna2Panel cardTotalSkus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalSkusTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalSkusVal;

        private Guna.UI2.WinForms.Guna2Panel cardTotalQty;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalQtyTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalQtyVal;

        private Guna.UI2.WinForms.Guna2Panel cardCostVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCostValTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCostValVal;

        private Guna.UI2.WinForms.Guna2Panel cardRetailVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRetailValTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRetailValVal;

        private Guna.UI2.WinForms.Guna2Panel pnlGrid;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMargin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}