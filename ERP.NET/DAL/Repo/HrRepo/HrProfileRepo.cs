using DAL.EF;
using DAL.Interfaces.Common;
using DAL.Interfaces.Hr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.HrRepo
{
    public class HrProfileRepo : IRepo<User, int, bool>, IProfileEdit<User, int, string>, IHrEmail<Hr_Email, string>
    {
        ERPEntities db;

        public HrProfileRepo(ERPEntities db)
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

        public string EmailSend(Hr_Email email)
        {
            var Email = "student.38040@gmail.com";
            var Password = "dkgzjtsehhtwautp";

            using (MailMessage mm = new MailMessage(Email, email.To))
            {
                mm.Subject = email.Subject;
                mm.Body = email.Body;
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential cred = new NetworkCredential(Email, Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = cred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    return "Email sent";
                }
            }

        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public string ProfileEdit(int id, User obj)
        {

           
            var user = db.Users.FirstOrDefault(e => e.id == obj.id);

            var user1 = db.Users.FirstOrDefault(e => e.email== obj.email);

            var user3 = db.Users.FirstOrDefault(e => e.username == obj.username);
            

            if (user1 != null && (!user1.username.Equals(user.username)))
            {
                return "A user with this email address already exists";
            }
            if (user3!= null && (!user3.username.Equals(user.username)))
            {
                return "A user with this username already exists";
            }

            else
            {
                db.Entry(user).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return "Profile Updated successfully";

            }

        }


        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
