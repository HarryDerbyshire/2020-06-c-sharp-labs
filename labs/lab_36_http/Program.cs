using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab_36_http
{
    class Program
    {
        static Uri url = new Uri("https://jsonplaceholder.typicode.com/todos/1");
        static Uri url2 = new Uri("https://www.bbc.co.uk");
        static void Main(string[] args)
        {
            //GetDataUsingWebClient();
            //GetPageUsingWebClient();
            //GetPageUsingWebRequest();
            //GetDataUsingHttpClient();
            //JsonObjectCreation(GetDataUsingHttpClient());
            

        }

        static void GetDataUsingWebClient()
        {
            var webClient = new WebClient { Proxy = null };
            var data = webClient.DownloadString(url);
            Console.WriteLine(data);
        }

        static void GetPageUsingWebClient()
        {
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(url2, "bbcWebPage.html");
            Process.Start("explorer", "https://www.bbc.co.uk");
            //Process.Start("cmd", $"/C start {url2}"); 
        }

        static void GetPageUsingWebRequest()
        {
            var bbcPageRequest = WebRequest.Create(url2.ToString());
            var bbcPageResponse = bbcPageRequest.GetResponse();

            // Interrogate response
            Console.WriteLine("BBC Page has arrived");
            Console.WriteLine(bbcPageResponse.ContentType);
            Console.WriteLine(bbcPageResponse.ContentLength);

            // Interrogate request - page headers
            Console.WriteLine("Getting Page Header Information");
            var pageResponseHeaders = bbcPageResponse.Headers.AllKeys;
            // Values
            foreach (var key in pageResponseHeaders)
            {
                
                Console.Write($"KEY -- {key} -- ");
                foreach(var value in bbcPageResponse.Headers.GetValues(key))
                {
                    Console.Write($"VALUE -- {value}\n\n");
                }
            }

            
        }
        static User GetDataUsingHttpClient()
        {
            var httpClient = new HttpClient();
            var httpResponse = httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<User>(httpResponse.Result);

            //var json = JObject.Parse(data);
            //Console.WriteLine(json["userId"]);
        }

        static void JsonObjectCreation(string jsonString)
        {
            User user = new User();

            user = JsonConvert.DeserializeObject<User>(jsonString);

            Console.WriteLine($"UserID: {user.userId}\nID: {user.id}\nTitle: {user.title}\nCompleted: {user.completed}");
        }

       
    }

    public class User
    {
        public int userId { get; set; }
        public int id { get; set; }

        public string title { get; set; }

        public bool completed { get; set; }
        
        
    }

    
}
