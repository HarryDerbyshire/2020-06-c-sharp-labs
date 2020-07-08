using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace lab_09_logging
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("Output.log", $"Printing i: \n\n");

            #region loop with stopwatch

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //TODO: Test again
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                File.AppendAllText("Output.log",$"The value of i is {i} at {DateTime.Now} \n");
                Thread.Sleep(500);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed); // seconds
            Console.WriteLine(stopwatch.ElapsedMilliseconds); //ms
            Console.WriteLine(stopwatch.ElapsedTicks); // 10 to pwoer -7 seconds

            #endregion
            //reading the log file`
            //1. Simple way - all as one string
            string outputAsString = File.ReadAllText("Output.log");
            string outputAsString2 = File.ReadAllText("../../../Output2.log");
            Console.WriteLine(outputAsString);
            Console.WriteLine(outputAsString2);

            //2. Each line pushed to an array
            Console.WriteLine($"\n\nOutput As Array\n\n");
            string[] outputAsArray = File.ReadAllLines("Output.log");
            foreach(string line in outputAsArray) {
                Console.WriteLine(line);
            }
            //TODO: Test
        }
    }
}
