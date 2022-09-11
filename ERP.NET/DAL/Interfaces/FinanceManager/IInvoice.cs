using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.FinanceManager
{
   public interface IInvoice<CLASS, ID>
    {
        List<CLASS> GetCustomer(ID id);
        List<CLASS> GetSupplier(ID id);
        bool CustomerAdjust(ID id,ID id1);
        bool SupplierAdjust(ID id,ID id1);

    }
}
