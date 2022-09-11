using BLL.Entities;
using DAL.DataAccessFactory;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.HrServices
{
   public class ExpenseService
    {
        public static List<Hr_ExpenseModel> Get()
        {
            var data = DataAccessFactory.ExpenseDataAccess().Get();
            var expenses = new List<Hr_ExpenseModel>();
            foreach (var expense in data)
            {
                expenses.Add(new Hr_ExpenseModel()
                {
                    name = expense.name,
                    catagory = expense.catagory,
                    amount = expense.amount,
                    description = expense.description,
                    expense_date = expense.expense_date
            });
            }
            return expenses;
        }
        public static bool Create(Hr_ExpenseModel expense)
        {
            var expense1= new Expens();


            expense1.name = expense.name;
            expense1.catagory = expense.catagory;
            expense1.amount = expense.amount;
            expense1.description = expense.description;
            expense1.expense_date = expense.expense_date;



            return DataAccessFactory.ExpenseDataAccess().Create(expense1);
        }
        public static Hr_ExpenseModel Get(int id)
        {
            var expense = DataAccessFactory.ExpenseDataAccess().Get(id);

            var expense1 = new Hr_ExpenseModel()
            {
                id = expense.id,
                name = expense.name,
                catagory = expense.catagory,
                amount = expense.amount,
                description = expense.description,
                expense_date = expense.expense_date
            };
            return expense1;

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ExpenseDataAccess().Delete(id);
        }
        public static List<int> Chart()
        {
            return DataAccessFactory.ExpenseChartDataAccess().ExpenseChart();
        }
    }
}


