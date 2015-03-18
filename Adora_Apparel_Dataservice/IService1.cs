using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Adora_Apparel_Dataservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<stock_purchasing> getstockPurchasing();

        [OperationContract]
        bool addStockPurchase(string ship_code,Nullable<int> peices,Nullable<double> peice_price,Nullable<double> transport_cost,Nullable<double> supplier_commision,Nullable<double> miscellenaouse,Nullable<double> total_ship_cost,Nullable<double> actual_cost,int status,Nullable<System.DateTime> shipped);

        [OperationContract]
        bool addUser(string username,string firstname,string lastname,string password,string security,string answer);

        [OperationContract]
        bool login(string username,string password);

        [OperationContract]
        bool updateStockPurchase(string ship_code, Nullable<int> peices, Nullable<double> peice_price, Nullable<double> transport_cost, Nullable<double> supplier_commision,Nullable<double> miscellenaouse, Nullable<double> total_ship_cost, Nullable<double> actual_cost, int shipID, Nullable<System.DateTime> shipped);

        [OperationContract]
        bool deleteStockPurchase(int ship_code);

        [OperationContract]
        bool addNewShipment(string shippment_code, string shipment_title, Nullable<bool> status);

        [OperationContract]
        IEnumerable<string> getshippmentTitle();
        // TODO: Add your service operations here

       // [OperationContract]
        //bool addStockOrders(string Factoy_Name, string Description, Nullable<System.DateTime> Date, string Item, Nullable<double> NoOfPeices, Nullable<double> CostPerPeice, string Image, Nullable<double> materialAmount, string Shipment_code);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
}
