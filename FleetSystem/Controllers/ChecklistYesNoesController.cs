using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FleetSystem.Models;

namespace FleetSystem.Controllers
{
    public class ChecklistYesNoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChecklistYesNoes
        public ActionResult Index()
        {
            return View(db.ChecklistYesNoes.ToList());
        }

        // GET: ChecklistYesNoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistYesNo checklistYesNo = db.ChecklistYesNoes.Find(id);
            if (checklistYesNo == null)
            {
                return HttpNotFound();
            }
            return View(checklistYesNo);
        }

        // GET: ChecklistYesNoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChecklistYesNoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] ChecklistYesNo checklistYesNo)
        {
            if (ModelState.IsValid)
            {
                db.ChecklistYesNoes.Add(checklistYesNo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(checklistYesNo);
        }

        // GET: ChecklistYesNoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistYesNo checklistYesNo = db.ChecklistYesNoes.Find(id);
            if (checklistYesNo == null)
            {
                return HttpNotFound();
            }
            return View(checklistYesNo);
        }

        // POST: ChecklistYesNoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] ChecklistYesNo checklistYesNo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checklistYesNo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checklistYesNo);
        }

        // GET: ChecklistYesNoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistYesNo checklistYesNo = db.ChecklistYesNoes.Find(id);
            if (checklistYesNo == null)
            {
                return HttpNotFound();
            }
            return View(checklistYesNo);
        }

        // POST: ChecklistYesNoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChecklistYesNo checklistYesNo = db.ChecklistYesNoes.Find(id);
            db.ChecklistYesNoes.Remove(checklistYesNo);
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
