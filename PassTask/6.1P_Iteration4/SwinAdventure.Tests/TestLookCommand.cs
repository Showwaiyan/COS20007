using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestLockCommand
    {
        private LookCommand look;
        private Player testPlayer;
        private Bag bag;
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
            look = new LookCommand();
            testPlayer = new Player("Show", "The Programmer");
            bag = new Bag(
                new string[] { "bag", "backpack", "leather bag" },
                "Leather Bag",
                "A sturdy leather bag to carry items"
            );
            testPlayer.Inventory.Put(bag);
        }

        [Test]
        public void TestLookAtMe()
        {
            string excepted = testPlayer.FullDescription;
            string testOutPut = look.Execute(
                testPlayer,
                new string[] { "look", "at", "Inventory" }
            );
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }

        [Test]
        public void TestLookAtGem()
        {
            string excepted = gem.FullDescription;
            testPlayer.Inventory.Put(gem);
            string testOutPut = look.Execute(testPlayer, new string[] { "look", "at", "Gem" });
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }

        [Test]
        public void TestLookAtUnk()
        {
            string excepted = "I cannot find the gem in the bag";
            string testOutPut = look.Execute(testPlayer, new string[] { "look", "at", "Gem" });
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            string excepted = gem.FullDescription;
            testPlayer.Inventory.Put(gem);
            string testOutPut = look.Execute(
                testPlayer,
                new string[] { "look", "at", "Gem", "in", "me" }
            );
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            string excepted = gem.FullDescription;
            bag.Inventory.Put(gem);
            string testOutPut = look.Execute(
                testPlayer,
                new string[] { "look", "at", "Gem", "in", "bag" }
            );
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            string excepted = "I cannot find the bag";
            Player noBagPlayer = new Player("Ricky", "I have No Bag bro");
            string testOutPut = look.Execute(
                noBagPlayer,
                new string[] { "look", "at", "Gem", "in", "bag" }
            );
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            string excepted = "I cannot find the gem in the bag";
            string testOutPut = look.Execute(
                testPlayer,
                new string[] { "look", "at", "Gem", "in", "bag" }
            );
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }

        [Test]
        public void InvalidLook()
        {
            string excepted = "I don\'t know how to look like that";
            string testOutPut = look.Execute(testPlayer, new string[] { "look", "around" });
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));

            excepted = "Error in look input";
            testOutPut = look.Execute(testPlayer, new string[] { "hello", "105293041" });
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));

            excepted = "I cannot find the show wai yan in the bag";
            testOutPut = look.Execute(testPlayer, new string[] { "look", "at", "Show Wai Yan" });
            ClassicAssert.That(testOutPut, Is.EqualTo(excepted));
        }
    }
}
