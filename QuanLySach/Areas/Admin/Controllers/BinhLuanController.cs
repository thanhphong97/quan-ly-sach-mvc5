using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLySach.Models;
using PagedList;
using PagedList.Mvc;
namespace QuanLySach.Areas.Admin.Controllers
{
    public class BinhLuanController : Controller
    {
        private QuanLySachEntity db = new QuanLySachEntity();

        // GET: /Admin/BinhLuan/
        public ActionResult Index(int ? page)
        {
            int pageSize = 10;// số lượng bình luận trên một trang
            int pageNumber = (page ?? 1);
            var binhluans = db.BinhLuans.Include(b => b.Sach).Include(b => b.TaiKhoan);
            return View(binhluans.ToList().OrderByDescending(n => n.ThoiGian).ToPagedList(pageNumber,pageSize));
        }
        
        // GET: /Admin/BinhLuan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhluan = db.BinhLuans.Find(id);
            if (binhluan == null)
            {
                return HttpNotFound();
            }
            return View(binhluan);
        }

        // GET: /Admin/BinhLuan/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach");
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoans, "TenDangNhap", "TenDangNhap");
            return View();
        }

        // POST: /Admin/BinhLuan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TenDangNhap,MaSach,ThoiGian,NoiDung")] BinhLuan binhluan)
        {
            binhluan.ThoiGian = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.BinhLuans.Add(binhluan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", binhluan.MaSach);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoans, "TenDangNhap", "TenDangNhap", binhluan.TenDangNhap);
            return View(binhluan);
        }

        // GET: /Admin/BinhLuan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhluan = db.BinhLuans.Find(id);
            if (binhluan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", binhluan.MaSach);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoans, "TenDangNhap", "TenDangNhap", binhluan.TenDangNhap);
            return View(binhluan);
        }

        // POST: /Admin/BinhLuan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TenDangNhap,MaSach,ThoiGian,NoiDung")] BinhLuan binhluan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binhluan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", binhluan.MaSach);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoans, "TenDangNhap", "TenDangNhap", binhluan.TenDangNhap);
            return View(binhluan);
        }

        // GET: /Admin/BinhLuan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhluan = db.BinhLuans.Find(id);
            if (binhluan == null)
            {
                return HttpNotFound();
            }
            return View(binhluan);
        }

        // POST: /Admin/BinhLuan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BinhLuan binhluan = db.BinhLuans.Find(id);
            db.BinhLuans.Remove(binhluan);
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
