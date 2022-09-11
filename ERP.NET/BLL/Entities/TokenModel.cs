using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TokenModel
    {
        public int id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Token1 { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> ExpiredAt { get; set; }

        public virtual UserModel User { get; set; }
    }
}
