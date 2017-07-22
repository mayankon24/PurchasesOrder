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
    }
}
