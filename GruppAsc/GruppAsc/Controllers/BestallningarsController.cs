using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GruppAsc.Models;

namespace GruppAsc.Controllers
{
    public class BestallningarsController : Controller
    {
        private AsciEntities db = new AsciEntities();

        // GET: Bestallningars
        public ActionResult Index()
        {
            var bestallningars = db.Bestallningars.Include(b => b.KundInfo);
            return View(bestallningars.ToList());
        }

        // GET: Bestallningars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestallningar bestallningar = db.Bestallningars.Find(id);
            if (bestallningar == null)
            {
                return HttpNotFound();
            }
            return View(bestallningar);
        }

        // GET: Bestallningars/Create
        public ActionResult Create()
        {
            ViewBag.KID = new SelectList(db.KundInfoes, "KID", "ForetagsNamn");
            return View();
        }

        // POST: Bestallningars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BID,KID,Datum,ArbetsPeriod")] Bestallningar bestallningar)
        {
            if (ModelState.IsValid)
            {
                db.Bestallningars.Add(bestallningar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KID = new SelectList(db.KundInfoes, "KID", "ForetagsNamn", bestallningar.KID);
            return View(bestallningar);
        }

        // GET: Bestallningars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestallningar bestallningar = db.Bestallningars.Find(id);
            if (bestallningar == null)
            {
                return HttpNotFound();
            }
            ViewBag.KID = new SelectList(db.KundInfoes, "KID", "ForetagsNamn", bestallningar.KID);
            return View(bestallningar);
        }

        // POST: Bestallningars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BID,KID,Datum,ArbetsPeriod")] Bestallningar bestallningar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bestallningar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KID = new SelectList(db.KundInfoes, "KID", "ForetagsNamn", bestallningar.KID);
            return View(bestallningar);
        }

        // GET: Bestallningars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestallningar bestallningar = db.Bestallningars.Find(id);
            if (bestallningar == null)
            {
                return HttpNotFound();
            }
            return View(bestallningar);
        }

        // POST: Bestallningars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bestallningar bestallningar = db.Bestallningars.Find(id);
            db.Bestallningars.Remove(bestallningar);
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
