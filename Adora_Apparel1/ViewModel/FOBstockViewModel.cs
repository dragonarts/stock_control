using Adora_Apparel1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Adora_Apparel1.ViewModel
{
    class FOBstockViewModel : INotifyPropertyChanged
    {
        private fob_stock_orders orders;
        private ICommand command;
        private Service1Client dataClient = new Service1Client();

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

        private string Item;

        public string Item1
        {
            get { return Item; }
            set { Item = value; RaisePropertyChanged("Item"); }
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


        private string Image;

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



    }
}
