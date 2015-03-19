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
    /// Interaction logic for SelectType.xaml
    /// </summary>
    public partial class SelectType : UserControl
    {
        public SelectType()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // NavigationCommands.GoToPage.Execute("/Pages/stocks.xaml", this);
                NavigationCommands.GoToPage.Execute("/Pages/FOB_PURCHASING/FOBItemPurchasing.xaml", this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                // NavigationCommands.GoToPage.Execute("/Pages/stocks.xaml", this);
                NavigationCommands.GoToPage.Execute("/Pages/FOB_PURCHASING/Fabric.xaml", this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           // Page.Response.Redirect("Pages/FOB_PURCHASING/Fabric.xaml/");
        }
    }
}
