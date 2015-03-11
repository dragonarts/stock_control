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
        bool addStockPurchase(string ship_code,int peices,double peice_price,double transport_cost,double supplier_commision,string miscellenaouse,double total_ship_cost,double actual_cost);

        [OperationContract]
        bool addUser(string username,string firstname,string lastname,string password,string security,string answer);

        [OperationContract]
        bool login(string username,string password);

        [OperationContract]
        bool updateStockPurchase(string ship_code, int peices, double peice_price, double transport_cost, double supplier_commision, string miscellenaouse, double total_ship_cost, double actual_cost,int shipID);

        [OperationContract]
        bool deleteStockPurchase(int ship_code);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
}
