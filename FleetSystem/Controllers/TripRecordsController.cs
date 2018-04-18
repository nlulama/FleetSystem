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
    public class TripRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TripRecords
        public async Task<ActionResult> Index()
        {
            var tripRecords = db.TripRecords.Include(t => t.Driver).Include(t => t.Trip);
            return View(await tripRecords.ToListAsync());
        }

        // GET: TripRecords/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRecord tripRecord = await db.TripRecords.FindAsync(id);
            if (tripRecord == null)
            {
                return HttpNotFound();
            }
            return View(tripRecord);
        }

        // GET: TripRecords/Create
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name");
            ViewBag.TripId = new SelectList(db.Trips, "Id", "ServiceNo");
            return View();
        }

        // POST: TripRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TripId,Odometer,StoppingPoint,ArrivalTime,Depart,PassengersIn,PassengersOut,DriverId,Remarks")] TripRecord tripRecord)
        {
            if (ModelState.IsValid)
            {
                db.TripRecords.Add(tripRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name", tripRecord.DriverId);
            ViewBag.TripId = new SelectList(db.Trips, "Id", "ServiceNo", tripRecord.TripId);
            return View(tripRecord);
        }

        // GET: TripRecords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRecord tripRecord = await db.TripRecords.FindAsync(id);
            if (tripRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name", tripRecord.DriverId);
            ViewBag.TripId = new SelectList(db.Trips, "Id", "ServiceNo", tripRecord.TripId);
            return View(tripRecord);
        }

        // POST: TripRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TripId,Odometer,StoppingPoint,ArrivalTime,Depart,PassengersIn,PassengersOut,DriverId,Remarks")] TripRecord tripRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name", tripRecord.DriverId);
            ViewBag.TripId = new SelectList(db.Trips, "Id", "ServiceNo", tripRecord.TripId);
            return View(tripRecord);
        }

        // GET: TripRecords/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRecord tripRecord = await db.TripRecords.FindAsync(id);
            if (tripRecord == null)
            {
                return HttpNotFound();
            }
            return View(tripRecord);
        }

        // POST: TripRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TripRecord tripRecord = await db.TripRecords.FindAsync(id);
            db.TripRecords.Remove(tripRecord);
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
