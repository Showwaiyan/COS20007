using System;
using SwinAdventure;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTests
{
    [TestFixture]
    public class TestItem
    {
        private Item testItem;

        [SetUp]
        public void Setup()
        {
            testItem = new Item(new string[]{ "sword", "bronze sword" }, "Bronze Sword", "A shiny bronze sword");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            ClassicAssert.True(testItem.AreYou("sword"));
            ClassicAssert.True(testItem.AreYou("bronze sword"));
            ClassicAssert.False(testItem.AreYou("golden sword"));
        }

        [Test]
        public void TestShortDescription()
        {
            ClassicAssert.AreEqual("a bronze sword (sword)", testItem.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            string description = "A shiny bronze sword";

            ClassicAssert.AreEqual(description, testItem.FullDescription);
        }

        [Test]
        public void TestPrivilegeEscalarion()
        {
            string myStudentID = "105293041";
            testItem.PrivilegeEscalation("3041");

            // Test that aftert escalation the first id should be my student id;
            ClassicAssert.AreEqual(myStudentID, testItem.FirstId);
        }
    }
}
