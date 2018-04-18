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
    public class VehicleModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VehicleModels
        public async Task<ActionResult> Index()
        {
            var vehicleModels = db.VehicleModels.Include(v => v.VehicleMake);
            return View(await vehicleModels.ToListAsync());
        }

        // GET: VehicleModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = await db.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            ViewBag.VehicleMakeId = new SelectList(db.VehicleMakes, "Id", "Make");
            ViewBag.VehicleColorId = new SelectList(db.VehicleColors, "Id", "Color");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,VehicleColorId,VehicleMakeId,Model,ModelYear,RegNo,NoOfPassengers,ArrivalKms,DateArrived")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.VehicleModels.Add(vehicleModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleMakeId = new SelectList(db.VehicleMakes, "Id", "Make", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = await db.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleMakeId = new SelectList(db.VehicleMakes, "Id", "Make", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,VehicleMakeId,Model")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleMakeId = new SelectList(db.VehicleMakes, "Id", "Make", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = await db.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleModel vehicleModel = await db.VehicleModels.FindAsync(id);
            db.VehicleModels.Remove(vehicleModel);
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
