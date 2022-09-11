using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    class OrganizationModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public Nullable<System.DateTime> established { get; set; }
    }
}
