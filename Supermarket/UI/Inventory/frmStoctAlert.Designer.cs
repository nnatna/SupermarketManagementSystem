namespace Supermarket.UI.Inventory
{
    partial class frmStoctAlert
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
            this.displayStockAlert = new Guna.UI2.WinForms.Guna2DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSort = new Guna.UI2.WinForms.Guna2Button();
            this.pnlButton = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbSortColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnRefesh = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.colPartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlertQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastRestocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.displayStockAlert)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayStockAlert
            // 
            this.displayStockAlert.AllowDrop = true;
            this.displayStockAlert.AllowUserToAddRows = false;
            this.displayStockAlert.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.displayStockAlert.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.displayStockAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayStockAlert.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.displayStockAlert.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.displayStockAlert.ColumnHeadersHeight = 45;
            this.displayStockAlert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.displayStockAlert.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPartID,
            this.colBarcode,
            this.colProductName,
            this.colCategory,
            this.colCurrentStock,
            this.colAlertQty,
            this.colLastRestocked,
            this.colStatusText});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.displayStockAlert.DefaultCellStyle = dataGridViewCellStyle3;
            this.displayStockAlert.Enabled = false;
            this.displayStockAlert.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.displayStockAlert.Location = new System.Drawing.Point(9, 107);
            this.displayStockAlert.Margin = new System.Windows.Forms.Padding(2);
            this.displayStockAlert.Name = "displayStockAlert";
            this.displayStockAlert.ReadOnly = true;
            this.displayStockAlert.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.displayStockAlert.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.displayStockAlert.RowHeadersVisible = false;
            this.displayStockAlert.RowHeadersWidth = 45;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayStockAlert.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.displayStockAlert.RowTemplate.Height = 45;
            this.displayStockAlert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.displayStockAlert.Size = new System.Drawing.Size(1214, 498);
            this.displayStockAlert.TabIndex = 27;
            this.displayStockAlert.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.displayStockAlert.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.displayStockAlert.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Gray;
            this.displayStockAlert.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayStockAlert.ThemeStyle.HeaderStyle.Height = 45;
            this.displayStockAlert.ThemeStyle.ReadOnly = true;
            this.displayStockAlert.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayStockAlert.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.displayStockAlert.ThemeStyle.RowsStyle.Height = 45;
            this.displayStockAlert.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.displayStockAlert.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.txtSearch);
            this.flowLayoutPanel2.Controls.Add(this.btnSort);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(848, 55);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(375, 48);
            this.flowLayoutPanel2.TabIndex = 29;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(4, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search by Product, Type, Reason...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(321, 40);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSort
            // 
            this.btnSort.Animated = true;
            this.btnSort.BackColor = System.Drawing.Color.Transparent;
            this.btnSort.BorderRadius = 8;
            this.btnSort.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSort.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnSort.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSort.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSort.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSort.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSort.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSort.FillColor = System.Drawing.Color.White;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSort.ForeColor = System.Drawing.Color.Black;
            this.btnSort.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSort.Image = global::Supermarket.Properties.Resources.sort;
            this.btnSort.IndicateFocus = true;
            this.btnSort.Location = new System.Drawing.Point(331, 2);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(40, 40);
            this.btnSort.TabIndex = 8;
            this.btnSort.TabStop = false;
            this.btnSort.UseTransparentBackground = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cmbSortColumn);
            this.pnlButton.Controls.Add(this.btnRefesh);
            this.pnlButton.Location = new System.Drawing.Point(12, 55);
            this.pnlButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(842, 48);
            this.pnlButton.TabIndex = 28;
            // 
            // cmbSortColumn
            // 
            this.cmbSortColumn.BackColor = System.Drawing.Color.Transparent;
            this.cmbSortColumn.BorderRadius = 8;
            this.cmbSortColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSortColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSortColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSortColumn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSortColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSortColumn.ItemHeight = 34;
            this.cmbSortColumn.Location = new System.Drawing.Point(2, 2);
            this.cmbSortColumn.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSortColumn.Name = "cmbSortColumn";
            this.cmbSortColumn.Size = new System.Drawing.Size(280, 40);
            this.cmbSortColumn.TabIndex = 3;
            // 
            // btnRefesh
            // 
            this.btnRefesh.Animated = true;
            this.btnRefesh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefesh.BorderRadius = 8;
            this.btnRefesh.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnRefesh.CheckedState.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRefesh.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnRefesh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefesh.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnRefesh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefesh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefesh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefesh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefesh.FillColor = System.Drawing.Color.White;
            this.btnRefesh.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefesh.ForeColor = System.Drawing.Color.Black;
            this.btnRefesh.HoverState.FillColor = System.Drawing.Color.DarkGray;
            this.btnRefesh.Image = global::Supermarket.Properties.Resources.refresh;
            this.btnRefesh.IndicateFocus = true;
            this.btnRefesh.Location = new System.Drawing.Point(286, 2);
            this.btnRefesh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(120, 40);
            this.btnRefesh.TabIndex = 4;
            this.btnRefesh.TabStop = false;
            this.btnRefesh.Text = "Refresh";
            this.btnRefesh.UseTransparentBackground = true;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(14, 12);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(124, 27);
            this.guna2HtmlLabel1.TabIndex = 26;
            this.guna2HtmlLabel1.Text = "STOCK ALERT";
            // 
            // colPartID
            // 
            this.colPartID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPartID.Frozen = true;
            this.colPartID.HeaderText = "ID";
            this.colPartID.Name = "colPartID";
            this.colPartID.ReadOnly = true;
            this.colPartID.Width = 45;
            // 
            // colBarcode
            // 
            this.colBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colBarcode.Frozen = true;
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.Width = 250;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductName.HeaderText = "Product";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 250;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCurrentStock.HeaderText = "Current Stock";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            this.colCurrentStock.Width = 160;
            // 
            // colAlertQty
            // 
            this.colAlertQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAlertQty.HeaderText = "Alert Quantity";
            this.colAlertQty.Name = "colAlertQty";
            this.colAlertQty.ReadOnly = true;
            this.colAlertQty.Width = 160;
            // 
            // colLastRestocked
            // 
            this.colLastRestocked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colLastRestocked.HeaderText = "Last Restocked";
            this.colLastRestocked.Name = "colLastRestocked";
            this.colLastRestocked.ReadOnly = true;
            this.colLastRestocked.Width = 160;
            // 
            // colStatusText
            // 
            this.colStatusText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStatusText.HeaderText = "Stutas";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.ReadOnly = true;
            this.colStatusText.Width = 150;
            // 
            // frmStoctAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 617);
            this.Controls.Add(this.displayStockAlert);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmStoctAlert";
            this.Text = "StoctAlert";
            this.Load += new System.EventHandler(this.frmStoctAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayStockAlert)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView displayStockAlert;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSort;
        private System.Windows.Forms.FlowLayoutPanel pnlButton;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSortColumn;
        private Guna.UI2.WinForms.Guna2Button btnRefesh;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlertQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastRestocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusText;
    }
}