using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Point_of_sale
{
    public partial class frmEditSaleHistory : Form
    {
        private readonly SalesDAL _salesDAL = new SalesDAL();
        private readonly long _saleId;
        private readonly string _currentStatus;
        private readonly string _invoiceNumber;

        public frmEditSaleHistory(long saleId = 0, string currentStatus = "Completed", string invoiceNumber = "")
        {
            InitializeComponent();
            _saleId = saleId;
            _currentStatus = currentStatus ?? "Completed";
            _invoiceNumber = invoiceNumber ?? "";
            this.StartPosition = FormStartPosition.CenterParent;
            WireUpEvents();
        }

        public frmEditSaleHistory(vw_SaleHistory sale)
            : this(sale != null ? sale.sale_id : 0, sale != null ? sale.status : "Completed", sale != null ? sale.invoice_number : "")
        {
        }

        private void WireUpEvents()
        {
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void frmEditSaleHistory_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Completed");
            cmbStatus.Items.Add("Cancelled");

            if (!string.IsNullOrWhiteSpace(_invoiceNumber))
            {
                guna2HtmlLabel1.Text = $"Edit Status ({_invoiceNumber})";
            }
            else
            {
                guna2HtmlLabel1.Text = "Edit Status";
            }

            if (_currentStatus.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                cmbStatus.SelectedItem = "Cancelled";
            }
            else
            {
                cmbStatus.SelectedItem = "Completed";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = cmbStatus.SelectedItem.ToString();

            bool isCurrentlyCancelled = _currentStatus.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase);
            bool isNewCancelled = newStatus.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase);

            if (isCurrentlyCancelled == isNewCancelled)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if (isNewCancelled)
            {
                var confirm = MessageBox.Show(
                    $"Are you sure you want to change the status of Invoice '{_invoiceNumber}' to 'Cancelled'?\n\nThis will restore the product stock quantities.",
                    "Confirm Status Change",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                string errorMsg = string.Empty;
                bool success = await Task.Run(() =>
                {
                    string err;
                    bool res = _salesDAL.CancelSale(_saleId, out err);
                    errorMsg = err;
                    return res;
                });

                if (success)
                {
                    MessageBox.Show("Sale status updated to Cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Failed to cancel sale:\n{errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string errorMsg = string.Empty;
                bool success = await Task.Run(() =>
                {
                    string err;
                    bool res = _salesDAL.UpdateSaleStatus(_saleId, newStatus, out err);
                    errorMsg = err;
                    return res;
                });

                if (success)
                {
                    MessageBox.Show("Sale status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Failed to update status:\n{errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
