using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Supermarket.UI.Report
{
    public partial class frmReportViewer : Form
    {
        private readonly string _reportRdlcFileName;
        private readonly string _datasetName;
        private readonly IEnumerable _dataSource;
        private readonly string _title;

        public frmReportViewer(string reportRdlcFileName, string datasetName, IEnumerable dataSource, string title = "Report Preview")
        {
            InitializeComponent();
            _reportRdlcFileName = reportRdlcFileName;
            _datasetName = datasetName;
            _dataSource = dataSource;
            _title = title;
            this.Text = _title;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                if (reportViewer1 != null)
                {
                    reportViewer1.CancelRendering(0);
                    reportViewer1.Reset();
                }
            }
            catch { }
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReport()
        {
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            // 1. Locate Report Definition (.rdlc)
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string devPath = Path.GetFullPath(Path.Combine(appDir, @"..\..\UI\Report", _reportRdlcFileName));
            string localPath = Path.Combine(appDir, _reportRdlcFileName);
            string uiPath = Path.Combine(appDir, "UI", "Report", _reportRdlcFileName);

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
                reportViewer1.LocalReport.ReportEmbeddedResource = $"Supermarket.UI.Report.{_reportRdlcFileName}";
            }

            // 2. Bind DataSource
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource(_datasetName, _dataSource);
            reportViewer1.LocalReport.DataSources.Add(rds);

            // 3. Display Settings
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }
    }
}
