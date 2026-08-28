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
        private readonly CustomersDAL _customersDAL = new CustomersDAL();
        private readonly List<CartItemControl> _cartItems;
        private readonly decimal _subtotal;
        private readonly decimal _discount;
        private readonly decimal _total;
        private readonly long? _promotionId;

        private class CustomerComboItem
        {
            public long Id { get; set; }
            public string DisplayText { get; set; }
            public int Points { get; set; }
            public override string ToString() => DisplayText;
        }

        private readonly long _initialCustomerId = 0;

        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(List<CartItemControl> cartItems, decimal subtotal, decimal discount, decimal total, long initialCustomerId = 0, long? promotionId = null) : this()
        {
            _cartItems = cartItems ?? new List<CartItemControl>();
            _subtotal = subtotal;
            _discount = discount;
            _total = total;
            _initialCustomerId = initialCustomerId;
            _promotionId = promotionId;
        }

        private async void frmPayment_Load(object sender, EventArgs e)
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

            // Load Customers
            await LoadCustomersAsync(_initialCustomerId);
        }

        private async Task LoadCustomersAsync(long selectCustomerId = 0)
        {
            var customers = await Task.Run(() => _customersDAL.GetAllCustomers());

            cmbCustomer.Items.Clear();
            cmbCustomer.Items.Add(new CustomerComboItem
            {
                Id = 0,
                DisplayText = "General / Walk-in Customer",
                Points = 0
            });

            int selectedIndex = 0;
            int currentIndex = 1;

            if (customers != null)
            {
                foreach (var c in customers)
                {
                    string phoneText = string.IsNullOrWhiteSpace(c.Phone) ? "" : $" ({c.Phone})";
                    var item = new CustomerComboItem
                    {
                        Id = c.Id,
                        DisplayText = $"{c.Name}{phoneText} [Pts: {c.Points}]",
                        Points = c.Points
                    };
                    cmbCustomer.Items.Add(item);

                    if (selectCustomerId > 0 && c.Id == selectCustomerId)
                    {
                        selectedIndex = currentIndex;
                    }
                    currentIndex++;
                }
            }

            cmbCustomer.SelectedIndex = selectedIndex;
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (var frm = new Customers.frmAddEditCustomer(0))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    // Reload customers and select the most recently added customer
                    var latestCustomers = await Task.Run(() => _customersDAL.GetAllCustomers());
                    long newCustId = latestCustomers != null && latestCustomers.Count > 0 ? latestCustomers.First().Id : 0;
                    await LoadCustomersAsync(newCustId);
                }
            }
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
            btnAddCustomer.Enabled = false;

            long? customerId = null;
            string customerDisplayName = "General Customer";
            if (cmbCustomer.SelectedItem is CustomerComboItem selectedCust && selectedCust.Id > 0)
            {
                customerId = selectedCust.Id;
                customerDisplayName = selectedCust.DisplayText;
            }

            Sales sale = new Sales
            {
                Invoice_number = SalesDAL.GenerateInvoiceNumber(),
                Customer_id = customerId,
                Promotion_id = _promotionId,
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
                int earnedPoints = customerId.HasValue ? (int)Math.Floor(_total) : 0;
                string pointsInfo = earnedPoints > 0 ? $"\nLoyalty Points Earned: +{earnedPoints}" : "";

                MessageBox.Show(
                    $"Payment completed successfully!\n\nInvoice Number: {sale.Invoice_number}\nCustomer: {customerDisplayName}\nPayment Method: {sale.Payment_method}\nTotal Amount: ${_total:N2}{pointsInfo}",
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
                btnAddCustomer.Enabled = true;
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
