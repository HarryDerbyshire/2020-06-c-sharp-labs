using System;

namespace lab_15_unit_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

    }

    public class Calc
    {
        public static (int sum, int product) TripleCalc(int a, int b, int c)
        {
            return (a + b + c, a * b * c);
        }
        public static int TripleCalc(int a, int b, int c, out int sum)
        {
            sum = a + b + c;
            return a * b * c;
        }
    }
}
