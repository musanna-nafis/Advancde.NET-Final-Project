using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.FinanceManager
{
    public interface IProfile<CLASS, ID, RT>
    {
        RT UpdateProfile(ID id,CLASS obj);
    }
}
