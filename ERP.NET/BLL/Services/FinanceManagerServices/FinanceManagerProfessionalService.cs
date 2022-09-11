using BLL.Entities;
using DAL.DataAccessFactory;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.FinanceManagerServices
{ 
   public class FinanceManagerProfessionalService
    {
        public static List<Finance_payment_historiesModel> paymenthistory(int id)
        {
            var data = DataAccessFactory.FinanceManagerPaymentDataAccess().Gethistory(id);
            var histories = new List<Finance_payment_historiesModel>();
            foreach (var item in data)
            {
                histories.Add(new Finance_payment_historiesModel()
                {
                    id = item.id,
                    type = item.type,
                    amount = item.amount,
                    manager_id=item.manager_id
                });
            }
            return histories;
        }
        public static List<InvoiceModel> customerpayment(int id)
        {
            var data = DataAccessFactory.FinanceManagerInvoiceDataAccess().GetCustomer(id);
            var Customer = new List<InvoiceModel>();
            foreach (var item in data)
            {
                Customer.Add(new InvoiceModel()
                {
                    id = item.id,
                    for_name = item.for_name,
                    total_amount = item.total_amount,
                });
            }
            return Customer;
        }

        public static List<InvoiceModel> supplierpayment(int id)
        {
            var data = DataAccessFactory.FinanceManagerInvoiceDataAccess().GetSupplier(id);
            var Supplier = new List<InvoiceModel>();
            foreach (var item in data)
            {
                Supplier.Add(new InvoiceModel()
                {
                    id = item.id,
                    for_name = item.for_name,
                    total_amount = item.total_amount,
                });
            }
            return Supplier;
        }

        public static bool supplieradjust(int id,int id1)
        {
            return DataAccessFactory.FinanceManagerInvoiceDataAccess().SupplierAdjust(id,id1);
           
        }
        public static bool customeradjust(int id, int id1)
        {
            return DataAccessFactory.FinanceManagerInvoiceDataAccess().CustomerAdjust(id, id1);

        }
        public static string Sendemail(FinanceManager_EmailModel email)
        {
            var e = new FinanceManager_Email();
            e.To = email.To;
            e.Subject = email.Subject;
            e.Body = email.Body;
            e.Password = email.Password;
            return DataAccessFactory.FinanceManagerEmailDataAccess().emailsend(e);

        }

        public static List<int> chart(int id)
        {
            return DataAccessFactory.FinanceManagerPaymentDataAccess().PaymentsChart(id);
        }
    }
}
