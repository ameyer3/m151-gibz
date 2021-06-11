using gibz.m151.business;
using gibz.m151.data.Models;
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
            List<Person> persons = Businesslogic.GetAllPersons();
            int amountOfPersons = persons.Count();
            return View(amountOfPersons);
        }
    }
}
