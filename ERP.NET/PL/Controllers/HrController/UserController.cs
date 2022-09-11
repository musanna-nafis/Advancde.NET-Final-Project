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
    [EnableCors("*","*","*")]
    public class UserController : ApiController
    {
        [Route("api/user/create")]
        [HttpPost]
        public HttpResponseMessage Create(UserModel user)
        {
            var data = UserService.Create(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/user/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/user/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/user/update")]
        [HttpPost]
        public HttpResponseMessage Update(UserModel user)
        {
            var data = UserService.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
