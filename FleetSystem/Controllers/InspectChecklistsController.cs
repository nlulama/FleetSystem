using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FleetSystem.Models;

namespace FleetSystem.Controllers
{
    public class InspectChecklistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InspectChecklists
        public async Task<ActionResult> Index()
        {
            var inspectChecklists = db.InspectChecklists.Include(i => i.Route);
            return View(await inspectChecklists.ToListAsync());
        }

        // GET: InspectChecklists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectChecklist inspectChecklist = await db.InspectChecklists.FindAsync(id);
            if (inspectChecklist == null)
            {
                return HttpNotFound();
            }
            return View(inspectChecklist);
        }

        // GET: InspectChecklists/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName");
            return View();
        }

        // POST: InspectChecklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,RouteId,VehicleId,StartKm")] InspectChecklist inspectChecklist)
        {
            if (ModelState.IsValid)
            {
                db.InspectChecklists.Add(inspectChecklist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName", inspectChecklist.RouteId);
            return View(inspectChecklist);
        }

        // GET: InspectChecklists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectChecklist inspectChecklist = await db.InspectChecklists.FindAsync(id);
            if (inspectChecklist == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName", inspectChecklist.RouteId);
            return View(inspectChecklist);
        }

        // POST: InspectChecklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,RouteId,VehicleId,StartKm")] InspectChecklist inspectChecklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectChecklist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName", inspectChecklist.RouteId);
            return View(inspectChecklist);
        }

        // GET: InspectChecklists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectChecklist inspectChecklist = await db.InspectChecklists.FindAsync(id);
            if (inspectChecklist == null)
            {
                return HttpNotFound();
            }
            return View(inspectChecklist);
        }

        // POST: InspectChecklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InspectChecklist inspectChecklist = await db.InspectChecklists.FindAsync(id);
            db.InspectChecklists.Remove(inspectChecklist);
            await db.SaveChangesAsync();
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
