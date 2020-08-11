using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using Entity_Framework_MSDN_Tutorial;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;


namespace CRUDManager
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create("www.atestblog.co.uk");
            //var readReturn = Retrieve();
            foreach (var item in Retrieve())
            {
                Console.WriteLine(item);
            }
        
        }

        public static void Create(string blogUrl)
        {
            using (var db = new BloggingContext()) {
                
                db.Add(new Blog { Url = $"{blogUrl}" });
                db.SaveChanges();
            }

        }

        public static void Update(string blogUrl, string title, string content)
        {
            using(var db = new BloggingContext())
            {
                var blog = db.Blogs.First();
                blog.Url = blogUrl;
                blog.Posts.Add(
                    new Post
                    {
                        Title = title,
                        Content = content
                    });
                db.SaveChanges();
            }
        }
        public static List<Blog> Retrieve()
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }

    }

}
