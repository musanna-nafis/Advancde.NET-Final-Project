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
    public class FinanceManagerBudgetingService
    {
        public static List<BankModel> connectedbank(int id)
        {
            var data = DataAccessFactory.FinanceManagerBankworkDataAccess().All(id);
            var bank = new List<BankModel>();
            foreach (var item in data)
            {
                bank.Add(new BankModel()
                {
                    id = item.id,
                    name = item.name,
                    holder_name = item.holder_name,
                    account_no=item.account_no,
                    balance=item.balance,
                    manager_id = item.manager_id
                });
            }
            return bank;
        }

        public static bool disconnectdbank(int id,int id1)
        { 
            return DataAccessFactory.FinanceManagerBankworkDataAccess().Disconnect(id, id1);
        }

        public static string addBank(int id, BankModel b)
        {
            var bank = new Bank();
            bank.id = b.id;
            bank.name = b.name;
            bank.holder_name = b.holder_name;
            bank.account_no = b.account_no;
            bank.balance = b.balance;
            bank.manager_id =id;
            return DataAccessFactory.FinanceManagerBankworkDataAccess().Add(bank,id);
            
        }

        public static string expense(int id, AssetModel a)
        {
            var asset = new Asset();
            asset.id = a.id;
            asset.amount = a.amount;
            asset.manager_id = a.manager_id;
            asset.type = a.type;
            return DataAccessFactory.FinanceManagerAssetDataAccess().Expenses(id,asset);

        }

        public static string liability(int id, LiabilityModel a)
        {
            var lib = new Liability();
            lib.id = a.id;
            lib.amount = a.amount;
            lib.manager_id = a.manager_id;
            lib.type = a.type;
            return DataAccessFactory.FinanceManagerLiabilityDataAccess().Liability(id, lib);

        }

        public static string asset(int id, AssetModel a)
        {
            var asset = new Asset();
            asset.id = a.id;
            asset.amount = a.amount;
            asset.manager_id = a.manager_id;
            asset.type = a.type;
            return DataAccessFactory.FinanceManagerAssetDataAccess().Asset(id, asset);

        }
    }
}
