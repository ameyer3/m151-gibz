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
        public ActionResult GetPersonById(int id)
        {
            Person person = gibz.m151.business.Businesslogic.GetPerson(id);
            return View("Person", person);
        }



        //[HttpDelete]
        //public ActionResult deletePerson(int id)
        //{
        //    PersonList.Remove(PersonList.First(x => x.Id == id));
        //    return View(PersonList);
        //}
    }
}
