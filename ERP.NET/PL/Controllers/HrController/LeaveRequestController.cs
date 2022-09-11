using BLL.Entities;
using BLL.Services.HrServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PL.Controllers.HrController
{
    [EnableCors("*", "*", "*")]
    public class LeaveRequestController : ApiController
    {

        [Route("api/leaverequests")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = LeaveRequestService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/leaverequest/create")]
        [HttpPost]
        public HttpResponseMessage Create(LeaveRequestModel req)
        {
            var data = LeaveRequestService.Create(req);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/leaverequest/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = LeaveRequestService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/leaverequest/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = LeaveRequestService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
