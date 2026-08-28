using Supermarket.Utils;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplierModel = Supermarket.Model.Suppliers;

namespace Supermarket.UI.Purchasing_and_Suppliers
{
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displaySuppliers);
            displaySuppliers.AutoGenerateColumns = false;
            //displaySuppliers.RowTemplate.Height = 45;
            this.btnAdd.Click += btnAdd_Click;
            this.btnEdit.Click += btnEdit_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnRefesh.Click += btnRefresh_Click;
            this.txtSearch.TextChanged += txtSearch_TextChanged;
            this.cmbSortColumn.SelectedIndexChanged += cmbSortColumn_SelectedIndexChanged;
            this.btnSort.Click += btnSort_Click;
        }

        private readonly SuppliersDAL _suppliersDAL = new SuppliersDAL();
        private List<SupplierModel> _allSuppliers = new List<SupplierModel>();

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.Items.Add("Company Name");
            cmbSortColumn.Items.Add("Contact Name");
            cmbSortColumn.Items.Add("Phone");
            cmbSortColumn.Items.Add("Email");
            cmbSortColumn.Items.Add("Address");
            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmSuppliers_Load(object sender, EventArgs e)
        {
            PopulateSortColumns();
            displaySuppliers.AutoGenerateColumns = false;
            txtSearch.PlaceholderForeColor = Color.Gray;
            await LoadSuppliersAsync();
        }

        private async Task LoadSuppliersAsync()
        {
            _allSuppliers = await Task.Run(() => _suppliersDAL.GetAllSuppliers());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allSuppliers == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            IEnumerable<SupplierModel> query = _allSuppliers;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c =>
                    c.SupplierId.ToString().Contains(keyword) ||
                    (c.CompanyName != null && c.CompanyName.ToLower().Contains(keyword)) ||
                    (c.ContactName != null && c.ContactName.ToLower().Contains(keyword)) ||
                    (c.Phone != null && c.Phone.ToLower().Contains(keyword)) ||
                    (c.Email != null && c.Email.ToLower().Contains(keyword)) ||
                    (c.Address != null && c.Address.ToLower().Contains(keyword))
                );
            }

            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Id";
            bool isDescending = btnSort.Checked;

            switch (selectedCol)
            {
                case "Company Name":
                    query = isDescending ? query.OrderByDescending(c => c.CompanyName) : query.OrderBy(c => c.CompanyName);
                    break;
                case "Contact Name":
                    query = isDescending ? query.OrderByDescending(c => c.ContactName) : query.OrderBy(c => c.ContactName);
                    break;
                case "Phone":
                    query = isDescending ? query.OrderByDescending(c => c.Phone) : query.OrderBy(c => c.Phone);
                    break;
                case "Email":
                    query = isDescending ? query.OrderByDescending(c => c.Email) : query.OrderBy(c => c.Email);
                    break;
                case "Address":
                    query = isDescending ? query.OrderByDescending(c => c.Address) : query.OrderBy(c => c.Address);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(c => c.SupplierId) : query.OrderBy(c => c.SupplierId);
                    break;
            }

            displaySuppliers.AutoGenerateColumns = false;
            displaySuppliers.DataSource = null;
            displaySuppliers.DataSource = query.ToList();
        }

        private long GetSelectedSupplierId()
        {
            if (displaySuppliers.CurrentRow != null)
            {
                if (displaySuppliers.CurrentRow.DataBoundItem is SupplierModel supplier)
                {
                    return supplier.SupplierId;
                }
                else if (displaySuppliers.CurrentRow.Cells["colId"].Value != null &&
                         long.TryParse(displaySuppliers.CurrentRow.Cells["colId"].Value.ToString(), out long id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedSupplierName()
        {
            if (displaySuppliers.CurrentRow != null)
            {
                if (displaySuppliers.CurrentRow.DataBoundItem is SupplierModel supplier)
                {
                    return supplier.CompanyName;
                }
                else if (displaySuppliers.Columns.Contains("colCompanyName") && displaySuppliers.CurrentRow.Cells["colCompanyName"].Value != null)
                {
                    return displaySuppliers.CurrentRow.Cells["colCompanyName"].Value.ToString();
                }
                else if (displaySuppliers.Columns.Contains("colSupplierName") && displaySuppliers.CurrentRow.Cells["colSupplierName"].Value != null)
                {
                    return displaySuppliers.CurrentRow.Cells["colSupplierName"].Value.ToString();
                }
                else if (displaySuppliers.Columns.Contains("CompanyName") && displaySuppliers.CurrentRow.Cells["CompanyName"].Value != null)
                {
                    return displaySuppliers.CurrentRow.Cells["CompanyName"].Value.ToString();
                }
            }
            return "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditSuppliers())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadSuppliersAsync();
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            long selectedSupplierId = GetSelectedSupplierId();
            if (selectedSupplierId <= 0)
            {
                MessageBox.Show("Please select a supplier to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new frmAddEditSuppliers(selectedSupplierId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadSuppliersAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            long selectedSupplierId = GetSelectedSupplierId();
            if (selectedSupplierId <= 0)
            {
                MessageBox.Show("Please select a supplier to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedSupplierName = GetSelectedSupplierName();

            if (MessageBox.Show($"Are you sure you want to delete the supplier '{selectedSupplierName}'?",
                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await Task.Run(() => _suppliersDAL.DeleteSupplier(selectedSupplierId));

                if (result)
                {
                    MessageBox.Show("Supplier deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadSuppliersAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete supplier. It may be in use by existing products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            if (cmbSortColumn.Items.Count > 0)
            {
                cmbSortColumn.SelectedIndex = 0;
            }
            btnSort.Checked = false;
            await LoadSuppliersAsync();
        }
    }
}

