using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using k22cnt3_tdt_2210900134.Models;

namespace k22cnt3_tdt_2210900134.Controllers
{
    public class the_napController : Controller
    {
        private k22cnt3_tdtEntities db = new k22cnt3_tdtEntities();

        // GET: the_nap
        public ActionResult Index()
        {
            return View(db.the_nap.ToList());
        }

        // GET: the_nap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            the_nap the_nap = db.the_nap.Find(id);
            if (the_nap == null)
            {
                return HttpNotFound();
            }
            return View(the_nap);
        }

        // GET: the_nap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: the_nap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_the,ten_the,gia_tri,so_luong")] the_nap the_nap)
        {
            if (ModelState.IsValid)
            {
                db.the_nap.Add(the_nap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(the_nap);
        }

        // GET: the_nap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            the_nap the_nap = db.the_nap.Find(id);
            if (the_nap == null)
            {
                return HttpNotFound();
            }
            return View(the_nap);
        }

        // POST: the_nap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_the,ten_the,gia_tri,so_luong")] the_nap the_nap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(the_nap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(the_nap);
        }

        // GET: the_nap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            the_nap the_nap = db.the_nap.Find(id);
            if (the_nap == null)
            {
                return HttpNotFound();
            }
            return View(the_nap);
        }

        // POST: the_nap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            the_nap the_nap = db.the_nap.Find(id);
            db.the_nap.Remove(the_nap);
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
