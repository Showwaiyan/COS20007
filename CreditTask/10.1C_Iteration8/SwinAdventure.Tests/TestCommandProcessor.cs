using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    public class TestCommandProcessor
    {
        private CommandProcessor cp;
        private LookCommand look;
        private MoveCommand move;
        private PickUpCommand pickup;
        private PutCommand put;
        private Player player;
        private Location l1;
        private Location l2;
        private SwinAdventure.Path p1;
        private Bag bag;
        private Item gem;
        private Item shovel;
        private Item diamond;

        [SetUp]
        public void Setup()
        {
            cp = new CommandProcessor();
            look = new LookCommand();
            move = new MoveCommand();
            pickup = new PickUpCommand();
            put = new PutCommand();

            cp.AddCommand(look);
            cp.AddCommand(move);
            cp.AddCommand(pickup);
            cp.AddCommand(put);

            l1 = new Location(
                new string[] { "a small tent", "tent" },
                "Small Tent",
                "This is a resting place for travelers."
            );
            l2 = new Location(
                new string[] { "a dark cave", "cave" },
                "Dark Cave",
                "A damp, echoing cave stretches into the darkness."
            );
            p1 = new SwinAdventure.Path(
                new string[] { "north", "n" },
                "forest",
                "You are entering a dense forest from the north.",
                l2
            );
            l1.AddPath(p1);

            player = new Player("Show", "The Programmer", l1);

            bag = new Bag(
                new string[] { "bag", "backpack" },
                "Leather Bag",
                "A sturdy leather bag to carry items"
            );

            gem = new Item(new string[] { "gem" }, "Gem", "This is a gem");
            shovel = new Item(new string[] { "shovel" }, "Shovel", "This is a shovel");
            diamond = new Item(new string[] { "diamond" }, "Diamond", "This is a diamond");

            player.Inventory.Put(diamond);
            l1.Inventory.Put(bag);
            l1.Inventory.Put(shovel);
            bag.Inventory.Put(gem);
        }

        [Test]
        public void TestLookCommand()
        {
            string excepted = gem.FullDescription;
            string result = cp.Execute(player, "look at gem in bag");
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestMoveCommand()
        {
            string excepted =
                $"{player.Exit(p1.FirstId)}\n{player.Travel(p1)}\nYou have arrived in {l2.ShortDescription}";
            ClassicAssert.That(cp.Execute(player, "move north"), Is.EqualTo(excepted));
        }

        [Test]
        public void TestPickUpCommand()
        {
            string excepted = "You have taken a shovel from the small tent";
            string result = cp.Execute(player, "pickup shovel");
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestPutCommand()
        {
            string excepted = "You have put a diamond in the small tent";
            string result = cp.Execute(player, "put diamond");
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void TestInvalidCommand()
        {
            string excepted = "I don\'t understand sleep";
            string result = cp.Execute(player, "sleep");
            ClassicAssert.That(result, Is.EqualTo(excepted));
        }
    }
}
