using NUnit.Framework;
using NUnit.Framework.Legacy;
using UnitTest;

namespace TestCase
{
    [TestFixture]
    public class TestCaseClass
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_Test()
        {
            double result = calculator.Add(2, 8);
            ClassicAssert.AreEqual(10, result);
        }
    }

}
