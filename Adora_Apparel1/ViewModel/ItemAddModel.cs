using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Adora_Apparel1.ServiceReference1;
using FirstFloor.ModernUI.Presentation;

namespace Adora_Apparel1.ViewModel
{
    public class ItemAddModel : INotifyPropertyChanged,IDataErrorInfo
    {
        private string ship_code;
        private string itype;
        private Nullable<DateTime> purchase_date;
        private Nullable<int> no_of_units;
        private Nullable<double> price_per_item;
        private Nullable<double> transportCost;


        // binding the buttons------------------------//
        private ICommand addItem;
        private ICommand updateItem;
        private ICommand deleteItem;
       // private ICommand commandRefesh;
        private Service1Client dataClient = new Service1Client();

        public ItemAddModel()
        {
            try
            {
                addItem = new RelayCommand(AddItemPurchase);
                updateItem = new RelayCommand(updateItemPurchase);
                deleteItem = new RelayCommand(DeleteItemPurchase);
              //  commandRefesh = new RelayCommand(refresh_shipcode);
            }catch (Exception b)
            {
                
            }
        }


        public ICommand Add
        {
            get
            {
                return addItem;
            }
        }

        public ICommand Update
        {
            get
            {
                return updateItem;
            }
        }

        public ICommand Delete
        {
            get
            {
                return deleteItem;
            }
        }


       // public ICommand CommandRefesh
      //  {
         //   get { return commandRefesh; }
      //  }



        public string Ship_Code
        {
            get { return ship_code; }
            set { ship_code = value; RaisePropertyChanged("Ship_Code"); }
        }

        ObservableCollection<string> result;

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

        public string set_itype
        {
            get { return itype; }
            set { itype = value; RaisePropertyChanged("set_itype"); }
        }


        public Nullable<DateTime> Purchase_date
        {
            get { return purchase_date; }
            set { purchase_date = value; RaisePropertyChanged("Purchase_date"); }
        }


        public Nullable<int> Units
        {
            get { return no_of_units; }
            set { no_of_units = value; RaisePropertyChanged("Units"); }
        }

        public Nullable<double> PPU
        {
            get { return price_per_item; }
            set { price_per_item = value; RaisePropertyChanged("PPU"); }

        }

        public Nullable<double> TCost
        {
            get { return transportCost; }
            set { transportCost = value; RaisePropertyChanged("TCost"); }

        }


       // private void refresh_shipcode(object obj)
        //{
          //  var cc = dataClient.getshippmentTitle().ToArray();
         //   result.Clear();
         //   Array.ForEach(cc, result.Add);
      //  }
      


        //------------------------insert,update,delete, search-----------------------------------//


        private async void AddItemPurchase(object obj)
        {
            
            try
            {
                dataClient = new Service1Client();
                var success = dataClient.addFOBPurchasing(purchase_date, price_per_item, no_of_units, transportCost, ship_code);
                if (success)
                {
                    MessageBox.Show("Item Adding ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //to instantly show the search when we add data 
                    var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobitem_purchase.Clear();
                    Array.ForEach(content, fobitem_purchase.Add);
                    dataClient.Close();
                }
                else
                {

                    MessageBox.Show("Unable to Enter Data");
                }
            }
            catch (Exception d)
            {
                MessageBox.Show("Item Adding Error....!", "Error....!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void updateItemPurchase(object obj)
        {

            try
            {

                dataClient = new Service1Client();
                var success = dataClient.updateFOBPurchasing(purchase_date, price_per_item, no_of_units, transportCost, ship_code);
                if (success)
                {
                    MessageBox.Show("Fabirc Updating ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobitem_purchase.Clear();
                    Array.ForEach(content, fobitem_purchase.Add);
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



        private async void DeleteItemPurchase(object obj)
        {

            try
            {

                dataClient = new Service1Client();
                var success = dataClient.deleteFOBPurchase(ship_code);
                if (success)
                {
                    MessageBox.Show("Fabirc Deleting ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobitem_purchase.Clear();
                    Array.ForEach(content, fobitem_purchase.Add);



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
        private ObservableCollection<fob_purchasing> fobitem_purchase;
        public ObservableCollection<fob_purchasing> FobItem_purchase
        {

            get
            {
                Service1Client st = new Service1Client();
                fobitem_purchase = new ObservableCollection<fob_purchasing>(st.getfabricFOBPurchasing());
                st.Close();
                return fobitem_purchase;

            }

        }





        //-------------------------------------------------------------------------------------







        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string a)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(a));
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

                case "Units":
                    if (Units <= 0)
                        validationMessage = "Please enter valid Units";
                    break;
                case "PPU":
                    if (PPU <= 0)
                        validationMessage = "Please enter valid  Price";
                    break;
                case "TCost":
                    if (TCost <= 0)
                        validationMessage = "Please enter valid Cost";
                    break;

            }
            return validationMessage;
        }
    }
}
