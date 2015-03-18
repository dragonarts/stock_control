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
    class fixedOverHeadViewModel : INotifyPropertyChanged
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

    }
}
