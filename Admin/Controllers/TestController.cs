using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult DeleteFile()
        {
            string path = Server.MapPath("~/Images/Product/论坛项目.txt");

            try
            {
                System.IO.File.Delete(path);
            }
            catch
            {
                return Content("删除失败");
            }

            return Content("删除成功");
        }
    }
}