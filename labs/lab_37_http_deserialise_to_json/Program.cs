using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab_37_http_deserialise_to_json
{
    class Program
    {
        static List<ToDo> todos = new List<ToDo>();
        static List<ToDo> todosAsync = new List<ToDo>();
        static Uri url = new Uri("https://jsonplaceholder.typicode.com/todos");
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            
            s.Start();
            //GetTodos();
            GetTodosAsync();
            Console.WriteLine($"Program terminates at {s.ElapsedMilliseconds}    {todosAsync.Count}");
            Thread.Sleep(500);
            todosAsync.ForEach(item => Console.WriteLine($"ID: {item.id}\nUserID: {item.userId}\nTitle: {item.title}\nCompleted: {item.completed}\n"));
        }

        static void GetTodos()
        {
            using (var httpClient = new HttpClient())
            {
                //String with 200 items within it
                var data = httpClient.GetStringAsync(url);
                todos = (JsonConvert.DeserializeObject<List<ToDo>>(data.Result));
            }
        }

        static async void GetTodosAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync(url);
                todosAsync = (JsonConvert.DeserializeObject<List<ToDo>>(data));
                Console.WriteLine($"Todos aysnc data has arrived at {s.ElapsedMilliseconds}");
            }
        }
    }

    class ToDo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
