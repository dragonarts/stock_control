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
    
    public partial class shippment_title
    {
        public shippment_title()
        {
            this.fob_purchasing = new HashSet<fob_purchasing>();
            this.fob_sales = new HashSet<fob_sales>();
            this.fob_stock_in_hand = new HashSet<fob_stock_in_hand>();
            this.fob_stock_orders = new HashSet<fob_stock_orders>();
            this.stock_monitor = new HashSet<stock_monitor>();
            this.stock_purchasing = new HashSet<stock_purchasing>();
            this.stock_sales = new HashSet<stock_sales>();
            this.stocks = new HashSet<stock>();
        }
    
        public string Shipment_Code { get; set; }
        public string Shippment_title1 { get; set; }
        public Nullable<bool> isFOB { get; set; }
    
        public virtual ICollection<fob_purchasing> fob_purchasing { get; set; }
        public virtual ICollection<fob_sales> fob_sales { get; set; }
        public virtual ICollection<fob_stock_in_hand> fob_stock_in_hand { get; set; }
        public virtual ICollection<fob_stock_orders> fob_stock_orders { get; set; }
        public virtual ICollection<stock_monitor> stock_monitor { get; set; }
        public virtual ICollection<stock_purchasing> stock_purchasing { get; set; }
        public virtual ICollection<stock_sales> stock_sales { get; set; }
        public virtual ICollection<stock> stocks { get; set; }
    }
}
