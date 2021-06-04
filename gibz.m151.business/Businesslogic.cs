using gibz.m151.data.Models;
using gibz.m151.data.Data;
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
            Person person = dbContext.Person.First(x => x.Id == id);
            //Person person = Data.personList.First(x => x.Id == id);
            return person;
        }

        public static List<Person> GetAllPersons()
        {
            return Data.personList;
        }
    }
}
