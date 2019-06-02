using MVCApplication.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult Index()
        {
            var myList = db.Realeses.OrderBy(x => x.ReleaseDate).ToList();
            return View(myList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}