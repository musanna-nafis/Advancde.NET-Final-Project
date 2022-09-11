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
    public class ExpenseController : ApiController
    {
        [Route("api/expenses")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = ExpenseService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/expense/create")]
        [HttpPost]
        public HttpResponseMessage Create(Hr_ExpenseModel expense)
        {
            var data = ExpenseService.Create(expense);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/expense/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = ExpenseService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/expense/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = ExpenseService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/expensechart")]
        [HttpGet]
        public HttpResponseMessage GetChart()
        {
            var data = ExpenseService.Chart();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
