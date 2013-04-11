using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoTrinidadAndTobago.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> categories = new List<string>()
            {
                "Visiting Friends & Relatives", 
                "Leisure",
                "Business",
                "Wedding/Honeymoon",
                "Study",
                "Other"
            };

            ViewBag.SelectedCategory = new SelectList(categories);
            ViewBag.Category = GetCurrentCategory();

            return View();
        }

        private string GetCurrentCategory()
        {
            return "Leisure";
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
