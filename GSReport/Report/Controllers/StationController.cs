using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLReport;

namespace Report.Controllers
{
    public class StationController : Controller
    {
        //
        // GET: /Station/

        public ActionResult Index()
        {
            return View(new BLStation().GetStations());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string stationname)
        {
            new BLStation().AddStation(stationname);
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            return View(new BLStation().GetStation(id));
        }

        [HttpPost]
        public ActionResult Update(int id,string stationname)
        {
            new BLStation().UpdateStation(id,stationname);
            return RedirectToAction("index");
        }


        public ActionResult delete(int id)
        {
            new BLStation().DeleteStation(id);
            return RedirectToAction("index");
        }

        public ActionResult CollectionClasses(int id)
        {
            ViewBag.StationID = id;
            return View(new BLStation().GetCollectionClasses(id));
        }


        public ActionResult AddClass(int id)
        {
            ViewBag.StationID = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddClass(int id, string classname)
        {
            new BLStation().AddCollectionClass(id,classname);
            return RedirectToAction("CollectionClasses", new { id = id });
        }

        public ActionResult deleteclass(int id,int stationid)
        {
            new BLStation().DeleteClass(id);
            return RedirectToAction("CollectionClasses", new { id = stationid });
        }

    }
}
