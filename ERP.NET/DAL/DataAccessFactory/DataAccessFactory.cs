using DAL.EF;
using DAL.Interfaces.Common;
using DAL.Interfaces.FinanceManager;
using DAL.Interfaces.Hr;
using DAL.Interfaces.ProductManager;
using DAL.Repo.FinanceManagerRepo;
using DAL.Repo.HrRepo;
using DAL.Repo.ProductManagerRepo;
using DAL.Repo.SalesManagerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessFactory
{
    public class DataAccessFactory
    {
        static ERPEntities db = new ERPEntities();

        /*Product Manager*/
        public static IRepo<Product, int, bool> ProductDataAccess()
        {
            return new ProductRepo(db);
        }

        public static IRepo<Warehouse, int, bool> WareHouseDataAccess()
        {
            return new WareHouseRepo(db);
        }

        public static IWarehouse<Warehouse,string> WareHouseDataAccessName()
        {
            return new WareHouseRepo(db);
        }

        public static IRepo<Issue, int, bool> ProductManagerIssueDataAccess()
        {
            return new IssueRepo(db);
        }

        public static IRepo<Token, string, Token> ProductManagerTokenDataAccess()
        {
            return new TokenRepo(db);
        }
        /*End*/


        ///////////////////////////////////////////////hr
        public static IRepo<User, int, bool> UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepo<Employee, int, bool> EmployeeDataAccess()
        {
            return new EmployeeRepo(db);
        }
        public static IRepo<Expens, int, bool> ExpenseDataAccess()
        {
            return new ExpenseRepo(db);
        }
        public static Interfaces.Hr.IChart<int> ExpenseChartDataAccess()
        {
            return new ExpenseRepo(db);
        }
        public static IRepo<Leave_requests, int, bool> LeaveRequestDataAccess()
        {
            return new HrLeaveRequestRepo(db);
        }
        public static IRepo<User, int, bool> ProfileDataAccess()
        {
            return new HrProfileRepo(db);
        }
        public static IProfileEdit<User, int, string> ProfileEditDataAccess()
        {
            return new HrProfileRepo(db);
        }
        public static IHrEmail<Hr_Email, string> HrEmailDataAccess()
        {
            return new HrProfileRepo(db);
        }

        ////////////////////////////////////////////////hr

        //FinanceManager
        public static ILeave_request<Leave_requests, int> FinanceManagerLeaveDataAccess()
        {
            return new LeaveRequestRepo(db);
        }

        public static IRepo<Leave_requests, int, bool> FinanceManagerLeave1DataAccess()
        {
            return new LeaveRequestRepo(db);
        }

        public static IRepo<User, int, bool> FinanceManagerProfileDataAccess()
        {
            return new ProfileRepo(db);
        }

        public static IProfile<User, int, string> FinanceManagerProfile1DataAccess()
        {
            return new ProfileRepo(db);
        }
        public static IPass<FinanceManagerPass, int, string> FinanceManagerProfile2DataAccess()
        {
            return new ProfileRepo(db);
        }

        public static IPaymentHistory<Finance_payment_histories, int> FinanceManagerPaymentDataAccess()
        {
            return new PaymentRepo(db);
        }
        public static IInvoice<Invoice, int> FinanceManagerInvoiceDataAccess()
        {
            return new PaymentRepo(db);
        }

        public static IEmail<FinanceManager_Email, string> FinanceManagerEmailDataAccess()
        {
            return new EmailSendRepo(db);
        }

        public static IBank<Bank, int, bool> FinanceManagerBankworkDataAccess()
        {
            return new BudgetingRepo(db);
        }

        public static IBudget<Asset, int, string> FinanceManagerAssetDataAccess()
        {
            return new BudgetingRepo(db);
        }

        public static IBudget<Liability, int, string> FinanceManagerLiabilityDataAccess()
        {
            return new BudgetingRepo(db);
        }

        ///end
        ///
        //sales
        public static IRepo<Customer, int, bool> CustomerworkDataAccess()
        {
            return new CustomerRepo(db);
        }
        public static IRepo<Order, int, bool> OrderDataAccess()
        {
            return new OrderRepo(db);
        }
        public static IRepo<User, int, bool> SalesManagerProfileDataAccess()
        {
            return new SalesProfileRepo(db);
        }
    }
}
