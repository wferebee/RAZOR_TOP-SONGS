using SongsRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SongsRazor.Controllers
{
    public class TopSongsController : Controller
    {
        // GET: TopSongs
        public ActionResult Index()
        {
            List<Object> cool  = new List<Object>();
            using (top_songsdbEntities cty = new top_songsdbEntities())
            {

                var query = cty.top5000.Where(x => x.position == 16);
              

                foreach(var z in query)
                {
                    cool.Add(z);
                }
                ViewBag.Songs = cool;
            }
            return View(cool);
                
        }

        // GET: TopSongs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TopSongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopSongs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TopSongs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TopSongs/Edit/5
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

        // GET: TopSongs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TopSongs/Delete/5
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
