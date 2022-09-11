using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.FinanceManager
{
    public interface IBank<CLASS,ID,RT>
    {
        string Add(CLASS b, ID id);
        RT Disconnect(ID id, ID id1);
        List<CLASS> All(ID id);
        string Expenses(int id, Asset asset);
        string Liability(int id, Liability lib);
        string Asset(int id, Asset asset);
    }
}
