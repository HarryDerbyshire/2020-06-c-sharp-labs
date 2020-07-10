using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace lab_16_selection
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 5;
            //int y = 10;

            //Console.WriteLine(x > y ? "x is greater than y" : "x is less than y");

            //Console.WriteLine(Switch.AlertLevel(3));

            //int[] newArray = { 2, 3, 4, 5, 6 };
            //Console.WriteLine(Array.ArraySum(newArray));
            //Array.MultiDimensionalArray();
            //Array.JaggedArray();
            //String.CharArray();
            //String.Casting();
            Console.WriteLine(String.StringBuilder());
            
            
        }
    }

    public class Selection
    {
        public static string PassFail(int mark)
        {

            if (mark >= 75 && mark <= 100) return "Pass with Distinction";
            else if (mark >= 60 && mark < 75) return "Pass with Merit";
            else if (mark >= 40 && mark < 60) return "Pass";
            else if (mark >= 0 && mark < 40) return "Fail";
            else return "Input was invalid";

        }
    }

    public class Switch
    {
        public static string AlertLevel(int level)
        {
            string priority = "Code ";

            switch (level)
            {
                case 3:
                    priority += "Red";
                    break;
                case 2:
                case 1:
                    priority += "Amber";
                    break;
                case 0:
                    priority += "Green";
                    break;
                default:
                    priority = "Error";
                    break;
            }

            return priority;
        }
    }

    public class Array
    {
        public static void ArrayCreation()
        {
            char[] harry = new char[5];

            harry[0] = 'H';
            harry[1] = 'a';
            harry[2] = 'r';
            harry[3] = 'r';
            harry[4] = 'y';

            char[] sparta = { 's', 'a', 'r', 't', 'a' };
        }

        public static int ArraySum(int[] practiceArray)
        {
            int arraySum = practiceArray[0] + practiceArray[1] + practiceArray[2];
            return arraySum;
        }

        public static void MultiDimensionalArray()
        {
            int[,] grid = new int[2, 4]; //create a 2 dimensional array

            int[,,,] grid4d = new int[3, 4, 20, 30]; //creates a 4 dimensional array

            int[,] grid2d = { { 4, 7, 8, 9 }, { 6, 1, 7, 10 } }; //they pair from their index, (4, 6) is index 0 of both, (8, 7) is index 2 etc

            Console.WriteLine(grid2d[0, 1]); //7

            int[,,] grid3d = { { { 4, 7, 8, 9 }, { 6, 1, 7, 10 }, { 4, 5, 4, 5 } } }; //creates a 3 dimensional array
            Console.WriteLine(grid3d[0, 1, 0]); //6
        }
        public static void JaggedArray()
        {
            string[][] animalGrid = new string[2][];
            animalGrid[0] = new string[4];
            animalGrid[1] = new string[2];

            string[][] animalGrid2 = new string[][]
            {
                new string[] {"llama", "puma", "horse", "kitten"},
                new string[] {"haddock", "tuna"}
            };
            Console.WriteLine(animalGrid2[1][1]);
        }
    }

    public class List
    {
        public static void InitiateList()
        {
            var names = new List<string>(); //{ "Harry", "Christopher", "Bruno" }; //does the same as code block above

            names.Add("Nish"); //unlike an array can add on items after initialisation

            foreach (string name in names)
                Console.WriteLine(name); //
        }
    }

    public class String
    {
        public static void CharArray()
        {
            string firstName = "Harry";
            string lastName = "Derbyshire";
            int age = 19;
            double score = 90.45454756;
            double percentScore = 0.9045454756;

            Console.WriteLine( $"{firstName} {lastName} Age: {age}");
            Console.WriteLine($"{firstName} {lastName} Score: {score:f4}");
            Console.WriteLine($"{firstName} {lastName} Score: {percentScore:p2}");
        }

        public static void Casting()
        {
            string input = "3";
            bool success = Int32.TryParse(input, out int input3);
            Console.WriteLine($"{success} & {input3}");
        }

        public static string StringBuilder()
        {
            StringBuilder sb = new StringBuilder("Hello Engineering 66");
            sb.Append("\nEspecially Nish!");
            
            Console.WriteLine(sb);
            
            return sb.ToString();

        }
    }
}

