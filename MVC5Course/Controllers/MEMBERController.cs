using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize] //加入後一定要登入驗證
    public class MEMBERController : Controller
    {
        // GET: MEMBER
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login)
        {
            //註web.config 裡的
             //<!--<remove name="FormsAuthentication" />-->要註解
             // <authentication mode="Forms">
             // <forms loginUrl="/MEMBER/Login"></forms>
            //</authentication>
            if (CheckLogin(login.Email,login.Password))
            {
                //表單驗證
                FormsAuthentication.RedirectFromLoginPage(login.Email, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤"); //自訂驗證錯誤
            return View();
        }

        private bool CheckLogin(string username, string password)
        {
            return (
                   username == "kio@gmail.com" &&
                   password == "123"
                   );
        
        }
        public ActionResult Logout()
        {
          //表單驗證
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}