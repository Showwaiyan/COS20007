using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestMoveCommand
    {
        private MoveCommand move;
        private Player player;
        private Location l1;
        private Location l2;
        private SwinAdventure.Path p1;
        private SwinAdventure.Path p2;

        [SetUp]
        public void Setup()
        {
            move = new MoveCommand();

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

            player = new Player("Show", "The Programmer", l1);

            p1 = new SwinAdventure.Path(
                new string[] { "north", "n" },
                "forest",
                "You are entering a dense forest from the north.",
                l2
            );

            p2 = new SwinAdventure.Path(
                new string[] { "south", "s" },
                "valley",
                "You descend into a quiet valley from the south.",
                l1
            );

            l1.AddPath(p1);

            l2.AddPath(p2);
        }

        [Test]
        public void TestLengthValidation()
        {
            string exceptedString = "I don\'t know how to move like that";
            ClassicAssert.That(
                move.Execute(player, new string[] { "move" }),
                Is.EqualTo(exceptedString)
            );
            ClassicAssert.That(
                move.Execute(player, new string[] { "move", "to", "east", "ok?" }),
                Is.EqualTo(exceptedString)
            );
        }

        [Test]
        public void TestCommandValidation()
        {
            string exceptedString = "Error in move input";
            ClassicAssert.That(
                move.Execute(player, new string[] { "mover", "west" }),
                Is.EqualTo(exceptedString)
            );
            ClassicAssert.That(
                move.Execute(player, new string[] { "moving", "wast" }),
                Is.EqualTo(exceptedString)
            );
            ClassicAssert.That(
                move.Execute(player, new string[] { "evom", "north", "wast" }),
                Is.EqualTo(exceptedString)
            );
        }

        [Test]
        public void TestDirectionValidation()
        {
            string exceptedString = "Where are you heading to?";
            ClassicAssert.That(
                move.Execute(player, new string[] { "move", "western" }),
                Is.EqualTo(exceptedString)
            );
            ClassicAssert.That(
                move.Execute(player, new string[] { "move", "eastern" }),
                Is.EqualTo(exceptedString)
            );
            ClassicAssert.That(
                move.Execute(player, new string[] { "move", "over", "there" }),
                Is.EqualTo(exceptedString)
            );
        }

        [Test]
        public void TestPathExist()
        {
            string exceptedString = "Traveller, there is no exist in west, try another way!";
            ClassicAssert.That(
                move.Execute(player, new string[] { "move", "west" }),
                Is.EqualTo(exceptedString)
            );
        }

        [Test]
        public void TestPathTravelable()
        {
            string exceptedString =
                "Traveller, forest is currently blocked, please try in another time!";
            p1.Lookable = false;
            ClassicAssert.That(
                move.Execute(player, new string[] { "move", "north" }),
                Is.EqualTo(exceptedString)
            );
        }

        [Test]
        public void TestPlayerTravel()
        {
            string exceptedString =
                $"{player.Exit(p1.FirstId)}\n{player.Travel(p1)}\nYou have arrived in {l2.ShortDescription}";
            ClassicAssert.That(
                move.Execute(player, new string[] { "move", "north" }),
                Is.EqualTo(exceptedString)
            );
        }

        [Test]
        public void TestPlayerMove()
        {
          Location exceptedLocation = l2;
          move.Execute(player,new string[] {"move", "north"});
          ClassicAssert.True(player.CurrentLocation == exceptedLocation);
        }

        [Test]
        public void TestPlayerNotMove()
        {
          Location exceptedLocation = player.CurrentLocation;
          move.Execute(player,new string[] {"moveing", "north"});
          ClassicAssert.True(player.CurrentLocation == exceptedLocation);
        }
    }
}
