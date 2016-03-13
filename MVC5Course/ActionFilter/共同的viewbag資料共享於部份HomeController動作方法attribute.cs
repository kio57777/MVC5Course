using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
   public class 共同的viewbag資料共享於部份HomeController動作方法attribute : ActionFilterAttribute

    {


       public override void OnActionExecuting(ActionExecutingContext filterContext)
       {
           filterContext.Controller.ViewBag.Message = "Your application description page.";

           //if (!filterContext.HttpContext.Request.IsLocal)
           //{
           //    filterContext.Result = new RedirectResult("/");
           //}

           base.OnActionExecuting(filterContext);
       }
      
    }
}
