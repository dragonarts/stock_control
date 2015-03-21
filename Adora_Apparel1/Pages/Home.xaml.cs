using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Timers;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {

        string days;
        private string _currenttime;
        private TimeZoneInfo _selectedTimeZone;
        public Home()
        {
            InitializeComponent();
            //DateTime moment = new DateTime();
            int day = (int)DateTime.Now.DayOfWeek;
            if (day == 0)
                days = "Sunday";
            else if (day == 1)
                days = "Monday";
            else if (day == 2)
                days = "Tuesday";
            else if (day == 3)
                days = "Wednesday";
            else if (day == 4)
                days = "Thursday";
            else if (day == 5)
                days = "Friday";
            else if (day == 6)
                days = "Saturday";
            int dates = DateTime.Now.Day;
            int year = DateTime.Now.Year;
            int months = DateTime.Now.Month;
            string month = "";
            if (months == 1)
                month = "January";
            else if (months == 2)
                month = "February";
            else if (months == 3)
                month = "March";
            else if (months == 4)
                month = "April";
            else if (months == 5)
                month = "May";
            else if (months == 6)
                month = "June";
            else if (months == 7)
                month = "July";
            else if (months == 8)
                month = "August";
            else if (months == 9)
                month = "September";
            else if (months == 10)
                month = "October";
            else if (months == 11)
                month = "November";
            else if (months == 12)
                month = "December";

            Day.Content="    "+days;
            date.Content = "          "+dates;
            year_month.Content = "          " + month + "," + year;
            //time.Content ="\t"+DateTime.Now.ToString("hh:mm:ss");
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer(System.Windows.Threading.DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => {

                Timer_Click();
            };
        }
        public List<TimeZoneInfo> TimeZones {

            get { return TimeZoneInfo.GetSystemTimeZones().ToList(); }
        }

        public string CurrentTime {


            get { return _currenttime; }
            set { _currenttime = value; OnPropertyChanged("CurrentTime"); }
        }

        public TimeZoneInfo SelectedTimeZone {


            get { return _selectedTimeZone; }
            set {

                _selectedTimeZone = value;
                OnPropertyChanged("SelectedTimeZone");
                Timer_Click();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) {

            if (PropertyChanged != null) {


                PropertyChanged(this,new PropertyChangedEventArgs(property));
            }
        
        }
        private void Timer_Click() {

            DateTime d;
            d = DateTime.Now;
            time.Content = "\t"+d.Hour + ":" + d.Minute + ":" + d.Second;
        }
        private void WrapPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            try
            {

                NavigationCommands.GoToPage.Execute("/Pages/stocks.xaml",this);
               // NavigationCommands.GoToPage.Execute("/Pages/FOB_PURCHASING/SelectType.xaml",this);
                
            }
            catch (Exception ex) {

                MessageBox.Show(ex.ToString());
            }

        }
        private void FOBPurchasing_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

               // NavigationCommands.GoToPage.Execute("/Pages/stocks.xaml", this);
                NavigationCommands.GoToPage.Execute("/Pages/FOB_PURCHASING/SelectType.xaml",this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void FOBStockInHand_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            try
            {

                // NavigationCommands.GoToPage.Execute("/Pages/stocks.xaml", this);
                NavigationCommands.GoToPage.Execute("/Pages/fobStockInhand.xaml", this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void FOBOverhead_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                // NavigationCommands.GoToPage.Execute("/Pages/stocks.xaml", this);
                NavigationCommands.GoToPage.Execute("/Pages/fixOverHead.xaml", this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        //link fob purchase to home-------------

     
        

        //--------end link------------------------
    }
}
