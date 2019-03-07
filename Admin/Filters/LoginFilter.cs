using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Filters
{
    /// <summary>
    /// 登录的过滤器
    /// </summary>
    public class LoginFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 重写 请求到达 Action 之前的 方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ( filterContext.HttpContext.Session["admin"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Admin/Login?ErrorMessage=您尚未登录");
            }

        }
    }
}