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
   public class ProfileRepo : IRepo<User, int, bool> , IProfile<User , int, string> , IPass<FinanceManagerPass,int,string>
    {
        private ERPEntities db;

        public ProfileRepo(ERPEntities db)
        {
            this.db = db;
        }

        public bool Create(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            var user = (from e in db.Users
                            where e.id == id
                            select e).FirstOrDefault();
            return user;
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }

        public string UpdatePass(int id, FinanceManagerPass obj)
        {
            var a = (string)obj.password;
            var b = (string)obj.password1;
            var c = (string)obj.password2;

            var user = (from e in db.Users
                        where e.id==id
                        select e).SingleOrDefault();

            if (!user.password.Equals(a))
            {
                return "Your current password doesnot match";
            }
            else
            {
                if (!b.Equals(c))
                {
                    return "Your new password and confirm new password doesnot match";
                }
                else
                {
                    if (b.Length < 7)
                    {
                        return "New password must be at least 7 character";
                    }
                    else if (a.Equals(b))
                    {
                        return "Current password and new password should not be match";
                    }
                    else
                    {
                        user.password = b;
                        db.SaveChanges();
                        return "Password successfully updated";
                    }
                }
            }
            
        }

        public string UpdateProfile(int id, User ff)
        {
            var user = (from e in db.Users
                        where e.id==id
                        select e).SingleOrDefault();
            var count = 0;
            var str = "";
            if (!user.username.Equals(ff.username))
            {
                var user1 = (from e in db.Users
                             where e.username.Equals(ff.username)
                             select e).SingleOrDefault();
                if (user1 != null)
                {
                    return "This username already used";
                }
                else
                {
                    count++;
                    str += "Username" + ",";
                }
            }
            if (!user.email.Equals(ff.email))
            {
                var user2 = (from e in db.Users
                             where e.email.Equals(ff.email)
                             select e).SingleOrDefault();
                if (user2 != null)
                {
                    return "This email already used";
                }
                else
                {
                    count++;
                    str += "Email" + ",";
                }
            }

            if (!user.phone.Equals(ff.phone))
            {
                var user3 = (from e in db.Users
                             where e.phone.Equals(ff.phone)
                             select e).SingleOrDefault();
                if (user3 != null)
                {
                    return "This Mobile number already used";
                }
                else
                {
                    count++;
                    str += "Mobile number" + ",";
                }
            }
            if (user.address != (ff.address))
            {
                count++;
                str += "Address";
            }

            if (count == 0)
            {
                return "You don't apply to update anything,Thank You!";
            }
            else
            {
                str=str+ " " + "Update successfully";
                user.username = ff.username;
                user.email = ff.email;
                user.phone = ff.phone;
                user.address = ff.address;
                db.SaveChanges();
                return str;

            }

        }
    }
}
