using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasesOrder.Entity
{
    public class PurchaseOrderEL
    {
        public int Purchases_Order_Id { get; set; }
        public int Company_id { get; set; }
        public DateTime Date { get; set; }
        public string Purchases_Order_No { get; set; }
        public decimal Tax_Percentage { get; set; }
        public decimal Other_Amount { get; set; }
        public string Requisitioner { get; set; }
        public string Credit_Term { get; set; }
        public string Shipping_Term { get; set; }
        public string Comments { get; set; }        
    }
}
