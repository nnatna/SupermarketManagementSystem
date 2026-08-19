using Guna.UI2.WinForms;
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
using ProductModel = Supermarket.Model.Products;

namespace Supermarket.UI.Products
{
    public partial class frmProductsList : Form
    {
        private readonly ProductsDAL _productsDAL = new ProductsDAL();
        private List<ProductModel> _allProducts = new List<ProductModel>();

        public frmProductsList()
        {
            InitializeComponent();
        }

        private void cmbFilter()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.Items.Add("Name");
            cmbSortColumn.Items.Add("Supplier");
            cmbSortColumn.Items.Add("Barcode");
            cmbSortColumn.Items.Add("Category");
            cmbSortColumn.Items.Add("Unit");
            cmbSortColumn.Items.Add("Cost Price");
            cmbSortColumn.Items.Add("Selling Price");
            cmbSortColumn.Items.Add("Stock Quantity");

            cmbSortColumn.SelectedIndex = 0;
        }



        private async void frmProductsList_Load(object sender, EventArgs e)
        {
            cmbFilter();
            displayProducts.AutoGenerateColumns = false;
            await LoadProductsAsync();
            txtSearch.PlaceholderText = "Search by Product...";
            txtSearch.PlaceholderForeColor = Color.Gray;
        }

        //btnAdd
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditProduct frm = new frmAddEditProduct();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadProductsAsync();
            }
        }

        //btnEdit
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            long selectedProductId = GetSelectedProductId();
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Please select a product to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddEditProduct frm = new frmAddEditProduct(selectedProductId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadProductsAsync();
            }
        }

        //btnDelete
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            long selectedProductId = GetSelectedProductId();
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Please select a product to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productName = GetSelectedProductName();
            var dialogResult = MessageBox.Show($"Are you sure you want to delete product '{productName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool deleted = await Task.Run(() => _productsDAL.DeleteProduct(selectedProductId));
                if (deleted)
                {
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                }
            }
        }

        private long GetSelectedProductId()
        {
            if (displayProducts.CurrentRow != null)
            {
                if (displayProducts.CurrentRow.DataBoundItem is ProductModel product)
                {
                    return product.Id;
                }
                else if (displayProducts.CurrentRow.Cells["Id"].Value != null &&
                         long.TryParse(displayProducts.CurrentRow.Cells["Id"].Value.ToString(), out long id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedProductName()
        {
            if (displayProducts.CurrentRow != null)
            {
                if (displayProducts.CurrentRow.DataBoundItem is ProductModel product)
                {
                    return product.Name;
                }
                else if (displayProducts.CurrentRow.Cells["colProductName"].Value != null)
                {
                    return displayProducts.CurrentRow.Cells["colProductName"].Value.ToString();
                }
            }
            return "";
        }

        private async Task LoadProductsAsync()
        {
            _allProducts = await Task.Run(() => _productsDAL.GetAllProducts());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allProducts == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<ProductModel> query = _allProducts;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p =>
                    (p.Name != null && p.Name.ToLower().Contains(keyword)) ||
                    (p.Barcode != null && p.Barcode.ToLower().Contains(keyword)) ||
                    (p.Category != null && p.Category.ToLower().Contains(keyword)) ||
                    (p.Supplier != null && p.Supplier.ToLower().Contains(keyword))
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Id";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "Name":
                    query = isDescending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name);
                    break;
                case "Supplier":
                    query = isDescending ? query.OrderByDescending(p => p.Supplier) : query.OrderBy(p => p.Supplier);
                    break;
                case "Barcode":
                    query = isDescending ? query.OrderByDescending(p => p.Barcode) : query.OrderBy(p => p.Barcode);
                    break;
                case "Category":
                    query = isDescending ? query.OrderByDescending(p => p.Category) : query.OrderBy(p => p.Category);
                    break;
                case "Unit":
                    query = isDescending ? query.OrderByDescending(p => p.Unit) : query.OrderBy(p => p.Unit);
                    break;
                case "Cost Price":
                    query = isDescending ? query.OrderByDescending(p => p.Cost_price) : query.OrderBy(p => p.Cost_price);
                    break;
                case "Selling Price":
                    query = isDescending ? query.OrderByDescending(p => p.Selling_price) : query.OrderBy(p => p.Selling_price);
                    break;
                case "Stock Quantity":
                    query = isDescending ? query.OrderByDescending(p => p.Stock_quantity) : query.OrderBy(p => p.Stock_quantity);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id);
                    break;
            }

            displayProducts.DataSource = null;
            displayProducts.DataSource = query.ToList();
            ApplyColumnOrder();
        }

        private void ApplyColumnOrder()
        {
            string[] columnNames = new string[]
            {
                "Id",
                "ProductImage",
                "colProductName",
                "Barcode",
                "Supplier",
                "Categories",
                "Units",
                "Cost_price",
                "Selling_price",
                "Stock_quantity",
                "Stock_alert_level"
            };

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (displayProducts.Columns.Contains(columnNames[i]))
                {
                    displayProducts.Columns[columnNames[i]].DisplayIndex = i;
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void displayProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && displayProducts.Columns[e.ColumnIndex].Name == "Stock_alert_level")
            {
                var product = displayProducts.Rows[e.RowIndex].DataBoundItem as ProductModel;
                if (product != null)
                {
                    int qty = product.Stock_quantity;
                    int alertLevel = product.Stock_alert_level;

                    if (qty <= alertLevel)
                    {
                        e.Value = "Low";
                        e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // Light Red
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Dark Red
                    }
                    else if (qty <= alertLevel * 2)
                    {
                        e.Value = "Medium";
                        e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // Light Yellow/Amber
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);  // Dark Amber
                    }
                    else
                    {
                        e.Value = "High";
                        e.CellStyle.BackColor = Color.FromArgb(209, 250, 229); // Light Green
                        e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105);  // Dark Green
                    }

                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            txtSearch.PlaceholderText = "Search by Product...";
            if (cmbSortColumn.Items.Count > 0)
            {
                cmbSortColumn.SelectedIndex = 0;
            }
            btnSort.Checked = false;
            await LoadProductsAsync();
        }


    }
}
