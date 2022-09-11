using DAL.EF;
using DAL.Interfaces.FinanceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.FinanceManagerRepo
{
    public class BudgetingRepo : IBank<Bank, int, bool> , IBudget<Asset, int, string> , IBudget<Liability, int, string>
    {
        private ERPEntities db;

        public BudgetingRepo(ERPEntities db)
        {
            this.db = db;
        }

        public string Add(Bank b, int id)
        {
            if (b.balance < 0)
            {
                return "Balance can not be negative";
            }
          
            db.Banks.Add(b);
            db.SaveChanges();
            return "New Bank Account Created";
        }

        public List<Bank> All(int id)
        {
            var bank = (from e in db.Banks
                        where e.manager_id == id
                        select e).ToList();
            return bank;
        }

        public string Asset(int id, Asset a)
        {
            if (a.amount < 0)
            {
                return "Balance can not be negative";
         
            }
            var bank = (from e in db.Banks
                        where e.manager_id == id
                        select e).FirstOrDefault();


            bank.balance += a.amount;

            var expence = new Asset();
            expence.manager_id = id;
            expence.amount = a.amount;
            expence.type = a.type;
            db.Assets.Add(expence);
            db.SaveChanges();
            return "done";
        }

        public string Asset(int id, Liability a)
        {
            throw new NotImplementedException();
        }

        public bool Disconnect(int id, int id1)
        {
            var bank = (from e in db.Banks
                        where e.manager_id == id && e.id == id1
                        select e).SingleOrDefault();
            db.Banks.Remove(bank);
            db.SaveChanges();
            return true;
        }

        public string Expenses(int id, Asset a)
        {
            if (a.amount < 0)
            {
                return "Balance can not be negative";
            }
            var bank = (from e in db.Banks
                        where e.manager_id == id
                        select e).FirstOrDefault();

            if (bank.balance < a.amount)
            {
                return "Bank Doesnot have Enough Money";
            }
            bank.balance -= a.amount;

            var expence = new Asset();
            expence.manager_id = id;
            expence.amount = a.amount;
            expence.type = a.type;
            db.Assets.Add(expence);
            db.SaveChanges();
            return "done";
        }

        public string Expenses(int id, Liability a)
        {
            throw new NotImplementedException();
        }

        public string Liability(int id, Asset a)
        {
            throw new NotImplementedException();
        }

        public string Liability(int id, Liability a)
        {
            if (a.amount < 0)
            {
                return "Balance can not be negative";
               
            }
            var bank = (from e in db.Banks
                        where e.manager_id == id
                        select e).FirstOrDefault();

            if (bank.balance < a.amount)
            {
                return "Bank Doesnot have Enough Money";
                
            }
            bank.balance -= a.amount;

            var expence = new Liability();
            expence.manager_id = id;
            expence.amount = a.amount;
            expence.type = a.type;
            db.Liabilities.Add(expence);
            db.SaveChanges();
            return "done";
        }
    }
}
