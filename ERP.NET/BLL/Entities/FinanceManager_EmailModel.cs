using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class FinanceManager_EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Password { get; set; }
    }
}
