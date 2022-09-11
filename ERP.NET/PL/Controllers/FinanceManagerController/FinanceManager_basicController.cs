using BLL.Entities;
using BLL.Services.FinanceManagerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PL.Controllers.FinanceManagerController
{
    [EnableCors("*","*","*")]
    public class FinanceManager_basicController : ApiController
    {
        [Route("api/FinanceManager/Home/{id}")]
        [HttpGet]
        public HttpResponseMessage Home(int id)
        {
            var data = FinanceManagerBasicService.GetHomePage(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //Leave Request

        [Route("api/financemanager/leaverequest/{id}")]
        [HttpGet]
        public HttpResponseMessage Leave(int id)
        {
            var data = FinanceManagerBasicService.LeaveRequest(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/leaverequest/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage LeaveDelete(int id)
        {
            var data = FinanceManagerBasicService.LeaveRequestDelete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/leaverequest/new/{id}")]
        [HttpPost]
        public HttpResponseMessage CreateLeave(int id,LeaveRequestModel l)
        {
            var data = FinanceManagerBasicService.LeaveRequestCreate(id,l);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // Profile show

        [Route("api/financemanager/profile/{id}")]
        [HttpGet]
        public HttpResponseMessage profile(int id)
        {
            var data = FinanceManagerBasicService.myprofile(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // change info
        [Route("api/financemanager/changeinfo/{id}")]
        [HttpGet]
        public HttpResponseMessage info(int id)
        {
            var data = FinanceManagerBasicService.myprofile(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/changeinfo/{id}")]
        [HttpPost]
        public HttpResponseMessage info(int id,UserModel user)
        {
            var data = FinanceManagerBasicService.changeprofile(id,user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/changepass/{id}")]
        [HttpPost]
        public HttpResponseMessage pass(int id, FinanceManagerPassModel p)
        {
            var data = FinanceManagerBasicService.changepass(id, p);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


    }
}
