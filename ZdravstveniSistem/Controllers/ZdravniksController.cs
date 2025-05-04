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
    public class ZdravniksController : Controller
    {
        private ZdravstveniSistemContext db = new ZdravstveniSistemContext();

        // GET: Zdravniks
        public ActionResult Index()
        {
            return View(db.Zdravniks.ToList());
        }

        // GET: Zdravniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdravnik zdravnik = db.Zdravniks.Find(id);
            if (zdravnik == null)
            {
                return HttpNotFound();
            }
            return View(zdravnik);
        }

        // GET: Zdravniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zdravniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Priimek,Specializacija,Email,TelefonskaStevilka,LetoZaposlitve")] Zdravnik zdravnik)
        {
            if (ModelState.IsValid)
            {
                db.Zdravniks.Add(zdravnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zdravnik);
        }

        // GET: Zdravniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdravnik zdravnik = db.Zdravniks.Find(id);
            if (zdravnik == null)
            {
                return HttpNotFound();
            }
            return View(zdravnik);
        }

        // POST: Zdravniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Priimek,Specializacija,Email,TelefonskaStevilka,LetoZaposlitve")] Zdravnik zdravnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zdravnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zdravnik);
        }

        // GET: Zdravniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdravnik zdravnik = db.Zdravniks.Find(id);
            if (zdravnik == null)
            {
                return HttpNotFound();
            }
            return View(zdravnik);
        }

        // POST: Zdravniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zdravnik zdravnik = db.Zdravniks.Find(id);
            db.Zdravniks.Remove(zdravnik);
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
