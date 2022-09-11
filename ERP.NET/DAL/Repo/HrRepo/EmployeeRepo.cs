using DAL.EF;
using DAL.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.HrRepo
{
    public class EmployeeRepo : IRepo<Employee, int, bool>
    {
        ERPEntities db;

        public EmployeeRepo(ERPEntities db)
        {
            this.db = db;
        }
        public bool Create(Employee obj)
        {
            db.Employees.Add(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            db.Employees.Remove(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public  List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public bool Update(Employee obj)
        {
            var emp = (from e in db.Employees
                        where e.id == obj.id
                       select e).SingleOrDefault();
            if (emp == null) { return false; }
            else
            {
                db.Entry(emp).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            
        }
    }
}
