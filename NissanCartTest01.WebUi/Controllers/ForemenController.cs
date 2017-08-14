using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NissanCartTest01.WebUi.Models;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize(Roles = "admin")]
    public class ForemenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Foreman
        public ActionResult Index()
        {
            return View(db.Foremens.ToList());
        }

        // GET: Foreman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foremen foreman = db.Foremens.Find(id);
            if (foreman == null)
            {
                return HttpNotFound();
            }
            return View(foreman);
        }

        // GET: Foreman/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Foreman/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ForemanId,Name,Description,ContactNumber,Address,username")] Foremen foreman)
        {
            if (ModelState.IsValid)
            {
                db.Foremens.Add(foreman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foreman);
        }

        // GET: Foreman/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foremen foreman = db.Foremens.Find(id);
            if (foreman == null)
            {
                return HttpNotFound();
            }
            return View(foreman);
        }

        // POST: Foreman/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ForemanId,Name,Description,ContactNumber,Address,username")] Foremen foreman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foreman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foreman);
        }

        // GET: Foreman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foremen foreman = db.Foremens.Find(id);
            if (foreman == null)
            {
                return HttpNotFound();
            }
            return View(foreman);
        }

        // POST: Foreman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foremen foreman = db.Foremens.Find(id);
            db.Foremens.Remove(foreman);
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
