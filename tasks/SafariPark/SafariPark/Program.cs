using ClassApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
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

            //Airplane test = new Airplane(200, 150, "testAirline", 300) { NumPassengers = 200 };
            //test.Ascend(123);
            //Console.WriteLine(test.Move());
            //Console.WriteLine(test.Move(8));
            //Console.WriteLine(test);

            //var gameObject = new List<Object>()
            //{
            //    new Person("Cathy", "French"),
            //    new Airplane(400, 200, "EasyJet", 9000),
            //    new Vehicle(12, 20),
            //    new Hunter("Phil", "Anderson", "Canon")
            //};

            //foreach (var item in gameObject)
            //{
            //    Console.WriteLine(item);
            //}

            //    SpartaWrite(gameObject[3]);

            //Person harry = new Person("Harry", "Derbyshire");

            //harry.Move(4);

            //var moveObjs = new List<IMovable>()
            //{
            //    new Person("Chen", "Shan"),
            //    new Airplane(400, 200, "BrynAir", 9000),
            //    new Vehicle(6, 10),
            //    new Hunter("Dog", "Dundee", "Nikon")
            //};

            //Console.WriteLine();
            //Console.WriteLine("Moving the objects:");
            //foreach (var item in moveObjs)
            //{
            //    Console.WriteLine(item.Move(3));
            //}
            Weapon pistol = new WaterPistol("Supersoaker");
            Hunter harry = new Hunter("Harry", "Derbyshire", pistol);
            //Console.WriteLine(harry.ToString());
            Console.WriteLine(harry.Shoot());
            Weapon test = new LaserGun("Raygun");
            harry.Shooter = test;
            Console.WriteLine(harry.Shoot());
            Console.WriteLine(harry.ToString());

            Person tester = new Person("Test", "name") { Age = 13 };

        }

        //public static void SpartaWrite(Object obj)
        //{
        //    Console.WriteLine(obj);
        //    if (obj is Hunter)
        //    {
        //        var hunterObj = (Hunter)obj;
        //        Console.WriteLine(hunterObj.Shoot());
        //    }
        //}

        //static void DemoMethod(Point3D pt, Person P)
        //{
        //    pt.y = 1000;
        //    P.Age = 92;
        //}
    }
}
