using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;

namespace Adora_Apparel_Dataservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public List<DataModel.stock_purchasing> getstockPurchasing()
        {

            adoraDB context = new adoraDB();
            context.Configuration.ProxyCreationEnabled = false;
            var load = from g in context.stock_purchasing where(g.status==1) select g;
            //context.SaveChanges();

            return load.ToList();
        }
        public List<DataModel.fob_stock_orders> getStockOrders()
        {
            adoraDB context = new adoraDB();
            context.Configuration.ProxyCreationEnabled = false;
            var load = from g in context.fob_stock_orders select g;
            return load.ToList();
        }
        public IEnumerable<string> getshippmentTitle()
        {

            adoraDB context = new adoraDB();

            var data = from g in context.shippment_title select g.Shipment_Code;
           // context.SaveChanges();
            return data.ToList();
        }
        public bool addStockPurchase(string ship_code, Nullable<int> peices, Nullable<double> peice_price, Nullable<double> transport_cost, Nullable<double> supplier_commision, Nullable<double> miscellenaouse, Nullable<double> total_ship_cost, Nullable<double> actual_cost,int status ,Nullable<System.DateTime> shipped,string sub_cat)
        {
            bool newStockAdded=false;
            adoraDB context = new adoraDB();

                stock_purchasing stock = new stock_purchasing{
                    Shippment_code = ship_code,
                    NoOfPeices = peices,
                    PricePerPiece = peice_price,
                    Transport_Cost = transport_cost,
                    Supplier_Commision = supplier_commision,
                    Miscellanouse = miscellenaouse,
                    Total_Shippment_cost = total_ship_cost,
                    ActualCostPerPiece = actual_cost,
                    status=status,
                    shipped_date=shipped,
                    sub_cat_name=sub_cat
                };
                context.stock_purchasing.Add(stock);
                context.SaveChanges();
                newStockAdded=true;

                return newStockAdded;
            //throw new NotImplementedException();
        }

        public bool addUser(string username, string firstname, string lastname, string password, string security, string answer)
        {
            bool status = false;
            adoraDB context = new adoraDB();
            var result = from user in context.users where user.username == username && user.password == password select user;
            if (result.ToList().Count == 0) {

                user User = new user { 
                
                    username=username,
                    firstName=firstname,
                    lastName=lastname,
                    password=password,
                    securityQuestion=security,
                    Answer=answer
                
                };
                context.users.Add(User);
                context.SaveChanges();
                status = true;
            
            }
            return status;
        }

        public bool addNewShipment(string shippment_code,string shipment_title,Nullable<bool> status)
        {
            bool state = false;
            adoraDB context = new adoraDB();
            shippment_title title = new shippment_title
            {

                Shipment_Code = shippment_code,
                Shippment_title1 = shipment_title,
                isFOB = status
            };
            context.shippment_title.Add(title);
            context.SaveChanges();
            state = true;
            return state;
        }
        public bool login(string username,string password)
        {
            adoraDB context = new adoraDB();
            var result = from user in context.users where user.username == username && user.password == password select user;
            if (result.ToList().Count == 1) {

                return true;
            }
            return false;
        }

        public bool updateStockPurchase(string ship_code, Nullable<int> peices, Nullable<double> peice_price, Nullable<double> transport_cost, Nullable<double> supplier_commision, Nullable<double> miscellenaouse, Nullable<double> total_ship_cost, Nullable<double> actual_cost, int shipID, Nullable<System.DateTime> shipped,string sub_cat)
        {
            adoraDB context = new adoraDB();
            bool status=false;
            stock_purchasing stock = context.stock_purchasing.First(i => i.idStock_purchasing == shipID);
            {

                stock.Shippment_code = ship_code;
                stock.NoOfPeices = peices;
                stock.PricePerPiece = peice_price;
                stock.Transport_Cost = transport_cost;
                stock.Supplier_Commision = supplier_commision;
                stock.Miscellanouse = miscellenaouse;
                stock.Total_Shippment_cost = total_ship_cost;
                stock.ActualCostPerPiece = actual_cost;
                stock.shipped_date = shipped;
                context.SaveChanges();
                status = true;
                stock.sub_cat_name = sub_cat;
            };
            return status;
        }

        public bool deleteStockPurchase(int ship_code)
        {
            adoraDB context = new adoraDB();
            bool status = false;
            stock_purchasing stock = context.stock_purchasing.First(i => i.idStock_purchasing == ship_code);
            {

                stock.status = 0;
                context.SaveChanges();
                status = true;
            }
            return status;
        }

        //------------------------ Stock In Hand ----------starts----------------------

        public bool addStockOrders(string Factoy_Name, string Description, Nullable<System.DateTime> Date, string Item, Nullable<double> NoOfPeices, Nullable<double> CostPerPeice, string Image, Nullable<double> materialAmount, string Shipment_code)
        {
            bool newStockAdded = false;
            adoraDB context = new adoraDB();

            fob_stock_orders stock = new fob_stock_orders
            {
                Factory_Name = Factoy_Name,
                Description = Description,
                Date = Date,
                Item = Item,
                NoOfPeices = NoOfPeices,
                CostPerPeice = CostPerPeice,
                Image=Image,
                user_username = "asantha",
                materialAmount = materialAmount,
                Shippment_code = Shipment_code,


            };

            context.fob_stock_orders.Add(stock);
            context.SaveChanges();
            newStockAdded = true;
            return newStockAdded;
            throw new NotImplementedException();
        }

      /*  public bool deleteStockOrders(string Shipment_code)
        {
            adoraDB context = new adoraDB();
            bool status = false;

            fob_stock_orders stock = context.fob_stock_orders.First(i => idFOB_Stock = Shipment_code);
            {

                stock.status = 0;
                context.SaveChanges();
                status = true;
            }
            return status;
        
        }*/

        public bool UpdateStockOrder(string Factoy_Name, string Description, Nullable<System.DateTime> Date, string Item, Nullable<double> NoOfPeices, Nullable<double> CostPerPeice, string Image, Nullable<double> materialAmount, string Shipment_code,int shipID)
        {
            adoraDB context = new adoraDB();
            bool status = false;

            fob_stock_orders stock = context.fob_stock_orders.First(i => i.idFOB_Stock == shipID);
            {
                stock.Factory_Name = Factoy_Name;
                stock.Description = Description;
                stock.Date = Date;
                stock.Item = Item;
                stock.NoOfPeices = NoOfPeices;
                stock.CostPerPeice = CostPerPeice;
                stock.Image = Image;
                stock.materialAmount = materialAmount;
                stock.Shippment_code = Shipment_code;
            
            
            }
            return status;

        }
        //------------------------ Stock In Hand ----------ends----------------------

        //------------------------ fixoverHead-----------starts---------------------

        public bool addFixOverHead(Nullable<System.DateTime> Date_From, Nullable<System.DateTime> Date_To, string Type_Of_Cost, Nullable<double> amount)
        {
            adoraDB context = new adoraDB();
            bool newDataAdded = false;
            fixed_over_heads data= new fixed_over_heads
            {
                Date_From=Date_From,
                Date_To=Date_To,
                Type_Of_Cost=Type_Of_Cost,
                amount=amount,
                enteredBy="asantha"
                
            
            };
            context.SaveChanges();
            newDataAdded = true;
            return newDataAdded;
        
        }

        //------------------------ fixoverHead-----------ends-----------------------

        public bool addFOBPurchasing(Nullable<System.DateTime> Purchased_Date, Nullable<double> Price_per_yard, Nullable<double> Yardage, Nullable<double> Transport_cost, string Shipment_Code)
        {
            bool newFOBPurchaseAdd = false;
            try
            {
                adoraDB context = new adoraDB();

                fob_purchasing fob = new fob_purchasing
                {
                    Date = Purchased_Date,
                    price_per_yard = Price_per_yard,
                    yardage = Yardage,
                    transport_cost = Transport_cost,
                    cost = (Price_per_yard * Yardage) + Transport_cost,
                    cost_per_yard = ((Price_per_yard * Yardage) + Transport_cost) / Yardage,
                    Shipment_Code = Shipment_Code
                };
                context.fob_purchasing.Add(fob);
                context.SaveChanges();
                newFOBPurchaseAdd = true;
            }
            catch (Exception d)
            {
                Exception ff = d.InnerException;
            }


            return newFOBPurchaseAdd;

        }


        public bool updateFOBPurchasing(Nullable<System.DateTime> Purchased_Date, Nullable<double> Price_per_yard, Nullable<double> Yardage, Nullable<double> Transport_cost, string Shipment_Code)
        {
            bool newFOBPurchaseAdd = false;
            try
            {
                adoraDB context = new adoraDB();

                fob_purchasing fob = context.fob_purchasing.First(f => f.Shipment_Code == Shipment_Code);

                fob.Date = Purchased_Date;
                fob.price_per_yard = Price_per_yard;
                fob.yardage = Yardage;
                fob.transport_cost = Transport_cost;
                fob.cost = (Price_per_yard * Yardage) + Transport_cost;
                fob.cost_per_yard = ((Price_per_yard * Yardage) + Transport_cost) / Yardage;

                context.SaveChanges();
                newFOBPurchaseAdd = true;
            }
            catch (Exception d)
            {
                Exception ff = d.InnerException;
            }


            return newFOBPurchaseAdd;

        }





        public bool deleteFOBPurchase(string shipment_Code)
        {
            bool status = false;
            try
            {
                adoraDB context = new adoraDB();

                fob_purchasing fob = context.fob_purchasing.First(a => a.Shipment_Code == shipment_Code);
                context.fob_purchasing.Remove(fob);
                context.SaveChanges();
                status = true;
            }
            catch (Exception d)
            {

            }
            return status;
        }



        public List<DataModel.fob_purchasing> getfabricFOBPurchasing()
        {

            adoraDB context = new adoraDB();
            context.Configuration.ProxyCreationEnabled = false;
            var load = from g in context.fob_purchasing select g;
            //context.SaveChanges();

            return load.ToList();
        }

       
    }
}
