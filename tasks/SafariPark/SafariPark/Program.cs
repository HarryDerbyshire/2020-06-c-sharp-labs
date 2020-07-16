using ClassApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace SafariPark
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person harry = new Person("Harry", "Derbyshire");
            //harry.Age = 19;
            //Console.WriteLine($"Harry is {harry.Age}");
            //Console.WriteLine(harry.GetFullName());

            //var list = new ShoppingList() { Bread = 1, Lemon = 3, Milk = 1 };

            //var s1 = new Point3D() { x = 1, y = 2, z = 3 };
            //Person john = new Person("John", "Jones") { Age = 20 };

            //Point3D pt3d = new Point3D(5, 8, 1);

            //DemoMethod(pt3d, john);


            //Hunter bryn = new Hunter("Bryn", "Morley", "Nikon") { Age = 25 };
            //Console.WriteLine(bryn.ToString());

            //Hunter jimmy = new Hunter();
            //Console.WriteLine(jimmy.Shoot());
            //Person p1 = new Person("Harry", "Derbyshire");

            //Person nish = new Person("Nish", "Mandal") { Age = 21 };
            //Hunter cathy = new Hunter("Cathy", "French", "Nikon") { Age = 21 };
            //MonsterHunter phil = new MonsterHunter("Phil", "Anderson", "Nikon", "Love") { Age = 21 };

            //Console.WriteLine(phil.Attack());

            //var safariList = new List<object>();
            //safariList.Add(nish);
            //safariList.Add(cathy);
            //safariList.Add(phil);

            //foreach (var item in safariList)
            //{
            //    Console.WriteLine(item);
            //}

            Airplane test = new Airplane(200, 150, "testAirline", 300) { NumPassengers = 200 };
            test.Ascend(123);
            Console.WriteLine(test.Move());
            Console.WriteLine(test.Move(8));
            Console.WriteLine(test);
        }

        static void DemoMethod(Point3D pt, Person P)
        {
            pt.y = 1000;
            P.Age = 92;
        }
    }
}
