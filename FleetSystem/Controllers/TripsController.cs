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
    public class TripsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trips
        public async Task<ActionResult> Index()
        {
            var trips = db.Trips.Include(t => t.Vehicle);
            return View(await trips.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(db.VehicleModels, "Id", "Model");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,ServiceNo,FromId,ToId,VehicleId,StartKm,EndKm")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(db.VehicleModels, "Id", "Model", trip.VehicleId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(db.VehicleModels, "Id", "Model", trip.VehicleId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,ServiceNo,FromId,ToId,VehicleId,StartKm,EndKm")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(db.VehicleModels, "Id", "Model", trip.VehicleId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trip trip = await db.Trips.FindAsync(id);
            db.Trips.Remove(trip);
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
