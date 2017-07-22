using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasesOrder.Entity
{
    class PurchasesOrderDetailEL
    {
        public int Purchase_Order_Detail_Id { get; set; }
        public int Purchases_Order_Id { get; set; }
        public string Item_Name { get; set; }
        public int Item_id { get; set; }
        public double Item_Quantity { get; set; }
        public double Item_Rate { get; set; }
        public string Item_Unit { get; set; }
        public decimal Total_Amount { get; set; }
    }
}
