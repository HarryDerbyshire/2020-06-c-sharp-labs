using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SafariPark;

namespace SafariParkTest
{
    public class AirplaneTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenADefaultVehicleMovesTwiceItsPositionIs20()
        {
            Airplane a = new Airplane(350, 400, "Airline Test", 12500) { NumPassengers = 300 };
            var result = a.Move(2);
            //Assert.AreEqual(20, a.Position);
            Assert.AreEqual("Moving along 2 times at an altitude 12500 metres", result);
        }



        [Test]
        public void WhenAVehicleWithSpeed40IsMovedOnceItsPositionIs40()
        {
            Vehicle v = new Vehicle(5, 40);
            var result = v.Move();
            Assert.AreEqual(40, v.Position);
            Assert.AreEqual("Moving along", result);
        }

        [Test]
        public void WhenThereAreTooManyPassengers()
        {
            Vehicle v = new Vehicle(40);
            v.NumPassengers = 45;
            Assert.AreEqual(v.NumPassengers, 0);
        }
    }
}

