using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace lab_35_async_await
{
    class Program
    {

        static Stopwatch s = new Stopwatch();
        static List<string> ourAysncList = new List<string>();
        static List<string> ourStringBuilderAysncList = new List<string>();
        static void Main(string[] args)
        {
            // Sync code ... line by line

            // Aysnc code

            /* async void DoThisAsync() {  <= convention s to add "Async as the last word
                var output = await ReadFileAsync("file.txt");
                var output = await GetHttp/JsonDataAsync(Url);
            }
            */

            //1. Create text file 10,000 lines
            //2. Method to read the text file to array
            //3. Call this method from main()
            //4. Time the application start to finish


            //s.Start();
            //if (!File.Exists("data.txt"))
            //{
            //    for(int i = 0; i < 10000; i++)
            //    {
            //        File.AppendAllText("data.txt", $"Adding line no. {i}\n");
            //    }
            //}
            //Console.WriteLine($"Writing took: {s.ElapsedMilliseconds}");

            //s.Restart();
            //string[] array = ReadTextFileToArray();


            //Console.WriteLine($"Program terminated at {s.ElapsedMilliseconds}");
            var ourList = new List<string>();
            
            string path = @"C:\github\2020-06-c-sharp-labs\labs\lab_35_async_await\bin\Debug\netcoreapp3.1\data.txt";
            s.Start();
            if (!File.Exists(path))
            {
              
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        sw.WriteLine("I am a line");
                    }
                }
            }
            Console.WriteLine($"Writing took: {s.ElapsedMilliseconds}");

            s.Restart();
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    ourList.Add(s);
                }
            }

            Console.WriteLine($"Reading took: {s.ElapsedMilliseconds}");


            //Streamreader to read to stringbuilder
            s.Restart();
            var stringBuilder = new StringBuilder();
            using (var reader = new StreamReader("data.txt"))
            {
                while (!reader.EndOfStream)
                {
                    stringBuilder.AppendLine(reader.ReadLine());
                }
            }
            string fileOutput = stringBuilder.ToString();
            Console.WriteLine($"Stringbuilder took: {s.ElapsedMilliseconds}");


            // aysnc read - basic FileReadAsync
            s.Restart();
            ReadTextFileToArrayAsync();
            Console.WriteLine($"Async took {s.ElapsedMilliseconds} with {ourAysncList.Count} records");

            // async read using streamreader
            s.Restart();
            StringBuilderReadToArrayAsync();
            Console.WriteLine($"Streambuilder async took {s.ElapsedMilliseconds} with {ourStringBuilderAysncList.Count} records");

            Thread.Sleep(3000);
            Console.WriteLine($"Async file read has {ourAysncList.Count}");
            Console.WriteLine($"Async streamreader file read has {ourStringBuilderAysncList.Count}");

            s.Restart();
            var arrayOutput = ReturnTextFileToArrayAsync();
            Console.WriteLine($"Async array returned in {s.ElapsedMilliseconds} with {arrayOutput.Result.Length} records");
           
        
        }

       static string[] ReadTextFileToArray()
        {
            return File.ReadAllLines("data.txt");
        }

        static async void ReadTextFileToArrayAsync()
        {
            var array = await File.ReadAllLinesAsync("data.txt");
            ourAysncList = array.ToList();
        }

        static async void StringBuilderReadToArrayAsync()
        {
            using (StreamReader sr = File.OpenText("data.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    ourStringBuilderAysncList.Add(await sr.ReadLineAsync());
                }
            }
        }

        static async Task<string[]> ReturnTextFileToArrayAsync()
        {
            var array = await File.ReadAllLinesAsync("data.txt");
            return array;
        }
    }
}
