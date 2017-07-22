using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasesOrder.Entity
{
    [Serializable]

    public class ItemNameEL
    {
        public int Item_id { get; set; }
        public string Item_name { get; set; }
    }
}
