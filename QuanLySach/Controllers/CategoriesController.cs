using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySach.Models;
namespace QuanLySach.Controllers
{
    public class CategoriesController : Controller
    {
        //
        // GET: /Categories/
        QuanLySachEntity db = new QuanLySachEntity();

        public PartialViewResult DanhMuc_Partial()
        {
            var dsLoai = db.LoaiSaches.ToList();
            return PartialView(dsLoai);
        }
	}
}