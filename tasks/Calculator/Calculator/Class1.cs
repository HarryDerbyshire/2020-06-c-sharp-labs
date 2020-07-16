using System;

namespace Calculator
{
    public class Operations
    {
          public static int Addition(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Subtraction(int num1, int num2)
        {
            return num1 - num2;
        }

        public static int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }

        public static double Division(int num1, int num2)
        {
            if (num2 == 0) return 0;

            return num1 / num2;
        }

        public static int Modulus(int num1, int num2)
        {
            if (num2 == 0) return 0;

            return num1 % num2;
        }
    }
}
