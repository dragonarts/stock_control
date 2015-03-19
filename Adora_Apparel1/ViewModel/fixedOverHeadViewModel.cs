using Adora_Apparel1.ServiceReference1;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Adora_Apparel1.ViewModel
{
    class fixedOverHeadViewModel : INotifyPropertyChanged
    {
        private fixed_over_heads orders;
        private ICommand command;
        private Service1Client dataClient = new Service1Client();

        public fixedOverHeadViewModel()
        {
            try
            {
                //Refresh = new RelayCommand(refresh_shipcode);
                 command = new RelayCommand(AddFixed);
                // Update = new RelayCommand(UpdateFobStock);

            }

            catch (Exception s) { }
        }

        private ICommand Update;

        public ICommand Update1
        {
            get { return Update; }
         
        }
        private ICommand Delete;

        public ICommand Delete1
        {
            get { return Delete; }
            
        }
        private ICommand Save;

        public ICommand Save1
        {
            get { return Save; }
           
        }

        public ICommand Command
        {
            get
            {
                return command;
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

        private Nullable<System.DateTime> Date_From;

        public Nullable<System.DateTime> Date_From1
        {
            get { return Date_From; }
            set { Date_From = value; RaisePropertyChanged("Date_From"); }
        }

        private Nullable<System.DateTime> Date_To;

        public Nullable<System.DateTime> Date_To1
        {
            get { return Date_To; }
            set { Date_To = value; RaisePropertyChanged("Date_To"); }
        }

        private string Type_Of_Cost;

        public string Type_Of_Cost1
        {
            get { return Type_Of_Cost; }
            set { Type_Of_Cost = value; RaisePropertyChanged("Type_Of_Cost"); }
        }

        private Nullable<double> amount;

        public Nullable<double> Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged("Type_Of_Cost"); }
        }



        private async void AddFixed(object obj)
        {
            // MessageBox.Show("Fixed overhead Adding Error....!", "Error", MessageBoxButton.OK, MessageBoxIcon.Error);

            try
            {
                //dataClient = new Service1Client();

                var success = dataClient.addFixOverHead(Date_From,Date_To,Type_Of_Cost,amount);
                if (success)
                {
                    MessageBox.Show("fixed Overhead Adding ok", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //to instantly show the search when we add data 
                    /*var content = dataClient.getfabricFOBPurchasing().ToArray();
                    fobfabric_purchase.Clear();
                    Array.ForEach(content, fobfabric_purchase.Add);
                    dataClient.Close();*/
                }

                else
                {

                    MessageBox.Show("Unabale to Connect");
                }
            }

            catch (Exception d)
            {
                MessageBox.Show(" fixed Overhead adding error..!", "error..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




    }
}
