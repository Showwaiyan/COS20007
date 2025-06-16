namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        // Constructor
        public MoveCommand()
            : base(new string[] { "move", "go", "head", "leave" }) { }

        // Methods
        public override string Execute(Player p, string[] text)
        {
            string[] validMoveCommand = { "move", "go", "head", "leave" };
            string[] validDirection =
            {
                "east",
                "e",
                "south east",
                "southeast",
                "se",
                "south",
                "s",
                "south west",
                "southwest",
                "sw",
                "west",
                "w",
                "north west",
                "northwest",
                "nw",
                "north",
                "n",
                "north east",
                "northeast",
                "ne",
                "up",
                "down",
            };

            // Check text has no more 3 word
            if (text.Length > 3 || text.Length < 2)
                return "I don\'t know how to move like that";

            // Check first letter of text is valid
            if (!validMoveCommand.Contains(text[0].ToLower()))
                return "Error in move input";

            // Check for direction validation
            string direction = String.Join(" ", text[1..]).ToLower();
            if (!validDirection.Contains(direction))
                return "Where are you heading to?";

            // Check path exist
            Path travelPath = p.CurrentLocation.FindExits(direction);
            if (travelPath == null)
                return $"Traveller, there is no exist in {direction}, try another way!";

            // Check path is travelable
            if (!travelPath.Lookable)
                return $"Traveller, {travelPath.Name} is currently blocked, please try in another time!";

            // Player Travel
            return p.Move(travelPath);
        }
    }
}
