using NUnit.Framework;
using ClassApp;

namespace SafariParkTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Cathy", "French", "Cathy French")]
        [TestCase("", "", " ")]
        public void GetFullNameTest(string fName, string lName, string expected)
        {
            var instance = new Person(fName, lName);
            var actual = instance.GetFullName();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(25, 25)]

        public void GetAgeTest(int age, int expected)
        {
            var instance = new Person("Harry", "Derbyshire") { Age = 19 };
            instance.Age = 19;
            Assert.AreEqual(19, instance.Age);
        }
    }
}