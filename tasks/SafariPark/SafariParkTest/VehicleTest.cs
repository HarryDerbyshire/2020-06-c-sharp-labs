using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SafariPark;

namespace SafariParkTest
{
    public class VehicleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenADefaultVehicleMovesTwiceItsPositionIs20()
        {
            Vehicle v = new Vehicle();
            var result = v.Move(2);
            Assert.AreEqual(20, v.Position);
            Assert.AreEqual("Moving along 2 times", result);
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
