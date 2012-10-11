using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAReport;
using ReportModel;
using ReportModel.Common;

namespace BLReport
{
    public class BLUser
    {
        private DAUser daUser = new DAUser();

        public int CreateUser(NewUserModel user)
        {
            return daUser.CreateUser(user);
        }

        public UserModel GetUser(int userid)
        {
            return daUser.GetUser(userid);
        }

        public IList<UserModel> GetUsers()
        {
            return daUser.GetUsers();
        }


        public void DeleteUser(int id)
        {
            daUser.DeleteUser(id);
        }

        public void ResetPassword(int id)
        {
            string newpassword = Guid.NewGuid().ToString().Substring(0, 6);
            daUser.ResetPassword(id, newpassword);
        }

        public int ValidateUser(string username, string password)
        {
            return daUser.ValidateUser(username, password);
        }

        public bool ChangePassword(int userid, string oldpassword, string newpassword)
        {
            return daUser.ChangePassword(userid, oldpassword, newpassword);

        }

        public void UpdateUser(UserModel user)
        {
            daUser.UpdateUser(user);
        }
    }
}
