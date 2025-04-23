using NUnit.Framework;
using NUnit.Framework.Legacy;
using ClockProgram;

namespace CounterTest
{
    [TestFixture]
    public class CounterTest
    {
        private Counter _counter;
        [SetUp]
        public void Setup()
        {
            _counter = new Counter("Test");
        }

        [Test]
        public void TestInitialize()
        {
            // ClassicAssert.AreEqual(0, _counter.Ticks);
            Assert.That(_counter.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void TestOneIncrement()
        {
            _counter.Increment();
            // ClassicAssert.AreEqual(1, _counter.Ticks);
            Assert.That(_counter.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void TestNIncrement()
        {
            _counter = new Counter("Test"); // create a new obj for testing
            int nIncrement = 10;
            for (int i = 0; i < nIncrement; i++)
            {
                _counter.Increment();
            }

            // ClassicAssert.AreEqual(nIncrement, _counter.Ticks);
            Assert.That(_counter.Ticks, Is.EqualTo(nIncrement));
        }

        [Test]
        public void TestReset()
        {
            _counter.Reset();
            Assert.That(_counter.Ticks, Is.EqualTo(0));
        }
    }
}
