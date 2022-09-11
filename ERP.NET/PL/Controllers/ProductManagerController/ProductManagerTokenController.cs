using BLL.Entities;
using BLL.Services.ProductManagerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PL.Controllers.ProductManagerController
{
    [EnableCors("*", "*", "*")]
    public class ProductManagerTokenController : ApiController
    {
        [Route("api/tokens")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = TokenServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tokens/create/{id}")]
        [HttpGet]
        public HttpResponseMessage Create(int id)
        {
            var data = TokenServices.create(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tokens/{token}")]
        [HttpGet]
        public HttpResponseMessage Get(string token)
        {
            var data = TokenServices.Get(token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/token/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(string id)
        {
            var data = TokenServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tokens/update")]
        [HttpPost]
        public HttpResponseMessage Update(TokenModel token)
        {
            var data = TokenServices.Update(token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tokens/GetUserLog/{date}")]
        [HttpGet]
        public HttpResponseMessage FetchLog(string date)
        {
            var data = TokenServices.TokenByDate(date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
