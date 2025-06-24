using SwinAdventure;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTests
{
    [TestFixture]
    public class TestInventory
    {
        private Inventory testInventory;
        private Item sword = new Item(new string[] { "sword", "bronze sword" }, "Bronze Sword", "A shiny bronze sword");
        private Item shield = new Item(new string[] { "shield", "wooden shield" }, "Wooden Shield", "A tough wooden shield");
        private Item potion = new Item(new string[] { "potion", "health potion" }, "Health Potion", "A magical red potion that restores health");

        [SetUp]
        public void Setup()
        {
            testInventory = new Inventory();


            testInventory.Put(sword);
            testInventory.Put(potion);
            testInventory.Put(shield);
        }

        [Test]
        public void TestFindItem()
        {
            ClassicAssert.True(testInventory.HasItem("sword"));
            ClassicAssert.True(testInventory.HasItem("potion"));
        }

        [Test]
        public void TestNoItemFind()
        {
            ClassicAssert.False(testInventory.HasItem("arrow"));
        }

        [Test]
        public void TestFetchItem()
        {
            ClassicAssert.That(shield, Is.EqualTo(testInventory.Fetch("wooden shield")));
            ClassicAssert.True(testInventory.HasItem("wooden shield"));
        }

        [Test]
        public void TestTakeItem()
        {
            ClassicAssert.That(potion, Is.EqualTo(testInventory.Take("health potion")));
            ClassicAssert.False(testInventory.HasItem("health potion"));
        }

        [Test]
        public void TestItemList()
        {
            string testList = $"\t{sword.ShortDescription}\n\t{potion.ShortDescription}\n\t{shield.ShortDescription}\n";
            ClassicAssert.That(testList, Is.EqualTo(testInventory.ItemList));
        }
    }
}
