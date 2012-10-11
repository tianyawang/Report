using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportModel;
using Report.Models;
using BLReport;

namespace Report.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DailyAmountReport()
        {
            return View(new DailyAmountReport());
        }

        [HttpPost]
        public ActionResult DailyAmountReport(DailyAmountReport model)
        {
            if (ModelState.IsValid)
            {
                model.CrUser = CurrentUserModel.Current.UserID;
                model.StationID = CurrentUserModel.Current.StationID;
                new BLReports().AddDailyAmountReport(model);
                return Content("<script>alert('添加成功');window.location.href='/report/DailyAmountReport';</script>");

            }
            return View(model);
        }

        public ActionResult DailyCardReport()
        {
            ViewBag.Classes = new BLStation().GetCollectionClasses(CurrentUserModel.Current.StationID);
            return View(new DailyCardReport());
        }

        [HttpPost]
        public ActionResult DailyCardReport(DailyCardReport model)
        {
            if (ModelState.IsValid)
            {
                model.CrUser = CurrentUserModel.Current.UserID;
                model.StationID = CurrentUserModel.Current.StationID;
                new BLReports().AddDailyCardReport(model);
                return Content("<script>alert('添加成功');window.location.href='/report/DailyCardReport';</script>");

            }
            return View(model);
        }

        public ActionResult TrafficReport()
        {
            return View(new TrafficeFlowReport());
        }

        [HttpPost]
        public ActionResult TrafficReport(TrafficeFlowReport model)
        {
            if (ModelState.IsValid)
            {
                model.CrUser = CurrentUserModel.Current.UserID;
                model.StationID = CurrentUserModel.Current.StationID;
                new BLReports().AddTrafficReport(model);
                return Content("<script>alert('添加成功');window.location.href='/report/TrafficReport';</script>");

            }
            return View(model);
        }

        public ActionResult Truck5Report()
        {
            return View(new Truck5ReportModel());
        }

        [HttpPost]
        public ActionResult Truck5Report(Truck5ReportModel model)
        {
            if (ModelState.IsValid)
            {
                model.CrUser = CurrentUserModel.Current.UserID;
                model.StationID = CurrentUserModel.Current.StationID;
                model.Year = DateTime.Now.Year;
                new BLReports().AddTruck5Report(model);
                return Content("<script>alert('添加成功');window.location.href='/report/Truck5Report';</script>");

            }
            return View(model);
        }

        public ActionResult Truck6Report()
        {
            return View(new Truck6ReportModel());
        }

        [HttpPost]
        public ActionResult Truck6Report(Truck6ReportModel model)
        {
            if (ModelState.IsValid)
            {
                model.CrUser = CurrentUserModel.Current.UserID;
                model.StationID = CurrentUserModel.Current.StationID;
                model.Year = DateTime.Now.Year;
                new BLReports().AddTruck6Report(model);
                return Content("<script>alert('添加成功');window.location.href='/report/Truck6Report';</script>");

            }
            return View(model);
        }

        public ActionResult SpiltBill()
        {
            return View(new SplitBillReport());
        }

        [HttpPost]
        public ActionResult SpiltBill(SplitBillReport model)
        {
            if (ModelState.IsValid)
            {
                model.CrUser = CurrentUserModel.Current.UserID;
                model.StationID = CurrentUserModel.Current.StationID;
                model.Year = DateTime.Now.Year;
                new BLReports().SpiltBill(model);
                return Content("<script>alert('添加成功');window.location.href='/report/SpiltBill';</script>");

            }
            return View(model);
        }

        public ActionResult ShortOver()
        {
            return View(new ShortOverReport());
        }

        [HttpPost]
        public ActionResult ShortOver(ShortOverReport model)
        {
            if (ModelState.IsValid)
            {
                model.CrUser = CurrentUserModel.Current.UserID;
                model.StationID = CurrentUserModel.Current.StationID;
                new BLReports().AddShortOver(model);
                return Content("<script>alert('添加成功');window.location.href='/report/ShortOver';</script>");

            }
            return View(model);
        }

        public ActionResult tollstationReport()
        {
            return View();
        }

        public ActionResult chargedepartmentReport()
        {

            return View();
        }

    }
}
