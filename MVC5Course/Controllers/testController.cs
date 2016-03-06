using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult MemberProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberProfile(MemberViewModel data)
        {
            return View();
        }
    }
}