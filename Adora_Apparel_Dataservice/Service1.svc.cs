﻿using DataModel;
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
            var load = from g in context.stock_purchasing select g;
            return load.ToList();
        }

        public bool addStockPurchase(string ship_code, int peices, double peice_price, double transport_cost, double supplier_commision, string miscellenaouse, double total_ship_cost, double actual_cost)
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
                    ActualCostPerPiece = actual_cost
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

        public bool login(string username,string password)
        {
            adoraDB context = new adoraDB();
            var result = from user in context.users where user.username == username && user.password == password select user;
            if (result.ToList().Count == 1) {

                return true;
            }
            return false;
        }

        public bool updateStockPurchase(string ship_code, int peices, double peice_price, double transport_cost, double supplier_commision, string miscellenaouse, double total_ship_cost, double actual_cost,int shipID)
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
                context.SaveChanges();
                status = true;
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
    }
}