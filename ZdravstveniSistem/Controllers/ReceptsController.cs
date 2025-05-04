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
    public class ReceptsController : Controller
    {
        private ZdravstveniSistemContext db = new ZdravstveniSistemContext();

        // GET: Recepts
        public ActionResult Index()
        {
            var recepts = db.Recepts.Include(r => r.Obisk);
            return View(recepts.ToList());
        }

        // GET: Recepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recept recept = db.Recepts.Find(id);
            if (recept == null)
            {
                return HttpNotFound();
            }
            return View(recept);
        }

        // GET: Recepts/Create
        public ActionResult Create()
        {
            ViewBag.ObiskId = new SelectList(db.Obisks, "Id", "RazlogObiska");
            return View();
        }

        // POST: Recepts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImeZdravila,Doziranje,DneviJemanja,Navodila,ObiskId")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                db.Recepts.Add(recept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObiskId = new SelectList(db.Obisks, "Id", "RazlogObiska", recept.ObiskId);
            return View(recept);
        }

        // GET: Recepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recept recept = db.Recepts.Find(id);
            if (recept == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObiskId = new SelectList(db.Obisks, "Id", "RazlogObiska", recept.ObiskId);
            return View(recept);
        }

        // POST: Recepts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImeZdravila,Doziranje,DneviJemanja,Navodila,ObiskId")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObiskId = new SelectList(db.Obisks, "Id", "RazlogObiska", recept.ObiskId);
            return View(recept);
        }

        // GET: Recepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recept recept = db.Recepts.Find(id);
            if (recept == null)
            {
                return HttpNotFound();
            }
            return View(recept);
        }

        // POST: Recepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recept recept = db.Recepts.Find(id);
            db.Recepts.Remove(recept);
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
