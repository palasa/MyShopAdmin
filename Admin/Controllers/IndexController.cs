using BLL;
using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace Admin.Controllers
{
    [Admin.Filters.LoginFilter]
    public class IndexController : Controller
    {
        public IMenuBLL menuBLL { get; set; }

        // GET: Index
        public ActionResult Index()
        {
            IQueryable<MenuViewModel> menus = menuBLL.GetByCondition( m=>m.ParentId == null ).Select( m=> new MenuViewModel {
                Id = m.Id ,
                ParentId = m.ParentId ,
                Name = m.Name ,
                Controller = m.Controller ,
                Action = m.Action ,
                ChildMenus = m.ChildMenus
            });
            return View(menus);
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}