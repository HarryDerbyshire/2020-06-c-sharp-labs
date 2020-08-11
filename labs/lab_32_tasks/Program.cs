using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace lab_32_tasks
{
    class Program
    {

        static Stopwatch s = new Stopwatch();
        delegate void myDelegate();

        static void Main(string[] args)
        {
            // Tasks
            // Async - Main() thread
            // Sync - sequence in order
            // Process - .exe running application which is able to send commands to CPU for processing
            // Thread - set of instructions bundled up and sent to CPU for processing
            // Main(){
            // Sub() - execute as different process on computer
            // }

            // C#
            // Threading - manually created thread
            // Tasks - hard work removed - easy for programmer to work with sub-threads/sub-tasks

            // Key words:
            // Process: Running exe
            // Application: Run by user and runs in foreground
            // Service: Run by computer at startup and runs in background (DNS, DHCP
            // Thread: Set of instructions sent to CPU for processing
            // Single-Threaded: Runs on main thread
            // Multi-Threaded: Take advantage of multi-core CPUs which can run mulitple threads simultaneously

            // When are tasks/threads useful?
                // Multitask processing such as background processing of graphics
                // Background processing jobs e.g. overnight tasks for credit card financial reporting (doing mulitple things together)
                // Website - click - data can take 5 seconds or so but rather than freeze the screen, can still work

            // Just be aware with threads and tasks we have no control over when the operating system will run a particular task

            var thread = new Thread(

              () => {
                  Thread.Sleep(3000); Console.WriteLine($"New thread at {s.ElapsedMilliseconds}");
              }

            );

            var task01 = new Task(

              () => {
                  Thread.Sleep(2000);
                  Console.WriteLine($"This is a task at {s.ElapsedMilliseconds}");
              }

          );

            var task03 = new Task(
                () => { 
                    Console.WriteLine("Another Task"); 
                }
            );

            

            var instance = new myDelegate(DoThis);

            var task04 = new Task(
                new Action(DoThis)
            );

            // Task factory
            var task05 = Task.Factory.StartNew(
                () => {
                    Console.WriteLine("Hey I am runnning a factory task");
                }
            );

            s.Start();
          

            thread.Start();

          

            task01.Start();

            var task02 = Task.Run(

                () => { Thread.Sleep(1000); Console.WriteLine($"Creating and running a task at the same time at {s.ElapsedMilliseconds}"); }
                
            );

            task04.Start();
            Console.WriteLine($"Program ended at {s.ElapsedMilliseconds}");
            Console.ReadLine();
            

        }

        static void DoThis()
        {
            Console.WriteLine($"I am doing this at {s.ElapsedMilliseconds}");
        }

       
    }
}
