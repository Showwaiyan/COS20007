using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestPickUpCommand
    {
        private PickUpCommand pickUp;
        private Player player;
        private Location l1;
        private Bag bag;
        private Item gem = new Item(new string[] { "gem" }, "Gem", "This is a gem");
        private Item shovel = new Item(new string[] { "shovel" }, "Shovel", "This is a shovel");
        private Item diamond = new Item(new string[] { "diamond" }, "Diamond", "This is a diamond");

        [SetUp]
        public void Setup()
        {
            pickUp = new PickUpCommand();

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
            l1.Inventory.Put(bag);
            l1.Inventory.Put(shovel);
        }

        [Test]
        public void TestPickUpFromCurrentLocation()
        {
            string excepted = "You have taken a shovel from the small tent";
            string result = pickUp.Execute(player, new string[] { "pickup", "shovel" });
            ClassicAssert.False(l1.Inventory.HasItem("shovel"));
            ClassicAssert.True(player.Inventory.HasItem("shovel"));
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestPickUpNothingFromCurrentLocation()
        {
            string excepted = "There is no such sword to pick up.";
            string result = pickUp.Execute(player, new string[] { "pickup", "sword" });
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestPickUpFromNothing()
        {
            string excepted = "We cannot find the box.";
            string result = pickUp.Execute(
                player,
                new string[] { "pickup", "shovel", "from", "box" }
            );
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestPickUpSomethingFromSomething()
        {
            string excepted = "You have taken a gem from the leather bag";
            string result = pickUp.Execute(player, new string[] { "pickup", "gem", "from", "bag" });
            ClassicAssert.False(bag.Inventory.HasItem("gem"));
            ClassicAssert.True(player.Inventory.HasItem("gem"));
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestFromValidation()
        {
            string excepted = "Where do you want to pick up from?";
            ClassicAssert.That(
                pickUp.Execute(player, new string[] { "pickup", "paper", "in", "room" }),
                Is.EqualTo(excepted)
            );
        }
    }
}
