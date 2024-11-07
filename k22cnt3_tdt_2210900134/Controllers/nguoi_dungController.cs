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
    public class nguoi_dungController : Controller
    {
        private k22cnt3_tdtEntities db = new k22cnt3_tdtEntities();

        // GET: nguoi_dung
        public ActionResult Index()
        {
            return View(db.nguoi_dung.ToList());
        }

        // GET: nguoi_dung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nguoi_dung nguoi_dung = db.nguoi_dung.Find(id);
            if (nguoi_dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_dung);
        }

        // GET: nguoi_dung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nguoi_dung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_nguoi_dung,ten_dang_nhap,email,mat_khau,so_du")] nguoi_dung nguoi_dung)
        {
            if (ModelState.IsValid)
            {
                db.nguoi_dung.Add(nguoi_dung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoi_dung);
        }

        // GET: nguoi_dung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nguoi_dung nguoi_dung = db.nguoi_dung.Find(id);
            if (nguoi_dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_dung);
        }

        // POST: nguoi_dung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_nguoi_dung,ten_dang_nhap,email,mat_khau,so_du")] nguoi_dung nguoi_dung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoi_dung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoi_dung);
        }

        // GET: nguoi_dung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nguoi_dung nguoi_dung = db.nguoi_dung.Find(id);
            if (nguoi_dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_dung);
        }

        // POST: nguoi_dung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nguoi_dung nguoi_dung = db.nguoi_dung.Find(id);
            db.nguoi_dung.Remove(nguoi_dung);
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
