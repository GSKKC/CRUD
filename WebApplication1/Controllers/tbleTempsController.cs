using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class tbleTempsController : Controller
    {
        private TemporaryDbEntities db = new TemporaryDbEntities();

        // GET: tbleTemps
        public ActionResult Index()
        {
            return View(db.tbleTemps.ToList());
        }

        // GET: tbleTemps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbleTemp tbleTemp = db.tbleTemps.Find(id);
            if (tbleTemp == null)
            {
                return HttpNotFound();
            }
            return View(tbleTemp);
        }

        // GET: tbleTemps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbleTemps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cname,ctech,cduration,cprice")] tbleTemp tbleTemp)
        {
            if (ModelState.IsValid)
            {
                db.tbleTemps.Add(tbleTemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbleTemp);
        }

        // GET: tbleTemps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbleTemp tbleTemp = db.tbleTemps.Find(id);
            if (tbleTemp == null)
            {
                return HttpNotFound();
            }
            return View(tbleTemp);
        }

        // POST: tbleTemps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cname,ctech,cduration,cprice")] tbleTemp tbleTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbleTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbleTemp);
        }

        // GET: tbleTemps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbleTemp tbleTemp = db.tbleTemps.Find(id);
            if (tbleTemp == null)
            {
                return HttpNotFound();
            }
            return View(tbleTemp);
        }

        // POST: tbleTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbleTemp tbleTemp = db.tbleTemps.Find(id);
            db.tbleTemps.Remove(tbleTemp);
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
