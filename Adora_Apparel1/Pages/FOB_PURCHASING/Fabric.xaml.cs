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
    /// Interaction logic for Fabric.xaml
    /// </summary>
    public partial class Fabric : UserControl
    {

        private FabricModal view = new FabricModal();
        public Fabric()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = this.view; };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewShippment form = new AddNewShippment();
            form.ShowDialog();
            view = new FabricModal();
         //   this.ship_title.Items.Refresh();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ship_title_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
