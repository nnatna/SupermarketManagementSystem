using System;
using System.Windows.Forms;
using Supermarket.DAL;
using Supermarket.Model;

namespace Supermarket.UI.Purchasing_and_Suppliers
{
    public partial class frmAddEditSuppliers : Form
    {
        private readonly SuppliersDAL _suppliersDAL = new SuppliersDAL();
        private readonly long _supplierId = 0;

        public frmAddEditSuppliers(long supplierId = 0)
        {
            InitializeComponent();
            _supplierId = supplierId;

            this.Load += frmAddEditSuppliers_Load;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void frmAddEditSuppliers_Load(object sender, EventArgs e)
        {
            if (_supplierId > 0)
            {
                guna2HtmlLabel1.Text = "Edit Supplier";
                LoadSupplierData(_supplierId);
            }
            else
            {
                guna2HtmlLabel1.Text = "Add Supplier";
            }
        }

        private void LoadSupplierData(long id)
        {
            var supplier = _suppliersDAL.GetSupplierById(id);
            if (supplier != null)
            {
                txtCategoryName.Text = supplier.CompanyName ?? "";
                guna2TextBox1.Text = supplier.ContactName ?? "";
                guna2TextBox2.Text = supplier.Phone ?? "";
                guna2TextBox3.Text = supplier.Email ?? "";
                txtDescription.Text = supplier.Address ?? "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string companyName = txtCategoryName.Text.Trim();
            string contactName = guna2TextBox1.Text.Trim();
            string phone = guna2TextBox2.Text.Trim();
            string email = guna2TextBox3.Text.Trim();
            string address = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show("Please enter a company name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            Suppliers supplier = new Suppliers
            {
                SupplierId = _supplierId,
                CompanyName = companyName,
                ContactName = contactName,
                Phone = phone,
                Email = email,
                Address = address
            };

            bool success = false;
            if (_supplierId > 0)
            {
                success = _suppliersDAL.UpdateSupplier(supplier);
            }
            else
            {
                success = _suppliersDAL.AddSupplier(supplier);
            }

            if (success)
            {
                MessageBox.Show(_supplierId > 0 ? "Supplier updated successfully!" : "Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
