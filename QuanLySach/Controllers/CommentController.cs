using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySach.Models;
namespace QuanLySach.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        QuanLySachEntity db = new QuanLySachEntity();
        
        public PartialViewResult BinhLuan_Partial(int ms = 0)
        {
            int masach = 0;
            if (Session["MaSach"] != null)
            {
                masach = (int)Session["MaSach"];
            }
            else
            {
                masach = ms;
            }
            List<BinhLuan> lsBinhLuan = db.BinhLuans.OrderByDescending(n => n.ThoiGian).Where(m => m.MaSach == masach).ToList();

            return PartialView(lsBinhLuan);
        }
        [HttpPost]
        public ActionResult BinhLuan(FormCollection f)
        {
            BinhLuan binhluan = new BinhLuan();
            int masach = (int)Session["MaSach"];

            binhluan.NoiDung = f["binhluan"].ToString();
            binhluan.MaSach = masach;
            binhluan.ThoiGian = DateTime.Now;
            if (Session["TaiKhoan"] != null)
            {
                binhluan.TenDangNhap = Session["TaiKhoan"].ToString();
            }
            else
            {
                binhluan.TenDangNhap = "GUEST";
            }
            if (ModelState.IsValid)
            {
                db.BinhLuans.Add(binhluan);
                db.SaveChanges();
            }
            Session.Remove("MaSach");
            return RedirectToAction("NoiDungChiTiet", "Book", new { @masach = masach });
        }
    }
}