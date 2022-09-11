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
    public class FinanceManager_BudgetingController : ApiController
    {
        [Route("api/financemanager/connectedbank/{id}")]
        [HttpGet]
        public HttpResponseMessage Bank(int id)
        {
            var data = FinanceManagerBudgetingService.connectedbank(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/disconnectbank/{id}/{id1}")]
        [HttpGet]
        public HttpResponseMessage Bankdisconnect(int id,int id1)
        {
            var data = FinanceManagerBudgetingService.disconnectdbank(id,id1);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/addbank/{id}")]
        [HttpPost]
        public HttpResponseMessage BankAdd(int id, BankModel b)
        {
            var data = FinanceManagerBudgetingService.addBank(id, b);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/expense/{id}")]
        [HttpPost]
        public HttpResponseMessage Expense(int id, AssetModel a)
        {
            var data = FinanceManagerBudgetingService.expense(id, a);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/liability/{id}")]
        [HttpPost]
        public HttpResponseMessage Liability(int id,LiabilityModel a)
        {
            var data = FinanceManagerBudgetingService.liability(id, a);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/financemanager/asset/{id}")]
        [HttpPost]
        public HttpResponseMessage Asset(int id, AssetModel a)
        {
            var data = FinanceManagerBudgetingService.asset(id, a);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
