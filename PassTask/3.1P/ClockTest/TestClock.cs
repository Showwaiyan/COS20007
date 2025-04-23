using NUnit.Framework;
using ClockProgram;

namespace ClockTest
{
    [TestFixture]
    public class Tests
    {
        private Clock clock;
        [SetUp]
        public void Setup()
        {
            clock = new Clock();
        }

        [Test]
        public void TestOneSecond()
        {
            clock.Reset();
            clock.Tick();
            Assert.That(clock.GetTime(), Is.EqualTo("00:00:01"));
        }

        [Test]
        public void TestNSecond()
        {
            clock.Reset();
            int second = 49;
            for (int i = 0; i < second; i++) clock.Tick();


            Assert.That(clock.GetTime(), Is.EqualTo($"00:00:{second.ToString("D2")}"));
        }

        [Test]
        public void TestOneMinute()
        {
            clock.Reset();
            int second = 60;
            for (int i = 0; i < second; i++) clock.Tick();
            Assert.That(clock.GetTime(), Is.EqualTo("00:01:00"));
        }

        [Test]
        public void TestNMinute()
        {
            clock.Reset();
            int minute = 3;
            int second = 60 * minute;
            for (int i = 0; i < second; i++) clock.Tick();
            Assert.That(clock.GetTime(), Is.EqualTo($"00:{minute.ToString("D2")}:00"));
        }

        [Test]
        public void TestSecondMinute()
        {
            clock.Reset();
            int second = 190;
            int minute = second / 60;
            for (int i = 0; i < second; i++) clock.Tick();
            Assert.That(clock.GetTime(), Is.EqualTo($"00:{minute.ToString("D2")}:{(second % 60).ToString("D2")}"));
        }

        [Test]
        public void TestOneHour()
        {
            clock.Reset();
            int second = 3600;
            for (int i = 0; i < second; i++) clock.Tick();
            Assert.That(clock.GetTime(), Is.EqualTo("01:00:00"));
        }

        [Test]
        public void TestNHour()
        {
            clock.Reset();
            int hour = 5;
            int second = 3600 * hour;
            for (int i = 0; i < second; i++) clock.Tick();
            Assert.That(clock.GetTime(), Is.EqualTo($"{hour.ToString("D2")}:00:00"));
        }

        [Test]
        public void TestHourMinuteSecond()
        {
            clock.Reset();
            int second = 5500;
            int minute = (second % 3600) / 60;
            int hour = second / 3600;
            for (int i = 0; i < second; i++) clock.Tick();
            Assert.That(clock.GetTime(), Is.EqualTo($"{hour.ToString("D2")}:{minute.ToString("D2")}:{(second % 60).ToString("D2")}"));
        }
    }
}
