namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        // Field
        private Inventory _inventory = new Inventory();
        private Location _currentLocation;

        // Constructor
        public Player(string name, string desc, Location spawnLocatoin)
            : base(new string[] { "me", "inventory" }, name, desc)
        {
            _currentLocation = spawnLocatoin;
        }

        // Properties
        public override string FullDescription
        {
            get
            {
                return $"You are {Name} {base.FullDescription}\nYou are carrying\n {Inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Location CurrentLocation {
          get {return _currentLocation;}
        }

        // Methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            GameObject obj = Inventory.Fetch(id);
            if (obj != null)
                return obj;

            obj = CurrentLocation.Locate(id);
            if (obj != null)
                return obj;

            return null;
        }

        public string WhereAmI()
        {
            return $"You are in {CurrentLocation.ShortDescription}";
        }

        public string Arrive()
        {
            return $"You have arrived in {CurrentLocation.ShortDescription}";
        }

        // For Iteration 7
        // public string Exit()
        // {
        //     return "";
        // }

        // public string Travel()
        // {
        //     return "";
        // }
    }
}
