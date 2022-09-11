using DAL.EF;
using DAL.Interfaces.FinanceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.FinanceManagerRepo
{
    public class EmailSendRepo : IEmail<FinanceManager_Email, string>
    {
        private ERPEntities db;

        public EmailSendRepo(ERPEntities db)
        {
            this.db = db;
        }

        public string emailsend(FinanceManager_Email obj)
        {
            var Email = "student.38040@gmail.com";

            using (MailMessage mm = new MailMessage(Email, obj.To))
            {
                mm.Subject = obj.Subject;
                mm.Body = obj.Body;
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential cred = new NetworkCredential(Email, obj.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = cred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    return "Email sent";
                }
            }

            
        }
    }
}
