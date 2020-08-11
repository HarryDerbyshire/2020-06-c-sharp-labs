using System;

namespace lab_27_delegates
{
    class Program
    {

        delegate void MyDelegate01();

        static void Main(string[] args)
        {

            var delegateInstance = new MyDelegate01(Method01);


        }

        //Action method
        static void Method01()
        {
            Console.WriteLine("Method01");
        }

        static void Method02()
        {
            Console.WriteLine("Method02");
        }
    }
}
