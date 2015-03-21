using Adora_Apparel1.ServiceReference1;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Adora_Apparel1.ViewModel
{
    class FOBstockViewModel : INotifyPropertyChanged,IDataErrorInfo
    {
        private fob_stock_orders orders;
        private ICommand command;
        private Service1Client dataClient = new Service1Client();

        public FOBstockViewModel()
        {
            try
            {
                Refresh = new RelayCommand(refresh_shipcode);
                command = new RelayCommand(AddFobStock);
                Update = new RelayCommand(UpdateFobStock);
                Delete = new RelayCommand(DeleteFobStock);

            }

            catch (Exception s) { }
        }

        private async void DeleteFobStock(object obj)
        {
            var success = await dataClient.deleteStockOrdersAsync(Ship_code);
            if (success)
            {
                MessageBox.Show("Stock Deleted Successfully");
                var content = dataClient.getStockOrders().ToArray();
                stock_orders.Clear();
                Array.ForEach(content, stock_orders.Add);
            }
        }

        private async void UpdateFobStock(object obj)
        {
            var success =await dataClient.UpdateStockOrderAsync(Factory_Name,Description,Date,Items,NoOfPeices,CostPerPeice,Image,materialAmount,Ship_code);
            if (success)
            {
                MessageBox.Show("Stock Updated Successfully");
                var content = dataClient.getStockOrders().ToArray();
                stock_orders.Clear();
                Array.ForEach(content, stock_orders.Add);
            }
        }

        private ICommand Refresh;

        public ICommand Refresh1
        {
            get { return Refresh; }

        }
        private ICommand Save;

        public ICommand Save1
        {
            get { return Save; }

        }
        private ICommand Delete;

        public ICommand Delete1
        {
            get { return Delete; }

        }
        private ICommand Update;

        public ICommand Update1
        {
            get { return Update; }

        }
        public ICommand Command
        {
            get
            {
                return command;
            }
        }
        private ObservableCollection<fob_stock_orders> stock_orders;
        public ObservableCollection<fob_stock_orders> Stock_orders
        {

            get
            {

                Service1Client st=new Service1Client();
                stock_orders = new ObservableCollection<fob_stock_orders>(st.getStockOrders());
                st.Close();
                return stock_orders;

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

        private string Factory_Name;

        public string Factory_Name1
        {
            get { return Factory_Name; }
            set { Factory_Name = value; RaisePropertyChanged("Factory_Name"); }
        }

        private string Description;

        public string Description1
        {
            get { return Description; }
            set { Description = value; RaisePropertyChanged("Description"); }
        }

        private Nullable<System.DateTime> Date;

        public Nullable<System.DateTime> Date1
        {
            get { return Date; }
            set { Date = value; RaisePropertyChanged("Date"); }
        }

        private string Items;

        public string Item1
        {
            get { return Items; }
            set { Items = value; RaisePropertyChanged("Item"); }
        }

        private Nullable<double> NoOfPeices;

        public Nullable<double> NoOfPeices1
        {
            get { return NoOfPeices; }
            set { NoOfPeices = value; RaisePropertyChanged("NoOfPeices"); }
        }

        private Nullable<double> CostPerPeice;

        public Nullable<double> CostPerPeice1
        {
            get { return CostPerPeice; }
            set { CostPerPeice = value; RaisePropertyChanged("CostPerPeice"); }
        }


        private string Image="asasas";

        public string Image1
        {
            get { return Image; }
            set { Image = value; RaisePropertyChanged("Image1"); }
        }

        private Nullable<double> materialAmount;

        public Nullable<double> MaterialAmount
        {
            get { return materialAmount; }
            set { materialAmount = value; RaisePropertyChanged("MaterialAmount"); }
        }

        private string Shippment_code;

        public string Shippment_code1
        {
            get { return Shippment_code; }
            set { Shippment_code = value; RaisePropertyChanged("Shippment_code1"); }
        }

        private string Ship_code;

        public string Ship_code1
        {
            get { return Ship_code; }
            set { Ship_code = value; RaisePropertyChanged("Ship_code"); }
        }

        ObservableCollection<string> result;

        public ObservableCollection<string> Ship_code_list
        {
            get
            {
                Service1Client client = new Service1Client();
                result = new ObservableCollection<string>(client.getshippmentTitle());
                client.Close();
                return result;
            }

        }

        private void refresh_shipcode(object obj)
        {
            var cc = dataClient.getshippmentTitle().ToArray();
            result.Clear();
            Array.ForEach(cc, result.Add);
        }

        private async void AddFobStock(object obj)
        {
            // MessageBox.Show("Fabric Adding Error....!", "Error", MessageBoxButton.OK, MessageBoxIcon.Error);

            try
            {
                //dataClient = new Service1Client();

                var success = dataClient.addStockOrders(Factory_Name, Description, Date, Items, NoOfPeices, CostPerPeice, Image, MaterialAmount, Ship_code);
                if (success)
                {
                    MessageBox.Show("Stock in Hand Adding ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //to instantly show the search when we add data 
                    /*var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobfabric_purchase.Clear();
                    Array.ForEach(content, fobfabric_purchase.Add);
                    dataClient.Close();*/
                    var content = dataClient.getStockOrders().ToArray();
                    stock_orders.Clear();
                    Array.ForEach(content, stock_orders.Add);
                }

                else {

                    MessageBox.Show("Unabale to Connect");
                }
            }

            catch (Exception d)
            {
                MessageBox.Show(" Stock in Hand adding error..!","error..!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { return Validate(columnName); }
        }
        private string Validate(string columnName)
        {
            string validationMessage = string.Empty;
            switch (columnName)
            {

                case "NoOfPeices1":
                    if (NoOfPeices1 <= 0)
                        validationMessage = "Please enter valid Peices";
                    break;
                case "CostPerPeice1":
                    if (CostPerPeice1 <= 0)
                        validationMessage = "Please enter valid  Price";
                    break;
                case "MaterialAmount":
                    if (MaterialAmount <= 0)
                        validationMessage = "Please enter valid Amount";
                    break;

            }
            return validationMessage;
        }
    }
}
