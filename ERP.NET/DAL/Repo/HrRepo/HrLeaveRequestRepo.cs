using DAL.EF;
using DAL.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.HrRepo
{
    public class HrLeaveRequestRepo : IRepo<Leave_requests, int, bool>
    {
        ERPEntities db;
        public HrLeaveRequestRepo(ERPEntities db)
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
            var obj = Get(id);
            db.Leave_requests.Remove(obj);
            int res = db.SaveChanges();
            return res > 0;
        }

        public List<Leave_requests> Get()
        {
            return db.Leave_requests.ToList();
        }

        public Leave_requests Get(int id)
        {
            return db.Leave_requests.Find(id);
        }

        public bool Update(Leave_requests obj)
        {
            throw new NotImplementedException();
        }
    }
}
