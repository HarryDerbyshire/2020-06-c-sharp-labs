using System;

namespace lab_13_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 5;
            var b = 3;
            var c = 4;
            c += +a++ + ++b;
            Console.WriteLine(c);
        }
    }
}
