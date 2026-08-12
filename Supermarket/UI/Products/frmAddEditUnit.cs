using System;
using System.Windows.Forms;
using Supermarket.DAL;
using Supermarket.Model;

namespace Supermarket.UI.Products
{
    public partial class frmAddEditUnit : Form
    {
        private readonly UnitsDAL _unitsDAL = new UnitsDAL();
        private readonly int _unitId = 0;

        public frmAddEditUnit(int unitId = 0)
        {
            InitializeComponent();
            _unitId = unitId;
        }

        private void frmAddEditUnit_Load(object sender, EventArgs e)
        {
            if (_unitId > 0)
            {
                lblTitle.Text = "Edit Unit";
                LoadUnitData(_unitId);
            }
            else
            {
                lblTitle.Text = "Add Unit";
            }
        }

        private void LoadUnitData(int id)
        {
            var unit = _unitsDAL.GetUnitById(id);
            if (unit != null)
            {
                txtUnitName.Text = unit.UnitName ?? "";
                txtShortName.Text = unit.ShortName ?? "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string unitName = txtUnitName.Text.Trim();
            string shortName = txtShortName.Text.Trim();

            if (string.IsNullOrWhiteSpace(unitName))
            {
                MessageBox.Show("Please enter a unit name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return;
            }

            Units unit = new Units
            {
                UnitId = _unitId,
                UnitName = unitName,
                ShortName = shortName
            };

            bool success = false;
            if (_unitId > 0)
            {
                success = _unitsDAL.UpdateUnit(unit);
            }
            else
            {
                success = _unitsDAL.AddUnit(unit);
            }

            if (success)
            {
                MessageBox.Show(_unitId > 0 ? "Unit updated successfully!" : "Unit added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
