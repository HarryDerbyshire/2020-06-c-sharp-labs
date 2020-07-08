using System;

namespace lab_03_dot_net_core_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World From a Programmer");
            int[] myArray = {1, 2, 3, 4, 5};
            foreach(var item in myArray) {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            int total = 0;

            for(int i=0; i < 5000; i++)
            {
                //Console.WriteLine(i);
                total += i;
            }
        }
    }
}
