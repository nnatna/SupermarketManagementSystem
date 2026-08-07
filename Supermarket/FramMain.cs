using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class FramMain : Form
    {
        bool isInventoryCollapsed = true;
        bool isMenuCollapsed = true;
        bool isSalesCollapsed = true;

        public FramMain()
        {
            InitializeComponent();
        }

        private void FramMain_Load(object sender, EventArgs e)
        {
            btnDashboard.Checked = true;
            btnInventory.Checked = false;
            btnSales.Checked = false;

            this.ActiveControl = null;
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

                //Dropdown
                if (sender == btnInventory)
                {
                    inventoryTimer.Start();
                    if (!isSalesCollapsed)
                    {
                        salesTimer.Start();
                    }
                }
                else if (sender == btnSales)
                {
                    salesTimer.Start();
                    if (!isInventoryCollapsed)
                    {
                        inventoryTimer.Start();
                    }
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
                pnlInventoryContainer.Height += 10;
                if (pnlInventoryContainer.Height >= 150)
                {
                    if (isMenuCollapsed)
                    {
                        MenuTimer.Start();
                    }
                    pnlInventoryContainer.Height = 150;
                    inventoryTimer.Stop();
                    isInventoryCollapsed = false;
                }
            }
            else
            {
                pnlInventoryContainer.Height -= 10;
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
                pnlSalesContainer.Height += 10;
                if (pnlSalesContainer.Height >= 150)
                {
                    if (isMenuCollapsed)
                    {
                        MenuTimer.Start();
                    }
                    pnlSalesContainer.Height = 150;
                    salesTimer.Stop();
                    isSalesCollapsed = false;
                }
            }
            else
            {
                pnlSalesContainer.Height -= 10;
                if (pnlSalesContainer.Height <= 45)
                {
                    pnlSalesContainer.Height = 45;
                    salesTimer.Stop();
                    isSalesCollapsed = true;
                }
            }
        }

        //Sidebar Menu Collapse/Expand Timer
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (isMenuCollapsed)
            {
                pnlSidebar.Width += 10;
                if (pnlSidebar.Width >= 200)
                {
                    pnlSidebar.Width = 200;
                    MenuTimer.Stop();
                    isMenuCollapsed = false;
                }
            }
            else
            {
                pnlSidebar.Width -= 10;
                if (pnlSidebar.Width <= 44)
                {
                    if (!isInventoryCollapsed)
                    {
                        inventoryTimer.Start();
                    }
                    else if (!isSalesCollapsed)
                    {
                        salesTimer.Start();
                    }

                    pnlSidebar.Width = 44;
                    MenuTimer.Stop();
                    isMenuCollapsed = true;


                }
            }
        }

        // Button Menu Click Event
        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuTimer.Start();
        }
    }
}