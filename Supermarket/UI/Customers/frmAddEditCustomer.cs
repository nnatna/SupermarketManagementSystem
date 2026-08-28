using System;
using System.Windows.Forms;
using Supermarket.DAL;
using Supermarket.Model;

namespace Supermarket.UI.Customers
{
    public partial class frmAddEditCustomer : Form
    {
        private readonly CustomersDAL _customersDAL = new CustomersDAL();
        private readonly long _customerId = 0;

        public frmAddEditCustomer(long customerId = 0)
        {
            InitializeComponent();
            _customerId = customerId;

            this.Load += frmAddEditCustomer_Load;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            if (_customerId > 0)
            {
                lblTitle.Text = "Edit Customer";
                LoadCustomerData(_customerId);
            }
            else
            {
                lblTitle.Text = "Add Customer";
            }
        }

        private void LoadCustomerData(long id)
        {
            var customer = _customersDAL.GetCustomerById(id);
            if (customer != null)
            {
                txtName.Text = customer.Name ?? "";
                txtPhone.Text = customer.Phone ?? "";
                txtEmail.Text = customer.Email ?? "";
                txtAddress.Text = customer.Address ?? "";
                txtPoints.Text = customer.Points.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            int.TryParse(txtPoints.Text.Trim(), out int points);

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            Model.Customers customer = new Model.Customers
            {
                Id = _customerId,
                Name = name,
                Phone = phone,
                Email = email,
                Address = address,
                Points = points < 0 ? 0 : points
            };

            bool success = false;
            string errorMessage = "";

            if (_customerId > 0)
            {
                success = _customersDAL.UpdateCustomer(customer, out errorMessage);
            }
            else
            {
                customer.CreatedAt = DateTime.Now;
                success = _customersDAL.AddCustomer(customer, out errorMessage);
            }

            if (success)
            {
                MessageBox.Show(_customerId > 0 ? "Customer updated successfully!" : "Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
