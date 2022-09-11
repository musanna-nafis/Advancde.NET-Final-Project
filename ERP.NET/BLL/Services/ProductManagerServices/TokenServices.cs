using BLL.Entities;
using DAL.DataAccessFactory;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ProductManagerServices
{
    public class TokenServices
    {
        public static TokenModel create(int id)
        {
            var token = new Token()
            {
                Token1 = GetToken(),
                UserId = id,
                CreatedAt = DateTime.Now
            };
            var data = DataAccessFactory.ProductManagerTokenDataAccess().Create(token);
            var newToken = new TokenModel()
            {
                id = data.id,
                CreatedAt = data.CreatedAt,
                Token1 = data.Token1,
                UserId = data.UserId
            };
            return newToken;
        }
        public static string GetToken()
        {
            Random res = new Random();
            String str = "abcdefghijklmnopqrstuvwxyz";
            String ran = "";
            for(int i=0;i<40;i++)
            {
                int ind = res.Next(25);
                ran = ran + str[ind];
            }
            string num = "0123456789";
            for(int i=0;i<20;i++)
            {
                int ind = res.Next(9);
                ran = ran + num[ind];
            }
            return ran;
        }
        public static bool Delete(string token)
        {
            return DataAccessFactory.ProductManagerTokenDataAccess().Delete(token);
        }

        public static List<TokenModel> Get()
        {
            var data = DataAccessFactory.ProductManagerTokenDataAccess().Get();
            var tokens = new List<TokenModel>();
            foreach (var item in data)
            {
                
                tokens.Add(new TokenModel()
                {
                    id = item.id,
                    CreatedAt=item.CreatedAt,
                    ExpiredAt=item.ExpiredAt,
                    Token1=item.Token1,
                    UserId=item.UserId

                });
            }
            return tokens;
        }
        public static TokenModel Get(string token)
        {
            var item = DataAccessFactory.ProductManagerTokenDataAccess().Get(token);
            if (item == null) return null;
            return new TokenModel()
            {
                id = item.id,
                CreatedAt = item.CreatedAt,
                ExpiredAt = item.ExpiredAt,
                Token1 = item.Token1,
                UserId = item.UserId
            };
        }
        public static bool Update(TokenModel item)
        {
            var token = new Token()
            {
                id = item.id,
                CreatedAt = item.CreatedAt,
                ExpiredAt = item.ExpiredAt,
                Token1 = item.Token1,
                UserId = item.UserId
            };
            return DataAccessFactory.ProductManagerTokenDataAccess().Update(token);
        }

        public static List<UserLog> TokenByDate(string date)
        {
            var item = DataAccessFactory.ProductManagerTokenDataAccess().Get();
            var x = DateTime.Parse(date).Date;
            var data= (from n in item where DateTime.Parse(n.CreatedAt.ToString()).Date>=DateTime.Parse(date).Date select new UserLog{ UserId= (int)n.UserId,Username=n.User.username,Email=n.User.email,TokenCreatedAt= (DateTime)n.CreatedAt,TokenExpiredAt=n.ExpiredAt}).ToList();
            return data;
        }
    }
}
