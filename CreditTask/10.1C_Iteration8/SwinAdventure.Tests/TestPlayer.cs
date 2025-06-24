using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestPlayer
    {
        private Player testPlayer;
        private Location testLocation;
        private Item sword = new Item(
            new string[] { "sword", "bronze sword" },
            "Bronze Sword",
            "A shiny bronze sword"
        );
        private Item shield = new Item(
            new string[] { "shield", "wooden shield" },
            "Wooden Shield",
            "A tough wooden shield"
        );
        private Item potion = new Item(
            new string[] { "potion", "health potion" },
            "Health Potion",
            "A magical red potion that restores health"
        );

        [SetUp]
        public void Setup()
        {
            testLocation = new Location(
                new string[] { "a small tant", "tant" },
                "Small Tant",
                "This a rest place for traveller."
            );
            testPlayer = new Player("Show", "The Programmer", testLocation);

            testPlayer.Inventory.Put(sword);
            testPlayer.Inventory.Put(shield);
            testPlayer.Inventory.Put(potion);
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            ClassicAssert.True(testPlayer.AreYou("me"));
            ClassicAssert.True(testPlayer.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocateItems()
        {
            ClassicAssert.That(sword, Is.EqualTo(testPlayer.Locate("sword")));
            ClassicAssert.True(testPlayer.Inventory.HasItem("sword"));
            ClassicAssert.That(shield, Is.EqualTo(testPlayer.Locate("wooden shield")));
            ClassicAssert.True(testPlayer.Inventory.HasItem("wooden shield"));
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            ClassicAssert.That(testPlayer, Is.EqualTo(testPlayer.Locate("me")));
            ClassicAssert.That(testPlayer, Is.EqualTo(testPlayer.Locate("inventory")));
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            ClassicAssert.That(testPlayer.Locate("gun"), Is.EqualTo(null));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string testDescription =
                $"You are Show The Programmer\nYou are carrying\n \t{sword.ShortDescription}\n\t{shield.ShortDescription}\n\t{potion.ShortDescription}\n";
            ClassicAssert.That(testPlayer.FullDescription, Is.EqualTo(testDescription));
        }
    }
}
