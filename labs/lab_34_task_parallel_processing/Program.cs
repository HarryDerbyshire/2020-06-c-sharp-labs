using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace lab_34_task_parallell_processing
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# has a library to help with task 'parallel' processing
            // Firtly - running methods in paraleel



            //Parallel.Invoke(
            //    () => { Console.WriteLine("Task 01"); },
            //    () => { Console.WriteLine("Task 02"); },
            //    () => { Console.WriteLine("Task 03"); },
            //    () => { Console.WriteLine("Task 04"); },
            //    () => { Console.WriteLine("Task 05"); }
            //);

            ////OR declare methods then run them

            //Parallel.Invoke(
            //    () => { OvernightTask01(); },            
            //    () => { OvernightTask02(); },            
            //    () => { OvernightTask03(); }          
            //);

            ////OR declare the methods as Actions
            //Action instance01 = OvernightTask04;
            //Action instance02 = OvernightTask05;

            //Parallel.Invoke(
            //    () => { instance01(); },    
            //    () => { instance02(); }
            //);

            var s = new Stopwatch();
            s.Start();

            // Parallel for
            var taskArray = new Task[10];
            for(int i = 0; i < taskArray.Length; i++)
            {
                var j = i;
                taskArray[i] = Task.Run(
                    () => { Console.WriteLine($"Task {j} has completed at {s.ElapsedMilliseconds}"); }    
                );
            }

            // Parallel for
            Parallel.For(0, 10,
                (i) =>
                {
                    Thread.Sleep(7);
                    Console.WriteLine($"Parallel For job {i} - running background processing");
                }
                    
            );

            // Parallel foreach
            var stringArray = new string[] { "hey", "there", "I", "am", "string", "array" };
            Parallel.ForEach(stringArray,
                (item) => { Console.WriteLine($"Processing string array item {item} with length {item.Length}"); }    
            );


            //Parallel LINQ from database
            var customers = new List<string>(); //Imagine as list from Northwind (not importing for one example)
            var processingOutput = customers.AsParallel();

            Console.WriteLine($"All completed at {s.ElapsedTicks}");
            Console.ReadLine();

        }

        static void OvernightTask01() { Console.WriteLine("Task 01 from method"); }
        static void OvernightTask02() { Console.WriteLine("Task 02 from method"); }
        static void OvernightTask03() { Console.WriteLine("Task 03 from method"); }
        static void OvernightTask04() { Console.WriteLine("Task 03 from action"); }
        static void OvernightTask05() { Console.WriteLine("Task 03 from action"); }
    }
}
