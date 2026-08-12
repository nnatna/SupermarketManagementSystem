using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategoryModel = Supermarket.Model.Categories;

namespace Supermarket.UI.Products
{
    public partial class frmCategories : Form
    {
        private readonly CategoriesDAL _categoriesDAL = new CategoriesDAL();
        private List<CategoryModel> _allCategories = new List<CategoryModel>();

        public frmCategories()
        {
            InitializeComponent();
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.Items.Add("Name");
            cmbSortColumn.Items.Add("Description");
            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmCategoriesUnits_Load(object sender, EventArgs e)
        {
            PopulateSortColumns();
            displayCategories.AutoGenerateColumns = false;
            txtSearch.PlaceholderText = "Search by Category...";
            txtSearch.PlaceholderForeColor = Color.Gray;
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            _allCategories = await Task.Run(() => _categoriesDAL.GetAllCategories());
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (_allCategories == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<CategoryModel> query = _allCategories;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c =>
                    c.CategoryId.ToString().Contains(keyword) ||
                    (c.CategoryName != null && c.CategoryName.ToLower().Contains(keyword)) ||
                    (c.Description != null && c.Description.ToLower().Contains(keyword))
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Id";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "Name":
                    query = isDescending ? query.OrderByDescending(c => c.CategoryName) : query.OrderBy(c => c.CategoryName);
                    break;
                case "Description":
                    query = isDescending ? query.OrderByDescending(c => c.Description) : query.OrderBy(c => c.Description);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(c => c.CategoryId) : query.OrderBy(c => c.CategoryId);
                    break;
            }

            displayCategories.DataSource = null;
            displayCategories.DataSource = query.ToList();
        }

        private int GetSelectedCategoryId()
        {
            if (displayCategories.CurrentRow != null)
            {
                if (displayCategories.CurrentRow.DataBoundItem is CategoryModel category)
                {
                    return category.CategoryId;
                }
                else if (displayCategories.CurrentRow.Cells["Id"].Value != null &&
                         int.TryParse(displayCategories.CurrentRow.Cells["Id"].Value.ToString(), out int id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedCategoryName()
        {
            if (displayCategories.CurrentRow != null)
            {
                if (displayCategories.CurrentRow.DataBoundItem is CategoryModel category)
                {
                    return category.CategoryName;
                }
                else if (displayCategories.Columns.Contains("colCategoryName") && displayCategories.CurrentRow.Cells["colCategoryName"].Value != null)
                {
                    return displayCategories.CurrentRow.Cells["colCategoryName"].Value.ToString();
                }
                else if (displayCategories.Columns.Contains("colProductName") && displayCategories.CurrentRow.Cells["colProductName"].Value != null)
                {
                    return displayCategories.CurrentRow.Cells["colProductName"].Value.ToString();
                }
                else if (displayCategories.Columns.Contains("Name") && displayCategories.CurrentRow.Cells["Name"].Value != null)
                {
                    return displayCategories.CurrentRow.Cells["Name"].Value.ToString();
                }
            }
            return "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditCategory frm = new frmAddEditCategory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadCategoriesAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = GetSelectedCategoryId();
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Please select a category to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddEditCategory frm = new frmAddEditCategory(selectedCategoryId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadCategoriesAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = GetSelectedCategoryId();
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Please select a category to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categoryName = GetSelectedCategoryName();
            var dialogResult = MessageBox.Show($"Are you sure you want to delete category '{categoryName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool deleted = await Task.Run(() => _categoriesDAL.DeleteCategory(selectedCategoryId));
                if (deleted)
                {
                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCategoriesAsync();
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
            await LoadCategoriesAsync();
        }
    }
}
