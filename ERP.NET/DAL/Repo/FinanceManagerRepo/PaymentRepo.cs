using DAL.EF;
using DAL.Interfaces.Common;
using DAL.Interfaces.FinanceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.FinanceManagerRepo
{
    public class PaymentRepo : IRepo<Finance_payment_histories, int, bool> , IPaymentHistory<Finance_payment_histories, int> , IInvoice<Invoice, int> ,IChart<int>
    {
        private ERPEntities db;

        public PaymentRepo(ERPEntities db)
        {
            this.db = db;
        }
        public bool Create(Finance_payment_histories obj)
        {
            throw new NotImplementedException();
        }

        public bool CustomerAdjust(int id, int id1)
        {
            var user = (from e in db.Users
                        where e.id == id
                        select e).SingleOrDefault();
            var invoice = (from e in db.Invoices
                           where e.id == id1
                           select e).SingleOrDefault();
            invoice.status = "Adjusted";
            var asset = new Asset();
            asset.type = "Sales";
            asset.amount = invoice.total_amount;
            asset.manager_id = user.id;
            db.Assets.Add(asset);
            //add to payment history
            var payment_history = new Finance_payment_histories();
            payment_history.type = "Credit";
            payment_history.amount = invoice.total_amount;
            payment_history.manager_id = user.id;
            db.Finance_payment_histories.Add(payment_history);

            //Banks Balance add
            var bank = (from e in db.Banks
                        where e.manager_id == user.id
                        select e).FirstOrDefault();
            bank.balance += payment_history.amount;
            db.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Finance_payment_histories> Get()
        {
            throw new NotImplementedException();
        }

        public Finance_payment_histories Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetCustomer(int id)
        {
            var invoice = (from e in db.Invoices
                           where e.manager_id == id && e.type.Equals("Customer") && e.status.Equals("Unadjusted")
                           select e).ToList();
            return invoice;
        }

        public List<Finance_payment_histories> Gethistory(int id)
        {
            var history = (from e in db.Finance_payment_histories
                            where e.manager_id == id
                            select e).ToList();
            return history;
        }

        public List<Invoice> GetSupplier(int id)
        {
            var invoice = (from e in db.Invoices
                           where e.manager_id == id && e.type.Equals("Supplier") && e.status.Equals("Unadjusted")
                           select e).ToList();
            return invoice;
        }

        public List<int> PaymentsChart(int id)
        {
            var Debit = (from e in db.Finance_payment_histories
                         where e.type.Equals("Debit") && e.manager_id == id
                         select e).Count();

            var Credit = (from e in db.Finance_payment_histories
                          where e.type.Equals("Credit") && e.manager_id == id
                          select e).Count();
            var cou=new List<int> ();
            cou.Add(Debit);
            cou.Add(Credit);
            return cou;
        }

        public bool SupplierAdjust(int id, int id1)
        {
            var user = (from e in db.Users
                        where e.id==id
                        select e).SingleOrDefault();
            var invoice = (from e in db.Invoices
                           where e.id == id1
                           select e).SingleOrDefault();
            invoice.status = "Adjusted";

            var asset = new Asset();
            asset.type = "Purchases";
            asset.amount = invoice.total_amount;
            asset.manager_id = user.id;
            db.Assets.Add(asset);

            //add to payment history
            var payment_history = new Finance_payment_histories();
            payment_history.type = "Debit";
            payment_history.amount = invoice.total_amount;
            payment_history.manager_id = user.id;
            db.Finance_payment_histories.Add(payment_history);

            //
            var liability = new Liability();
            liability.type = "Expenses";
            liability.amount = payment_history.amount;
            liability.manager_id = user.id;

            //Banks Balance add
            var bank = (from e in db.Banks
                        where e.manager_id == user.id
                        select e).FirstOrDefault();
            bank.balance -= payment_history.amount;

            db.SaveChanges();
            return true;
        }

        public bool Update(Finance_payment_histories obj)
        {
            throw new NotImplementedException();
        }
    }
}
