using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using Web.Models;

namespace Web.Controllers
{
    public class MyActionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyActions
        public ActionResult Index()
        {
            return View(db.Actions.ToList());
        }

        // GET: MyActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAction myAction = db.Actions.Find(id);
            if (myAction == null)
            {
                return HttpNotFound();
            }
            return View(myAction);
        }

        // GET: MyActions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Adresse")] MyAction myAction)
        {
            if (ModelState.IsValid)
            {
                db.Actions.Add(myAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myAction);
        }

        // GET: MyActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAction myAction = db.Actions.Find(id);
            if (myAction == null)
            {
                return HttpNotFound();
            }
            return View(myAction);
        }

        // POST: MyActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Adresse")] MyAction myAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myAction);
        }

        // GET: MyActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAction myAction = db.Actions.Find(id);
            if (myAction == null)
            {
                return HttpNotFound();
            }
            return View(myAction);
        }

        // POST: MyActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyAction myAction = db.Actions.Find(id);
            db.Actions.Remove(myAction);
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
