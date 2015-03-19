using Adora_Apparel1.ServiceReference1;
using FirstFloor.ModernUI.Presentation;
using System;
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
    class UpdateStockPurchaseViewModel : INotifyPropertyChanged
    {
        private stock_purchasing purchase;
        private stock_purchasing selectedRow;

        public stock_purchasing SelectedRow
        {
            get { return selectedRow; }
            set { selectedRow = value; RaisePropertyChanged("SelectedRow"); }
        }
        private ICommand command;
        private ICommand deleteStock;

        public ICommand DeleteStock
        {
            get { return deleteStock; }
            set { deleteStock = value; }
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

        private string sub_cat_name;

        public string Sub_cat_name
        {
            get { return sub_cat_name; }
            set { sub_cat_name = value; }
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
        public UpdateStockPurchaseViewModel() {

           // RefreshEvents();
            command = new RelayCommand(updateStock);
            deleteStock = new RelayCommand(deleteStocks);
        }

        private async void deleteStocks(object obj)
        {
            var success = await dataClient.deleteStockPurchaseAsync(SelectedRow.idStock_purchasing);
            if (success)
            {

                MessageBox.Show("Stock Deleted Successfully!");
                var content = dataClient.getstockPurchasing().ToArray();
                stock_purchase.Clear();
                Array.ForEach(content, stock_purchase.Add);
            }
        }

        private async void updateStock(object obj) {

            //selectedRow = new stock_purchasing();
            Nullable<double> total_shippment_cost = (SelectedRow.NoOfPeices * SelectedRow.PricePerPiece) + SelectedRow.Transport_Cost +SelectedRow.Supplier_Commision + SelectedRow.Miscellanouse;
            Nullable<double> actual_cost = total_shippment_cost / SelectedRow.NoOfPeices;
            //var success = await dataClient.addStockPurchaseAsync(ship_code,peices,price_per_peice,transport_cost,supplier_comission,miscellenouse,total_shippment_cost,actual_cost,1,shipped_date);
            var success = await dataClient.updateStockPurchaseAsync(SelectedRow.Shippment_code, SelectedRow.NoOfPeices, SelectedRow.PricePerPiece, SelectedRow.Transport_Cost, SelectedRow.Supplier_Commision, SelectedRow.Miscellanouse, total_shippment_cost, actual_cost,SelectedRow.idStock_purchasing, SelectedRow.shipped_date,SelectedRow.sub_cat_name);
            if (success)
            {

                MessageBox.Show("Stock Updated Successfully!");
                var content = dataClient.getstockPurchasing().ToArray();
                stock_purchase.Clear();
                Array.ForEach(content,stock_purchase.Add);
                //dataClient.Close();
               
            }
            else {

                MessageBox.Show("Unable to Enter Data");
            }

        }

        public void ReloadShipmentTitle(string val)
        {

            this.Ship_code_list.Add(val);
                
        }

       
    }
    
}
