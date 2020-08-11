using System;
using System.Globalization;

namespace lab_31_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {
            // Goal : annual event (triggered by time(calendar)) - have birthday party
            var James = new Child("James");

            // Events ==> not reachable externally so have to call from a method within the class
            for (int i = 0; i < 20; i++)
            {
                James.AnotherYearOlder();

            }
            
        }
    }

    class Child
    {
        public string Name { get; set; }
        public int Age { get; set; }

        delegate void BirthdayDelegate(int age);
        event BirthdayDelegate BirthdayEvent; // Event is null on creation

        public Child(string name)
        {
            // New person allocate name but age = 0
            this.Name = name;
            this.Age = 0;

            // Fill event
            BirthdayEvent += Celebrate; // Event is no longer null
        }

        public void AnotherYearOlder()
        {
            this.Age++;
            BirthdayEvent(this.Age);
        }


        // Method to run from event
        void Celebrate(int age)
        {
            Console.WriteLine($"Congratulations, you have survived until {age} years old");
        }
    }

}
