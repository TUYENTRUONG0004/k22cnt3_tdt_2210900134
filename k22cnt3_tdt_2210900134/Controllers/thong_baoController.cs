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
    public class thong_baoController : Controller
    {
        private k22cnt3_tdtEntities db = new k22cnt3_tdtEntities();

        // GET: thong_bao
        public ActionResult Index()
        {
            var thong_bao = db.thong_bao.Include(t => t.nguoi_dung);
            return View(thong_bao.ToList());
        }

        // GET: thong_bao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thong_bao thong_bao = db.thong_bao.Find(id);
            if (thong_bao == null)
            {
                return HttpNotFound();
            }
            return View(thong_bao);
        }

        // GET: thong_bao/Create
        public ActionResult Create()
        {
            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap");
            return View();
        }

        // POST: thong_bao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_thong_bao,ma_nguoi_dung,noi_dung")] thong_bao thong_bao)
        {
            if (ModelState.IsValid)
            {
                db.thong_bao.Add(thong_bao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap", thong_bao.ma_nguoi_dung);
            return View(thong_bao);
        }

        // GET: thong_bao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thong_bao thong_bao = db.thong_bao.Find(id);
            if (thong_bao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap", thong_bao.ma_nguoi_dung);
            return View(thong_bao);
        }

        // POST: thong_bao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_thong_bao,ma_nguoi_dung,noi_dung")] thong_bao thong_bao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thong_bao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.nguoi_dung, "ma_nguoi_dung", "ten_dang_nhap", thong_bao.ma_nguoi_dung);
            return View(thong_bao);
        }

        // GET: thong_bao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thong_bao thong_bao = db.thong_bao.Find(id);
            if (thong_bao == null)
            {
                return HttpNotFound();
            }
            return View(thong_bao);
        }

        // POST: thong_bao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thong_bao thong_bao = db.thong_bao.Find(id);
            db.thong_bao.Remove(thong_bao);
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
