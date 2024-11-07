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
    public class dich_vuController : Controller
    {
        private k22cnt3_tdtEntities db = new k22cnt3_tdtEntities();

        // GET: dich_vu
        public ActionResult Index()
        {
            return View(db.dich_vu.ToList());
        }

        // GET: dich_vu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu dich_vu = db.dich_vu.Find(id);
            if (dich_vu == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu);
        }

        // GET: dich_vu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dich_vu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_dich_vu,ten_dich_vu,mo_ta")] dich_vu dich_vu)
        {
            if (ModelState.IsValid)
            {
                db.dich_vu.Add(dich_vu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dich_vu);
        }

        // GET: dich_vu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu dich_vu = db.dich_vu.Find(id);
            if (dich_vu == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu);
        }

        // POST: dich_vu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_dich_vu,ten_dich_vu,mo_ta")] dich_vu dich_vu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dich_vu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dich_vu);
        }

        // GET: dich_vu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dich_vu dich_vu = db.dich_vu.Find(id);
            if (dich_vu == null)
            {
                return HttpNotFound();
            }
            return View(dich_vu);
        }

        // POST: dich_vu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dich_vu dich_vu = db.dich_vu.Find(id);
            db.dich_vu.Remove(dich_vu);
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
