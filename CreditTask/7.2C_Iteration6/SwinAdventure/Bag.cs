namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        // Fields
        private Inventory _inventory;

        // Constructor
        public Bag(string[] ids, string name, string desc)
            : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        // Methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            return _inventory.Fetch(id);
        }

        // Properties
        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}.\nYou look in the {Name.ToLower()} and see:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
