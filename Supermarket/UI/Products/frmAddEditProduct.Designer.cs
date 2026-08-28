namespace Supermarket.UI.Products
{
    partial class frmAddEditProduct
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSupplier = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCategory = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.UnitCateroy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblUnit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbUnit = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCostPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCostPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSellingPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSellingPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStockQuantity = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtStockQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStockAlertLevel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtStockAlertLevel = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblImage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtImagePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPath = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlTop.Controls.Add(this.guna2HtmlLabel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(650, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(24, 16);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(142, 27);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Product Details";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(24, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Product Name *:";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 6;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtName.Location = new System.Drawing.Point(24, 100);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Enter full product name";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(600, 40);
            this.txtName.TabIndex = 2;
            // 
            // lblSupplier
            // 
            this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSupplier.Location = new System.Drawing.Point(24, 155);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(56, 19);
            this.lblSupplier.TabIndex = 3;
            this.lblSupplier.Text = "Supplier:";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.BackColor = System.Drawing.Color.Transparent;
            this.cmbSupplier.BorderRadius = 6;
            this.cmbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSupplier.ItemHeight = 34;
            this.cmbSupplier.Location = new System.Drawing.Point(24, 180);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(600, 40);
            this.cmbSupplier.TabIndex = 4;
            // 
            // lblCategory
            // 
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCategory.Location = new System.Drawing.Point(24, 235);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(70, 19);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category *:";
            // 
            // UnitCateroy
            // 
            this.UnitCateroy.BackColor = System.Drawing.Color.Transparent;
            this.UnitCateroy.BorderRadius = 6;
            this.UnitCateroy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.UnitCateroy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitCateroy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UnitCateroy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UnitCateroy.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.UnitCateroy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.UnitCateroy.ItemHeight = 34;
            this.UnitCateroy.Location = new System.Drawing.Point(24, 260);
            this.UnitCateroy.Name = "UnitCateroy";
            this.UnitCateroy.Size = new System.Drawing.Size(285, 40);
            this.UnitCateroy.TabIndex = 6;
            // 
            // lblUnit
            // 
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnit.Location = new System.Drawing.Point(339, 235);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(39, 19);
            this.lblUnit.TabIndex = 7;
            this.lblUnit.Text = "Unit *:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.Transparent;
            this.cmbUnit.BorderRadius = 6;
            this.cmbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbUnit.ItemHeight = 34;
            this.cmbUnit.Location = new System.Drawing.Point(339, 260);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(285, 40);
            this.cmbUnit.TabIndex = 8;
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblCostPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCostPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCostPrice.Location = new System.Drawing.Point(24, 315);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(89, 19);
            this.lblCostPrice.TabIndex = 9;
            this.lblCostPrice.Text = "Cost Price ($) *:";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.BorderRadius = 6;
            this.txtCostPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCostPrice.DefaultText = "";
            this.txtCostPrice.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtCostPrice.Location = new System.Drawing.Point(24, 340);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.PlaceholderText = "e.g. 1.25";
            this.txtCostPrice.SelectedText = "";
            this.txtCostPrice.Size = new System.Drawing.Size(285, 40);
            this.txtCostPrice.TabIndex = 10;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblSellingPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblSellingPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSellingPrice.Location = new System.Drawing.Point(339, 315);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(102, 19);
            this.lblSellingPrice.TabIndex = 11;
            this.lblSellingPrice.Text = "Selling Price ($) *:";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BorderRadius = 6;
            this.txtSellingPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSellingPrice.DefaultText = "";
            this.txtSellingPrice.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtSellingPrice.Location = new System.Drawing.Point(339, 340);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.PlaceholderText = "e.g. 1.75";
            this.txtSellingPrice.SelectedText = "";
            this.txtSellingPrice.Size = new System.Drawing.Size(285, 40);
            this.txtSellingPrice.TabIndex = 12;
            // 
            // lblStockQuantity
            // 
            this.lblStockQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblStockQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStockQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStockQuantity.Location = new System.Drawing.Point(24, 395);
            this.lblStockQuantity.Name = "lblStockQuantity";
            this.lblStockQuantity.Size = new System.Drawing.Size(95, 19);
            this.lblStockQuantity.TabIndex = 13;
            this.lblStockQuantity.Text = "Stock Quantity:";
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.BorderRadius = 6;
            this.txtStockQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStockQuantity.DefaultText = "0";
            this.txtStockQuantity.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtStockQuantity.Location = new System.Drawing.Point(24, 420);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.PlaceholderText = "0";
            this.txtStockQuantity.SelectedText = "";
            this.txtStockQuantity.Size = new System.Drawing.Size(285, 40);
            this.txtStockQuantity.TabIndex = 14;
            // 
            // lblStockAlertLevel
            // 
            this.lblStockAlertLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblStockAlertLevel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStockAlertLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStockAlertLevel.Location = new System.Drawing.Point(339, 395);
            this.lblStockAlertLevel.Name = "lblStockAlertLevel";
            this.lblStockAlertLevel.Size = new System.Drawing.Size(107, 19);
            this.lblStockAlertLevel.TabIndex = 15;
            this.lblStockAlertLevel.Text = "Stock Alert Level:";
            // 
            // txtStockAlertLevel
            // 
            this.txtStockAlertLevel.BorderRadius = 6;
            this.txtStockAlertLevel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStockAlertLevel.DefaultText = "5";
            this.txtStockAlertLevel.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtStockAlertLevel.Location = new System.Drawing.Point(339, 420);
            this.txtStockAlertLevel.Name = "txtStockAlertLevel";
            this.txtStockAlertLevel.PlaceholderText = "5";
            this.txtStockAlertLevel.SelectedText = "";
            this.txtStockAlertLevel.Size = new System.Drawing.Size(285, 40);
            this.txtStockAlertLevel.TabIndex = 16;
            // 
            // lblImage
            // 
            this.lblImage.BackColor = System.Drawing.Color.Transparent;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblImage.Location = new System.Drawing.Point(24, 475);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(78, 19);
            this.lblImage.TabIndex = 17;
            this.lblImage.Text = "Image Path:";
            // 
            // txtImagePath
            // 
            this.txtImagePath.BorderRadius = 6;
            this.txtImagePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImagePath.DefaultText = "";
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImagePath.Location = new System.Drawing.Point(24, 500);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.PlaceholderText = "Select product image...";
            this.txtImagePath.SelectedText = "";
            this.txtImagePath.Size = new System.Drawing.Size(545, 40);
            this.txtImagePath.TabIndex = 18;
            // 
            // btnPath
            // 
            this.btnPath.Animated = true;
            this.btnPath.BorderRadius = 6;
            this.btnPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPath.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPath.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPath.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnPath.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnPath.ForeColor = System.Drawing.Color.White;
            this.btnPath.Image = global::Supermarket.Properties.Resources.LinkFile;
            this.btnPath.Location = new System.Drawing.Point(578, 500);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(46, 40);
            this.btnPath.TabIndex = 19;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BorderRadius = 8;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(484, 565);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 45);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(334, 565);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 630);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtStockAlertLevel);
            this.Controls.Add(this.lblStockAlertLevel);
            this.Controls.Add(this.txtStockQuantity);
            this.Controls.Add(this.lblStockQuantity);
            this.Controls.Add(this.txtSellingPrice);
            this.Controls.Add(this.lblSellingPrice);
            this.Controls.Add(this.txtCostPrice);
            this.Controls.Add(this.lblCostPrice);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.UnitCateroy);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Details";
            this.Load += new System.EventHandler(this.frmAddEditProduct_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSupplier;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSupplier;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCategory;
        private Guna.UI2.WinForms.Guna2ComboBox UnitCateroy;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUnit;
        private Guna.UI2.WinForms.Guna2ComboBox cmbUnit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCostPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtCostPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSellingPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtSellingPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStockQuantity;
        private Guna.UI2.WinForms.Guna2TextBox txtStockQuantity;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStockAlertLevel;
        private Guna.UI2.WinForms.Guna2TextBox txtStockAlertLevel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblImage;
        private Guna.UI2.WinForms.Guna2TextBox txtImagePath;
        private Guna.UI2.WinForms.Guna2Button btnPath;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}