using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;

namespace Admin.Controllers
{
    public class AdminController : Controller
    {
        IAdminBLL adminBLL;

        public AdminController(IAdminBLL adminBLL)
        {
            this.adminBLL = adminBLL;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( Model.Admin admin )
        {
            var result = adminBLL.Login(admin);

            if (result != null)
            {
                Session["admin"] = result;
                return RedirectToAction("Index", "Index");
            }

            ViewBag.ErrorMessage = "用户名或密码错误！";
            return View();
        }
    }
}