namespace Supermarket.UI.Point_of_sale
{
    partial class CardProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDiscountBadge = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.lblOriginalPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCatagory = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtProductName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.pnlCard.BorderRadius = 10;
            this.pnlCard.BorderThickness = 1;
            this.pnlCard.Controls.Add(this.lblDiscountBadge);
            this.pnlCard.Controls.Add(this.btnAdd);
            this.pnlCard.Controls.Add(this.lblOriginalPrice);
            this.pnlCard.Controls.Add(this.guna2HtmlLabel2);
            this.pnlCard.Controls.Add(this.txtCatagory);
            this.pnlCard.Controls.Add(this.txtProductName);
            this.pnlCard.Controls.Add(this.image);
            this.pnlCard.FillColor = System.Drawing.Color.White;
            this.pnlCard.Location = new System.Drawing.Point(3, 3);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(230, 345);
            this.pnlCard.TabIndex = 0;
            // 
            // lblDiscountBadge
            // 
            this.lblDiscountBadge.BackColor = System.Drawing.Color.Crimson;
            this.lblDiscountBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscountBadge.ForeColor = System.Drawing.Color.White;
            this.lblDiscountBadge.Location = new System.Drawing.Point(12, 12);
            this.lblDiscountBadge.Name = "lblDiscountBadge";
            this.lblDiscountBadge.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblDiscountBadge.Size = new System.Drawing.Size(40, 21);
            this.lblDiscountBadge.TabIndex = 6;
            this.lblDiscountBadge.Text = "-20%";
            this.lblDiscountBadge.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDiscountBadge.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.AutoRoundedCorners = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderRadius = 21;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Image = global::Supermarket.Properties.Resources.plus;
            this.btnAdd.ImageSize = new System.Drawing.Size(18, 18);
            this.btnAdd.IndicateFocus = true;
            this.btnAdd.Location = new System.Drawing.Point(176, 290);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 44);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseTransparentBackground = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblOriginalPrice
            // 
            this.lblOriginalPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblOriginalPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Strikeout);
            this.lblOriginalPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblOriginalPrice.Location = new System.Drawing.Point(8, 296);
            this.lblOriginalPrice.Name = "lblOriginalPrice";
            this.lblOriginalPrice.Size = new System.Drawing.Size(34, 19);
            this.lblOriginalPrice.TabIndex = 5;
            this.lblOriginalPrice.Text = "$0.50";
            this.lblOriginalPrice.Visible = false;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Crimson;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(8, 313);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(48, 27);
            this.guna2HtmlLabel2.TabIndex = 2;
            this.guna2HtmlLabel2.Text = "$0.40";
            // 
            // txtCatagory
            // 
            this.txtCatagory.BackColor = System.Drawing.Color.Transparent;
            this.txtCatagory.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtCatagory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(155)))));
            this.txtCatagory.Location = new System.Drawing.Point(8, 270);
            this.txtCatagory.Name = "txtCatagory";
            this.txtCatagory.Size = new System.Drawing.Size(65, 19);
            this.txtCatagory.TabIndex = 3;
            this.txtCatagory.Text = "Beverages";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Transparent;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtProductName.Location = new System.Drawing.Point(8, 244);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(78, 23);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.Text = "Coca Cola";
            // 
            // image
            // 
            this.image.BorderRadius = 8;
            this.image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image.CustomizableEdges.BottomLeft = false;
            this.image.CustomizableEdges.BottomRight = false;
            this.image.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.image.Image = global::Supermarket.Properties.Resources.coca_cola;
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(5, 5);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(220, 230);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // CardProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlCard);
            this.Name = "CardProduct";
            this.Size = new System.Drawing.Size(236, 352);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtProductName;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtCatagory;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOriginalPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiscountBadge;
        private Guna.UI2.WinForms.Guna2Panel pnlCard;
        private Guna.UI2.WinForms.Guna2PictureBox image;
    }
}
