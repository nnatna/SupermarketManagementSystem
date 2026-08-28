namespace Supermarket.UI.Point_of_sale
{
    partial class frmApplyDiscount
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.rbPromo = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbPercent = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbFixed = new Guna.UI2.WinForms.Guna2RadioButton();
            this.pnlPromo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPromoDetails = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbActivePromos = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCheckCode = new Guna.UI2.WinForms.Guna2Button();
            this.txtPromoCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlPercent = new Guna.UI2.WinForms.Guna2Panel();
            this.btnP50 = new Guna.UI2.WinForms.Guna2Button();
            this.btnP25 = new Guna.UI2.WinForms.Guna2Button();
            this.btnP20 = new Guna.UI2.WinForms.Guna2Button();
            this.btnP15 = new Guna.UI2.WinForms.Guna2Button();
            this.btnP10 = new Guna.UI2.WinForms.Guna2Button();
            this.btnP5 = new Guna.UI2.WinForms.Guna2Button();
            this.numPercent = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblPercentPrompt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlFixed = new Guna.UI2.WinForms.Guna2Panel();
            this.btnF20 = new Guna.UI2.WinForms.Guna2Button();
            this.btnF10 = new Guna.UI2.WinForms.Guna2Button();
            this.btnF5 = new Guna.UI2.WinForms.Guna2Button();
            this.btnF2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnF1 = new Guna.UI2.WinForms.Guna2Button();
            this.numFixed = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblFixedPrompt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGrandTotalVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGrandTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDiscountVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDiscount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtotalVal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlPromo.SuspendLayout();
            this.pnlPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).BeginInit();
            this.pnlFixed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFixed)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(262, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Discount per item, overall order, or by promo code";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(188, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Apply Order Discount";
            // 
            // rbPromo
            // 
            this.rbPromo.AutoSize = true;
            this.rbPromo.Checked = true;
            this.rbPromo.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rbPromo.CheckedState.BorderThickness = 0;
            this.rbPromo.CheckedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.rbPromo.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbPromo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbPromo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rbPromo.Location = new System.Drawing.Point(25, 85);
            this.rbPromo.Name = "rbPromo";
            this.rbPromo.Size = new System.Drawing.Size(99, 21);
            this.rbPromo.TabIndex = 1;
            this.rbPromo.TabStop = true;
            this.rbPromo.Text = "Promo Code";
            this.rbPromo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbPromo.UncheckedState.BorderThickness = 2;
            this.rbPromo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbPromo.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbPromo.CheckedChanged += new System.EventHandler(this.DiscountType_CheckedChanged);
            // 
            // rbPercent
            // 
            this.rbPercent.AutoSize = true;
            this.rbPercent.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rbPercent.CheckedState.BorderThickness = 0;
            this.rbPercent.CheckedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.rbPercent.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbPercent.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rbPercent.Location = new System.Drawing.Point(180, 85);
            this.rbPercent.Name = "rbPercent";
            this.rbPercent.Size = new System.Drawing.Size(124, 21);
            this.rbPercent.TabIndex = 2;
            this.rbPercent.Text = "Order % Discount";
            this.rbPercent.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbPercent.UncheckedState.BorderThickness = 2;
            this.rbPercent.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbPercent.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbPercent.CheckedChanged += new System.EventHandler(this.DiscountType_CheckedChanged);
            // 
            // rbFixed
            // 
            this.rbFixed.AutoSize = true;
            this.rbFixed.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rbFixed.CheckedState.BorderThickness = 0;
            this.rbFixed.CheckedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.rbFixed.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbFixed.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbFixed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rbFixed.Location = new System.Drawing.Point(360, 85);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Size = new System.Drawing.Size(121, 21);
            this.rbFixed.TabIndex = 3;
            this.rbFixed.Text = "Order $ Discount";
            this.rbFixed.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbFixed.UncheckedState.BorderThickness = 2;
            this.rbFixed.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbFixed.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbFixed.CheckedChanged += new System.EventHandler(this.DiscountType_CheckedChanged);
            // 
            // pnlPromo
            // 
            this.pnlPromo.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlPromo.BorderRadius = 8;
            this.pnlPromo.BorderThickness = 1;
            this.pnlPromo.Controls.Add(this.lblPromoDetails);
            this.pnlPromo.Controls.Add(this.cmbActivePromos);
            this.pnlPromo.Controls.Add(this.btnCheckCode);
            this.pnlPromo.Controls.Add(this.txtPromoCode);
            this.pnlPromo.FillColor = System.Drawing.Color.White;
            this.pnlPromo.Location = new System.Drawing.Point(20, 115);
            this.pnlPromo.Name = "pnlPromo";
            this.pnlPromo.Size = new System.Drawing.Size(520, 145);
            this.pnlPromo.TabIndex = 4;
            // 
            // lblPromoDetails
            // 
            this.lblPromoDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblPromoDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblPromoDetails.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPromoDetails.Location = new System.Drawing.Point(15, 110);
            this.lblPromoDetails.Name = "lblPromoDetails";
            this.lblPromoDetails.Size = new System.Drawing.Size(252, 17);
            this.lblPromoDetails.TabIndex = 3;
            this.lblPromoDetails.Text = "Enter promo code or choose from active promos";
            // 
            // cmbActivePromos
            // 
            this.cmbActivePromos.BackColor = System.Drawing.Color.Transparent;
            this.cmbActivePromos.BorderRadius = 6;
            this.cmbActivePromos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbActivePromos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivePromos.FocusedColor = System.Drawing.Color.DodgerBlue;
            this.cmbActivePromos.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbActivePromos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbActivePromos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbActivePromos.ItemHeight = 30;
            this.cmbActivePromos.Location = new System.Drawing.Point(15, 65);
            this.cmbActivePromos.Name = "cmbActivePromos";
            this.cmbActivePromos.Size = new System.Drawing.Size(490, 36);
            this.cmbActivePromos.TabIndex = 2;
            this.cmbActivePromos.SelectedIndexChanged += new System.EventHandler(this.cmbActivePromos_SelectedIndexChanged);
            // 
            // btnCheckCode
            // 
            this.btnCheckCode.Animated = true;
            this.btnCheckCode.BorderRadius = 6;
            this.btnCheckCode.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnCheckCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCheckCode.ForeColor = System.Drawing.Color.White;
            this.btnCheckCode.Location = new System.Drawing.Point(385, 15);
            this.btnCheckCode.Name = "btnCheckCode";
            this.btnCheckCode.Size = new System.Drawing.Size(120, 38);
            this.btnCheckCode.TabIndex = 1;
            this.btnCheckCode.Text = "Check Code";
            this.btnCheckCode.Click += new System.EventHandler(this.btnCheckCode_Click);
            // 
            // txtPromoCode
            // 
            this.txtPromoCode.BorderRadius = 6;
            this.txtPromoCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPromoCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPromoCode.DefaultText = "";
            this.txtPromoCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPromoCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPromoCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPromoCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPromoCode.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtPromoCode.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtPromoCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPromoCode.Location = new System.Drawing.Point(15, 15);
            this.txtPromoCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPromoCode.Name = "txtPromoCode";
            this.txtPromoCode.PasswordChar = '\0';
            this.txtPromoCode.PlaceholderText = "e.g. WELCOME10, SUMMERSALE";
            this.txtPromoCode.SelectedText = "";
            this.txtPromoCode.Size = new System.Drawing.Size(360, 38);
            this.txtPromoCode.TabIndex = 0;
            this.txtPromoCode.TextChanged += new System.EventHandler(this.txtPromoCode_TextChanged);
            // 
            // pnlPercent
            // 
            this.pnlPercent.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlPercent.BorderRadius = 8;
            this.pnlPercent.BorderThickness = 1;
            this.pnlPercent.Controls.Add(this.btnP50);
            this.pnlPercent.Controls.Add(this.btnP25);
            this.pnlPercent.Controls.Add(this.btnP20);
            this.pnlPercent.Controls.Add(this.btnP15);
            this.pnlPercent.Controls.Add(this.btnP10);
            this.pnlPercent.Controls.Add(this.btnP5);
            this.pnlPercent.Controls.Add(this.numPercent);
            this.pnlPercent.Controls.Add(this.lblPercentPrompt);
            this.pnlPercent.FillColor = System.Drawing.Color.White;
            this.pnlPercent.Location = new System.Drawing.Point(20, 115);
            this.pnlPercent.Name = "pnlPercent";
            this.pnlPercent.Size = new System.Drawing.Size(520, 145);
            this.pnlPercent.TabIndex = 5;
            this.pnlPercent.Visible = false;
            // 
            // btnP50
            // 
            this.btnP50.BorderRadius = 4;
            this.btnP50.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnP50.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnP50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnP50.Location = new System.Drawing.Point(430, 85);
            this.btnP50.Name = "btnP50";
            this.btnP50.Size = new System.Drawing.Size(75, 36);
            this.btnP50.TabIndex = 7;
            this.btnP50.Text = "50%";
            this.btnP50.Click += new System.EventHandler(this.QuickPercent_Click);
            // 
            // btnP25
            // 
            this.btnP25.BorderRadius = 4;
            this.btnP25.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnP25.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnP25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnP25.Location = new System.Drawing.Point(347, 85);
            this.btnP25.Name = "btnP25";
            this.btnP25.Size = new System.Drawing.Size(75, 36);
            this.btnP25.TabIndex = 6;
            this.btnP25.Text = "25%";
            this.btnP25.Click += new System.EventHandler(this.QuickPercent_Click);
            // 
            // btnP20
            // 
            this.btnP20.BorderRadius = 4;
            this.btnP20.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnP20.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnP20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnP20.Location = new System.Drawing.Point(264, 85);
            this.btnP20.Name = "btnP20";
            this.btnP20.Size = new System.Drawing.Size(75, 36);
            this.btnP20.TabIndex = 5;
            this.btnP20.Text = "20%";
            this.btnP20.Click += new System.EventHandler(this.QuickPercent_Click);
            // 
            // btnP15
            // 
            this.btnP15.BorderRadius = 4;
            this.btnP15.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnP15.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnP15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnP15.Location = new System.Drawing.Point(181, 85);
            this.btnP15.Name = "btnP15";
            this.btnP15.Size = new System.Drawing.Size(75, 36);
            this.btnP15.TabIndex = 4;
            this.btnP15.Text = "15%";
            this.btnP15.Click += new System.EventHandler(this.QuickPercent_Click);
            // 
            // btnP10
            // 
            this.btnP10.BorderRadius = 4;
            this.btnP10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnP10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnP10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnP10.Location = new System.Drawing.Point(98, 85);
            this.btnP10.Name = "btnP10";
            this.btnP10.Size = new System.Drawing.Size(75, 36);
            this.btnP10.TabIndex = 3;
            this.btnP10.Text = "10%";
            this.btnP10.Click += new System.EventHandler(this.QuickPercent_Click);
            // 
            // btnP5
            // 
            this.btnP5.BorderRadius = 4;
            this.btnP5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnP5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnP5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnP5.Location = new System.Drawing.Point(15, 85);
            this.btnP5.Name = "btnP5";
            this.btnP5.Size = new System.Drawing.Size(75, 36);
            this.btnP5.TabIndex = 2;
            this.btnP5.Text = "5%";
            this.btnP5.Click += new System.EventHandler(this.QuickPercent_Click);
            // 
            // numPercent
            // 
            this.numPercent.BackColor = System.Drawing.Color.Transparent;
            this.numPercent.BorderRadius = 6;
            this.numPercent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPercent.DecimalPlaces = 2;
            this.numPercent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.numPercent.Location = new System.Drawing.Point(235, 18);
            this.numPercent.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPercent.Name = "numPercent";
            this.numPercent.Size = new System.Drawing.Size(270, 42);
            this.numPercent.TabIndex = 1;
            this.numPercent.ValueChanged += new System.EventHandler(this.numPercent_ValueChanged);
            // 
            // lblPercentPrompt
            // 
            this.lblPercentPrompt.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentPrompt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblPercentPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblPercentPrompt.Location = new System.Drawing.Point(15, 28);
            this.lblPercentPrompt.Name = "lblPercentPrompt";
            this.lblPercentPrompt.Size = new System.Drawing.Size(161, 19);
            this.lblPercentPrompt.TabIndex = 0;
            this.lblPercentPrompt.Text = "Order Discount Rate (%):";
            // 
            // pnlFixed
            // 
            this.pnlFixed.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlFixed.BorderRadius = 8;
            this.pnlFixed.BorderThickness = 1;
            this.pnlFixed.Controls.Add(this.btnF20);
            this.pnlFixed.Controls.Add(this.btnF10);
            this.pnlFixed.Controls.Add(this.btnF5);
            this.pnlFixed.Controls.Add(this.btnF2);
            this.pnlFixed.Controls.Add(this.btnF1);
            this.pnlFixed.Controls.Add(this.numFixed);
            this.pnlFixed.Controls.Add(this.lblFixedPrompt);
            this.pnlFixed.FillColor = System.Drawing.Color.White;
            this.pnlFixed.Location = new System.Drawing.Point(20, 115);
            this.pnlFixed.Name = "pnlFixed";
            this.pnlFixed.Size = new System.Drawing.Size(520, 145);
            this.pnlFixed.TabIndex = 6;
            this.pnlFixed.Visible = false;
            // 
            // btnF20
            // 
            this.btnF20.BorderRadius = 4;
            this.btnF20.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnF20.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnF20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF20.Location = new System.Drawing.Point(415, 85);
            this.btnF20.Name = "btnF20";
            this.btnF20.Size = new System.Drawing.Size(90, 36);
            this.btnF20.TabIndex = 6;
            this.btnF20.Text = "$20.00";
            this.btnF20.Click += new System.EventHandler(this.QuickFixed_Click);
            // 
            // btnF10
            // 
            this.btnF10.BorderRadius = 4;
            this.btnF10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnF10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnF10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF10.Location = new System.Drawing.Point(315, 85);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(90, 36);
            this.btnF10.TabIndex = 5;
            this.btnF10.Text = "$10.00";
            this.btnF10.Click += new System.EventHandler(this.QuickFixed_Click);
            // 
            // btnF5
            // 
            this.btnF5.BorderRadius = 4;
            this.btnF5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnF5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnF5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF5.Location = new System.Drawing.Point(215, 85);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(90, 36);
            this.btnF5.TabIndex = 4;
            this.btnF5.Text = "$5.00";
            this.btnF5.Click += new System.EventHandler(this.QuickFixed_Click);
            // 
            // btnF2
            // 
            this.btnF2.BorderRadius = 4;
            this.btnF2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnF2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnF2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF2.Location = new System.Drawing.Point(115, 85);
            this.btnF2.Name = "btnF2";
            this.btnF2.Size = new System.Drawing.Size(90, 36);
            this.btnF2.TabIndex = 3;
            this.btnF2.Text = "$2.00";
            this.btnF2.Click += new System.EventHandler(this.QuickFixed_Click);
            // 
            // btnF1
            // 
            this.btnF1.BorderRadius = 4;
            this.btnF1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnF1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnF1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF1.Location = new System.Drawing.Point(15, 85);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(90, 36);
            this.btnF1.TabIndex = 2;
            this.btnF1.Text = "$1.00";
            this.btnF1.Click += new System.EventHandler(this.QuickFixed_Click);
            // 
            // numFixed
            // 
            this.numFixed.BackColor = System.Drawing.Color.Transparent;
            this.numFixed.BorderRadius = 6;
            this.numFixed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numFixed.DecimalPlaces = 2;
            this.numFixed.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.numFixed.Location = new System.Drawing.Point(235, 18);
            this.numFixed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numFixed.Name = "numFixed";
            this.numFixed.Size = new System.Drawing.Size(270, 42);
            this.numFixed.TabIndex = 1;
            this.numFixed.ValueChanged += new System.EventHandler(this.numFixed_ValueChanged);
            // 
            // lblFixedPrompt
            // 
            this.lblFixedPrompt.BackColor = System.Drawing.Color.Transparent;
            this.lblFixedPrompt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblFixedPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFixedPrompt.Location = new System.Drawing.Point(15, 28);
            this.lblFixedPrompt.Name = "lblFixedPrompt";
            this.lblFixedPrompt.Size = new System.Drawing.Size(176, 19);
            this.lblFixedPrompt.TabIndex = 0;
            this.lblFixedPrompt.Text = "Order Discount Amount ($):";
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlSummary.BorderRadius = 8;
            this.pnlSummary.BorderThickness = 1;
            this.pnlSummary.Controls.Add(this.lblGrandTotalVal);
            this.pnlSummary.Controls.Add(this.lblGrandTotal);
            this.pnlSummary.Controls.Add(this.lblDiscountVal);
            this.pnlSummary.Controls.Add(this.lblDiscount);
            this.pnlSummary.Controls.Add(this.lblSubtotalVal);
            this.pnlSummary.Controls.Add(this.lblSubtotal);
            this.pnlSummary.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlSummary.Location = new System.Drawing.Point(20, 275);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(520, 130);
            this.pnlSummary.TabIndex = 7;
            // 
            // lblGrandTotalVal
            // 
            this.lblGrandTotalVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotalVal.BackColor = System.Drawing.Color.Transparent;
            this.lblGrandTotalVal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalVal.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblGrandTotalVal.Location = new System.Drawing.Point(400, 85);
            this.lblGrandTotalVal.Name = "lblGrandTotalVal";
            this.lblGrandTotalVal.Size = new System.Drawing.Size(48, 25);
            this.lblGrandTotalVal.TabIndex = 5;
            this.lblGrandTotalVal.Text = "$0.00";
            this.lblGrandTotalVal.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(20, 88);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(120, 22);
            this.lblGrandTotal.TabIndex = 4;
            this.lblGrandTotal.Text = "New Grand Total:";
            // 
            // lblDiscountVal
            // 
            this.lblDiscountVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountVal.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountVal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDiscountVal.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblDiscountVal.Location = new System.Drawing.Point(400, 50);
            this.lblDiscountVal.Name = "lblDiscountVal";
            this.lblDiscountVal.Size = new System.Drawing.Size(40, 21);
            this.lblDiscountVal.TabIndex = 3;
            this.lblDiscountVal.Text = "-$0.00";
            this.lblDiscountVal.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDiscount
            // 
            this.lblDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDiscount.ForeColor = System.Drawing.Color.Gray;
            this.lblDiscount.Location = new System.Drawing.Point(20, 52);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(107, 19);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Discount Amount:";
            // 
            // lblSubtotalVal
            // 
            this.lblSubtotalVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalVal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotalVal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblSubtotalVal.Location = new System.Drawing.Point(400, 18);
            this.lblSubtotalVal.Name = "lblSubtotalVal";
            this.lblSubtotalVal.Size = new System.Drawing.Size(37, 21);
            this.lblSubtotalVal.TabIndex = 1;
            this.lblSubtotalVal.Text = "$0.00";
            this.lblSubtotalVal.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtotal.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtotal.Location = new System.Drawing.Point(20, 20);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(81, 19);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Cart Subtotal:";
            // 
            // btnApply
            // 
            this.btnApply.Animated = true;
            this.btnApply.BorderRadius = 6;
            this.btnApply.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(400, 425);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(140, 42);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply Discount";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClear
            // 
            this.btnClear.Animated = true;
            this.btnClear.BorderRadius = 6;
            this.btnClear.FillColor = System.Drawing.Color.MistyRose;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Crimson;
            this.btnClear.Location = new System.Drawing.Point(20, 425);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 42);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Remove Discount";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(275, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 42);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmApplyDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 485);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlPromo);
            this.Controls.Add(this.pnlPercent);
            this.Controls.Add(this.pnlFixed);
            this.Controls.Add(this.rbFixed);
            this.Controls.Add(this.rbPercent);
            this.Controls.Add(this.rbPromo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApplyDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply Discount";
            this.Load += new System.EventHandler(this.frmApplyDiscount_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPromo.ResumeLayout(false);
            this.pnlPromo.PerformLayout();
            this.pnlPercent.ResumeLayout(false);
            this.pnlPercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).EndInit();
            this.pnlFixed.ResumeLayout(false);
            this.pnlFixed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFixed)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtitle;
        private Guna.UI2.WinForms.Guna2RadioButton rbPromo;
        private Guna.UI2.WinForms.Guna2RadioButton rbPercent;
        private Guna.UI2.WinForms.Guna2RadioButton rbFixed;
        private Guna.UI2.WinForms.Guna2Panel pnlPromo;
        private Guna.UI2.WinForms.Guna2TextBox txtPromoCode;
        private Guna.UI2.WinForms.Guna2Button btnCheckCode;
        private Guna.UI2.WinForms.Guna2ComboBox cmbActivePromos;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPromoDetails;
        private Guna.UI2.WinForms.Guna2Panel pnlPercent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPercentPrompt;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPercent;
        private Guna.UI2.WinForms.Guna2Button btnP5;
        private Guna.UI2.WinForms.Guna2Button btnP10;
        private Guna.UI2.WinForms.Guna2Button btnP15;
        private Guna.UI2.WinForms.Guna2Button btnP20;
        private Guna.UI2.WinForms.Guna2Button btnP25;
        private Guna.UI2.WinForms.Guna2Button btnP50;
        private Guna.UI2.WinForms.Guna2Panel pnlFixed;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFixedPrompt;
        private Guna.UI2.WinForms.Guna2NumericUpDown numFixed;
        private Guna.UI2.WinForms.Guna2Button btnF1;
        private Guna.UI2.WinForms.Guna2Button btnF2;
        private Guna.UI2.WinForms.Guna2Button btnF5;
        private Guna.UI2.WinForms.Guna2Button btnF10;
        private Guna.UI2.WinForms.Guna2Button btnF20;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtotal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtotalVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiscount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiscountVal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGrandTotal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGrandTotalVal;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}
