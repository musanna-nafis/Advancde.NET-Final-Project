using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.FinanceManager
{
    public interface IBudget<CLASS,ID,RT>
    {
        RT Expenses(ID id, CLASS a);
        RT Liability(ID id, CLASS a);
        RT Asset(ID id, CLASS a);
    }
}
