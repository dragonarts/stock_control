
using Adora_Apparel1.ServiceReference1;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Adora_Apparel1.ViewModel
{
    public class StockPurchaseViewModel:INotifyPropertyChanged
    {
        
        private stock_purchasing purchase;
        private ICommand command;
        private Service1Client dataClient = new Service1Client();
        public ICommand Command
        {
            get
            {
                return command;
            }
        }

        private ObservableCollection<stock_purchasing> stock_purchase;
        public ObservableCollection<stock_purchasing> Stock_purchase
        {

            get
            {
                Service1Client st = new Service1Client();
                stock_purchase = new ObservableCollection<stock_purchasing>(st.getstockPurchasing());
                st.Close();
                return stock_purchase;
                
            }
            
        }
        //private ObservableCollection<>
        private ObservableCollection<string> ship_code_list;

        public ObservableCollection<string> Ship_code_list
        {
            get
            {
                Service1Client client = new Service1Client();
                ObservableCollection<string> result = new ObservableCollection<string>(client.getshippmentTitle());
                client.Close();
                return result;
            }
        }

        private string ship_code;

        public string Ship_code
        {
            get
            {

                return ship_code;
            }
            set
            {

                ship_code = value;
                RaisePropertyChanged("Ship_code");
            }
        }

        private Nullable<int> peices;

        public Nullable<int> Peices
        {
            get
            {
                return peices;
            }
            set
            {
                peices = value;
                RaisePropertyChanged("Peices");
            } 
        }

        private Nullable<double> price_per_peice;

        public Nullable<double> Price_per_peice
        {
            get
            {
                return price_per_peice;
            }
            set
            {
                price_per_peice = value;
                RaisePropertyChanged("Price_per_peice");
            }
        }

        private Nullable<double> transport_cost;

        public Nullable<double> Transport_cost
        {
            get
            {
                return transport_cost;
            }
            set
            {
                transport_cost = value;
                RaisePropertyChanged("Transport_cost");
            }
        }

        private Nullable<double> supplier_comission;

        public Nullable<double> Supplier_comission
        {
            get
            {
                return supplier_comission;
            }
            set
            {
                supplier_comission = value;
                RaisePropertyChanged("Supplier_comission");
            }
        
        }


        private Nullable<double> miscellenouse;
        

        public Nullable<double> Miscellenouse
        {
             get
            {
                return miscellenouse;
            }
            set
            {
                miscellenouse = value;
                RaisePropertyChanged("Miscellenouse");
            }
        }

        private Nullable<System.DateTime> shipped_date;

        public Nullable<System.DateTime> Shipped_date
        {
            get
            {
                return shipped_date;
            }
            set
            {
                shipped_date = value;
                RaisePropertyChanged("Shipped_date");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(p));
            }
        }
        public StockPurchaseViewModel() {

            if(purchase==null)
                this.purchase = new stock_purchasing();
           // RefreshEvents();
            command = new RelayCommand(addStock);
        }


        private async void addStock(object obj) {

            Nullable<double> total_shippment_cost = (peices * price_per_peice) + transport_cost + supplier_comission + miscellenouse;
            Nullable<double> actual_cost = total_shippment_cost / peices;
            var success = await dataClient.addStockPurchaseAsync(ship_code,peices,price_per_peice,transport_cost,supplier_comission,miscellenouse,total_shippment_cost,actual_cost,1,shipped_date);
            if (success)
            {

                MessageBox.Show("Data Inserted Successfully!"+shipped_date);
                var content = dataClient.getstockPurchasing().ToArray();
                stock_purchase.Clear();
                Array.ForEach(content,stock_purchase.Add);
                dataClient.Close();
            }
            else {

                MessageBox.Show("Unable to Enter Data");
            }

        }

        
    }
}
