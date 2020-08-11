using System;

namespace lab_28_delegates
{
    class Program
    {
        delegate void Delegate01();
        delegate string Delegate02(int x, bool y);


        static void Main(string[] args)
        {
            //shorter version
            //notice no brackets in method ==> just placeholder, don't call right now
            Delegate01 myDelegateInstance = Method01;


            Action myOtherDelegateInstance = Method02;

            Delegate02 delegateInstance = Method03;

            //myDelegateInstance();
            //myOtherDelegateInstance();

            Console.WriteLine(delegateInstance(15, false));
            Console.WriteLine(delegateInstance(34, true));
        }

        static void Method01()
        {
            Console.WriteLine("Running method01");
        }

        static void Method02()
        {
            Console.WriteLine("Running method02");
        }

        static string Method03(int x, bool employed)
        {
           return employed ? $"Your age is {x} and you are employed" : $"Your age is {x} and you are not employed";
          
        }
    }
}
