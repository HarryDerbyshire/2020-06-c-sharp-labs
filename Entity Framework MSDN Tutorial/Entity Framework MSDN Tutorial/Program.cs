using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace Entity_Framework_MSDN_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                db.Add(new Blog { Url = "http://whatisdifferent" });
                db.SaveChanges();

                //Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                Console.WriteLine(blog.ToString().ToList());

                var blog2 = db.Blogs
                   .OrderBy(b => b.BlogId)
                   .First();

                //Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });

                blog2.Url = "http://blogs2.msdn.com/adonet";
                blog2.Posts.Add(
                    new Post
                    {
                        Title = "Testing adding another post",
                        Content = "new post content"
                    });
                db.SaveChanges();

                //Delete
                //Console.WriteLine("Delete the blog");
                //db.Remove(blog);
                //db.SaveChanges();

                var blogQuery = db.Blogs.Include(o => o.Posts);

                foreach(var item in blogQuery)
                {
                    Console.WriteLine($"{item.BlogId}  {item.Posts}  {item.Url}");
                }






         }
        }
    }
}
