//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class fob_stock_orders
    {
        public int idFOB_Stock { get; set; }
        public string Factory_Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Item { get; set; }
        public Nullable<double> NoOfPeices { get; set; }
        public Nullable<double> CostPerPeice { get; set; }
        public string user_username { get; set; }
        public Nullable<double> materialAmount { get; set; }
        public string Shippment_code { get; set; }
    
        public virtual shippment_title shippment_title { get; set; }
        public virtual user user { get; set; }
    }
}