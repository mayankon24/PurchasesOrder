using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasesOrder.Entity
{
    public class CompanyEL
    {
        public int Company_id { get; set; }
        public string tin_no { get; set; }
        public string company_name { get; set; }
        public string address1 { get; set; }
        public string pan_no { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string Fax_No { get; set; }
        public string delivery_at { get; set; }
    }
}
