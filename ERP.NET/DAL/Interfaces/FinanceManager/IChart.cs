using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.FinanceManager
{
    public interface IChart<ID>
    {
        List<int> PaymentsChart(ID id);
    }
}
