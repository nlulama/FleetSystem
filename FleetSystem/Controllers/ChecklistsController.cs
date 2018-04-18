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
    public class ChecklistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checklists
        public async Task<ActionResult> Index()
        {
            return View(await db.Checklists.ToListAsync());
        }

        // GET: Checklists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = await db.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // GET: Checklists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CheckListYN,Comments")] Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                db.Checklists.Add(checklist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(checklist);
        }

        // GET: Checklists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = await db.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // POST: Checklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CheckListYN,Comments")] Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checklist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(checklist);
        }

        // GET: Checklists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = await db.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // POST: Checklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Checklist checklist = await db.Checklists.FindAsync(id);
            db.Checklists.Remove(checklist);
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
