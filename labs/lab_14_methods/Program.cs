using System;

namespace lab_14_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            // var output = DoThis();
            //SquareNumber(x: 2, y: "Hello");
            //var results = DoThisPartTwo(10, "Harry", out bool isLarge);
            //Console.WriteLine(isLarge); //true
            //Console.WriteLine(results); // 100
            //var myTuple = (fName: "Harry", lName: "Derbyshire", Age: 19);
            //Console.WriteLine(myTuple.lName);
            //var result = DoThat(10, "I'm a string"); //I'm a string
            //Console.WriteLine(result); //(100, true)
            //Console.WriteLine(result.xSquared); //100

            //var (square, greaterThan10) = DoThat(5, "Hello"); //Hello
            //Console.WriteLine(greaterThan10); //25
            Console.WriteLine(TripleCalc(1, 8, 3));
            Console.WriteLine(TripleCalc(1, 43, 3, out int sum));

        }

        public static string DoThis()
        {
            return "I hath returned";
        }

        public static int SquareNumber(int x, string y)
        {
            Console.WriteLine(y);
            return x * x;
        }

        public static int DoThisPartTwo(int x, string y, out bool z)
        {
            Console.WriteLine(y);
            z = (x > 9);
            return x * x;
        }
        public static (int xSquared, bool yGreater10) DoThat(int x, string y)
        {
            Console.WriteLine(y);
            var z = (x > 10);
            return (x * x, z);
        }

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
