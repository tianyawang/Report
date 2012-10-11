using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReportModel;
using BLReport;

namespace Report.Models
{
    public class CurrentUserModel
    {
        public UserModel UserName { get; private set; }

        public static UserModel Current
        {
            get
            {

                UserModel user;
                if (!HttpContext.Current.Items.Contains(ZTMUserKey))
                {
                    int userid = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    user = new BLUser().GetUser(userid);
                    HttpContext.Current.Items[ZTMUserKey] = user;
                }
                else
                {
                    user = HttpContext.Current.Items[ZTMUserKey] as UserModel;
                }
                return user;
            }
        }
        const string ZTMUserKey = "CurrentUser";
    }
}