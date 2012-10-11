using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ReportModel.Common;
namespace ReportModel
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public int StationID { get; set; }

        public string StationName { get; set; }

        public int Role { get; set; }

        public string Password { get; set; }
    }

    public class NewUserModel
    {
        [Required(ErrorMessage="用户名不能为空")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }

        public EntityInfo EntityInfo { get; set; }

        public int StationID { get; set; }

    }
}
