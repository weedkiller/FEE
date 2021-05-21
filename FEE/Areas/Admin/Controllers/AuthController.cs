using FEE.Authorize;
using FEE.Dtos;
using FEE.Enums;
using FEE.Library;
using FEE.Models;
using FEE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FEE.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        private FEEDbContext db = new FEEDbContext();
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            Session.Clear();
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public void setCookie(string username, bool rememberme = false, int role = 0)
        {
            var authTicket = new FormsAuthenticationTicket(
                               1,
                               username,
                               DateTime.Now,
                               DateTime.Now.AddMinutes(120),
                               rememberme,
                               role.ToString()
                               );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                var exist = db.Users.Any(x => x.Username == model.Username);
                            
                if (exist)
                {
                    var user = db.Users.Where(e => e.Username.Equals(model.Username)).First();
                    if (user != null)
                    {
                        if (user.Password == XString.ToMD5(model.Password) && user.Status == (int)UserStatus.Activated)
                        {
                            setCookie(user.Username, model.RememberMe, user.RoleId);
                            var userSession = new UserSession();
                            userSession.Id = user.Id;
                            userSession.Name = user.Name;
                            userSession.RoleId = user.RoleId;
                            userSession.Username = user.Username;
                            userSession.DepartmentId = user.DepartmentId;

                            Session.Add("USER", userSession);
                            Session.Add("PERMISSION", AuthPermission.GetProfileService(user.Id));

                            if (ReturnUrl != null)
                                return Redirect(ReturnUrl);
                            return RedirectToAction("Index", "Home");
                        }
                        ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu!");
                        return View();

                    }
                }

            }
            return View();
        }
    }
}