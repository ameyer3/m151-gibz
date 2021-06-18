using gibz.m151.business;
using gibz.m151.data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // https://www.c-sharpcorner.com/article/simple-login-application-using-Asp-Net-mvc/

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (PersonDb db = new PersonDb())
                {
                    var dbUser = db.User.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (dbUser != null)
                    {
                        HttpContext.Session.SetString("UserID", dbUser.Id.ToString());
                        HttpContext.Session.SetString("UserName", dbUser.UserName.ToString());

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(user);
        }

    }
}
