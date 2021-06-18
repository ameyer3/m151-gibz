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
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                List<Person> persons = Businesslogic.GetAllPersons();
                int amountOfPersons = persons.Count();
                return View(amountOfPersons);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
