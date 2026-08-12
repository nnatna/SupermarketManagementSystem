using System;
using System.Windows.Forms;
using Supermarket.DAL;
using Supermarket.Model;

namespace Supermarket.UI.Products
{
    public partial class frmAddEditCategory : Form
    {
        private readonly CategoriesDAL _categoriesDAL = new CategoriesDAL();
        private readonly int _categoryId = 0;

        public frmAddEditCategory(int categoryId = 0)
        {
            InitializeComponent();
            _categoryId = categoryId;
        }

        private void frmAddEditCategory_Load(object sender, EventArgs e)
        {
            if (_categoryId > 0)
            {
                guna2HtmlLabel1.Text = "Edit Category";
                LoadCategoryData(_categoryId);
            }
            else
            {
                guna2HtmlLabel1.Text = "Add Category";
            }
        }

        private void LoadCategoryData(int id)
        {
            var category = _categoriesDAL.GetCategoryById(id);
            if (category != null)
            {
                txtCategoryName.Text = category.CategoryName ?? "";
                txtDescription.Text = category.Description ?? "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            Categories category = new Categories
            {
                CategoryId = _categoryId,
                CategoryName = categoryName,
                Description = description
            };

            bool success = false;
            if (_categoryId > 0)
            {
                success = _categoriesDAL.UpdateCategory(category);
            }
            else
            {
                success = _categoriesDAL.AddCategory(category);
            }

            if (success)
            {
                MessageBox.Show(_categoryId > 0 ? "Category updated successfully!" : "Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
