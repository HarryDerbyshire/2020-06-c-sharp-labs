using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab_40_entity_code_first.Models
{
    class UserDbContext : DbContext
    {
        // map class to table with Dbset
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        // No startup.cs so connect to db here
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlite("DataSource = UserDatabase.db"); //Uses SQLite and creates it within the bin folder in project
            builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=UserDatabase"); //Uses SQL and creates it in your root of your user folders
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User { UserId = 1, Username = "Some User", DateOfBirth = new DateTime(2020, 08, 09), CategoryId = 1 });
            builder.Entity<User>().HasData(new User { UserId = 2, Username = "Another User", DateOfBirth = new DateTime(2020, 10, 10), CategoryId = 2 });
            builder.Entity<User>().HasData(new User { UserId = 3, Username = "Last User", DateOfBirth = new DateTime(2020, 09, 09), CategoryId = 3 });

            builder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Admin" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Database" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Standard" });
           
        }
    }
}
