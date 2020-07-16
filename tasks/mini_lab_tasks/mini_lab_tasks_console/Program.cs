using System;

namespace mini_lab_tasks_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Tasks.Loop();

        }
    }

    public class Tasks
    {
        public static double RaiseToPower(double x, double y, int p)
        {          
            return Math.Pow((x * y), p);
        }

        public static void Loop()
        {
            string name = "Loopy";
            Console.WriteLine("Please enter a number between 1 and 4");
            var choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                for (int i = 1; i <= 300; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else if (choice == 2)
            {
                for (int i = 1; i <= 300; i++)
                {
                    if (i == 100 || i == 200 || i == 300)
                    {
                        Console.WriteLine($"I'm a loop named {name}");
                    }
                }
            }
            else if (choice == 3)
            {
                for (int i = 1; i <= 300; i++)
                {
                    if (i == 5 || i == 105 || i == 205)
                    {
                        Console.WriteLine($"I'm a loop named {name}");
                    }
                }
            }
            else if (choice == 4)
            {
                for (int i = 50; i >= 0; i--)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice :(");
            }
        }
    }
}
