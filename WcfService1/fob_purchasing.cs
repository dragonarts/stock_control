//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService1
{
    using System;
    using System.Collections.Generic;
    
    public partial class fob_purchasing
    {
        public int idFOB_Purchasing { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> price_per_yard { get; set; }
        public Nullable<double> yardage { get; set; }
        public Nullable<double> transport_cost { get; set; }
        public Nullable<double> cost { get; set; }
        public Nullable<double> cost_per_yard { get; set; }
        public string Shipment_Code { get; set; }
    
        public virtual shippment_title shippment_title { get; set; }
    }
}
