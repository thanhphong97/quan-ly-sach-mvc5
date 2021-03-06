﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySach.Models;
namespace QuanLySach.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        QuanLySachEntity db = new QuanLySachEntity();
       
        public ViewResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string TaiKhoan = f["txtTaiKhoan"].ToString();
            string MatKhau = f["txtMatKhau"].ToString();
            TaiKhoan taikhoan = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == TaiKhoan && tk.MatKhau == MatKhau);
            if (taikhoan != null && taikhoan.TrangThai == 2)
            {
                Session["TaiKhoan"] = taikhoan.TenDangNhap;
                return RedirectToAction("AdminHome","Admin");
            }
            return RedirectToAction("Index", "Home");
        }
	}
}