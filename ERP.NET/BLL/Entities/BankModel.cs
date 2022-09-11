using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
   public class BankModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string holder_name { get; set; }
        public string account_no { get; set; }
        public Nullable<double> balance { get; set; }
        public Nullable<int> manager_id { get; set; }
    }
}
