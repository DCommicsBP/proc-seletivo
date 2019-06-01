using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAplication.Models;
using MVCApplication.DAO;

namespace MVCApplication.Controllers
{
    public class ReleasesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Releases
        public ActionResult Index(DateTime? start, DateTime? end)
        {
            ViewBag.start = new DateTime();
            ViewBag.end= new DateTime();

            var orders = db.Realeses
                .Where(x => x.ReleaseDate != null
                && x.ReleaseDate > start
                && x.ReleaseDate < end)
                .OrderByDescending(x => x.Status)
                .ToList();
            ViewBag.start = new DateTime(); 

            return View(orders);
        }


        // GET: Releases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Release release = db.Realeses.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            return View(release);
        }

        // GET: Releases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Releases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReleaseDate,Description,Value,Type,Status")] Release release)
        {
            if (ModelState.IsValid)
            {
                db.Realeses.Add(release);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(release);
        }

        // GET: Releases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Release release = db.Realeses.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            return View(release);
        }

        // POST: Releases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ReleaseDate,Description,Value,Type,Status")] Release release)
        {
            if (ModelState.IsValid)
            {
                db.Entry(release).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(release);
        }

        // GET: Releases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Release release = db.Realeses.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            return View(release);
        }

        // POST: Releases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Release release = db.Realeses.Find(id);
            db.Realeses.Remove(release);
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
