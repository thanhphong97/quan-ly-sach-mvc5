using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySach.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/
        public ActionResult Index()
        {
            return RedirectToAction("Index","Sach");
        }
        public ActionResult Logout()
        {
            Session.Remove("TaiKhoan");
            if(Session["TaiKhoan"] != null)
                return RedirectToAction("Index", "AdminHome");
            return RedirectToAction("Index","../Home");
        }
	}
}