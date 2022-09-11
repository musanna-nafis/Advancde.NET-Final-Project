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
    public class ProfileController : ApiController
    {
        [Route("api/profile/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = ProfileService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/profile/edit/{id}")]
        [HttpPost]
        public HttpResponseMessage info(int id, UserModel user)
        {
            var data = ProfileService.EditProfile(id, user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/profile/sendemail")]
        [HttpPost]
        public HttpResponseMessage sendemail(Hr_EmailModel email)
        {
            var data = ProfileService.SendEmail(email);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
