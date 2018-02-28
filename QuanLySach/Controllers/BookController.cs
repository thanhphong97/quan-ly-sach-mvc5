using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySach.Models;
namespace QuanLySach.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        QuanLySachEntity db = new QuanLySachEntity();
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult NoiDungChiTiet(int masach = 0)
        {
            var sach = db.Saches.SingleOrDefault(n => n.MaSach == masach);
            return View(sach);
        }
        public ViewResult ChiTietTheLoai(int maloai = 0, string tenloai = null)
        {
            List<Sach> lsSach = new List<Sach>();
            if (maloai == 0)
            {
                lsSach = db.Saches.ToList();
            }
            else
            {
                LoaiSach loaisach = db.LoaiSaches.SingleOrDefault(n => n.MaLoai == maloai);
                lsSach = db.Saches.Where(n => n.MaLoai == maloai).ToList();
            }
            if (lsSach.Count == 0)
            {
                ViewBag.ThongBao = "Không có sách nào thuộc chủ đề";
            }
            ViewBag.TenLoai = tenloai;
            return View(lsSach);
        }
	}
}