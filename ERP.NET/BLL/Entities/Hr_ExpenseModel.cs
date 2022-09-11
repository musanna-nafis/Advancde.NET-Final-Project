using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Hr_ExpenseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string catagory { get; set; }
        public Nullable<double> amount { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> expense_date { get; set; }
    }
}
