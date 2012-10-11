using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Report.Models;

namespace Report.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (CurrentUserModel.Current.Role != 0)
                return View();

            if (CurrentUserModel.Current.StationID == 0)
                return View("~/views/report/chargedepartmentReport.aspx");
            else
                return View("~/views/report/stationReport.aspx");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
