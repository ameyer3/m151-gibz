using gibz.m151.business;
using gibz.m151.data.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

            if (ModelState.IsValid)
            {
                using (PersonDb db = new PersonDb())
                {
                    var hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)).Aggregate(string.Empty, (current, next) => current + next.ToString("X2"));
                 
                    var dbUser = db.User.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(hash)).FirstOrDefault();
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
