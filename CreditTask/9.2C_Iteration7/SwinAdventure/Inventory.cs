namespace SwinAdventure
{
    public class Inventory
    {
        // Fields
        private List<Item> _items = new List<Item>();

        // Constructor
        public Inventory()
        {

        }

        // Properties
        public string ItemList
        {
            get
            {
                string itemListText = "";
                foreach (Item item in _items)
                {
                    itemListText += $"\t{item.ShortDescription}\n";
                    // format the string to look like
                    // You are carrying
                    //    Item A
                    //    Item B
                    //    Item C
                }
                return itemListText;
            }
        }

        // Methods
        public bool HasItem(string id)
        {
            foreach (Item item in _items) // Finding through item
            {
                if (item.AreYou(id)) return true;
            }
            return false;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item Take(string id)
        {
            Item itm = Fetch(id);

            if (itm == null) return null; // there is no such item
            _items.Remove(itm); // Remove from item list due to taken out
            return itm;
        }
        public Item Fetch(string id)
        {
            foreach (Item item in _items) // Finding through list
            {
                if (item.AreYou(id)) return item; // check item is in inventory
            }
            return null; // null if not exist
        }
    }
}
