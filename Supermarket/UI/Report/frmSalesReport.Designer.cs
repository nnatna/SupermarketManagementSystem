namespace Supermarket.UI.Report
{
    partial class frmSalesReport
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
            this.dgvSales = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colInv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCardsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.cardGross = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGrossTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGrossVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardDiscount = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDiscountTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDiscountVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardNetSales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNetTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNetVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardInvoices = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInvoicesTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblInvoicesVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrintReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.pnlCardsContainer.SuspendLayout();
            this.cardGross.SuspendLayout();
            this.cardDiscount.SuspendLayout();
            this.cardNetSales.SuspendLayout();
            this.cardInvoices.SuspendLayout();
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
            this.pnlGrid.Controls.Add(this.dgvSales);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.FillColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(18, 199);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGrid.Size = new System.Drawing.Size(1224, 531);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSales.ColumnHeadersHeight = 38;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInv,
            this.colCust,
            this.colDate,
            this.colItems,
            this.colSubtotal,
            this.colDiscount,
            this.colGrandTotal,
            this.colMethod,
            this.colStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSales.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSales.Location = new System.Drawing.Point(12, 12);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowTemplate.Height = 38;
            this.dgvSales.Size = new System.Drawing.Size(1200, 507);
            this.dgvSales.TabIndex = 0;
            this.dgvSales.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvSales.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSales.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSales.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvSales.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvSales.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvSales.ThemeStyle.ReadOnly = true;
            this.dgvSales.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvSales.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvSales.ThemeStyle.RowsStyle.Height = 38;
            this.dgvSales.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dgvSales.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvSales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSales_CellFormatting);
            // 
            // colInv
            // 
            this.colInv.DataPropertyName = "InvoiceNumber";
            this.colInv.FillWeight = 115F;
            this.colInv.HeaderText = "Invoice #";
            this.colInv.Name = "colInv";
            this.colInv.ReadOnly = true;
            // 
            // colCust
            // 
            this.colCust.DataPropertyName = "CustomerName";
            this.colCust.FillWeight = 110F;
            this.colCust.HeaderText = "Customer";
            this.colCust.Name = "colCust";
            this.colCust.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "SaleDate";
            this.colDate.FillWeight = 95F;
            this.colDate.HeaderText = "Sale Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colItems
            // 
            this.colItems.DataPropertyName = "TotalItems";
            this.colItems.FillWeight = 55F;
            this.colItems.HeaderText = "Items";
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            // 
            // colSubtotal
            // 
            this.colSubtotal.DataPropertyName = "Subtotal";
            this.colSubtotal.FillWeight = 75F;
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            // 
            // colDiscount
            // 
            this.colDiscount.DataPropertyName = "Discount";
            this.colDiscount.FillWeight = 70F;
            this.colDiscount.HeaderText = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.ReadOnly = true;
            // 
            // colGrandTotal
            // 
            this.colGrandTotal.DataPropertyName = "GrandTotal";
            this.colGrandTotal.FillWeight = 80F;
            this.colGrandTotal.HeaderText = "Grand Total";
            this.colGrandTotal.Name = "colGrandTotal";
            this.colGrandTotal.ReadOnly = true;
            // 
            // colMethod
            // 
            this.colMethod.DataPropertyName = "PaymentMethod";
            this.colMethod.FillWeight = 70F;
            this.colMethod.HeaderText = "Payment";
            this.colMethod.Name = "colMethod";
            this.colMethod.ReadOnly = true;
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
            this.pnlCardsContainer.Controls.Add(this.cardGross, 0, 0);
            this.pnlCardsContainer.Controls.Add(this.cardDiscount, 1, 0);
            this.pnlCardsContainer.Controls.Add(this.cardNetSales, 2, 0);
            this.pnlCardsContainer.Controls.Add(this.cardInvoices, 3, 0);
            this.pnlCardsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardsContainer.Location = new System.Drawing.Point(18, 99);
            this.pnlCardsContainer.Name = "pnlCardsContainer";
            this.pnlCardsContainer.RowCount = 1;
            this.pnlCardsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCardsContainer.Size = new System.Drawing.Size(1224, 100);
            this.pnlCardsContainer.TabIndex = 1;
            // 
            // cardGross
            // 
            this.cardGross.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardGross.BorderRadius = 10;
            this.cardGross.BorderThickness = 1;
            this.cardGross.Controls.Add(this.lblGrossTitle);
            this.cardGross.Controls.Add(this.lblGrossVal);
            this.cardGross.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.cardGross.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardGross.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardGross.FillColor = System.Drawing.Color.White;
            this.cardGross.Location = new System.Drawing.Point(3, 3);
            this.cardGross.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardGross.Name = "cardGross";
            this.cardGross.Padding = new System.Windows.Forms.Padding(14);
            this.cardGross.Size = new System.Drawing.Size(295, 94);
            this.cardGross.TabIndex = 0;
            // 
            // lblGrossTitle
            // 
            this.lblGrossTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGrossTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblGrossTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGrossTitle.Location = new System.Drawing.Point(14, 12);
            this.lblGrossTitle.Name = "lblGrossTitle";
            this.lblGrossTitle.Size = new System.Drawing.Size(78, 17);
            this.lblGrossTitle.TabIndex = 0;
            this.lblGrossTitle.Text = "GROSS SALES";
            // 
            // lblGrossVal
            // 
            this.lblGrossVal.BackColor = System.Drawing.Color.Transparent;
            this.lblGrossVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblGrossVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGrossVal.Location = new System.Drawing.Point(14, 36);
            this.lblGrossVal.Name = "lblGrossVal";
            this.lblGrossVal.Size = new System.Drawing.Size(57, 32);
            this.lblGrossVal.TabIndex = 1;
            this.lblGrossVal.Text = "$0.00";
            // 
            // cardDiscount
            // 
            this.cardDiscount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardDiscount.BorderRadius = 10;
            this.cardDiscount.BorderThickness = 1;
            this.cardDiscount.Controls.Add(this.lblDiscountTitle);
            this.cardDiscount.Controls.Add(this.lblDiscountVal);
            this.cardDiscount.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cardDiscount.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDiscount.FillColor = System.Drawing.Color.White;
            this.cardDiscount.Location = new System.Drawing.Point(309, 3);
            this.cardDiscount.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardDiscount.Name = "cardDiscount";
            this.cardDiscount.Padding = new System.Windows.Forms.Padding(14);
            this.cardDiscount.Size = new System.Drawing.Size(295, 94);
            this.cardDiscount.TabIndex = 1;
            // 
            // lblDiscountTitle
            // 
            this.lblDiscountTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDiscountTitle.Location = new System.Drawing.Point(14, 12);
            this.lblDiscountTitle.Name = "lblDiscountTitle";
            this.lblDiscountTitle.Size = new System.Drawing.Size(110, 17);
            this.lblDiscountTitle.TabIndex = 0;
            this.lblDiscountTitle.Text = "TOTAL DISCOUNTS";
            // 
            // lblDiscountVal
            // 
            this.lblDiscountVal.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDiscountVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblDiscountVal.Location = new System.Drawing.Point(14, 36);
            this.lblDiscountVal.Name = "lblDiscountVal";
            this.lblDiscountVal.Size = new System.Drawing.Size(57, 32);
            this.lblDiscountVal.TabIndex = 1;
            this.lblDiscountVal.Text = "$0.00";
            // 
            // cardNetSales
            // 
            this.cardNetSales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardNetSales.BorderRadius = 10;
            this.cardNetSales.BorderThickness = 1;
            this.cardNetSales.Controls.Add(this.lblNetTitle);
            this.cardNetSales.Controls.Add(this.lblNetVal);
            this.cardNetSales.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.cardNetSales.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardNetSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardNetSales.FillColor = System.Drawing.Color.White;
            this.cardNetSales.Location = new System.Drawing.Point(615, 3);
            this.cardNetSales.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardNetSales.Name = "cardNetSales";
            this.cardNetSales.Padding = new System.Windows.Forms.Padding(14);
            this.cardNetSales.Size = new System.Drawing.Size(295, 94);
            this.cardNetSales.TabIndex = 2;
            // 
            // lblNetTitle
            // 
            this.lblNetTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNetTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNetTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNetTitle.Location = new System.Drawing.Point(14, 12);
            this.lblNetTitle.Name = "lblNetTitle";
            this.lblNetTitle.Size = new System.Drawing.Size(78, 17);
            this.lblNetTitle.TabIndex = 0;
            this.lblNetTitle.Text = "NET REVENUE";
            // 
            // lblNetVal
            // 
            this.lblNetVal.BackColor = System.Drawing.Color.Transparent;
            this.lblNetVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblNetVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblNetVal.Location = new System.Drawing.Point(14, 36);
            this.lblNetVal.Name = "lblNetVal";
            this.lblNetVal.Size = new System.Drawing.Size(57, 32);
            this.lblNetVal.TabIndex = 1;
            this.lblNetVal.Text = "$0.00";
            // 
            // cardInvoices
            // 
            this.cardInvoices.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardInvoices.BorderRadius = 10;
            this.cardInvoices.BorderThickness = 1;
            this.cardInvoices.Controls.Add(this.lblInvoicesTitle);
            this.cardInvoices.Controls.Add(this.lblInvoicesVal);
            this.cardInvoices.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.cardInvoices.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cardInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardInvoices.FillColor = System.Drawing.Color.White;
            this.cardInvoices.Location = new System.Drawing.Point(921, 3);
            this.cardInvoices.Name = "cardInvoices";
            this.cardInvoices.Padding = new System.Windows.Forms.Padding(14);
            this.cardInvoices.Size = new System.Drawing.Size(300, 94);
            this.cardInvoices.TabIndex = 3;
            // 
            // lblInvoicesTitle
            // 
            this.lblInvoicesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoicesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoicesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInvoicesTitle.Location = new System.Drawing.Point(14, 12);
            this.lblInvoicesTitle.Name = "lblInvoicesTitle";
            this.lblInvoicesTitle.Size = new System.Drawing.Size(132, 17);
            this.lblInvoicesTitle.TabIndex = 0;
            this.lblInvoicesTitle.Text = "TOTAL TRANSACTIONS";
            // 
            // lblInvoicesVal
            // 
            this.lblInvoicesVal.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoicesVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblInvoicesVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblInvoicesVal.Location = new System.Drawing.Point(14, 36);
            this.lblInvoicesVal.Name = "lblInvoicesVal";
            this.lblInvoicesVal.Size = new System.Drawing.Size(61, 32);
            this.lblInvoicesVal.TabIndex = 1;
            this.lblInvoicesVal.Text = "0 Bills";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.dtpStartDate);
            this.pnlHeader.Controls.Add(this.dtpEndDate);
            this.pnlHeader.Controls.Add(this.cmbPaymentMethod);
            this.pnlHeader.Controls.Add(this.cmbStatus);
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
            this.lblTitle.Size = new System.Drawing.Size(273, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SALES REPORT & REVENUE";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(4, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(287, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Filter by date range, payment method and status";
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
            this.dtpStartDate.Location = new System.Drawing.Point(367, 16);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 42);
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
            this.dtpEndDate.Location = new System.Drawing.Point(492, 16);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 42);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.Value = new System.DateTime(2026, 8, 25, 0, 0, 0, 0);
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cmbPaymentMethod.BorderRadius = 8;
            this.cmbPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPaymentMethod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPaymentMethod.ItemHeight = 36;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "All Methods",
            "Cash",
            "Credit Card",
            "KHQR"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(617, 16);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(130, 42);
            this.cmbPaymentMethod.StartIndex = 0;
            this.cmbPaymentMethod.TabIndex = 4;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 8;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 36;
            this.cmbStatus.Items.AddRange(new object[] {
            "All Status",
            "Completed",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(752, 16);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(115, 42);
            this.cmbStatus.StartIndex = 0;
            this.cmbStatus.TabIndex = 5;
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
            this.btnFilter.Location = new System.Drawing.Point(872, 16);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 42);
            this.btnFilter.TabIndex = 6;
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
            this.btnRefresh.Location = new System.Drawing.Point(967, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 42);
            this.btnRefresh.TabIndex = 7;
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
            this.btnPrintReport.TabIndex = 8;
            this.btnPrintReport.Text = "Print RDLC";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalesReport";
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.pnlCardsContainer.ResumeLayout(false);
            this.cardGross.ResumeLayout(false);
            this.cardGross.PerformLayout();
            this.cardDiscount.ResumeLayout(false);
            this.cardDiscount.PerformLayout();
            this.cardNetSales.ResumeLayout(false);
            this.cardNetSales.PerformLayout();
            this.cardInvoices.ResumeLayout(false);
            this.cardInvoices.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2ComboBox cmbPaymentMethod;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnPrintReport;

        private System.Windows.Forms.TableLayoutPanel pnlCardsContainer;
        private Guna.UI2.WinForms.Guna2Panel cardGross;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGrossTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGrossVal;

        private Guna.UI2.WinForms.Guna2Panel cardDiscount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiscountTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiscountVal;

        private Guna.UI2.WinForms.Guna2Panel cardNetSales;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNetTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNetVal;

        private Guna.UI2.WinForms.Guna2Panel cardInvoices;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblInvoicesTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblInvoicesVal;

        private Guna.UI2.WinForms.Guna2Panel pnlGrid;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrandTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}