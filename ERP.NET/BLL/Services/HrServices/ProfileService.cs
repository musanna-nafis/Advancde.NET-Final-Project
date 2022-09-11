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
    public class ProfileService
    {
        public static UserModel Get(int id)
        {
            var user = DataAccessFactory.ProfileDataAccess().Get(id);

            var p = new UserModel()
            {
                id = user.id,
                firstname = user.firstname,
                lastname = user.lastname,
                phone = user.phone,
                email = user.email,
                address = user.address,
                username = user.username,
                dob = user.dob,
                gender=user.gender,
                position=user.position,
                type=user.type,
                organization_id=user.organization_id,
                user_status=user.user_status


            };
            return p;

        }
        public static string EditProfile(int id, UserModel u)
        {

            var user = new User();
            user.id = u.id;
            user.username = u.username;
            user.email = u.email;
            user.phone = u.phone;
            user.address = u.address;
            var data = DataAccessFactory.ProfileEditDataAccess().ProfileEdit(id, user);
            return data;
        }
        public static string SendEmail(Hr_EmailModel email)
        {
            var e = new Hr_Email();
            e.To = email.To;
            e.Subject = email.Subject;
            e.Body = email.Body;
            return DataAccessFactory.HrEmailDataAccess().EmailSend(e);

        }

    }
}
    

