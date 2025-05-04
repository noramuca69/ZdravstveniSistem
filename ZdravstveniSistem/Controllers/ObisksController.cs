using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZdravstveniSistem.Data;
using ZdravstveniSistem.Models;

namespace ZdravstveniSistem.Controllers
{
    public class ObisksController : Controller
    {
        private ZdravstveniSistemContext db = new ZdravstveniSistemContext();

        // GET: Obisks
        public ActionResult Index()
        {
            var obisks = db.Obisks.Include(o => o.Pacient).Include(o => o.Zdravnik);
            return View(obisks.ToList());
        }

        // GET: Obisks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obisk obisk = db.Obisks.Find(id);
            if (obisk == null)
            {
                return HttpNotFound();
            }
            return View(obisk);
        }

        // GET: Obisks/Create
        public ActionResult Create()
        {
            ViewBag.PacientId = new SelectList(db.Pacients, "Id", "Ime");
            ViewBag.ZdravnikId = new SelectList(db.Zdravniks, "Id", "Ime");
            return View();
        }

        // POST: Obisks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DatumObiska,RazlogObiska,Diagnoza,Opombe,PacientId,ZdravnikId")] Obisk obisk)
        {
            if (ModelState.IsValid)
            {
                db.Obisks.Add(obisk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PacientId = new SelectList(db.Pacients, "Id", "Ime", obisk.PacientId);
            ViewBag.ZdravnikId = new SelectList(db.Zdravniks, "Id", "Ime", obisk.ZdravnikId);
            return View(obisk);
        }

        // GET: Obisks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obisk obisk = db.Obisks.Find(id);
            if (obisk == null)
            {
                return HttpNotFound();
            }
            ViewBag.PacientId = new SelectList(db.Pacients, "Id", "Ime", obisk.PacientId);
            ViewBag.ZdravnikId = new SelectList(db.Zdravniks, "Id", "Ime", obisk.ZdravnikId);
            return View(obisk);
        }

        // POST: Obisks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DatumObiska,RazlogObiska,Diagnoza,Opombe,PacientId,ZdravnikId")] Obisk obisk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obisk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PacientId = new SelectList(db.Pacients, "Id", "Ime", obisk.PacientId);
            ViewBag.ZdravnikId = new SelectList(db.Zdravniks, "Id", "Ime", obisk.ZdravnikId);
            return View(obisk);
        }

        // GET: Obisks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obisk obisk = db.Obisks.Find(id);
            if (obisk == null)
            {
                return HttpNotFound();
            }
            return View(obisk);
        }

        // POST: Obisks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obisk obisk = db.Obisks.Find(id);
            db.Obisks.Remove(obisk);
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
