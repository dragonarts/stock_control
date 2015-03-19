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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Adora_Apparel1.ViewModel;

namespace Adora_Apparel1.Pages
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class BasicPage1 
    {
        private StockPurchaseViewModel view = new StockPurchaseViewModel();
        
        public BasicPage1()
        {
            InitializeComponent();
            //System.Windows.MessageBox.Show(view.Stock_purchase.ToString());
            //load_shippment_title();
            this.Loaded += (s, e) => { this.DataContext = this.view; };
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewShippment form = new AddNewShippment(view);
           // WindowInteropHelper wih = new WindowInteropHelper(this);
            //wih.Owner = form.Handle;
            form.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationCommands.GoToPage.Execute("/Pages/UpdateStockPurchase.xaml",this);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationCommands.GoToPage.Execute("/Pages/UpdateStockPurchase.xaml", this);
        }

        /*public void load_shippment_title()
        {

            StockPurchaseViewModel source = new StockPurchaseViewModel("test");
            ship_title.ItemsSource = source.Ship_code_list;
        }*/

       
    
    }
}
