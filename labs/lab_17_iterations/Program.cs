using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;

namespace lab_17_iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loop.ForLoop();
            //Loop.ForEach();
            //Loop.While();
            //Loop.DoWhile();

            #region task 1
            //    int total = 0;

            //    for (int i = 1; i <= 100; i++)
            //    {
            //        total += i;
            //    }
            //    Console.WriteLine(total);
            #endregion
            #region task 2
            //    string sentence = "NISH IS KING";

            //    foreach (char item in sentence)
            //    {
            //        Console.WriteLine(item.ToString().ToLower());
            //    }

            //    for(int i = 0; i <sentence.Length; i++)
            //    {
            //        Console.WriteLine(sentence.ToLower()[i]);
            //    }
            #endregion
            #region showing break
            //for (int i = 0; i < 10; i ++)
            //{
            //    Console.WriteLine(i);

            //    if (i == 5) break;
            //}
            #endregion
            #region showing continue
            //int counter = 0;

            //while (counter < 10)
            //{
            //    counter++;
            //    Console.WriteLine(counter);
            //    if (counter < 4) continue;
            //    Console.WriteLine(counter * 4);
            //}
            #endregion
            #region task 4
            for (int i =1; i <= 20; i++)
            {
                Console.WriteLine(i);
                if (i % 15 == 0) break;
            }
            #endregion
            
        }
    }

    class Loop
    {
        public static void ForLoop()
        {
            for (int i = 100; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
        }

        public static void ForEach()
        {
            int[] myArray = { 10, 20, 30 };
            foreach (int item in myArray)
            {
                Console.WriteLine(item);
            }
        }

        public static void While()
        {
            int counter = 0;

            while (counter < 10)
            {
                Console.WriteLine(counter * 10);
                counter++;
            }
        }

        public static void DoWhile()
        {
            int counter = 0;

            do
            {
                Console.WriteLine(counter);
                counter++;
            }
            while (counter < 10);
        }
    }
}
