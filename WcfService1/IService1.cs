using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        public stock_purchase add_stock();

        [OperationContract]
        public stock_purchase update_stock();
        [OperationContract]
        public stock_purchase delete_stock();
        [OperationContract]
        public List<stock_purchase> view_stock(int id);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class stock_purchase {

        string shippment_code;
        int NoOfPieces;
        double pricePerPiece;
        double transportCost;
        double supplierCommission;
        string Miscellanouse;
        double Total_Shippment_cost;
        double ActualCostPerPiece;
        [DataMember]
        public string Shippment_code
        {
            get { return shippment_code; }
            set { shippment_code = value; }
        }
        
        [DataMember]
        public int NoOfPieces1
        {
            get { return NoOfPieces; }
            set { NoOfPieces = value; }
        }
       
        [DataMember]
        public double PricePerPiece
        {
            get { return pricePerPiece; }
            set { pricePerPiece = value; }
        }
        
        [DataMember]
        public double TransportCost
        {
            get { return transportCost; }
            set { transportCost = value; }
        }
        
        [DataMember]
        public double SupplierCommission
        {
            get { return supplierCommission; }
            set { supplierCommission = value; }
        }
        
        [DataMember]
        public string Miscellanouse1
        {
            get { return Miscellanouse; }
            set { Miscellanouse = value; }
        }
       
        [DataMember]
        public double Total_Shippment_cost1
        {
            get { return Total_Shippment_cost; }
            set { Total_Shippment_cost = value; }
        }
        
        [DataMember]
        public double ActualCostPerPiece1
        {
            get { return ActualCostPerPiece; }
            set { ActualCostPerPiece = value; }
        }
    
    }


   
}
