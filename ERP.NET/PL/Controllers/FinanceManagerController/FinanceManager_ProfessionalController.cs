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
    [EnableCors("*", "*", "*")]
    public class FinanceManager_ProfessionalController : ApiController
    {
        [Route("api/financemanager/paymenthistory/{id}")]
        [HttpGet]
        public HttpResponseMessage Payment(int id)
        {
            var data = FinanceManagerProfessionalService.paymenthistory(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/customerpayment/{id}")]
        [HttpGet]
        public HttpResponseMessage CustomerPayment(int id)
        {
            var data = FinanceManagerProfessionalService.customerpayment(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/supplierpayment/{id}")]
        [HttpGet]
        public HttpResponseMessage SupplierPayment(int id)
        {
            var data = FinanceManagerProfessionalService.supplierpayment(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/supplieradjust/{id}/{id1}")]
        [HttpGet]
        public HttpResponseMessage SupplierAdjust(int id,int id1)
        {
            var data = FinanceManagerProfessionalService.supplieradjust(id,id1);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/customeradjust/{id}/{id1}")]
        [HttpGet]
        public HttpResponseMessage CustomerAdjust(int id, int id1)
        {
            var data = FinanceManagerProfessionalService.customeradjust(id, id1);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/sendemail")]
        [HttpPost]
        public HttpResponseMessage sendemail(FinanceManager_EmailModel email)
        {
            var data = FinanceManagerProfessionalService.Sendemail(email);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/paymentchart/{id}")]
        [HttpGet]
        public HttpResponseMessage CHart(int id)
        {
            var data = FinanceManagerProfessionalService.chart(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
