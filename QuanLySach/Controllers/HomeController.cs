using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySach.Models;
using PagedList;
using PagedList.Mvc;
namespace QuanLySach.Controllers
{
    public class HomeController : Controller
    {
        private QuanLySachEntity db = new QuanLySachEntity();
        //public ActionResult Index(int? page)
        //{
        //    int SLSanPham = 2;//số sản phẩm trên 1 trang
        //    int SoTrang = (page ?? 1);// biển số trên trang

        //    List<Sach> lsSach = db.Saches.OrderBy(n => n.NgayPhatHanh).Take(5).ToList();
        //    return View(lsSach);
        //}
        public ActionResult Index()
        {
            //List<Sach> lsSach = db.Saches.OrderByDescending(n => n.NgayPhatHanh).Take(5).ToList();
            List<Sach> lsSachs = db.Saches.OrderByDescending(n => n.NgayPhatHanh).Take(5).ToList();
            return View(lsSachs);
        }
    }
}