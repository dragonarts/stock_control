using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using Adora_Apparel1.Pages;
using Adora_Apparel1.ServiceReference1;
using FirstFloor.ModernUI.Presentation;
using System.Xml;

namespace Adora_Apparel1.ViewModel
{
   public class FabricModal : INotifyPropertyChanged,IDataErrorInfo
    {



        private string ship_code;
        private string ftype;
        private Nullable<DateTime> purchase_date;
        private Nullable<int> yardage;
        private Nullable<double> price_per_yard;
        private Nullable<double> transportCost;

        // for do the command part and initialize the view
        //private Fabric fbbpurchasebafric;
        private ICommand command;
        private ICommand commandUpdate;
        private ICommand commandDelete;
        private ICommand commandRefesh;
        private Service1Client dataClient = new Service1Client();



        public FabricModal()
        {
            try
            {
                // if (fbbpurchasebafric == null)
                 //   this.fbbpurchasebafric = new Fabric();
                // RefreshEvents();

                command = new RelayCommand(AddFabricPurchase);
                commandUpdate = new RelayCommand(updateFabricPurchase);
                commandDelete = new RelayCommand(DeleteFabricPurchase);
                commandRefesh = new RelayCommand(refresh_shipcode);
            }
            catch (Exception s)
            {

            }
            
        }
        public ICommand Command
        {
            get{return command;}
        }

        public ICommand CommandUpdate
        {
            get{return commandUpdate;}
        }


        public ICommand CommandDelete
        {
            get{return commandDelete;}
        }


        public ICommand CommandRefesh
        {
            get { return commandRefesh; }
        }


        private async void AddFabricPurchase(object obj)
        {
           
            
            try
            {
                dataClient = new Service1Client();
                var success =  dataClient.addFOBPurchasing(purchase_date, price_per_yard, yardage, transportCost, ship_code);
                if (success)
                {
                    MessageBox.Show("Fabirc Adding ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //to instantly show the search when we add data 
                    var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobfabric_purchase.Clear();
                    Array.ForEach(content, fobfabric_purchase.Add);
                    dataClient.Close();
                }
                else
                {

                    MessageBox.Show("Unable to Enter Data");
                }
            }
            catch (Exception d)
            {
                MessageBox.Show("Fabirc Adding Error....!", "Error....!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void updateFabricPurchase(object obj)
        {
            // MessageBox.Show("Fabric Adding Error....!", "Error", MessageBoxButton.OK, MessageBoxIcon.Error);

            try
            {

                dataClient = new Service1Client();
                var success = dataClient.updateFOBPurchasing(purchase_date, price_per_yard, yardage, transportCost, ship_code);
                if (success)
                {
                    MessageBox.Show("Fabirc Updating ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobfabric_purchase.Clear();
                    Array.ForEach(content, fobfabric_purchase.Add);
                    dataClient.Close();
                    
                }
                else
                {

                    MessageBox.Show("Unable to Update Data");
                }


            }
            catch (Exception d)
            {
                MessageBox.Show("Fabirc Updating Error....!", "Error....!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void DeleteFabricPurchase(object obj)
        {
            try
            {

                dataClient = new Service1Client();
                var success = dataClient.deleteFOBPurchase(ship_code);
                if (success)
                {
                    MessageBox.Show("Fabirc Deleting ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobfabric_purchase.Clear();
                    Array.ForEach(content, fobfabric_purchase.Add);

                    

                    dataClient.Close();
                }
                else
                {

                    MessageBox.Show("Unable to Delete");
                }


            }
            catch (Exception d)
            {
                MessageBox.Show("Fabirc Deleting Error....!", "Error....!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //search-------------

        private fob_purchasing fobpurchase;
        private ObservableCollection<fob_purchasing> fobfabric_purchase;
        public ObservableCollection<fob_purchasing>  Fobfabric_purchase
        {

            get
            {
                Service1Client st = new Service1Client();
                fobfabric_purchase = new ObservableCollection<fob_purchasing>(st.getfabricFOBPurchasing());
                st.Close();
                return fobfabric_purchase;

            }

        }


        private void refresh_shipcode(object obj)
        {
            var cc = dataClient.getshippmentTitle().ToArray();
            result.Clear();
            Array.ForEach(cc, result.Add);
        }
      

        public string Ship_code
        {
            get {return ship_code;}
            set{ship_code = value;RaisePropertyChanged("Ship_code");}
        }


        public string set_ftype
        {
            get { return ftype; }
            set { ftype = value; RaisePropertyChanged("set_ftype"); }
        }


        public Nullable<DateTime> Purchase_date
        {
            get { return purchase_date; }
            set { purchase_date = value; RaisePropertyChanged("Purchase_date"); }
        }

        public Nullable<int> Set_Yardage
        {
            get { return yardage; }
            set { yardage = value; RaisePropertyChanged("Set_Yardage"); }
        }

        public Nullable<double> Set_price_per_yard
        {
            get { return price_per_yard; }
            set { price_per_yard = value; RaisePropertyChanged("Set_price_per_yard"); }
        }


        public Nullable<double> Set_t_cost
        {
            get { return transportCost; }
            set { transportCost = value; RaisePropertyChanged("Set_t_cost"); }
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(p));
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

                case "Set_Yardage":
                    if (Set_Yardage <= 0)
                        validationMessage = "Please enter valid Yardage";
                    break;
                case "Set_price_per_yard":
                    if (Set_price_per_yard <= 0)
                        validationMessage = "Please enter valid  Price";
                    break;
                case "Set_t_cost":
                    if (Set_t_cost <= 0)
                        validationMessage = "Please enter valid Cost";
                    break;

            }
            return validationMessage;
        }
    }
}
