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
    public class giao_dichController : Controller
    {
        private k22cnt3_tdtEntities db = new k22cnt3_tdtEntities();

        // GET: giao_dich
        public ActionResult Index()
        {
            var giao_dich = db.giao_dich.Include(g => g.dich_vu).Include(g => g.nguoi_dung).Include(g => g.the_nap);
            return View(giao_dich.ToList());
        }

        // GET: giao_dich/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giao_dich giao_dich = db.giao_dich.Find(id);
            if (giao_dich == null)
            {
                return HttpNotFound();
            }
            return View(giao_dich);
        }

        // GET: giao_dich/Create
        public ActionResult Create()
        {
            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu");
            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap");
            ViewBag.ma_the = new SelectList(db.the_nap, "ma_the", "ten_the");
            return View();
        }

        // POST: giao_dich/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_giao_dich,ma_nguoi_dung,ma_the,ma_dich_vu,so_tien")] giao_dich giao_dich)
        {
            if (ModelState.IsValid)
            {
                db.giao_dich.Add(giao_dich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu", giao_dich.ma_dich_vu);
            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap", giao_dich.ma_nguoi_dung);
            ViewBag.ma_the = new SelectList(db.the_nap, "ma_the", "ten_the", giao_dich.ma_the);
            return View(giao_dich);
        }

        // GET: giao_dich/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giao_dich giao_dich = db.giao_dich.Find(id);
            if (giao_dich == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu", giao_dich.ma_dich_vu);
            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap", giao_dich.ma_nguoi_dung);
            ViewBag.ma_the = new SelectList(db.the_nap, "ma_the", "ten_the", giao_dich.ma_the);
            return View(giao_dich);
        }

        // POST: giao_dich/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_giao_dich,ma_nguoi_dung,ma_the,ma_dich_vu,so_tien")] giao_dich giao_dich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giao_dich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_dich_vu = new SelectList(db.dich_vu, "ma_dich_vu", "ten_dich_vu", giao_dich.ma_dich_vu);
            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap", giao_dich.ma_nguoi_dung);
            ViewBag.ma_the = new SelectList(db.the_nap, "ma_the", "ten_the", giao_dich.ma_the);
            return View(giao_dich);
        }

        // GET: giao_dich/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giao_dich giao_dich = db.giao_dich.Find(id);
            if (giao_dich == null)
            {
                return HttpNotFound();
            }
            return View(giao_dich);
        }

        // POST: giao_dich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            giao_dich giao_dich = db.giao_dich.Find(id);
            db.giao_dich.Remove(giao_dich);
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
