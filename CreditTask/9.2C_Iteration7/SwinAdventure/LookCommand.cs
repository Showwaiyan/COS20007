namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand()
            : base(new string[] { "look", "inv", "inventory" }) { }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container = null;
            string containerId = null;
            string itemId = null;
            switch (text.Length)
            {
                case 1:
                    if (text[0].ToLower() == "look")
                        return p.CurrentLocation.FullDescription;
                    else if (text[0].ToLower() == "inventory" || text[0].ToLower() == "inv")
                    {
                        container = p;
                        itemId = "me";
                    }
                    break;
                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at?";
                    container = p;
                    itemId = text[2].ToLower();
                    break;
                case 5:
                    if (text[3].ToLower() != "in")
                        return "What do you want to look in?";
                    containerId = text[4].ToLower();
                    itemId = text[2].ToLower();
                    container = FetchContainer(p, containerId);
                    break;
                default:
                    return "I don\'t know how to look like that";
            }
            return LookAtIn(itemId, container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container == null)
                return "I cannot find the bag";

            if (container.Locate(thingId) == null)
                return $"I cannot find the {thingId} in the {container.Name}";

            return container.Locate(thingId).FullDescription;
        }
    }
}
