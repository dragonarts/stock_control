using Adora_Apparel1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adora_Apparel1.Pages
{
    /// <summary>
    /// Interaction logic for StockPurchaseReport.xaml
    /// </summary>
    public partial class StockPurchaseReport : UserControl
    {
        public StockPurchaseReport()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewerLoad;
        }

        private bool _isReportViewerLoaded;
        private void ReportViewerLoad(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                Service1Client st = new Service1Client();
                IEnumerable<stock_purchasing> dataset = st.getstockPurchasingAsync().GetAwaiter().GetResult();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = dataset;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                this._reportViewer.LocalReport.ReportPath = "Report1.rdlc";
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
    }
}
