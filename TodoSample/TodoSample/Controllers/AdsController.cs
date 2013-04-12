using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoSample.Controllers
{
    public class AdsController : Controller
    {
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
            TodoSample.Models.todotntEntities context = new Models.todotntEntities();

            return View(context.Ads.First(a => a.ID == id));
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
