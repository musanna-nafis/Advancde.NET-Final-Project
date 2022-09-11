using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
   public  class Finance_payment_historiesModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public Nullable<double> amount { get; set; }
        public Nullable<int> manager_id { get; set; }
        public virtual UserModel User { get; set; }
    }
}
