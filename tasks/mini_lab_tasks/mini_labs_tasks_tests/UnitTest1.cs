using NUnit.Framework;
using mini_lab_tasks;

namespace mini_labs_tasks_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, 3, 3, 216)]
        [TestCase(6, 2, 4, 20736)]
        [TestCase(2, 9, 2, 324)]
        [TestCase(16, 5, 4, 40960000)]
        public void Test1(double a, double b, int c, double expected)
        {
            double actual = Tasks.RaiseToPower(a, b, c);
            Assert.AreEqual(expected, actual);
        }
    }
}