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
using Adora_Apparel1.ViewModel;

namespace Adora_Apparel1.Pages
{
    /// <summary>
    /// Interaction logic for FOBItemPurchasing.xaml
    /// </summary>
    public partial class FOBItemPurchasing : UserControl
    {

         private ItemAddModel view = new ItemAddModel();
       
        public FOBItemPurchasing()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = this.view; };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddNewShippment form = new AddNewShippment();
            // WindowInteropHelper wih = new WindowInteropHelper(this);
            //wih.Owner = form.Handle;
           // form.Show();

            AddNewShippment form = new AddNewShippment();
            form.ShowDialog();
            view = new ItemAddModel();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
