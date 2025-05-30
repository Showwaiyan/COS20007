namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand()
            : base(new string[] { "look" }) { }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory? container = null;
            string containerId;
            string itemId;

            if (text[0].ToLower() != "look")
                return "Error in look input";

            switch (text.Length)
            {
                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at?";
                    container = p;
                    break;
                case 5:
                    if (text[3].ToLower() != "in")
                        return "What do you want to look in?";
                    containerId = text[4].ToLower();
                    container = FetchContainer(p, containerId);
                    break;
                default:
                    return "I don\'t know how to look like that";
            }

            itemId = text[2].ToLower();
            return LookAtIn(itemId, container);
        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory? container)
        {
            if (container == null)
                return "I cannot find the bag";

            if (container.Locate(thingId) == null)
                return $"I cannot find the {thingId} in the bag";

            return container.Locate(thingId).FullDescription;
        }
    }
}
