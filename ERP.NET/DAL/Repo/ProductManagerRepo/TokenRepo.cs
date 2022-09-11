using DAL.EF;
using DAL.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.ProductManagerRepo
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        ERPEntities db;
        public TokenRepo(ERPEntities db)
        {
            this.db = db;
        }
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string token)
        {
            var obj = Get(token);
            db.Tokens.Remove(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }
        public Token Get(string token)
        {
            return db.Tokens.FirstOrDefault(t => t.Token1.Equals(token));
        }

        public bool Update(Token obj)
        {
            var exst = db.Tokens.FirstOrDefault(x => x.Token1.Equals(obj.Token1));
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
