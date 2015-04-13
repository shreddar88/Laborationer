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
    public class vPresentationsController : Controller
    {
        private AsciEntities db = new AsciEntities();

        // GET: vPresentations
        public ActionResult Index(string searchString)
        {
            var vpresentation = from m in db.vPresentations
                         select m;

            if(!String.IsNullOrEmpty(searchString))
            {
                vpresentation = vpresentation.Where(s => s.ForetagsNamn.Contains(searchString));
            }
            return View(vpresentation);
        }

        // GET: vPresentations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vPresentation vPresentation = db.vPresentations.Find(id);
            if (vPresentation == null)
            {
                return HttpNotFound();
            }
            return View(vPresentation);
        }

        // GET: vPresentations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vPresentations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ForetagsNamn,Adress,FID,ArbetsTimmar,Datum,SubTotal,ArbetsPeriod,Value")] vPresentation vPresentation)
        {
            if (ModelState.IsValid)
            {
                db.vPresentations.Add(vPresentation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vPresentation);
        }

        // GET: vPresentations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vPresentation vPresentation = db.vPresentations.Find(id);
            if (vPresentation == null)
            {
                return HttpNotFound();
            }
            return View(vPresentation);
        }

        // POST: vPresentations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ForetagsNamn,Adress,FID,ArbetsTimmar,Datum,SubTotal,ArbetsPeriod,Value")] vPresentation vPresentation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vPresentation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vPresentation);
        }

        // GET: vPresentations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vPresentation vPresentation = db.vPresentations.Find(id);
            if (vPresentation == null)
            {
                return HttpNotFound();
            }
            return View(vPresentation);
        }

        // POST: vPresentations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            vPresentation vPresentation = db.vPresentations.Find(id);
            db.vPresentations.Remove(vPresentation);
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
