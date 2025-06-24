namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand()
            : base(new string[] { "put", "drop" }) { }

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
                    if (text[2].ToLower() != "in")
                        return "Where do you want to put into?";
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

            Item itm = p.Inventory.Take(itemId);
            if (itm == null)
                return $"There is no such {itemId} to put in.";

            PutItem(itm, container);

            return $"You have put {itm.ShortDescription.Split("(")[0].Trim()} in the {container.Name.ToLower()}";
        }

        private IHaveInventory FetchContainer(Location l, string containerId)
        {
            return l.Locate(containerId) as IHaveInventory;
        }

        private Item PutItem(Item itm, IHaveInventory container)
        {
            container.Inventory.Put(itm);
            return itm;
        }
    }
}
