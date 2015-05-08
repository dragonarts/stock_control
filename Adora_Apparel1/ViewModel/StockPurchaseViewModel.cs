
using Adora_Apparel1.Pages;
using Adora_Apparel1.ServiceReference1;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Adora_Apparel1.ViewModel
{
    public class StockPurchaseViewModel:INotifyPropertyChanged,IDataErrorInfo
    {
        
        private stock_purchasing purchase;
        private stock_purchasing selectedRow;
        private bool status=true;

        public bool Status
        {
            get { return status; }
            set { 
                status = value;
                RaisePropertyChanged("Status");
            }
        }
        private ICommand refresh;

        public ICommand Refresh
        {
            get { return refresh; }
            set { refresh = value; }
        }
        public stock_purchasing SelectedRow
        {
            get { return selectedRow; }
            set { selectedRow = value; RaisePropertyChanged("SelectedRow"); }
        }
        private ICommand command;
        private ICommand addShipment;

        public ICommand AddShipment
        {
            get { return addShipment; }
            set { addShipment = value; }
        }
        
        private Service1Client dataClient = new Service1Client();
        public ICommand Command
        {
            get
            {
                return command;
            }
        }

        private ObservableCollection<stock_purchasing> stock_purchase;
        public  ObservableCollection<stock_purchasing> Stock_purchase
        {

            get
            {

                Service1Client st = new Service1Client();
                stock_purchase = new ObservableCollection<stock_purchasing>(st.getstockPurchasingAsync().GetAwaiter().GetResult());
                st.Close();
                return stock_purchase;
                
            }
            
            
        }

        private ObservableCollection<string> ship_code_list;

        public ObservableCollection<string> Ship_code_list
        {
            get
            {
                Service1Client client = new Service1Client();
                ship_code_list = new ObservableCollection<string>(client.getshippmentTitleAsync().GetAwaiter().GetResult());
                client.Close();
                return ship_code_list;
            }
            set
            {

                ship_code_list = value;
                RaisePropertyChanged("Ship_code_list");
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

        private Nullable<int> peices=null;
        public Nullable<int> Peices
        {
            get
            {
                 return peices;
            }
            set
            {
                //int checking;
                //bool check = int.TryParse(value.ToString(), out checking);
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
               // price_per_peice = Math.Round(value.Value, 2, MidpointRounding.AwayFromZero);
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
               // transport_cost = Math.Round(value.Value, 2,MidpointRounding.AwayFromZero);
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
               // supplier_comission = Math.Round(value.Value, 2, MidpointRounding.AwayFromZero);
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
                //miscellenouse = Math.Round(value.Value, 2, MidpointRounding.AwayFromZero);
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

           // RefreshEvents();
            command = new RelayCommand(addStock);
            addShipment = new RelayCommand(addShip);
            refresh = new RelayCommand(refreshShipTitle);
        }

        private void refreshShipTitle(object obj)
        {
            var cc = dataClient.getshippmentTitle().ToArray();
            ship_code_list.Clear();
            Array.ForEach(cc, ship_code_list.Add);
        }

        private void addShip(object obj)
        {
            AddNewShippment form = new AddNewShippment();
            form.Show();
        }

        private string sub_cat_name;

        public string Sub_cat_name
        {
            get { return sub_cat_name; }
            set { sub_cat_name = value; }
        }
        private async void addStock(object obj) {

            //selectedRow = new stock_purchasing();
            if (status)
            {
                Nullable<double> total_shippment_cost = (peices * price_per_peice) + transport_cost + supplier_comission + miscellenouse;
                Nullable<double> actual_cost = total_shippment_cost / peices;
                total_shippment_cost = Math.Round(total_shippment_cost.Value, 2, MidpointRounding.AwayFromZero);
                actual_cost = Math.Round(Math.Round(actual_cost.Value, 2, MidpointRounding.AwayFromZero));
                var success = await dataClient.addStockPurchaseAsync(ship_code, peices, price_per_peice, transport_cost, supplier_comission, miscellenouse, total_shippment_cost, actual_cost, 1, shipped_date, sub_cat_name);
                // var success = await dataClient.addStockPurchaseAsync(SelectedRow.Shippment_code,SelectedRow.NoOfPeices,SelectedRow.PricePerPiece,SelectedRow.Transport_Cost,SelectedRow.Supplier_Commision,SelectedRow.Miscellanouse, total_shippment_cost, actual_cost, 1,SelectedRow.shipped_date);
                if (success)
                {

                    MessageBox.Show("Data Inserted Successfully!");
                    var content = dataClient.getstockPurchasing().ToArray();
                    stock_purchase.Clear();
                    Array.ForEach(content, stock_purchase.Add);
                    //dataClient.Close();
                    Ship_code = "";
                    Peices = null;
                    Price_per_peice = null;
                    Transport_cost = null;
                    Supplier_comission = null;
                    Miscellenouse = null;
                    Shipped_date = null;
                }
                else
                {

                    MessageBox.Show("Unable to Enter Data");
                }
            }
            else {

                MessageBox.Show("Please Correct errors before add");
            }

        }

        public void ReloadShipmentTitle(string val)
        {

            this.Ship_code_list.Add(val);
                
        }



        public string Error
        {
            get { 
                throw new NotImplementedException();
                Status = false;
            }
            
        }

        public string this[string columnName]
        {
            get { return Validate(columnName); }
        }

        int check;
        private string Validate(string columnName)
        {
            string validationMessage = string.Empty;
            double res;
            int result;
            switch (columnName)
            { 
                case "Peices":
                    if (Peices <= 0 || !int.TryParse(Peices.ToString(),out result))
                    {
                        validationMessage = "Please enter valid Peices";
                        Status = false;
                    }
                    else {

                        Status = true;
                    }
                    break;
                case "Price_per_peice":
                    if (Price_per_peice <= 0 || !Double.TryParse(Price_per_peice.ToString(),out res))
                    {
                        validationMessage = "Please enter valid Price";
                        Status = false;
                    }
                    else {

                        Status = true;
                    }
                    break;
                case "Supplier_comission":
                    if (Supplier_comission <= 0 || !Double.TryParse(Supplier_comission.ToString(),out res))
                    {
                        validationMessage = "Please enter valid Comission";
                        Status = false;
                    }
                    else {

                        Status = true;
                    }
                    break;
                case "Miscellenouse":
                    if (Miscellenouse <= 0 || !Double.TryParse(Miscellenouse.ToString(),out res))
                    {
                        validationMessage = "Please enter valid Miscellenouse";
                        Status = false;
                    }
                    else {

                        Status = true;
                    }
                    break;
                case "Transport_cost":
                    if (Transport_cost <= 0 || !Double.TryParse(Transport_cost.ToString(),out res))
                    {
                        validationMessage = "Please enter valid cost";
                        Status=false;
                    }
                    else
                    {
                        Status = true;
                    }
                    break;

            }
            return validationMessage;
        }

        
    }
}
