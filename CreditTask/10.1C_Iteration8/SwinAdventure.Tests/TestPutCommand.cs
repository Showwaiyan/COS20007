using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestPutCommand
    {
        private PutCommand put;
        private Player player;
        private Location l1;
        private Bag bag;
        private Item gem = new Item(new string[] { "gem" }, "Gem", "This is a gem");
        private Item shovel = new Item(new string[] { "shovel" }, "Shovel", "This is a shovel");
        private Item diamond = new Item(new string[] { "diamond" }, "Diamond", "This is a diamond");

        [SetUp]
        public void Setup()
        {
            put = new PutCommand();

            l1 = new Location(
                new string[] { "a small tent", "tent" },
                "Small Tent",
                "This is a resting place for travelers."
            );

            player = new Player("Show", "The Programmer", l1);

            bag = new Bag(
                new string[] { "bag", "backpack" },
                "Leather Bag",
                "A sturdy leather bag to carry items"
            );

            bag.Inventory.Put(gem);
            player.Inventory.Put(diamond);
            l1.Inventory.Put(bag);
            l1.Inventory.Put(shovel);
        }

        [Test]
        public void PutSomethingInCurrentLocation()
        {
            string excepted = "You have put a diamond in the small tent";
            string result = put.Execute(player, new string[] { "put", "diamond" });
            ClassicAssert.True(l1.Inventory.HasItem("diamond"));
            ClassicAssert.False(player.Inventory.HasItem("diamond"));
            ClassicAssert.That(result,Is.EqualTo(excepted));
        }

        [Test]
        public void TestPickUpNothingFromCurrentLocation()
        {
            string excepted = "There is no such sword to put in.";
            string result = put.Execute(player, new string[] { "put", "sword" });
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void PutSomethingInSomething()
        {
            string excepted = "You have put a diamond in the leather bag";
            string result = put.Execute(player, new string[] { "put", "diamond", "in", "bag" });
            ClassicAssert.False(l1.Inventory.HasItem("diamond"));
            ClassicAssert.True(bag.Inventory.HasItem("diamond"));
            ClassicAssert.False(player.Inventory.HasItem("diamond"));
            ClassicAssert.That(result,Is.EqualTo(excepted));
        }

        [Test]
        public void TestPutInNothing()
        {
            string excepted = "We cannot find the box.";
            string result = put.Execute(
                player,
                new string[] { "put", "diamond", "in", "box" }
            );
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }


        [Test]
        public void TestPutSomethingInSomething()
        {
            string excepted = "You have put a diamond in the leather bag";
            string result = put.Execute(player, new string[] { "put", "diamond", "in", "bag" });
            ClassicAssert.True(bag.Inventory.HasItem("diamond"));
            ClassicAssert.False(player.Inventory.HasItem("diamond"));
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestInValidation()
        {
            string excepted = "Where do you want to put into?";
            ClassicAssert.That(
                put.Execute(player, new string[] { "put", "paper", "from", "room" }),
                Is.EqualTo(excepted)
            );
        }
    }
}
