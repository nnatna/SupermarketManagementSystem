using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Supermarket.UI.Point_of_sale
{
    public partial class frmInvoiceReport : Form
    {
        private readonly string _invoiceNumber;

        public frmInvoiceReport()
        {
            InitializeComponent();
        }

        public frmInvoiceReport(string invoiceNumber) : this()
        {
            _invoiceNumber = invoiceNumber;
            this.Text = $"Invoice Print Preview - {_invoiceNumber}";
        }

        private void frmInvoiceReport_Load(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load invoice report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReport()
        {
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            // 1. Locate Report Definition (.rdlc)
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string devPath = Path.GetFullPath(Path.Combine(appDir, @"..\..\UI\Point of sale\rptInvoice.rdlc"));
            string localPath = Path.Combine(appDir, "rptInvoice.rdlc");
            string uiPath = Path.Combine(appDir, "UI", "Point of sale", "rptInvoice.rdlc");

            if (File.Exists(devPath))
            {
                reportViewer1.LocalReport.ReportPath = devPath;
            }
            else if (File.Exists(localPath))
            {
                reportViewer1.LocalReport.ReportPath = localPath;
            }
            else if (File.Exists(uiPath))
            {
                reportViewer1.LocalReport.ReportPath = uiPath;
            }
            else
            {
                // Fallback to embedded resource
                reportViewer1.LocalReport.ReportEmbeddedResource = "Supermarket.UI.Point_of_sale.rptInvoice.rdlc";
            }

            // 2. Fetch Data for Invoice
            DataTable dt = GetInvoiceData(_invoiceNumber);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"No invoice records found for '{_invoiceNumber}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Bind Report Data Source
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rds);

            // 4. Set Parameters if required by RDLC
            try
            {
                if (!string.IsNullOrWhiteSpace(_invoiceNumber))
                {
                    ReportParameter param = new ReportParameter("ReportParameter1", _invoiceNumber);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param });
                }
            }
            catch
            {
                // Parameter might be optional or auto-resolved
            }

            // 5. Display Mode
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private DataTable GetInvoiceData(string invoiceNum)
        {
            DataTable dt = new DataTable("vw_SaleHistory");
            string connStr = ConfigurationManager.ConnectionStrings["SupermarketConnection"]?.ConnectionString
                ?? ConfigurationManager.ConnectionStrings["Supermarket.Properties.Settings.SupermarketManagementConnectionString"]?.ConnectionString
                ?? @"Data Source=.\SQLEXPRESS;Initial Catalog=SupermarketManagement;User Id=sa;Password=123;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query;
                if (!string.IsNullOrWhiteSpace(invoiceNum))
                {
                    query = @"SELECT * FROM vw_SaleHistory WHERE invoice_number = @inv ORDER BY SaleHistoryID ASC";
                }
                else
                {
                    query = @"SELECT TOP 50 * FROM vw_SaleHistory ORDER BY sale_date DESC, SaleHistoryID ASC";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(invoiceNum))
                    {
                        cmd.Parameters.AddWithValue("@inv", invoiceNum);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
