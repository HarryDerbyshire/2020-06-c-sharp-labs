using System;
using System.Security.Cryptography.X509Certificates;

namespace lab_18_datatypes_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(TimeSpan.TicksPerSecond);
            //Console.WriteLine(TimeSpan.TicksPerMinute);
            //Console.WriteLine(DateTime.Now.Ticks);

            //var d = new DateTime();
            //var d1 = DateTime.Today;

            //var d2 = DateTime.Now;

            //var harryBday = new DateTime(2001, 03, 14);
            //var age = DateTime.Now - harryBday;
            //int age2 = (int)((age.Days) / 365.25);
            //Console.WriteLine(age2);

            //var date = DateTime.Now.ToString("dd-MM-yyy");
            //var date2 = new DateTime(2020, 10, 19).ToString("yy/MMMM/dd");
            //Console.WriteLine(date);
            //Console.WriteLine(date2);

            //Suit theSuit = Suit.HEARTS;
            //int numSuit = (int)theSuit;
            //Console.WriteLine(theSuit); // HEARTS
            //Console.WriteLine(numSuit); // 0
            //Suit mySuit = (Suit)2;
            //Console.WriteLine(mySuit);

            //bool? hasPassed; //false default

            //int totalCost = 0;
            //int? item = 3;
            //if (item.HasValue) totalCost = item.Value * 10;

            //dynamic item = 100;
            //Console.WriteLine($"adding 10 to {item} gives {item + 10}");

            //item = "hello";
            //Console.WriteLine($"adding 10 to {item} gives {item + 10}");

            //var rng = new Random();
            ////var rngSeeded = new Random(42);
            //var between1And10 = rng.Next(1, 11);

            //Console.WriteLine(between1And10);



        }
        public enum Suit {
            HEARTS,
            CLUBS,
            DIAMONDS,
            SPADES
        }

        
    }
}
