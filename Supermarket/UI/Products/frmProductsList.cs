using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.Model;
using Supermarket.DAL;
using Supermarket.UI.Products;

namespace Supermarket.UI.Products
{
    public partial class frmProductsList : Form
    {
        public frmProductsList()
        {
            InitializeComponent();
        }

        ProductsDAL dal = new ProductsDAL();

        private void LoadData()
        {

            displayProducts.DataSource = null;
            displayProducts.DataSource = dal.GetAllProducts();
        }

        private void frmProductsList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}