using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
  public  class InvoiceModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string for_name { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public Nullable<int> sales_order_id { get; set; }
        public Nullable<int> total_amount { get; set; }
        public Nullable<int> manager_id { get; set; }
        public string file { get; set; }

        public virtual UserModel User { get; set; }
    }
}
