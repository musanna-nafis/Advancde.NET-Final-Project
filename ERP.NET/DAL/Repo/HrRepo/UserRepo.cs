using DAL.EF;
using DAL.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.HrRepo
{
    public class UserRepo:IRepo<User,int,bool>
    {
        ERPEntities db;

        public UserRepo(ERPEntities db)
        {
            this.db = db;
        }

        public bool Create(User obj)
        {
            db.Users.Add(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            db.Users.Remove(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var user= (from e in db.Users
                       where e.id == obj.id
                       select e).SingleOrDefault();
            if (user == null) { return false; }
            else
            {
                db.Entry(user).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
        }
    }
}

