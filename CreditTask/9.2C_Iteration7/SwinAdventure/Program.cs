namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configurations
            string helpCommand =
                $"Here is the List of command\n\t- look at me: Display what you are carrying in your inventory\n\t- look at <item> [?in <container>]: Get description of that item,which inside in the container\n\t- look: Display location's information\n\t- move <direction>: Player travel to that location\n\t- quit/exit: Halt the program\n";

            // Getting Player's Name and Description
            string PlayerName = "";
            string PlayerDescription = "";
            Console.WriteLine("Write Your Name, Traveller!");
            Console.Write("NAME -> ");
            PlayerName = Console.ReadLine();
            Console.WriteLine("How about Your description, Traveller!");
            Console.Write("Description -> ");
            PlayerDescription = Console.ReadLine();

            // LOCATIONS
            Location shire = new Location(
                new[] { "shire" },
                "The Shire",
                "A peaceful land of Hobbits, green and quiet."
            );
            Location bree = new Location(
                new[] { "bree" },
                "Bree",
                "A small town with The Prancing Pony inn."
            );
            Location rivendell = new Location(
                new[] { "rivendell" },
                "Rivendell",
                "An Elven sanctuary full of ancient magic."
            );
            Location moria = new Location(
                new[] { "moria" },
                "Moria",
                "A dark underground Dwarven city, full of echo and danger."
            );
            Location mountDoom = new Location(
                new[] { "mount doom", "doom" },
                "Mount Doom",
                "A fiery mountain in the heart of Mordor."
            );
            Location escapeTunnel = new Location(
                new[] { "tunnel", "escape tunnel" },
                "Secret Escape Tunnel",
                "A hidden tunnel beneath Mount Doom, dimly lit by glowing stones."
            );
            
            // Location items
            // SHIRE
            shire.Inventory.Put(
                new Item(
                    new[] { "pipeweed", "pouch" },
                    "Pipeweed Pouch",
                    "A small pouch of fine pipeweed."
                )
            );
            shire.Inventory.Put(
                new Item(
                    new[] { "hat", "farmer's hat" },
                    "Farmer's Hat",
                    "A straw hat once worn by a hobbit farmer."
                )
            );
            shire.Inventory.Put(
                new Item(
                    new[] { "loaf", "bread" },
                    "Hobbit Loaf",
                    "Freshly baked bread from the Shire."
                )
            );

            // BREE
            bree.Inventory.Put(
                new Item(
                    new[] { "mug", "ale" },
                    "Mug of Ale",
                    "A frothy mug from The Prancing Pony."
                )
            );
            bree.Inventory.Put(
                new Item(
                    new[] { "dagger", "rusty dagger" },
                    "Rusty Dagger",
                    "Old and blunt, but still dangerous."
                )
            );
            bree.Inventory.Put(
                new Item(
                    new[] { "cloak", "travel cloak" },
                    "Travel Cloak",
                    "A heavy cloak for cold nights."
                )
            );

            // RIVENDELL
            rivendell.Inventory.Put(
                new Item(
                    new[] { "bread", "elven bread", "lembas" },
                    "Elven Bread",
                    "One bite is enough for a full day's journey."
                )
            );
            rivendell.Inventory.Put(
                new Item(
                    new[] { "pendant", "silver pendant" },
                    "Silver Pendant",
                    "An Elven trinket that shimmers faintly."
                )
            );
            rivendell.Inventory.Put(
                new Item(
                    new[] { "book", "ancient book" },
                    "Ancient Book",
                    "Filled with forgotten lore and legends."
                )
            );

            // MORIA
            moria.Inventory.Put(
                new Item(
                    new[] { "pickaxe", "broken pickaxe" },
                    "Broken Pickaxe",
                    "Snapped at the handle."
                )
            );
            moria.Inventory.Put(new Item(new[] { "torch" }, "Torch", "Still usable if relit."));
            moria.Inventory.Put(
                new Item(
                    new[] { "gauntlets", "dwarven gauntlets" },
                    "Dwarven Gauntlets",
                    "Heavy gloves forged in the mountains."
                )
            );

            // MOUNT DOOM
            mountDoom.Inventory.Put(
                new Item(
                    new[] { "ring shard", "shard" },
                    "Black Ring Shard",
                    "A broken piece of something ancient and cursed."
                )
            );
            mountDoom.Inventory.Put(
                new Item(new[] { "lava", "rock" }, "Lava Rock", "Still warm to the touch.")
            );
            mountDoom.Inventory.Put(
                new Item(
                    new[] { "journal", "burned journal" },
                    "Burned Journal",
                    "Most pages are unreadable, but a few notes remain."
                )
            );

            // ESCAPE TUNNEL
            escapeTunnel.Inventory.Put(
                new Item(
                    new[] { "silk", "spider silk" },
                    "Spider Silk",
                    "Sticky and unnaturally strong."
                )
            );
            escapeTunnel.Inventory.Put(
                new Item(
                    new[] { "crystal", "shard" },
                    "Crystal Shard",
                    "Glows faintly with magical energy."
                )
            );
            escapeTunnel.Inventory.Put(
                new Item(
                    new[] { "torch", "elven torch" },
                    "Elven Torch",
                    "Lights automatically in the darkness."
                )
            );

            // PATHS (Bidirectional and One-Way)

            // Shire ↔ Bree
            Path shireToBree = new Path(
                new[] { "east", "e" },
                "east",
                "A path to Bree, lined with fields.",
                bree
            );
            Path breeToShire = new Path(
                new[] { "west", "w" },
                "west",
                "A path back to the Shire.",
                shire
            );

            // Bree ↔ Rivendell
            Path breeToRivendell = new Path(
                new[] { "north", "n" },
                "north",
                "The path to Rivendell through forested slopes.",
                rivendell
            );
            Path rivendellToBree = new Path(
                new[] { "south", "s" },
                "south",
                "A path back down to Bree.",
                bree
            );

            // Shire ↔ Rivendell (shortcut)
            Path shireToRivendell = new Path(
                new[] { "northeast", "ne" },
                "northeast",
                "An old Elven path to Rivendell.",
                rivendell
            );
            Path rivendellToShire = new Path(
                new[] { "southwest", "sw" },
                "southwest",
                "A trail through hills back to the Shire.",
                shire
            );

            // Bree ↔ Moria
            Path breeToMoria = new Path(
                new[] { "east", "e" },
                "east",
                "The eastern road to the mines of Moria.",
                moria
            );
            Path moriaToBree = new Path(
                new[] { "west", "w" },
                "west",
                "A narrow road back to Bree.",
                bree
            );

            // Moria → Mount Doom (one-way)
            Path moriaToDoom = new Path(
                new[] { "south", "s" },
                "south",
                "A dark, narrow path leads to Mount Doom.",
                mountDoom
            );

            // Mount Doom → Escape Tunnel (one-way)
            Path doomToTunnel = new Path(
                new[] { "down", "d" },
                "Escape Tunnel",
                "A rocky slope leads to a hidden escape tunnel.",
                escapeTunnel
            );

            // Escape Tunnel → Moria (return path)
            Path tunnelToMoria = new Path(
                new[] { "up", "u" },
                "Moria",
                "You follow the tunnel upward back into Moria's depths.",
                moria
            );

            // ADD PATHS TO LOCATIONS

            shire.AddPath(shireToBree);
            shire.AddPath(shireToRivendell);

            bree.AddPath(breeToShire);
            bree.AddPath(breeToRivendell);
            bree.AddPath(breeToMoria);

            rivendell.AddPath(rivendellToBree);
            rivendell.AddPath(rivendellToShire);

            moria.AddPath(moriaToBree);
            moria.AddPath(moriaToDoom); // No return from Doom to Moria

            mountDoom.AddPath(doomToTunnel); // No path back to Moria

            escapeTunnel.AddPath(tunnelToMoria); // Secret return

            // Player
            Player me = new Player(PlayerName, PlayerDescription, shire);

            // Player Items
            Item sword = new Item(
                new[] { "sword", "steel sword" },
                "Steel Sword",
                "A well-balanced sword of polished steel."
            );
            Item shield = new Item(
                new[] { "shield", "leather shield" },
                "Leather Shield",
                "A round shield made of hardened leather."
            );
            Bag starterBag = new Bag(
                new[] { "bag", "satchel" },
                "Adventurer's Bag",
                "A worn leather bag with room for essentials."
            );

            // Items inside the bag
            Item healingPotion = new Item(
                new[] { "potion", "healing potion" },
                "Healing Potion",
                "Restores health when consumed."
            );
            Item mapFragment = new Item(
                new[] { "map", "fragment" },
                "Map Fragment",
                "A torn piece of an ancient map leading somewhere..."
            );

            // Add items to bag
            starterBag.Inventory.Put(healingPotion);
            starterBag.Inventory.Put(mapFragment);

            // Add everything to player
            me.Inventory.Put(sword);
            me.Inventory.Put(shield);
            me.Inventory.Put(starterBag);

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
                else
                    Console.WriteLine("I don't know that command, Traveller!");
            }
        }
    }
}
