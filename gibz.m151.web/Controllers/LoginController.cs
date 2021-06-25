using gibz.m151.business;
using gibz.m151.data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    { 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            // https://github.com/viniciuschiele/Scrypt
            ScryptEncoder encoder = new ScryptEncoder();

            if (ModelState.IsValid)
            {
                using (PersonDb db = new PersonDb())
                {
                    var userPw = encoder.Encode(user.Password);
                    bool same = encoder.Compare("123456", userPw);


                    var dbUser = db.User.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(userPw)).FirstOrDefault();
                    //var dbUser = db.User.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (dbUser != null)
                    {
                        HttpContext.Session.SetString("UserID", dbUser.Id.ToString());

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                HttpContext.Session.Remove("UserID");

                // destroy session
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
