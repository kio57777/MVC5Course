using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [紀錄Action的執行時間]
    public class HomeController : BaseController
    //public class HomeController : Controller
    {
        [共同的viewbag資料共享於部份HomeController動作方法attribute]
        public ActionResult Index()
        {
            return View();
        }
         
        [共同的viewbag資料共享於部份HomeController動作方法attribute]
        public ActionResult About()
        {
          //  ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        [HandleError(ExceptionType = typeof(ArgumentException), View = "ErrorArgument")]
        //[HandleError(ExceptionType = typeof(SqlException), View = "ErrorSql")]
        public ActionResult ErrorTest(string errorType)
        {
            //HandleError 錯誤處理
            if (errorType =="1")
            {
                throw new Exception("Error 1"); //導入Shared/Error.cshtml 內建的errorＤ

            }
            if (errorType == "2")
            {
                throw new ArgumentException("Error 2");//導入Shared/ErrorArgument.cshtml
            }
            return Content("No Error");
        }

        public ActionResult RazorTest()
        {
          int[] data = new int[] { 1, 2, 3, 4, 5 };
 
             return PartialView(data);
        }


    }
}