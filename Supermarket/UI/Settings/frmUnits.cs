using Supermarket.Utils;
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
using UnitModel = Supermarket.Model.Units;

namespace Supermarket.UI.Settings
{
    public partial class frmUnits : Form
    {
        private readonly UnitsDAL _unitsDAL = new UnitsDAL();
        private List<UnitModel> _allUnits = new List<UnitModel>();

        public frmUnits()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayCategories);
        }

        private void PopulateSortColumns()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Id");
            cmbSortColumn.Items.Add("Name");
            cmbSortColumn.Items.Add("Short Name");
            cmbSortColumn.SelectedIndex = 0;
        }

        private async void frmUnits_Load(object sender, EventArgs e)
        {
            PopulateSortColumns();
            displayCategories.AutoGenerateColumns = false;
            txtSearch.PlaceholderText = "Search by Unit Name or Short Name...";
            txtSearch.PlaceholderForeColor = Color.Gray;
            await LoadUnitsAsync();
        }

        private async Task LoadUnitsAsync()
        {
            try
            {
                _allUnits = await Task.Run(() => _unitsDAL.GetAllUnits());
                ApplyFilterAndSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading units: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilterAndSort()
        {
            if (_allUnits == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();

            // 1. Filter
            IEnumerable<UnitModel> query = _allUnits;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(u =>
                    u.UnitId.ToString().Contains(keyword) ||
                    (!string.IsNullOrEmpty(u.UnitName) && u.UnitName.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(u.ShortName) && u.ShortName.ToLower().Contains(keyword))
                );
            }

            // 2. Sort
            string selectedCol = cmbSortColumn.SelectedItem != null ? cmbSortColumn.SelectedItem.ToString() : "Id";
            bool isDescending = btnSort.Checked; // ON = Descending, OFF = Ascending

            switch (selectedCol)
            {
                case "Name":
                    query = isDescending ? query.OrderByDescending(u => u.UnitName) : query.OrderBy(u => u.UnitName);
                    break;
                case "Short Name":
                    query = isDescending ? query.OrderByDescending(u => u.ShortName) : query.OrderBy(u => u.ShortName);
                    break;
                case "Id":
                default:
                    query = isDescending ? query.OrderByDescending(u => u.UnitId) : query.OrderBy(u => u.UnitId);
                    break;
            }

            displayCategories.DataSource = null;
            displayCategories.DataSource = query.ToList();
        }

        private int GetSelectedUnitId()
        {
            if (displayCategories.CurrentRow != null)
            {
                if (displayCategories.CurrentRow.DataBoundItem is UnitModel unit)
                {
                    return unit.UnitId;
                }
                else if (displayCategories.CurrentRow.Cells["Id"].Value != null &&
                         int.TryParse(displayCategories.CurrentRow.Cells["Id"].Value.ToString(), out int id))
                {
                    return id;
                }
            }
            return 0;
        }

        private string GetSelectedUnitName()
        {
            if (displayCategories.CurrentRow != null)
            {
                if (displayCategories.CurrentRow.DataBoundItem is UnitModel unit)
                {
                    return unit.UnitName;
                }
                else if (displayCategories.CurrentRow.Cells["colCategoryName"].Value != null)
                {
                    return displayCategories.CurrentRow.Cells["colCategoryName"].Value.ToString();
                }
            }
            return "selected unit";
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
            txtSearch.Clear();
            btnSort.Checked = false;
            cmbSortColumn.SelectedIndex = 0;
            await LoadUnitsAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new frmAddEditUnit(0))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await LoadUnitsAsync();
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedId = GetSelectedUnitId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a unit to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new frmAddEditUnit(selectedId))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await LoadUnitsAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedId = GetSelectedUnitId();
            if (selectedId <= 0)
            {
                MessageBox.Show("Please select a unit to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string unitName = GetSelectedUnitName();
            var confirm = MessageBox.Show($"Are you sure you want to delete the unit '{unitName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool deleted = _unitsDAL.DeleteUnit(selectedId);
                if (deleted)
                {
                    MessageBox.Show("Unit deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUnitsAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete the unit. It may be in use by other records.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

