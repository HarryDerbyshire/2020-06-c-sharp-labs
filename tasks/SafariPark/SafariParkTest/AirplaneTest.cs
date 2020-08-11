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
        public void WhenAnAirplaneDescendsThenAltitudeShouldChange()
        {
            Airplane a = new Airplane(350, 360, "Airline Test", 9000) { NumPassengers = 300 };
            a.Descend(650);
            var result = a.Altitude;
            Assert.AreEqual(8350, result);
        }

        [Test]
        public void WhenAnAirplaneAscendsThenAltitudeShouldChange()
        {
            Airplane a = new Airplane(350, 360, "Airline Test", 9000) { NumPassengers = 300 };
            a.Ascend(290);
            var result = a.Altitude;
            Assert.AreEqual(9290, result);
        }

        [Test]
        public void WhenAnAirplaneWithSpeed400MovesTwicePositionShouldBe800()
        {
            Airplane a = new Airplane(350, 400, "Airline Test", 12500) { NumPassengers = 300 };
            var result = a.Move(2);
            Assert.AreEqual(800, a.Position);
            Assert.AreEqual("Moving along 2 times at an altitude 12500 metres", result);
        }

        [Test]
        public void WhenAnAirplaneWithSpeed360MovesOncePositionShouldBe360()
        {
            Airplane a = new Airplane(350, 360, "Airline Test", 9000) { NumPassengers = 300 };
            var result = a.Move();
            Assert.AreEqual(360, a.Position);
            Assert.AreEqual("Moving along at an altitude 9000 metres", result);
        }

        [Test]
        public void WhenThereAreTooManyPassengers()
        {
            Airplane a = new Airplane(350, 360, "Airline Test", 9000) { NumPassengers = 360 };
            Assert.AreEqual(a.NumPassengers, 0);
        }

        [Test]
        public void WhenAnAirplaneDropsBelowZeroMetresAltitudeShouldReturn0()
        {
            Airplane a = new Airplane(350, 360, "Airline Test", 9000) { NumPassengers = 300 };
            a.Descend(9500);
            var result = a.Altitude;
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ToStringMethodShouldReturnCorrectString()
        {
            Airplane a = new Airplane(400, 360, "Airline Test", 11600) { NumPassengers = 389 };
            var result = a.ToString();
            Assert.AreEqual("Thank you for flying Airline Test: SafariPark.Airplane capacity: 400 passengers: 389 speed: 360 position: 0 altitude: 11600", result);
        }

        [Test]
        public void ToStringMethodShouldReturnCorrectStringAfterMove()
        {
            Airplane a = new Airplane(400, 360, "Airline Test", 11600) { NumPassengers = 389 };
            a.Move();
            var result = a.ToString();
            Assert.AreEqual("Thank you for flying Airline Test: SafariPark.Airplane capacity: 400 passengers: 389 speed: 360 position: 360 altitude: 11600", result);
        }

        [Test]
        public void ToStringMethodShouldReturnCorrectStringAfterMovingThreeTimes()
        {
            Airplane a = new Airplane(400, 360, "Airline Test", 11600) { NumPassengers = 389 };
            a.Move(3);
            var result = a.ToString();
            Assert.AreEqual("Thank you for flying Airline Test: SafariPark.Airplane capacity: 400 passengers: 389 speed: 360 position: 1080 altitude: 11600", result);
        }
    }
}

