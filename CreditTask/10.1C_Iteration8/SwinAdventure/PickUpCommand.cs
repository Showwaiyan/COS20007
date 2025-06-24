namespace SwinAdventure
{
    public class PickUpCommand : Command
    {
        public PickUpCommand()
            : base(new string[] { "pickup", "take" }) { }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container = null;
            string containerId = null;
            string itemId = null;
            switch (text.Length)
            {
                case 2:
                    itemId = text[1].ToLower();
                    container = p.CurrentLocation;
                    break;
                case 4:
                    if (text[2].ToLower() != "from")
                        return "Where do you want to pick up from?";
                    if (text[3].ToLower() == "room")
                        container = p.CurrentLocation;
                    else
                    {
                        containerId = text[3].ToLower();
                        container = FetchContainer(p.CurrentLocation, containerId);
                    }
                    itemId = text[1].ToLower();
                    break;
                default:
                    return "I don\'t know how to pick up like this.";
            }
            if (container == null)
                return $"We cannot find the {containerId}.";

            Item itm = GetItem(itemId, container);
            if (itm == null)
                return $"There is no such {itemId} to pick up.";

            p.Inventory.Put(itm);
            return $"You have taken {itm.ShortDescription.Split("(")[0].Trim()} from the {container.Name.ToLower()}";
        }

        private IHaveInventory FetchContainer(Location l, string containerId)
        {
            return l.Locate(containerId) as IHaveInventory;
        }

        private Item GetItem(string itemId, IHaveInventory container)
        {
            Item itm = container.Inventory.Take(itemId);
            return itm;
        }
    }
}
