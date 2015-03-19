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
        bool addStockPurchase(string ship_code,Nullable<int> peices,Nullable<double> peice_price,Nullable<double> transport_cost,Nullable<double> supplier_commision,Nullable<double> miscellenaouse,Nullable<double> total_ship_cost,Nullable<double> actual_cost,int status,Nullable<System.DateTime> shipped,string sub_cat);

        [OperationContract]
        bool addUser(string username,string firstname,string lastname,string password,string security,string answer);

        [OperationContract]
        bool login(string username,string password);

        [OperationContract]
        bool updateStockPurchase(string ship_code, Nullable<int> peices, Nullable<double> peice_price, Nullable<double> transport_cost, Nullable<double> supplier_commision,Nullable<double> miscellenaouse, Nullable<double> total_ship_cost, Nullable<double> actual_cost, int shipID, Nullable<System.DateTime> shipped,string sub_cat);

        [OperationContract]
        bool deleteStockPurchase(int ship_code);

        [OperationContract]
        bool addNewShipment(string shippment_code, string shipment_title, Nullable<bool> status);

        [OperationContract]
        IEnumerable<string> getshippmentTitle();
        // TODO: Add your service operations here


        //--------------------------fob stock in hand strats----------------------------------
        [OperationContract]
        bool addStockOrders(string Factoy_Name, string Description, Nullable<System.DateTime> Date, string Item, Nullable<double> NoOfPeices, Nullable<double> CostPerPeice, string Image, Nullable<double> materialAmount, string Shipment_code);
        //[OperationContract]
        //bool addStockOrders(string Factoy_Name, string Description, Nullable<System.DateTime> Date, string Item, Nullable<double> NoOfPeices, Nullable<double> CostPerPeice, string Image, Nullable<double> materialAmount, string Shipment_code);

        [OperationContract]
        bool addFixOverHead(Nullable<System.DateTime> Date_From, Nullable<System.DateTime> Date_To, string Type_Of_Cost, Nullable<double> amount);
       // [OperationContract]
        //bool deleteStockOrders(string Shipment_code);
        //--------------------------fob stock In hand ends------------------------------------
        [OperationContract]
        List<DataModel.fob_stock_orders> getStockOrders();
        [OperationContract]
        bool addFOBPurchasing(Nullable<System.DateTime> Purchased_Date, Nullable<double> Price_per_yard, Nullable<double> Yardage, Nullable<double> Transport_cost, string Shipment_Code);


        [OperationContract]
        bool updateFOBPurchasing(Nullable<System.DateTime> Purchased_Date, Nullable<double> Price_per_yard, Nullable<double> Yardage, Nullable<double> Transport_cost, string Shipment_Code);

        [OperationContract]

        bool deleteFOBPurchase(string Shipment_Code);

        [OperationContract]

        List<fob_purchasing> getfabricFOBPurchasing();

       
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
}
