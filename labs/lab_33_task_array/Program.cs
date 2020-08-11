using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace lab_33_task_array
{
    class Program
    {

        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            // Single tasks - not much benefit to them
            // Array of tasks - each one can complete at its own leisure

            var taskArray = new Task[5];
            s.Start();
            taskArray[0] = Task.Run(
                () => { Console.WriteLine($"Task 0 completed"); }    
            );

            taskArray[1] = Task.Run(
               () => { Console.WriteLine($"Task 1 completed"); }
           );

            taskArray[2] = Task.Run(
               () => { Console.WriteLine($"Task 2 completed"); }
           );

            taskArray[3] = Task.Run(
               () => {
                   //Thread.Sleep(500);
                   Console.WriteLine($"Task 3 completed"); }
           );

            taskArray[4] = Task.Run(
               () => {
                   //Thread.Sleep(300);
                   Console.WriteLine($"Task 4 completed"); }
           );

            //Wait for an individual task
            var oneTask = Task.Run(
                () =>
                {
                    //Thread.Sleep(800);
                    Console.WriteLine("Individual task completed");
                }    
            );

            //Get data back with Task.Result
            var getDataBack = Task<string>.Run(
                () =>
                {
                    return "Here is some data returned from task";
                }    
            );


            //Wait for any task to complete
            Task.WaitAny(taskArray);
            Task.WaitAll(taskArray);
            oneTask.Wait();
            Console.WriteLine($"Background data returns at {s.ElapsedMilliseconds} - data is: {getDataBack.Result}");
            Console.WriteLine($"Program terminates at {s.ElapsedMilliseconds}");
            Console.ReadLine();
        }
    }
}
