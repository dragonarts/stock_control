using Adora_Apparel1.ViewModel;
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
    /// Interaction logic for UpdateStockPurchase.xaml
    /// </summary>
    public partial class UpdateStockPurchase : UserControl
    {
        private UpdateStockPurchaseViewModel view = new UpdateStockPurchaseViewModel();
        public UpdateStockPurchase()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = this.view; };
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewShippment form = new AddNewShippment();
            // WindowInteropHelper wih = new WindowInteropHelper(this);
            //wih.Owner = form.Handle;
            form.Show();
        }
    }
}
