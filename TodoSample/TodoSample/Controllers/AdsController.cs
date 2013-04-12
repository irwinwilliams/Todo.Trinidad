using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TodoSample.Models;

namespace TodoSample.Controllers
{
    public class AdsController : Controller
    {
        private static string atomdata = "https://spreadsheets.google.com/feeds/list/0AqDm6Izoam4OdEpMN2VLT3RxV0szRThYOVA4VUhrdmc/ocx/public/basic";
        private static WebClient AtomService;
        private static List<AdFactor> AdFactors;

        static AdsController()
        {
            AtomService = new WebClient();
            //AtomService.DownloadDataCompleted += AtomService_DownloadDataCompleted;
            //AtomService.DownloadDataAsync(new Uri(atomdata));
            var data = AtomService.DownloadData(new Uri(atomdata));
            Process(data);
        }

        static void AtomService_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Process(e.Result);
        }

        private static void Process(byte[] data)
        {
            string textData = System.Text.Encoding.UTF8.GetString(data);

            XNamespace atomNS = "http://www.w3.org/2005/Atom";
            XNamespace dNS = "http://schemas.microsoft.com/ado/2007/08/dataservices";
            XNamespace mNS = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
            XNamespace gNS = "http://www.georss.org/georss";
            var results = (from item in XElement.Parse(textData).Descendants(atomNS + "entry")
                           select new AdFactor(
                               item.Element(atomNS + "title").Value, 
                               item.Element(atomNS + "content").Value));
            AdFactors = results.ToList();
        }
        //
        // GET: /Ads/

        public ActionResult Index()
        {
            TodoSample.Models.todotntEntities context = new Models.todotntEntities();
            return View(context.Ads.Where(a => a.UserProfile.UserName == User.Identity.Name));
        }

        //
        // GET: /Ads/Details/5

        public ActionResult Details(int id)
        {

            //update
            var data = AtomService.DownloadData(new Uri(atomdata));
            Process(data);
            var thisMonth = DateTime.Now.ToString("MMMM").ToUpper();
            
            var thisMonthsFactors = (from f in AdFactors
                                    where f.Name.ToUpper() 
                                    == thisMonth
                                    select f).FirstOrDefault();
            double sum = thisMonthsFactors.FNF + thisMonthsFactors.Leisure +
                thisMonthsFactors.Business + thisMonthsFactors.Other + thisMonthsFactors.Study +
                thisMonthsFactors.Wedding;
            double rem = 100 - sum;

            int fnf = (int)Math.Round(thisMonthsFactors.FNF / 100 * id, 0);
            int lei = (int)Math.Round(thisMonthsFactors.Leisure / 100 * id, 0);
            int biz = (int)Math.Round(thisMonthsFactors.Business / 100 * id, 0);
            int wed = (int)Math.Round(thisMonthsFactors.Wedding / 100 * id, 0);
            int sty = (int)Math.Round(thisMonthsFactors.Study / 100 * id, 0);
            int oth = (int)Math.Round(thisMonthsFactors.Other / 100 * id, 0);

            int fnfMore = (int)((rem / 2)/100 * id);
            fnf += fnfMore;
            lei += fnfMore;
            

            TodoSample.Models.todotntEntities context = new Models.todotntEntities();
            context.Configuration.ProxyCreationEnabled = false;

            var ads = context.GetAdsByFactors(fnf, lei, biz, wed, sty, oth).ToList();
            return Json(ads, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Ads/Create

        public ActionResult Create()
        {
            TodoSample.Models.todotntEntities context = new Models.todotntEntities();
            ViewBag.Category = new SelectList(context.Categories, "ID", "Name");
            ViewBag.AdType = new SelectList(context.AdTypes, "ID", "Name");
            return View();
        }

        //
        // POST: /Ads/Create

        [HttpPost]
        public ActionResult Create(TodoSample.Models.Ad ad)
        {
            try
            {
                // TODO: Add insert logic here
                TodoSample.Models.todotntEntities context = new Models.todotntEntities();
                ad.UserProfile = context.Users.First(u => u.UserName == User.Identity.Name);
                context.Ads.Add(ad);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ads/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Ads/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ads/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Ads/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
