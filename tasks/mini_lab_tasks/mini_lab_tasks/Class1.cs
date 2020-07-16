using System;

namespace mini_lab_tasks
{
   
    public class Tasks
    {
        public static double RaiseToPower(double x, double y, int p)
        {
            // 2, 3, 3  ==> (2*3)=6 and raise this to power 3 ie 36*6=216
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
            } else if (choice == 2)
            {
                for (int i = 1; i <= 300; i++)
                {
                    if (i == 100 || i == 200 || i == 300)
                    {
                        Console.WriteLine($"I'm a loop named {name}");
                    }
                }
            } else if (choice == 3)
            {
                for (int i = 1; i <= 300; i++)
                {
                    if (i == 5 || i == 105 || i == 205)
                    {
                        Console.WriteLine($"I'm a loop named {name}");
                    }
                }
            } else if (choice == 4)
            {
                for (int i = 50; i >= 0; i--)
                {
                    Console.WriteLine(i);
                }
            } else
            {
                Console.WriteLine("Invalid choice :(");
            }
        }
    }


}


//## Loops
//- Create a loop that outputs the numbers 1 to 300 to the screen.
//- For every 100th number, have the program output your name, a greeting, or anything else you want to the screen.
//- Same as the one above, but for every 5th, 105th, 205th, etc number.
//- Count down from 50 to 0 and output the numbers to the screen.
//- Implement the four labs above in one file, but ask the user which option (1-4) is chosen, and run the appropriate task
