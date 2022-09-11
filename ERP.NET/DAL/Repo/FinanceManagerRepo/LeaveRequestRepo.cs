using DAL.EF;
using DAL.Interfaces.Common;
using DAL.Interfaces.FinanceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.FinanceManagerRepo
{
    public class LeaveRequestRepo : IRepo<Leave_requests, int, bool> , ILeave_request<Leave_requests, int>
    {
        private ERPEntities db;

        public LeaveRequestRepo(ERPEntities db)
        {
            this.db = db;
        }

        public bool Create(Leave_requests obj)
        {
            db.Leave_requests.Add(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public bool Delete(int id)
        {
            var obj = db.Leave_requests.Find(id);
            db.Leave_requests.Remove(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public List<Leave_requests> Get()
        {
            throw new NotImplementedException();
        }

        public Leave_requests Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Leave_requests obj)
        {
            throw new NotImplementedException();
        }

        public List<Leave_requests> GetLeave(int id)
        {
            var requests = (from e in db.Leave_requests
                            where e.employee_id == id
                            select e).ToList();
            return requests;
        }
    }
}
