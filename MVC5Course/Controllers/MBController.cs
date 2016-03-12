using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
 
        //public ActionResult Index()
        //{
        //    return View();
        //}

         public ActionResult Index(MemberViewModel data)
          {
         
            return Content(data.Name + " " + data.Birthday);
          }


        [HttpPost]
        public ActionResult Index(string Name,DateTime Birthday)
        {
            return Content(Name + "" + Birthday);
        }
        //[HttpPost]
        //public ActionResult Index(FormCollection form) //FormCollection很少用
        //{
        //    return Content(form["Name"] + "" + form["Birthday"]); 
        //}
        //[HttpPost]
        //public ActionResult Index(int a) //Request.Form 不建議 這是早期為了asp
        //{
        //    return Content(Request.Form["Name"] + "" + Request.Form["Birthday"]);
        //}



    }
}