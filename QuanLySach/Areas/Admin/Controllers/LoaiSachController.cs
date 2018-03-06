using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLySach.Models;

namespace QuanLySach.Areas.Admin.Controllers
{
    public class LoaiSachController : Controller
    {
        private QuanLySachEntity db = new QuanLySachEntity();

        // GET: /Admin/LoaiSach/
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] == null)
                return RedirectToAction("Index", "../Home");
            return View(db.LoaiSaches.ToList());
        }

        // GET: /Admin/LoaiSach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaisach = db.LoaiSaches.Find(id);
            if (loaisach == null)
            {
                return HttpNotFound();
            }
            return View(loaisach);
        }

        // GET: /Admin/LoaiSach/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/LoaiSach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaLoai,TenLoai")] LoaiSach loaisach)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSaches.Add(loaisach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaisach);
        }

        // GET: /Admin/LoaiSach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaisach = db.LoaiSaches.Find(id);
            if (loaisach == null)
            {
                return HttpNotFound();
            }
            return View(loaisach);
        }

        // POST: /Admin/LoaiSach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaLoai,TenLoai")] LoaiSach loaisach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaisach);
        }

        // GET: /Admin/LoaiSach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaisach = db.LoaiSaches.Find(id);
            if (loaisach == null)
            {
                return HttpNotFound();
            }
            return View(loaisach);
        }

        // POST: /Admin/LoaiSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiSach loaisach = db.LoaiSaches.Find(id);
            db.LoaiSaches.Remove(loaisach);
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
