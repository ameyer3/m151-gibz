using gibz.m151.data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace gibz.m151.business
{
    public static class Businesslogic
    {
        private static data.Models.PersonDb dbContext = new data.Models.PersonDb();
        
        public static Person GetPerson(int id)
        {
            try
            {
                Person person = dbContext.Person.First(x => x.Id == id);
                return person;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Person> GetAllPersons()
        {
            return dbContext.Person.ToList<Person>();
        }

        public static void DeletePerson(Person person)
        {
            Person onePerson = dbContext.Person.Find(person.Id);
            dbContext.Person.Remove(onePerson);
            dbContext.SaveChanges();
        }
        public static Person ShowPersonToEdit(int id)
        {
            Person person = dbContext.Person.Find(id);
            return person;
        }

        public static void EditPerson(Person person)
        {
            Person personFromdbContext = dbContext.Person.Find(person.Id);
            if (personFromdbContext != null)
            {
                //Das Person Objekt wird manuell neu zogeordnet damit es modifiziert gespeichert werden kann
               
                personFromdbContext.Name = person.Name;
                personFromdbContext.Age = person.Age;
                personFromdbContext.Married = person.Married;
            }
            else
            {
                dbContext.Person.Add(person);
            }
            dbContext.SaveChanges();

        }
    }
}
