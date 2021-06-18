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
    public class PersonController : Controller
    { 
       
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                List<Person> persons = Businesslogic.GetAllPersons();
                return View(persons);
            }
            {
                return RedirectToAction("Login", "Login");
            }
        }
        //[HttpGet]
        //public ActionResult GetPersons()
        //{

        //    return View(PersonList);
        //}
        //[HttpPost]
        //public ActionResult PostPerson(int id, string name, string description, bool isHighlighted)
        //{
        //    Person Person = new Person() { Id = id, Name = name, Description = description, IsHighlighted = isHighlighted };
        //    PersonList.Add(Person);
        //    return View(PersonList);
        //}
        [HttpGet]
        public ActionResult GetPersonById()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetPersonById(int id)
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                Person person = gibz.m151.business.Businesslogic.GetPerson(id);
                return View("Person", person);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Person person)
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                Businesslogic.DeletePerson(person);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        //shows the site with the values, if existing
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                Person person = Businesslogic.ShowPersonToEdit(id);
            return View(person);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        //wenn Save wurde geklickt und ein Person erstellt oder überschrieben wird
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                Businesslogic.EditPerson(person);
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }


    }
}
