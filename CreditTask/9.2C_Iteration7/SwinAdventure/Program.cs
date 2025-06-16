namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configurations
            string helpCommand =
                $"Here is the List of command\n\t- look at me: Display what you are carrying in your inventory\n\t- look at <item> [?in <container>]: Get description of that item,which inside in the container\n\t- quit/exit: Halt the program\n";

            // Getting Player's Name and Description
            string PlayerName = "";
            string PlayerDescription = "";
            Console.WriteLine("Write Your Name, Traveller!");
            Console.Write("NAME -> ");
            PlayerName = Console.ReadLine();
            Console.WriteLine("How about Your description, Traveller!");
            Console.Write("Description -> ");
            PlayerDescription = Console.ReadLine();

            // Object Configurations
            Location hallWay = new Location(
                new string[] { "the Hallway", "Hallway" },
                "Hallway",
                "This is a long well lit Hallway."
            );
            Location tent = new Location(
                new string[] { "a small tent", "tent" },
                "Small Tent",
                "This is a resting place for travelers."
            );

            Location cave = new Location(
                new string[] { "a dark cave", "cave" },
                "Dark Cave",
                "A damp, echoing cave stretches into the darkness."
            );

            Player me = new Player(PlayerName, PlayerDescription, tent); // Create Player

            // Create two items and put these to player's inventory
            Item sword = new Item(
                new string[] { "sword", "bronze sword" },
                "Bronze Sword",
                "A shiny bronze sword"
            );
            Item shield = new Item(
                new string[] { "shield", "wooden shield" },
                "Wooden Shield",
                "A tough wooden shield"
            );

            me.Inventory.Put(sword);
            me.Inventory.Put(shield);

            // Create a bag and put it to player's inventory
            Bag myBag = new Bag(
                new string[] { "bag", "backpack" },
                "Leather Bag",
                "A sturdy leather bag to carry items"
            );
            me.Inventory.Put(myBag);

            // Create another item and add it to the bag
            Item potion = new Item(
                new string[] { "potion", "health potion" },
                "Health Potion",
                "A magical red potion that restores health"
            );

            myBag.Inventory.Put(potion);

            // Create three object and placed in the Hallway
            Item bow = new Item(
                new string[] { "bow", "longbow" },
                "Longbow",
                "A finely crafted bow with great range"
            );

            Item helmet = new Item(
                new string[] { "helmet", "iron helmet" },
                "Iron Helmet",
                "A sturdy iron helmet for head protection"
            );

            Item ring = new Item(
                new string[] { "ring", "magic ring" },
                "Magic Ring",
                "A mysterious ring that glows faintly with magical energy"
            );

            hallWay.Inventory.Put(bow);
            hallWay.Inventory.Put(helmet);
            hallWay.Inventory.Put(ring);

            // Create Paths
            Path p1 = new SwinAdventure.Path(
                new string[] { "north", "n", "up" },
                "forest",
                "You are entering a dense forest from the north.",
                cave
            );

            Path p2 = new SwinAdventure.Path(
                new string[] { "east", "e" },
                "valley",
                "You descend into a quiet valley from the south.",
                hallWay
            );

            // Connect Locations with paths
            tent.AddPath(p1);
            cave.AddPath(p2);

            // Command Configuration
            LookCommand lookCommand = new LookCommand();
            MoveCommand moveCommand = new MoveCommand();

            // Game Loop
            Console.WriteLine("Write '-h' for helper");

            Console.WriteLine(me.Arrive());
            while (true)
            {
                string command = "";
                Console.Write("Command -> ");
                command = Console.ReadLine().ToLower();
                Console.WriteLine(); // to make clear after input line for presented looking

                if (command == "exit" || command == "quit")
                {
                    Console.WriteLine("Take the rest, Traveller!");
                    return;
                }
                else if (command == "-h")
                {
                    Console.WriteLine(helpCommand);
                }
                else if (lookCommand.AreYou(command.Split(' ')[0]))
                {
                    Console.WriteLine(lookCommand.Execute(me, command.Split(' ')));
                }
                else if (moveCommand.AreYou(command.Split(' ')[0]))
                {
                    Console.WriteLine(moveCommand.Execute(me, command.Split(' ')));
                }
                else Console.WriteLine("I don't know that command, Traveller!");
            }
        }
    }
}
