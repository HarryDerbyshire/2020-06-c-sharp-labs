using lab_40_entity_code_first.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_40_entity_code_first
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Category> categories = new List<Category>();

            using (var db = new UserDbContext())
            {

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();



                //var user = new User()
                //{

                //    Username = "Some User"
                //};
                //db.Users.Add(user);
                //db.SaveChanges();

                users = db.Users.Include("Category").ToList();
                users.ForEach(user => Console.WriteLine($"{user.UserId}: {user.Username} was born on {user.DateOfBirth} with category {user.Category.CategoryName}"));
                Console.WriteLine("\n");
                categories = db.Categories.ToList();
                categories.ForEach(category => Console.WriteLine($"{category.CategoryId}: {category.CategoryName}"));
            }
        }
    }
}
