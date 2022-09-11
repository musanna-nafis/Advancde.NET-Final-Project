using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Hr
{
    public interface IProfileEdit<CLASS, ID, RT>
    {
        RT ProfileEdit(ID id, CLASS obj);
    }
}
