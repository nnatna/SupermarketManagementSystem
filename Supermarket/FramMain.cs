using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Supermarket.UI.Dashboard;
using Supermarket.UI.Customers;
using Supermarket.UI.Inventory;
using Supermarket.UI.Point_of_sale;
using Supermarket.UI.Report;
using Supermarket.UI.Purchasing_and_Suppliers;
using Supermarket.UI.Settings;
using Supermarket.UI.Products;


namespace Supermarket
{
    public partial class FramMain : Form
    {
        bool isInventoryCollapsed = true;
        bool isMenuCollapsed = true;
        bool isSalesCollapsed = true;
        bool isProductsCollapsed = true;
        bool isPurchasingSuppliersCollapsed = true;
        bool isReportsCollapsed = true;
        bool isSettingsCollapsed = true;

        public FramMain()
        {
            InitializeComponent();
            EnableDoubleBuffering(this);
        }

        private void EnableDoubleBuffering(Control control)
        {
            if (control == null) return;
            try
            {
                typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(control, true, null);
            }
            catch { }

            foreach (Control child in control.Controls)
            {
                EnableDoubleBuffering(child);
            }
        }

        private Form activeForm = null;
        private void FramMain_Load(object sender, EventArgs e)
        {
            btnDashboard.Checked = true;
            btnInventory.Checked = false;
            btnPointOfSales.Checked = false;
            openChildForrm(new frrmDashoard());

            this.ActiveControl = null;
        }

        private void openChildForrm(Form childForm)
        {
            pnlContent.SuspendLayout();
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            pnlContent.ResumeLayout(true);
        }

        private void closeDropdowns()
        {
            if (!isInventoryCollapsed)
            {
                inventoryTimer.Start();
            }
            if (!isSalesCollapsed)
            {
                PointOfSalesTimer.Start();
            }
            if (!isProductsCollapsed)
            {
                ProductsTimer.Start();
            }
            if (!isPurchasingSuppliersCollapsed)
            {
                PurchasingSuppliersTimer.Start();
            }
            if (!isReportsCollapsed)
            {
                ReportsTimer.Start();
            }
            if (!isSettingsCollapsed)
            {
                SettingsTimer.Start();
            }
        }

        private void closeMenu()
        {
            if (isMenuCollapsed)
            {
                MenuTimer.Start();
            }
        }

        bool isResetting = false;

        private void NavigationButton_Click(object sender, EventArgs e)
        {
            if (isResetting) return;

            try
            {
                isResetting = true;

                ResetAllButtons(pnlSidebar);

                //Checked​ Button
                if (sender is Guna.UI2.WinForms.Guna2Button clickedButton)
                {
                    clickedButton.Checked = true;
                }

                //Dasboard
                if(sender == btnDashboard)
                {
                    openChildForrm(new frrmDashoard());
                }

                //Cusrtomer
                if (sender==btnCustomers)
                {
                    openChildForrm(new frmCustomers());
                }
                //Inventory
                if (sender == btnStock)
                {
                    openChildForrm(new frmStoctAlert());
                }
                if (sender == btnStockAdjustment)
                {
                    openChildForrm(new frmStockAdjustment());
                }

                //Point Of Sales
                if (sender == btnSale)
                {
                    openChildForrm(new frmSales());
                }
                if (sender == btnSalesHistory)
                {
                    openChildForrm(new frmSaleHistory());
                }
                //Product
                if (sender == btnCategories)
                {
                    openChildForrm(new frmCategories());
                }
                if (sender == btnProductsList)
                {
                    openChildForrm(new frmProductsList());
                }
                if (sender == btnUnits)
                {
                    openChildForrm(new frmUnits());
                }

                //Purchasing & Suppliers
                if (sender == btnPurchasingSuppliers)
                {
                    openChildForrm(new frmPurchaseOrders());
                }
                if (sender == btnSuppliers)
                {
                    openChildForrm(new frmSuppliers());
                }
                //Report
                if (sender == btnInventoryReport)
                {
                    openChildForrm(new frminventoryReport());
                }
                if (sender == btnProfitLoss)
                {
                    openChildForrm(new frmProfitLoss());
                }
                if (sender == btnSalesReport)
                {
                    openChildForrm(new frmSalesReport());
                }

                //Settings
                if (sender == btnEmployees)
                {
                    openChildForrm(new frmEmployees());
                }
                if (sender == btnGeneralSetting)
                {
                    openChildForrm(new frmGeneralSettings());
                }
                if (sender == btnStoreInfo)
                {
                    openChildForrm(new frmStore_nfo());
                }
                if (sender == btnUsers)
                {
                    openChildForrm(new frmUsers());
                }

                //Dropdown
                if (sender == btnInventory)
                {
                    inventoryTimer.Start();
                    closeDropdowns();
                    
                }
                else if (sender == btnProducts)
                {
                    ProductsTimer.Start();
                    closeDropdowns();
                    openChildForrm(new frmProductsList());
                    

                }
                else if (sender == btnPointOfSales)
                {
                    PointOfSalesTimer.Start();
                    closeDropdowns();
                    openChildForrm(new frmSales());
                }
                else if (sender == btnPurchasingSuppliers)
                {
                    PurchasingSuppliersTimer.Start();
                    closeDropdowns();
                    
                }
                else if (sender == btnReports)
                {
                    ReportsTimer.Start();
                    closeDropdowns();
                    
                }
                else if (sender == btnSettings)
                {
                    SettingsTimer.Start();
                    closeDropdowns();
                }
            }
            finally
            {
                isResetting = false;
            }
        }

