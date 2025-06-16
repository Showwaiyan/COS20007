using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestLocation
    {
        private Location testLocation;
        private Bag bag;
        private Player player;
        private Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        private Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        private Item diamond = new Item(
            new string[] { "diamond" },
            "a diamond",
            "This is a diamond"
        );

        [SetUp]
        public void Setup()
        {
            testLocation = new Location(
                new string[] { "a small tant", "tant" },
                "Small Tant",
                "This a rest place for traveller."
            );
            bag = new Bag(
                new string[] { "bag", "backpack", "leather bag" },
                "Leather Bag",
                "A sturdy leather bag to carry items"
            );
            player = new Player("Show", "The Programmer", testLocation);
            bag.Inventory.Put(gem);
            bag.Inventory.Put(diamond);
            testLocation.Inventory.Put(shovel);
            testLocation.Inventory.Put(bag);
        }

        [Test]
        public void TestLocationIsIdentifiable()
        {
            ClassicAssert.True(testLocation.AreYou("location"));
            ClassicAssert.True(testLocation.AreYou("place"));
        }

        [Test]
        public void TestLocationCanLocateItem()
        {
            string bagId = bag.FirstId;
            ClassicAssert.That(bag, Is.EqualTo(testLocation.Locate(bagId)));

            string shovelId = shovel.FirstId;
            ClassicAssert.That(shovel, Is.EqualTo(testLocation.Locate(shovelId)));
        }

        [Test]
        public void TestPlayerCanLocateItemInLocation()
        {
            string bagId = bag.FirstId;
            ClassicAssert.That(bag, Is.EqualTo(player.Locate(bagId)));

            string shovelId = shovel.FirstId;
            ClassicAssert.That(shovel, Is.EqualTo(player.Locate(shovelId)));
        }

        [Test]
        public void TestGetAllExits()
        {
            SwinAdventure.Path p1 = new SwinAdventure.Path(
                new string[] { "north", "n" },
                "forest",
                "You are entering a dense forest from the north.",
                null
            );

            SwinAdventure.Path p2 = new SwinAdventure.Path(
                new string[] { "south", "s" },
                "valley",
                "You descend into a quiet valley from the south.",
                null
            );

            SwinAdventure.Path p3 = new SwinAdventure.Path(
                new string[] { "west", "w" },
                "bridge",
                "You cross a narrow bridge from the west.",
                null
            );
            testLocation.AddPath(p1);
            testLocation.AddPath(p2);
            testLocation.AddPath(p3);

            string exceptedString = "There are exits to north, south, and west.";
            ClassicAssert.That(testLocation.GetExits(), Is.EqualTo(exceptedString));
        }

        [Test]
        public void TestFindExits()
        {
            SwinAdventure.Path p1 = new SwinAdventure.Path(
                new string[] { "north", "n" },
                "forest",
                "You are entering a dense forest from the north.",
                null
            );
            testLocation.AddPath(p1);
            ClassicAssert.That(testLocation.FindExits("north"),Is.EqualTo(p1));
            ClassicAssert.That(testLocation.FindExits("east"),Is.EqualTo(null));
        }
    }
}
