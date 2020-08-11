using System;

namespace lab_30_basic_event
{
    class Program
    {

        delegate void MyDelegate();
        static event MyDelegate MyEvent;


        delegate void MySecondDelegate(int x, int y);
        static event MySecondDelegate MySecondEvent;

        static void Main(string[] args)
        {
            // Event ==> link to  multiple methods (delegates 1-1 mapping)
            // Event ==> external to program
            // User events - onclick, onkeydown/up etc., double click, mouse hover 
            // Data events - onload, onpageload, ondata arrive, track % complete (map to progress bar), on data complete
            //             - notification of email / chat message

            // 1. Create delegate (specify methods which can run)
            // 2. Create blank event `event [delegatename] [eventname];
            // 3. Add/remove methods using += or -=. Order matters => methods fire in this order
            MyEvent += Method01;
            MyEvent += Method02;
            MyEvent += Method03;
            // 4. Call event
            MyEvent();

            MySecondEvent += Addition;
            MySecondEvent += Multiplication;

            MySecondEvent(20, 5);
        }

        static void Method01()
        {
            Console.WriteLine("Running method numero 1");
        }
        static void Method02()
        {
            Console.WriteLine("Running method numero 2");
        }
        static void Method03()
        {
            Console.WriteLine("Running method numero 3");
        }

        static void Addition(int x, int y)
        {
            Console.WriteLine($"Sum of {x} and {y} is {x + y}");
        }

        static void Multiplication(int x, int y)
        {
            Console.WriteLine($"Product of {x} and {y} is {x * y}");
        }
    }
}
