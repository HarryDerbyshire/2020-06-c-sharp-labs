using System;
using System.Collections.Generic;
using System.Text;
using Entity_Framework_MSDN_Tutorial;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace CRUDManager
{
    public class CRUDManager
    {
        public static void Create(string blogUrl)
        {
            using (var db = new BloggingContext())
            {

                db.Add(new Blog { Url = $"{blogUrl}" });
                db.SaveChanges();
            }

        }

        public static void Update(string blogUrl, string title, string content)
        {
            using (var db = new BloggingContext())
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
        public static String PopulateBlogTitle(string blogUrl)
        {
            using (var db = new BloggingContext())
            {
                return (db.Blogs.OrderBy(b => b.BlogId).Where(b => b.Url == blogUrl).First().Posts).ToString();

            }
        }
        public static String PopulatePost(string blogUrl)
        {
            using (var db = new BloggingContext())
            {
                return (db.Blogs.OrderBy(b => b.BlogId).Where(b => b.Url == blogUrl).First().Posts).ToString();
 
            }
        }
    }
}
