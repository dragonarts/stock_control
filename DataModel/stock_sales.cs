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
    
    public partial class stock_sales
    {
        public int idStock_Sales { get; set; }
        public string Shippment_code { get; set; }
        public Nullable<int> NoOfPeices { get; set; }
        public Nullable<double> PricePerPeice { get; set; }
        public Nullable<double> Cost { get; set; }
        public string Sub_Cat_Name { get; set; }
    
        public virtual shippment_title shippment_title { get; set; }
    }
}
