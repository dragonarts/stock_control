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
    /// Interaction logic for StockPurchaseChart.xaml
    /// </summary>
    public partial class StockPurchaseChart : UserControl
    {
        Nullable<System.DateTime> from;
        Nullable<System.DateTime> to;
        public StockPurchaseChart()
        {
            InitializeComponent();
        }

        private bool _isReportViewerLoaded;
        private void ReportViewerLoad()
        {
            if (!_isReportViewerLoaded)
            {
                try
                {
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                    Service1Client st = new Service1Client();
                    IEnumerable<stock_purchasing> dataset = st.getStockPurchaseAsync(from, to).GetAwaiter().GetResult();
                    reportDataSource.Name = "DataSet1";
                    reportDataSource.Value = dataset;
                    this._reportViewerChart.LocalReport.DataSources.Add(reportDataSource);
                    this._reportViewerChart.LocalReport.ReportPath = "SalesChart.rdlc";
                    _reportViewerChart.RefreshReport();
                    _isReportViewerLoaded = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            from = fromDate.SelectedDate.Value;
            to = toDate.SelectedDate.Value;
            _isReportViewerLoaded = false;
            ReportViewerLoad();
        }
    }
}
