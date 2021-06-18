using gibz.m151.business;
using gibz.m151.data.Models;
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
            List<Person> persons = Businesslogic.GetAllPersons();
            return View(persons);
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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetPersonById(int id)
        {
            Person person = gibz.m151.business.Businesslogic.GetPerson(id);
            return View("Person", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Person person)
        {
            Businesslogic.DeletePerson(person);
            return RedirectToAction("Index");
        }

        //shows the site with the values, if existing
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Person person = Businesslogic.ShowPersonToEdit(id);
            return View(person);
        }


        //wenn Save wurde geklickt und ein Person erstellt oder überschrieben wird
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            Businesslogic.EditPerson(person);
            return RedirectToAction("Index");

        }


    }
}
