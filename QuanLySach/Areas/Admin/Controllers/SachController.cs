﻿using System;
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
using System.IO;
namespace QuanLySach.Areas.Admin.Controllers
{
    public class SachController : Controller
    {
        private QuanLySachEntity db = new QuanLySachEntity();

        // GET: /Admin/Sach/
        
        public ActionResult Index(int? page)
        {
            if (Session["TaiKhoan"] == null)
                return RedirectToAction("Index", "../Home");
            int pageSize = 3;// số lượng sách trên một trang
            int pageNumber = (page ?? 1);
            var saches = db.Saches.Include(s => s.LoaiSach);
            return View(saches.ToList().OrderByDescending(n=>n.NgayPhatHanh).ToPagedList(pageNumber,pageSize));
        }

        // GET: /Admin/Sach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: /Admin/Sach/Create
        public ActionResult Create()
        {
            ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai");
            return View();
        }

        // POST: /Admin/Sach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,GiaTien,GioiThieuChung,TheLoai,AnhBia,NoiDungChiTiet,TacGia,NgayPhatHanh")] Sach sach, HttpPostedFileBase fileUpload)
        {
            if(fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn hình ảnh";
            }
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);//tên của file
                //nối đường dẫn nơi lưu ảnh + tên của file
                var filePath = Path.Combine(Server.MapPath("~/Content/images/DuLieu/Truyen"), fileName);
                //Kiểm tra hình ảnh đã tồn tại hay chưa
                if (System.IO.File.Exists(filePath))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    return View(sach);
                }
                else
                {
                    fileUpload.SaveAs(filePath);
                }
                sach.AnhBia = "DuLieu\\Truyen\\" + fileName;
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai", sach.TheLoai);
            return View(sach);
        }

        // GET: /Admin/Sach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai", sach.TheLoai);
            return View(sach);
        }

        // POST: /Admin/Sach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,GiaTien,GioiThieuChung,TheLoai,AnhBia,NoiDungChiTiet,TacGia,NgayPhatHanh")] Sach sach, HttpPostedFileBase fileUpload)
        {
                if (fileUpload != null)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);//tên của file
                    //nối đường dẫn nơi lưu ảnh + tên của file
                    var filePath = Path.Combine(Server.MapPath("~/Content/images/DuLieu/Truyen"), fileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(filePath);

                    }
                    sach.AnhBia = "DuLieu\\Truyen\\" + fileName;
                }
                if (ModelState.IsValid)
                {
                    db.Entry(sach).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai", sach.TheLoai);
            return View(sach);
        }

        // GET: /Admin/Sach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: /Admin/Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<BinhLuan> lsBinhLuan = db.BinhLuans.Where(x => x.MaSach == id).ToList();
            foreach(BinhLuan bl in lsBinhLuan)
            {
                db.BinhLuans.Remove(bl);
                //db.SaveChanges();
            }
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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
