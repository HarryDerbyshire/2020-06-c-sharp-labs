using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SafariPark;

namespace SafariParkTest
{
    class IShootableTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("SuperSoaker", "Harry Derbyshire: Splash shooting a SuperSoaker")]
        [TestCase("Raygun", "Harry Derbyshire: Zing shooting a Raygun")]

        public void TestCorrectWaterPistolShootOutput(string weapon, string expected)
        {
            Weapon shooterInstance = new WaterPistol(weapon);

            var personInstance = new Hunter("Harry", "Derbyshire", shooterInstance);

            Assert.AreEqual(expected, personInstance.Shoot());
        }
    }
}
