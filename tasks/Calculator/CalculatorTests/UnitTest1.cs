using NUnit.Framework;
using Calculator;

namespace CalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(10, 20, 30)]
        [TestCase(30, 90, 120)]
        [TestCase(3, 87, 90)]
        [TestCase(300, 300, 600)]
        [TestCase(99, 1, 100)]
        public void Addition(int a, int b, int expected)
        {
            var actual = Operations.Addition(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 20, -10)]
        [TestCase(90, 30, 60)]
        [TestCase(87, 3, 84)]
        [TestCase(300, 300, 0)]
        [TestCase(99, 1, 98)]
        public void Subtraction(int a, int b, int expected)
        {
            var actual = Operations.Subtraction(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 2, 20)]
        [TestCase(30, 9, 270)]
        [TestCase(3, 8, 24)]
        [TestCase(300, 3, 900)]
        [TestCase(99, 1, 99)]
        public void Multiplication(int a, int b, int expected)
        {
            var actual = Operations.Multiplication(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(20, 10, 2)]
        [TestCase(90, 30, 3)]
        [TestCase(120, 3, 40)]
        [TestCase(300, 300, 1)]
        [TestCase(99, 0, 0)]
        public void Division(int a, int b, int expected)
        {
            var actual = Operations.Division(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(25, 10, 5)]
        [TestCase(93, 30, 3)]
        [TestCase(122, 3, 2)]
        [TestCase(399, 300, 99)]
        [TestCase(99, 0, 0)]
        public void Modulus(int a, int b, int expected)
        {
            var actual = Operations.Modulus(a, b);
            Assert.AreEqual(expected, actual);
        }

    }
}