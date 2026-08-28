using Supermarket.Utils;
using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI.Purchasing_and_Suppliers
{
    using ProductModel = Supermarket.Model.Products;
    using SupplierModel = Supermarket.Model.Suppliers;

    public partial class frmAddPurchaseOrder : Form
    {
        private readonly PurchaseOrdersDAL _purchaseOrdersDAL = new PurchaseOrdersDAL();
        private readonly SuppliersDAL _suppliersDAL = new SuppliersDAL();
        private readonly ProductsDAL _productsDAL = new ProductsDAL();

        private List<SupplierModel> _suppliersList = new List<SupplierModel>();
        private List<ProductModel> _productsList = new List<ProductModel>();
        private readonly List<PurchaseItemViewModel> _lineItems = new List<PurchaseItemViewModel>();

        public frmAddPurchaseOrder()
        {
            InitializeComponent();
            UIThemeHelper.ApplyModernGridStyle(displayItems);
            displayItems.AutoGenerateColumns = false;
            displayItems.RowTemplate.Height = 38;

            this.btnAddItem.Click += btnAddItem_Click;
            this.btnRemoveItem.Click += btnRemoveItem_Click;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.btnClose.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
            this.txtQuantity.TextChanged += (s, e) => CalculateItemSubtotal();
            this.txtUnitCost.TextChanged += (s, e) => CalculateItemSubtotal();
            this.displayItems.CellFormatting += displayItems_CellFormatting;
        }

        private async void frmAddPurchaseOrder_Load(object sender, EventArgs e)
        {
            txtPurchaseNumber.Text = _purchaseOrdersDAL.GenerateNextPurchaseNumber();
            dtpPurchaseDate.Value = DateTime.Now;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Received");
            cmbStatus.SelectedIndex = 0;

            await LoadSuppliersAndProductsAsync();
        }

        private async Task LoadSuppliersAndProductsAsync()
        {
            try
            {
                _suppliersList = await Task.Run(() => _suppliersDAL.GetAllSuppliers());
                _productsList = await Task.Run(() => _productsDAL.GetAllProducts());

                // Populate Suppliers
                cmbSupplier.DataSource = null;
                cmbSupplier.DisplayMember = "Company_name";
                cmbSupplier.ValueMember = "Id";
                cmbSupplier.DataSource = _suppliersList;

                // Populate Products
                cmbProduct.DataSource = null;
                cmbProduct.DisplayMember = "Name";
                cmbProduct.ValueMember = "Id";
                cmbProduct.DataSource = _productsList;

                if (_productsList.Count > 0)
                {
                    cmbProduct.SelectedIndex = 0;
                    UpdateUnitCostFromProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load reference data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUnitCostFromProduct();
        }

        private void UpdateUnitCostFromProduct()
        {
            if (cmbProduct.SelectedItem is ProductModel selectedProduct)
            {
                txtUnitCost.Text = selectedProduct.Cost_price.ToString("0.00");
                CalculateItemSubtotal();
            }
        }

        private void CalculateItemSubtotal()
        {
            int.TryParse(txtQuantity.Text.Trim(), out int qty);
            decimal.TryParse(txtUnitCost.Text.Trim(), out decimal cost);

            if (qty < 0) qty = 0;
            if (cost < 0) cost = 0;

            decimal subtotal = qty * cost;
            txtSubtotal.Text = subtotal.ToString("$#,##0.00");
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a positive integer greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            if (!decimal.TryParse(txtUnitCost.Text.Trim(), out decimal unitCost) || unitCost < 0)
            {
                MessageBox.Show("Unit cost must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitCost.Focus();
                return;
            }

            var selectedProduct = (ProductModel)cmbProduct.SelectedItem;

            // Check if already in list
            var existingItem = _lineItems.FirstOrDefault(i => i.ProductId == selectedProduct.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += qty;
                existingItem.UnitCost = unitCost;
                existingItem.Subtotal = existingItem.Quantity * existingItem.UnitCost;
            }
            else
            {
                _lineItems.Add(new PurchaseItemViewModel
                {
                    Index = _lineItems.Count + 1,
                    ProductId = selectedProduct.Id,
                    ProductName = selectedProduct.Name,
                    Barcode = selectedProduct.Barcode,
                    Quantity = qty,
                    UnitCost = unitCost,
                    Subtotal = qty * unitCost
                });
            }

            RefreshItemsGrid();

            // Reset input fields
            txtQuantity.Text = "1";
            UpdateUnitCostFromProduct();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (displayItems.CurrentRow == null || displayItems.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = displayItems.CurrentRow.Index;
            if (index >= 0 && index < _lineItems.Count)
            {
                _lineItems.RemoveAt(index);
                // Re-index
                for (int i = 0; i < _lineItems.Count; i++)
                {
                    _lineItems[i].Index = i + 1;
                }
                RefreshItemsGrid();
            }
        }

        private void RefreshItemsGrid()
        {
            displayItems.AutoGenerateColumns = false;
            displayItems.DataSource = null;
            displayItems.DataSource = _lineItems.ToList();

            // Summary
            int totalItems = _lineItems.Count;
            int totalQty = _lineItems.Sum(i => i.Quantity);
            decimal totalAmount = _lineItems.Sum(i => i.Subtotal);

            lblTotalItems.Text = $"Total Items: {totalItems}";
            lblTotalQty.Text = $"Total Qty: {totalQty}";
            lblTotalAmount.Text = $"Grand Total: {totalAmount:$#,##0.00}";
        }

        private void displayItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = displayItems.Columns[e.ColumnIndex].Name;
            if (colName == "colItemUnitCost" || colName == "colItemSubtotal")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = amount.ToString("$#,##0.00");
                    e.FormattingApplied = true;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedItem == null)
            {
                MessageBox.Show("Please select a supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return;
            }

            if (_lineItems.Count == 0)
            {
                MessageBox.Show("Please add at least one product item to the purchase order.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedSupplier = (SupplierModel)cmbSupplier.SelectedItem;
            string purchaseNumber = txtPurchaseNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(purchaseNumber))
            {
                purchaseNumber = _purchaseOrdersDAL.GenerateNextPurchaseNumber();
            }

            string status = cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : "Pending";
            decimal grandTotal = _lineItems.Sum(i => i.Subtotal);

            var purchase = new Purchases
            {
                PurchaseNumber = purchaseNumber,
                SupplierId = selectedSupplier.Id,
                UserId = 1, // Current logged-in user ID default
                PurchaseDate = dtpPurchaseDate.Value,
                Status = status,
                TotalAmount = grandTotal
            };

            var details = _lineItems.Select(item => new PurchaseDetails
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitCost = item.UnitCost,
                Subtotal = item.Subtotal
            }).ToList();

            btnSave.Enabled = false;
            bool success = await Task.Run(() => _purchaseOrdersDAL.CreatePurchaseOrder(purchase, details, out string err));
            btnSave.Enabled = true;

            if (success)
            {
                MessageBox.Show("Purchase Order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public class PurchaseItemViewModel
        {
            public int Index { get; set; }
            public long ProductId { get; set; }
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public int Quantity { get; set; }
            public decimal UnitCost { get; set; }
            public decimal Subtotal { get; set; }
        }
    }
}

