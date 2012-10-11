using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLReport;
using ReportModel;

namespace Report.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(new BLUser().GetUsers());
        }

        public ActionResult Details(int id)
        {
            ViewBag.Stations = new BLStation().GetStations();
            return View(new BLUser().GetUser(id));
        }

        public ActionResult Add()
        {
            ViewBag.Stations = new BLStation().GetStations();
            return View(new NewUserModel());
        }

        [HttpPost]
        public ActionResult Add(NewUserModel model)
        {
            if (ModelState.IsValid)
            {
                new BLUser().CreateUser(model);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Update(int userid, string username, string password, int stationid)
        {
            BLStation blstation = new BLStation();
            var usermodel = new UserModel()
            {
                StationID = stationid,
                UserName = username,
                Password = password,
                UserID = userid
            };
            new BLUser().UpdateUser(usermodel);
            return RedirectToAction("Details", new { id = userid });
        }

        public ActionResult Delete(int id)
        {
            new BLUser().DeleteUser(id);
            return RedirectToAction("index");
        }

    }
}
