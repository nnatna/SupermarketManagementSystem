using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.DAL;

namespace Supermarket.UI.Point_of_sale
{
    using Sales = Supermarket.Model.Sales;
    using SalesDetails = Supermarket.Model.SalesDetails;

    public partial class frmPayment : Form
    {
        private readonly SalesDAL _salesDAL = new SalesDAL();
        private readonly List<CartItemControl> _cartItems;
        private readonly decimal _subtotal;
        private readonly decimal _discount;
        private readonly decimal _total;

        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(List<CartItemControl> cartItems, decimal subtotal, decimal discount, decimal total) : this()
        {
            _cartItems = cartItems ?? new List<CartItemControl>();
            _subtotal = subtotal;
            _discount = discount;
            _total = total;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;

            // Populate Payment Methods
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "KHQR" });
            cmbPaymentMethod.SelectedIndex = 0;

            // Display Totals
            txtSubtotal.Text = $"${_subtotal:N2}";
            txtDiscount.Text = $"${_discount:N2}";
            txtTotal.Text = $"${_total:N2}";

            // Default Paid Amount to total
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_cartItems == null || _cartItems.Count == 0)
            {
                MessageBox.Show("The cart is empty. Cannot process payment.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            Sales sale = new Sales
            {
                Invoice_number = SalesDAL.GenerateInvoiceNumber(),
                Subtotal = _subtotal,
                Discount_amount = _discount,
                Grand_total = _total,
                Payment_method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash",
                Sale_date = DateTime.Now
            };

            List<SalesDetails> details = new List<SalesDetails>();
            foreach (var item in _cartItems)
            {
                if (item.Product != null)
                {
                    details.Add(new SalesDetails
                    {
                        Invoice_number = sale.Invoice_number,
                        Product_id = item.Product.Id,
                        Quantity = item.Quantity,
                        Unit_price = item.Product.Selling_price,
                        Subtotal = item.Subtotal
                    });
                }
            }

            string errorMessage = string.Empty;
            bool success = await Task.Run(() => _salesDAL.CreateSale(sale, details, out errorMessage));

            if (success)
            {
                MessageBox.Show(
                    $"Payment completed successfully!\n\nInvoice Number: {sale.Invoice_number}\nPayment Method: {sale.Payment_method}\nTotal Amount: ${_total:N2}",
                    "Sale Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                MessageBox.Show($"Failed to complete payment: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

