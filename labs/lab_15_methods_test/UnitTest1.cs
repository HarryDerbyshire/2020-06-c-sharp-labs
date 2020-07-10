using NUnit.Framework;
using lab_15_unit_testing;

namespace lab_15_methods_test
{
    public class Tests
    {
        //private int _result;
        //private int _sum;

        [SetUp]
        public void Setup()
        {
            //_result = Calc.TripleCalc(10, 2, 4, out int sum);
            //_sum = sum;
        }

        [TestCase(10, 2, 4, 80)]
        [TestCase(8, 4, 2, 64)]
        [TestCase(20, 10, 3, 600)]
        [TestCase(2, 108, 10, 2160)]
        [TestCase(36, 6, 3, 648)]
        public void ProductIsCorrect(int a, int b, int c, int expected)
        {
            var actual = Calc.TripleCalc(a, b, c, out int sum);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 1, 3)]
        [TestCase(11, 11, 11, 33)]
        [TestCase(11, 1, 1, 13)]
        [TestCase(10, 101, 1, 112)]
        [TestCase(5, 6, 1, 12)]
        [TestCase(26, 1, 10, 37)]
        [TestCase(2, 16, 8, 26)]
      
        public void SumIsCorrect(int a, int b, int c, int expected)
        {
            Calc.TripleCalc(a, b, c, out int sum);
            Assert.AreEqual(expected, sum);
        }

        //[Test]
        //public void SumIsCorrect()
        //{
        //    //Assert
        //    Assert.AreEqual(16, _sum);
        //}
    }
}