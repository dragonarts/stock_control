using Adora_Apparel1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private const int EM_SETCUEBANNER = 0x1501;

        int count_user = 0;
        int count_pass = 0;
        public Login()
        {
            InitializeComponent();
            
        }

        private void username_LostFocus(object sender, RoutedEventArgs e)
        {
            count_user++;
            if(count_user==1)
                username.Text = "Enter User Name";
        }

        private void username_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            username.Text = "";
        }

        private void password_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            password.Password = "";
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            count_pass++;
            if (count_pass == 1)
                password.Password = "Password";
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string user = username.Text;
            string pass = password.Password;
            Service1Client client = new Service1Client();
            if (client.getUserAsync(user, pass).GetAwaiter().GetResult())
            {
                error.Content = "success";
                try
                {

                   NavigationCommands.GoToPage.Execute("/Pages/Home.xaml", this);
                    /*string url = "/Pages/Home.xaml";
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new System.Uri(url, UriKind.RelativeOrAbsolute));*/
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else {

                error.Content = "Wrong username or password please check and re-enter";
                error.Foreground = Brushes.Red;
            }
        }

       
    }
}
