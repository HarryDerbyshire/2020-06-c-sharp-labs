using System;

namespace lab_29_delegate_lambda
{
    class Program
    {

        delegate string MyDelegate(string x, int y);

        static void Main(string[] args)
        {
            MyDelegate instance = MyMethod;
            Console.WriteLine(instance("Harry", 19));

            MyDelegate instance2 = (name, age) => 
            { 
                return $"Hello {name}, you are {age} years old";
            };

            Console.WriteLine(instance2("Bob", 33));
                    
        }

        static string MyMethod(string name, int age)
        {
            return $"Hello {name}, you are {age} years old";
        }
    }
}
