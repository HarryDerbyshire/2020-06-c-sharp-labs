using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace IterationLib
{

    public class Program
    {
       
        public static void Main(string[] args)
        {
            //int[] arr = { 2, -5, 10, 1, 43 } ;
            //Console.WriteLine(Exercises.Lowest(arr));
            //ignore
            Console.WriteLine(Exercises.SumEvenFive(22));
        }
    }
    public class Exercises
    {
        // returns the lowest number in the array nums
        public static int Lowest(int[] nums)
        {
            if (nums.Length == 0) return int.MaxValue;
            return nums.Min();
        }

        // returns the sum of all numbers between 1 and n inclusive that are divisible by either 2 or 5
        public static int SumEvenFive(int max)
        {
            int total = 0;
            for (int i = 1; i <= max; i++)
            {
                if (i % 2 == 0 || i % 5 == 0)
                {
                    total += i;
                  
                }
            }
            return total;
        }

        // Returns the a string containing the count of As, Bs, Cs and Ds in the parameter string
        // all other letters are ignored
        public static string CountLetters(string input)
        {
            return String.Empty;
        }
    }
}