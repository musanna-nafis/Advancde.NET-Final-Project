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
    public class FinanceManager_InvoiceController : ApiController
    {
    }
}
