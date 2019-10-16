using SF.Service;
using SF.Web.Authorization;
using SF.Web.BaseApplication;
using SF.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SF.Web.Controllers
{
    public class AplicationController : ServiceController<SystemService>
    {
        // GET: Aplication
        public ActionResult Index()
        {
            var user = ServiceHelper.GetCurrentUser();
            ViewBag.User = user.LoginName;
            int userId = user.UserID;
            bool isAdmin = user.IsAdmin;
            ViewBag.MenuList = Service.GetMenuByUserId(userId, isAdmin);
            return View();
        }
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.errorMsg = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            string errorMsg = "";
            if (ModelState.IsValid)
            {
                bool isLoginSc = AuthenticationModule.AuthenticateUser(model.LoginName, model.Password, ref errorMsg);
                if (isLoginSc)
                {
                    return RedirectToAction("Index", "Aplication");
                }
                ViewBag.errorMsg = errorMsg;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Aplication");
        }
    }
}