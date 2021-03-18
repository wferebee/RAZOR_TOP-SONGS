using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SongsRazor.Models;

namespace SongsRazor.Controllers
{
    public class top5000Controller : Controller
    {
        private top_songsdbEntities db = new top_songsdbEntities();

        // GET: top5000
        public ActionResult Index()
        {
            return View(db.top5000.Where(x => x.position == 16).ToList());
        }

        // GET: top5000/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            top5000 top5000 = db.top5000.Find(id);
            if (top5000 == null)
            {
                return HttpNotFound();
            }
            return View(top5000);
        }

        // GET: top5000/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: top5000/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "position,artist,song,year,raw_total,raw_usa,raw_uk,raw_eur,raw_row")] top5000 top5000)
        {
            if (ModelState.IsValid)
            {
                db.top5000.Add(top5000);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(top5000);
        }

        // GET: top5000/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            top5000 top5000 = db.top5000.Find(id);
            if (top5000 == null)
            {
                return HttpNotFound();
            }
            return View(top5000);
        }

        // POST: top5000/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "position,artist,song,year,raw_total,raw_usa,raw_uk,raw_eur,raw_row")] top5000 top5000)
        {
            if (ModelState.IsValid)
            {
                db.Entry(top5000).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(top5000);
        }

        // GET: top5000/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            top5000 top5000 = db.top5000.Find(id);
            if (top5000 == null)
            {
                return HttpNotFound();
            }
            return View(top5000);
        }

        // POST: top5000/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            top5000 top5000 = db.top5000.Find(id);
            db.top5000.Remove(top5000);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
