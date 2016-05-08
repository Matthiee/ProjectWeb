using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eva.Models;
using Eva.Models.DAL;

namespace Eva.Controllers
{
    public class EvaluatiesController : Controller
    {
        private EvaContext db = new EvaContext();

        // GET: Evaluaties
        public ActionResult Index()
        {
            return View(db.Evaluaties.ToList());
        }

        // GET: Evaluaties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluatie evaluatie = db.Evaluaties.Find(id);
            if (evaluatie == null)
            {
                return HttpNotFound();
            }
            return View(evaluatie);
        }

        // GET: Evaluaties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,naam")] Evaluatie evaluatie)
        {
            if (ModelState.IsValid)
            {
                db.Evaluaties.Add(evaluatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluatie);
        }

        // GET: Evaluaties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluatie evaluatie = db.Evaluaties.Find(id);
            if (evaluatie == null)
            {
                return HttpNotFound();
            }
            return View(evaluatie);
        }

        // POST: Evaluaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,naam")] Evaluatie evaluatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluatie);
        }

        // GET: Evaluaties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluatie evaluatie = db.Evaluaties.Find(id);
            if (evaluatie == null)
            {
                return HttpNotFound();
            }
            return View(evaluatie);
        }

        // POST: Evaluaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluatie evaluatie = db.Evaluaties.Find(id);
            db.Evaluaties.Remove(evaluatie);
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
