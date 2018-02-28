using System;
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
        //public ActionResult DangNhap_Partial(TaiKhoan tk)
        //{
        //    return PartialView();
        //}
        public ViewResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string TaiKhoan = f["txtTaiKhoan"].ToString();
            string MatKhau = f.Get("txtMatKhau").ToString();
            TaiKhoan taikhoan = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == TaiKhoan && tk.MatKhau == MatKhau);
            if (taikhoan != null)
            {
                //Session["TaiKhoan"] = taikhoan;
                return RedirectToAction("AdminHome","Admin");
            }
            //ViewBag.ThongBaoDangNhap = "Đăng nhập thất bại";
            return RedirectToAction("Index", "Home");
        }
	}
}