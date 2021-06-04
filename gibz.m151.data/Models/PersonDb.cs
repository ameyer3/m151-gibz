using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace gibz.m151.data.Models
{
    public class PersonDb : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=PersonAdministration;username=root");

        }

    }
}
