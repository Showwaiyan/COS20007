namespace SwinAdventure
{
    public class Player : GameObject
    {
        // Field
        private Inventory _inventory = new Inventory();

        // Constructor
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {

        }

    // Properties
        public override string FullDescription
        {
            get { return $"You are {Name} {base.FullDescription}\nYou are carrying\n {Inventory.ItemList}"; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        // Methods
        public GameObject? Locate(string id)
        {
            if (AreYou(id)) return this;
            return Inventory.Fetch(id);
        }
    }
}
