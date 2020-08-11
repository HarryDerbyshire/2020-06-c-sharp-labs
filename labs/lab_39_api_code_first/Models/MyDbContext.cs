using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace lab_39_api_code_first.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) { }

        //Create table from MyClass
        public DbSet<MyClass> MyClasses { get; set; }

        public MyDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyClass>(item =>
            {
                item.Property(myclass => myclass.MyClassId).IsRequired();

            });
            builder.Entity<MyClass>().HasData(new MyClass { MyClassId = 1, MyFieldName1 = "First row of data" });
            builder.Entity<MyClass>().HasData(new MyClass { MyClassId = 2, MyFieldName1 = "Second row of data" });
            builder.Entity<MyClass>().HasData(new MyClass { MyClassId = 3, MyFieldName1 = "Third row of data" });
        }
    }
}
