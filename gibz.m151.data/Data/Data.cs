using gibz.m151.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gibz.m151.data.Data
{
    public class Data
    {
        public static List<Person> personList = new List<Person>() {
        new Person { Id = 1, Name = "Person1", Age=1, Married=true },
        new Person { Id = 2, Name = "Person2", Age=2, Married=true },
        new Person { Id = 3, Name = "Person3", Age=3, Married=true },
        new Person { Id = 4, Name = "Person4", Age=4, Married=false },
        new Person { Id = 5, Name = "Person5", Age=5, Married=false },
        new Person { Id = 6, Name = "Person6", Age=6, Married=true }};
    }
}
