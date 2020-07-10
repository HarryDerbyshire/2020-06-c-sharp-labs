using NUnit.Framework;
using lab_16_selection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace lab_16_selection_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(100)]
        [TestCase(75)]
        public void PassWithDistinction(int mark)
        {
            var result = Selection.PassFail(mark);
            Assert.AreEqual("Pass with Distinction", result);
        }
        [Test]
        public void PassWithMerit()
        {
            var result = Selection.PassFail(65);
            Assert.AreEqual("Pass with Merit", result);
        }
        

        [Test]
        public void PassWithPass()
        {
            var result = Selection.PassFail(45);
            Assert.AreEqual("Pass", result);
        }

        [Test]
        public void PassWithFail()
        {
            var result = Selection.PassFail(25);
            Assert.AreEqual("Fail", result);
        }

        [Test]
        public void RedAlert()
        {
            var result = Switch.AlertLevel(3);
            Assert.AreEqual("Code Red", result);
        }

        [TestCase(2)]
        [TestCase(1)]
        public void AmberAlert(int level)
        {
            var result = Switch.AlertLevel(level);
            Assert.AreEqual("Code Amber", result);
        }

        [Test]
        public void GreenAlert()
        {
            var result = Switch.AlertLevel(0);
            Assert.AreEqual("Code Green", result);
        }
    }
}