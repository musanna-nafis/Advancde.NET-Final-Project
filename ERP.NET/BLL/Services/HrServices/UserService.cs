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
    public class UserService
    {
        public static List<UserModel> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var users = new List<UserModel>();
            foreach (var u in data)
            {
                users.Add(new UserModel()
                {
                    firstname = u.firstname,
                    lastname = u.lastname,
                    username = u.username,
                    organization_id = u.organization_id,
                    password = u.password,
                    gender = u.gender,
                    type = u.type,
                    phone = u.phone,
                    address = u.address,
                    email = u.email,
                    position = u.position

                });
                
        }
        return users;
    }
    public static bool Create(UserModel u)
        {
            var user = new User();
            

            user.firstname = u.firstname;
            user.lastname = u.lastname;
            user.username = u.username;
            user.organization_id = u.organization_id;
            user.dob = u.dob;
            user.password = u.password;
            user.gender = u.gender;
            user.type = u.type;
            user.phone = u.phone;
            user.address = u.address;
            user.email = u.email;
            user.position = u.position;
          
            return DataAccessFactory.UserDataAccess().Create(user);
    }
        public static UserModel Get(int id)
        {
            var u= DataAccessFactory.UserDataAccess().Get(id);
            
                var user = new UserModel()
                {
                    id = u.id,
                    firstname = u.firstname,
                    lastname = u.lastname,
                    username = u.username,
                    organization_id = u.organization_id,
                    password = u.password,
                    gender = u.gender,
                    type = u.type,
                    phone = u.phone,
                    address = u.address,
                    email = u.email,
                    position = u.position
                };
                return user;
            
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }
        public static bool Update(UserModel u)
        {
            var product = new User()
            {
                id = u.id,
                firstname = u.firstname,
                lastname = u.lastname,
                username = u.username,
                organization_id = u.organization_id,
                password = u.password,
                gender = u.gender,
                type = u.type,
                phone = u.phone,
                address = u.address,
                email = u.email,
                position = u.position
            };
            return DataAccessFactory.UserDataAccess().Update(product);
        }

    }
   
}














 
           


