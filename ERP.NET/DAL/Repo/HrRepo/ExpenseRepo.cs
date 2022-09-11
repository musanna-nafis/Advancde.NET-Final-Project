using DAL.EF;
using DAL.Interfaces.Common;
using DAL.Interfaces.Hr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.HrRepo
{
    public class ExpenseRepo : IRepo<Expens, int, bool>, IChart<int>
    {
        ERPEntities db;
        public ExpenseRepo(ERPEntities db)
        {
            this.db = db;
        }

        public bool Create(Expens obj)
        {
            db.Expenses.Add(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            db.Expenses.Remove(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public List<int> ExpenseChart()
        {
            var food = (from e in db.Expenses
                        where e.catagory.Equals("Food")
                        select e).Count();

            var transport = (from e in db.Expenses
                             where e.catagory.Equals("Transport")
                             select e).Count();
            var data = new List<int>();
            data.Add(food);
            data.Add(transport);
            return data;

        }

        public List<Expens> Get()
        {
            return db.Expenses.ToList();
        }

        public Expens Get(int id)
        {
            return db.Expenses.Find(id);
        }

        public bool ProfileEdit(int id, Expens obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Expens obj)
        {
            throw new NotImplementedException();
        }
    }
}
