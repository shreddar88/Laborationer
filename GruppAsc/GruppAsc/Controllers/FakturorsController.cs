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
    public class FakturorsController : Controller
    {
        private AsciEntities db = new AsciEntities();

        // GET: Fakturors
        public ActionResult Index()
        {
            var fakturors = db.Fakturors.Include(f => f.Bestallningar).Include(f => f.Status);
            return View(fakturors.ToList());
        }

        // GET: Fakturors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakturor fakturor = db.Fakturors.Find(id);
            if (fakturor == null)
            {
                return HttpNotFound();
            }
            return View(fakturor);
        }

        // GET: Fakturors/Create
        public ActionResult Create()
        {
            ViewBag.BID = new SelectList(db.Bestallningars, "BID", "BID");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Value");
            return View();
        }

        // POST: Fakturors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FID,BID,Datum,SubTotal,StatusID,ArbetsTimmar,OCRNummer")] Fakturor fakturor)
        {
            if (ModelState.IsValid)
            {
                db.Fakturors.Add(fakturor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BID = new SelectList(db.Bestallningars, "BID", "BID", fakturor.BID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Value", fakturor.StatusID);
            return View(fakturor);
        }

        // GET: Fakturors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakturor fakturor = db.Fakturors.Find(id);
            if (fakturor == null)
            {
                return HttpNotFound();
            }
            ViewBag.BID = new SelectList(db.Bestallningars, "BID", "BID", fakturor.BID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Value", fakturor.StatusID);
            return View(fakturor);
        }

        // POST: Fakturors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FID,BID,Datum,SubTotal,StatusID,ArbetsTimmar,OCRNummer")] Fakturor fakturor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fakturor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BID = new SelectList(db.Bestallningars, "BID", "BID", fakturor.BID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Value", fakturor.StatusID);
            return View(fakturor);
        }

        // GET: Fakturors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakturor fakturor = db.Fakturors.Find(id);
            if (fakturor == null)
            {
                return HttpNotFound();
            }
            return View(fakturor);
        }

        // POST: Fakturors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fakturor fakturor = db.Fakturors.Find(id);
            db.Fakturors.Remove(fakturor);
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
