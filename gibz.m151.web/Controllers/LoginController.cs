using gibz.m151.business;
using gibz.m151.data.Models;
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
                    var obj = db.User.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Current.Session["UserID"] = obj.Id.ToString();
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");


                        //read from session
                        //string value = (string)HttpContext.Current.Session["key"];

                        //write to session
                        //HttpContext.Current.Session["key"] = "value";
                    }
                }
            }
            return View(user);
        }

        public ActionResult UserDashboard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
