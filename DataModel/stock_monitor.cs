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
    
    public partial class stock_monitor
    {
        public int id { get; set; }
        public Nullable<int> amountBefore { get; set; }
        public Nullable<int> amountNow { get; set; }
        public Nullable<System.DateTime> dateModifiedd { get; set; }
        public string userModified { get; set; }
        public string Shipment_Code { get; set; }
        public string responsibleUser { get; set; }
        public string reason { get; set; }
    
        public virtual shippment_title shippment_title { get; set; }
        public virtual user user { get; set; }
    }
}
