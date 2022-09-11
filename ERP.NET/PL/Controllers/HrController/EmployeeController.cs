
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
    public class EmployeeController : ApiController
    {
       [Route("api/employees")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = EmployeeService.Get(); 
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/employee/create")]
        [HttpPost]
        public HttpResponseMessage Create(EmployeeModel employee)
        {
            var data = EmployeeService.Create(employee);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/employee/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = EmployeeService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/employee/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = EmployeeService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/employee/update")]
        [HttpPost]
        public HttpResponseMessage Update(EmployeeModel employee)
        {
            var data = EmployeeService.Update(employee);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