        private void ResetAllButtons(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.Checked = false;
                }

                if (ctrl.HasChildren)
                {
                    ResetAllButtons(ctrl);
                }
            }
        }

        //Inventory Dropdown Timer
        private void inventoryTimer_Tick(object sender, EventArgs e)
        {
            if (isInventoryCollapsed)
            {
                closeMenu();
                pnlInventoryContainer.Height += 25;
                if (pnlInventoryContainer.Height >= 150)
                {
                    pnlInventoryContainer.Height = 150;
                    inventoryTimer.Stop();
                    isInventoryCollapsed = false;
                }
            }
            else
            {
                pnlInventoryContainer.Height -= 25;
                if (pnlInventoryContainer.Height <= 45)
                {
                    pnlInventoryContainer.Height = 45;
                    inventoryTimer.Stop();
                    isInventoryCollapsed = true;
                }
            }
        }

        //Sales Dropdown Timer
        private void salesTimer_Tick(object sender, EventArgs e)
        {
            if (isSalesCollapsed)
            {
                closeMenu();
                pnlSalesContainer.Height += 25;
                if (pnlSalesContainer.Height >= 150)
                {
                    pnlSalesContainer.Height = 150;
                    PointOfSalesTimer.Stop();
                    isSalesCollapsed = false;
                }
            }
            else
            {
                pnlSalesContainer.Height -= 25;
                if (pnlSalesContainer.Height <= 45)
                {
                    pnlSalesContainer.Height = 45;
                    PointOfSalesTimer.Stop();
                    isSalesCollapsed = true;
                }
            }
        }

        //Sidebar Menu Collapse/Expand Timer
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (isMenuCollapsed)
            {
                btnLogout.ImageAlign = HorizontalAlignment.Center;
                btnLogout.TextAlign = HorizontalAlignment.Center;
                pnlSidebar.Width += 30;
                if (pnlSidebar.Width >= 265)
                {
                    pnlSidebar.Width = 265;
                    MenuTimer.Stop();
                    isMenuCollapsed = false;
                }
            }
            else
            {
                btnLogout.ImageAlign = HorizontalAlignment.Left;
                btnLogout.TextAlign = HorizontalAlignment.Left;
                pnlSidebar.Width -= 30;
                if (pnlSidebar.Width <= 44)
                {
                    pnlSidebar.Width = 44;
                    MenuTimer.Stop();
                    isMenuCollapsed = true;
                }
            }
        }

        // Button Menu Click Event
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (!isMenuCollapsed)
            {
                closeDropdowns();
            }
            MenuTimer.Start();
        }

        //Products Timer Tick Event
        private void ProductsTimer_Tick(object sender, EventArgs e)
        {
            if(isProductsCollapsed)
            {
                closeMenu();
                pnlProductsContainer.Height += 25;
                if(pnlProductsContainer.Height >= 200)
                {
                    pnlProductsContainer.Height = 200;
                    ProductsTimer.Stop();
                    isProductsCollapsed = false;
                }
            }
            else
            {
                pnlProductsContainer.Height -= 25;
                if(pnlProductsContainer.Height <= 45)
                {
                    pnlProductsContainer.Height = 45;
                    ProductsTimer.Stop();
                    isProductsCollapsed = true;
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Purchasing Suppliers Timer Tick Event
        private void PurchasingSuppliersTimer_Tick(object sender, EventArgs e)
        {
            if (isPurchasingSuppliersCollapsed)
            {
                closeMenu();
                pnlPurchasingSuppliersContainer.Height += 25;
                if (pnlPurchasingSuppliersContainer.Height >= 200)
                {
                    pnlPurchasingSuppliersContainer.Height = 200;
                    PurchasingSuppliersTimer.Stop();
                    isPurchasingSuppliersCollapsed = false;
                }

            }
            else
            {
                pnlPurchasingSuppliersContainer.Height -= 25;
                if (pnlPurchasingSuppliersContainer.Height <= 45)
                {
                    pnlPurchasingSuppliersContainer.Height = 45;
                    PurchasingSuppliersTimer.Stop();
                    isPurchasingSuppliersCollapsed = true;
                }
            }
        }

        //Reports Timer Tick Event
        private void ReportsTimer_Tick(object sender, EventArgs e)
        {
            if (isReportsCollapsed)
            {
                closeMenu();
                pnlReportsContainer.Height += 25;
                if (pnlReportsContainer.Height >= 200)
                {
                    pnlReportsContainer.Height = 200;
                    ReportsTimer.Stop();
                    isReportsCollapsed = false;
                }
            }
            else
            {
                pnlReportsContainer.Height -= 25;
                if (pnlReportsContainer.Height <= 45)
                {
                    pnlReportsContainer.Height = 45;
                    ReportsTimer.Stop();
                    isReportsCollapsed = true;
                }
            }
        }

        private void SettingsTimer_Tick(object sender, EventArgs e)
        {
            if (isSettingsCollapsed)
            {
                closeMenu();
                pnlSettingsContainer.Height += 30;
                if (pnlSettingsContainer.Height >= 255)
                {
                    pnlSettingsContainer.Height = 255;
                    SettingsTimer.Stop();
                    isSettingsCollapsed = false;
                }
            }
            else
            {
                pnlSettingsContainer.Height -= 30;
                if (pnlSettingsContainer.Height <= 45)
                {
                    pnlSettingsContainer.Height = 45;
                    SettingsTimer.Stop();
                    isSettingsCollapsed = true;
                }
            }
        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}