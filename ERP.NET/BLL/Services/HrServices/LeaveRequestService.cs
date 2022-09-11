using BLL.Entities;
using DAL.DataAccessFactory;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.HrServices
{
    public class LeaveRequestService
    {
        public static List<LeaveRequestModel> Get()
        {
            var data = DataAccessFactory.LeaveRequestDataAccess().Get();
            var leaveRequests = new List<LeaveRequestModel>();
            foreach (var r in data)
            {
                leaveRequests.Add(new LeaveRequestModel()
                {
                    request_description = r.request_description,
                    type = r.type,
                    status = r.status,
                    id = r.id,
                    employee_id = r.employee_id,
                    start_time = r.start_time,
                    end_time = r.end_time
                });
            }
            return leaveRequests;
        }
        public static bool Create(LeaveRequestModel r)
        {
            var req = new Leave_requests();


            req.type = r.type;
            req.request_description = r.request_description;
            req.start_time = r.start_time;
            req.end_time = r.end_time;
            req.status = r.status;
            req.employee_id = r.employee_id;
            req.request_made = r.request_made;
            req.status = r.status;
           


            return DataAccessFactory.LeaveRequestDataAccess().Create(req);
        }
        public static LeaveRequestModel Get(int id)
        {
            var r = DataAccessFactory.LeaveRequestDataAccess().Get(id);

            var req = new LeaveRequestModel()
            {
                request_description = r.request_description,
                type = r.type,
                status = r.status,
                id = r.id,
                employee_id=r.employee_id,
                start_time = r.start_time,
                end_time = r.end_time
            };
            return req;

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.LeaveRequestDataAccess().Delete(id);
        }
    }
}

