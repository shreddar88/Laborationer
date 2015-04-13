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
    public class KundInfoesController : Controller
    {
        private AsciEntities db = new AsciEntities();

        // GET: KundInfoes
        public ActionResult Index()
        {
            return View(db.KundInfoes.ToList());
        }

        // GET: KundInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundInfo kundInfo = db.KundInfoes.Find(id);
            if (kundInfo == null)
            {
                return HttpNotFound();
            }
            return View(kundInfo);
        }

        // GET: KundInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KundInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KID,ForetagsNamn,Adress")] KundInfo kundInfo)
        {
            if (ModelState.IsValid)
            {
                db.KundInfoes.Add(kundInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kundInfo);
        }

        // GET: KundInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundInfo kundInfo = db.KundInfoes.Find(id);
            if (kundInfo == null)
            {
                return HttpNotFound();
            }
            return View(kundInfo);
        }

        // POST: KundInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KID,ForetagsNamn,Adress")] KundInfo kundInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kundInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kundInfo);
        }

        // GET: KundInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundInfo kundInfo = db.KundInfoes.Find(id);
            if (kundInfo == null)
            {
                return HttpNotFound();
            }
            return View(kundInfo);
        }

        // POST: KundInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KundInfo kundInfo = db.KundInfoes.Find(id);
            db.KundInfoes.Remove(kundInfo);
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
