using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Settings
{
    public partial class frmStore_nfo : Form
    {
        private readonly StoreInfoDAL _storeInfoDAL = new StoreInfoDAL();

        public frmStore_nfo()
        {
            InitializeComponent();
        }

        private async void frmStore_nfo_Load(object sender, EventArgs e)
        {
            await LoadStoreInfoAsync();
        }

        private async Task LoadStoreInfoAsync()
        {
            try
            {
                var info = await Task.Run(() => _storeInfoDAL.GetStoreInfo());
                if (info != null)
                {
                    txtStoreName.Text = info.StoreName ?? "";
                    txtStoreBranch.Text = info.BranchName ?? "";
                    txtStorePhone.Text = info.PhoneNumber ?? "";
                    txtStoreEmail.Text = info.Email ?? "";
                    txtStoreAddress.Text = info.Address ?? "";
                    txtTaxRate.Text = info.TaxRate.ToString("0.##");
                    txtCurrency.Text = info.CurrencySymbol ?? "$";
                    txtExchangeRate.Text = info.ExchangeRate.ToString("0.##");
                    txtReceiptHeader.Text = info.ReceiptHeader ?? "";
                    txtReceiptFooter.Text = info.ReceiptFooter ?? "";
                }
                else
                {
                    LoadFromLocalSettings();
                }
            }
            catch
            {
                LoadFromLocalSettings();
            }
        }

        private void LoadFromLocalSettings()
        {
            txtStoreName.Text = Properties.Settings.Default.StoreName ?? "Supermarket Management";
            txtStoreBranch.Text = Properties.Settings.Default.StoreBranch ?? "Main Branch - Fresh & Quality Goods";
            txtStorePhone.Text = Properties.Settings.Default.StorePhone ?? "+855 12 345 678";
            txtStoreEmail.Text = Properties.Settings.Default.StoreEmail ?? "info@supermarket.com";
            txtStoreAddress.Text = Properties.Settings.Default.StoreAddress ?? "Phnom Penh, Cambodia";
            txtTaxRate.Text = Properties.Settings.Default.TaxRate ?? "10.00";
            txtCurrency.Text = Properties.Settings.Default.CurrencySymbol ?? "$";
            txtExchangeRate.Text = Properties.Settings.Default.ExchangeRate ?? "4100";
            txtReceiptHeader.Text = Properties.Settings.Default.ReceiptHeader ?? "Thank you for shopping with us!";
            txtReceiptFooter.Text = Properties.Settings.Default.ReceiptFooter ?? "Goods sold are not returnable. Please keep your receipt.";
        }

        private async void btnSaveStoreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string storeName = txtStoreName.Text.Trim();
                if (string.IsNullOrWhiteSpace(storeName))
                {
                    MessageBox.Show("Store Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStoreName.Focus();
                    return;
                }

                decimal taxRate = 10.0m;
                if (!decimal.TryParse(txtTaxRate.Text.Trim(), out taxRate))
                {
                    taxRate = 10.0m;
                }

                decimal exchangeRate = 4100.0m;
                if (!decimal.TryParse(txtExchangeRate.Text.Trim(), out exchangeRate))
                {
                    exchangeRate = 4100.0m;
                }

                var info = new StoreInfo
                {
                    StoreName = storeName,
                    BranchName = txtStoreBranch.Text.Trim(),
                    PhoneNumber = txtStorePhone.Text.Trim(),
                    Email = txtStoreEmail.Text.Trim(),
                    Address = txtStoreAddress.Text.Trim(),
                    TaxRate = taxRate,
                    CurrencySymbol = string.IsNullOrWhiteSpace(txtCurrency.Text.Trim()) ? "$" : txtCurrency.Text.Trim(),
                    ExchangeRate = exchangeRate,
                    ReceiptHeader = txtReceiptHeader.Text.Trim(),
                    ReceiptFooter = txtReceiptFooter.Text.Trim()
                };

                // 1. Save to SQL Server Database
                string errorMsg = "";
                bool savedToDb = await Task.Run(() =>
                {
                    string err;
                    bool res = _storeInfoDAL.SaveStoreInfo(info, out err);
                    errorMsg = err;
                    return res;
                });

                // 2. Save to Application Settings
                Properties.Settings.Default.StoreName = info.StoreName;
                Properties.Settings.Default.StoreBranch = info.BranchName;
                Properties.Settings.Default.StorePhone = info.PhoneNumber;
                Properties.Settings.Default.StoreEmail = info.Email;
                Properties.Settings.Default.StoreAddress = info.Address;
                Properties.Settings.Default.TaxRate = info.TaxRate.ToString("0.##");
                Properties.Settings.Default.CurrencySymbol = info.CurrencySymbol;
                Properties.Settings.Default.ExchangeRate = info.ExchangeRate.ToString("0.##");
                Properties.Settings.Default.ReceiptHeader = info.ReceiptHeader;
                Properties.Settings.Default.ReceiptFooter = info.ReceiptFooter;
                Properties.Settings.Default.Save();

                // Refresh Form Main Title / Store display
                if (this.TopLevelControl is FramMain mainForm)
                {
                    mainForm.RefreshStoreInfoDisplay();
                }
                else if (Application.OpenForms.Cast<Form>().OfType<FramMain>().FirstOrDefault() is FramMain openMain)
                {
                    openMain.RefreshStoreInfoDisplay();
                }

                if (savedToDb)
                {
                    MessageBox.Show("Store information updated and saved successfully to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Store info saved locally. Database update note: " + errorMsg, "Saved Locally", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving store info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnResetStoreInfo_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to discard your changes and reload stored info?",
                "Discard Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                await LoadStoreInfoAsync();
            }
        }
    }
}
