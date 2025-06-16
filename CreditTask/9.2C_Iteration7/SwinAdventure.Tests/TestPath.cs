using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestPath
    {
        private SwinAdventure.Path testPath;
        private Location l1;

        [SetUp]
        public void Setup()
        {
            l1 = new Location(
                new string[] { "a small tant", "tant" },
                "Small Tant",
                "This a rest place for traveller."
            );
            testPath = new SwinAdventure.Path(
                new string[] { "east", "e" },
                "road",
                "You are walking down the road from the east.",
                l1
            );
        }

        [Test]
        public void TestPathIsIdentifiable()
        {
          ClassicAssert.True(testPath.AreYou("east"));
          ClassicAssert.True(testPath.AreYou("e"));
          ClassicAssert.True(testPath.AreYou("path"));
          ClassicAssert.False(testPath.AreYou("north west"));
        }

        [Test]
        public void TestPathEndLocation()
        {
          ClassicAssert.That(testPath.EndLocation, Is.EqualTo(l1));
        }
    }
}
