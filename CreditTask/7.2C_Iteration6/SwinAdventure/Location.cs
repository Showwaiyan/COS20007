namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        // Fields
        private readonly Inventory _inventory;
        private readonly string _arrivalJourney; // to indicate how player enter this location
        private Dictionary<string, Location> _exists; // to indicate 10 directions

        // Constructor
        public Location(string[] ids, string name, string description, string arrivalJourney)
            : base(ids.Concat(new string[] { "location", "place" }).ToArray(), name, description)
        {
            _inventory = new Inventory();
            _arrivalJourney = arrivalJourney;
        }

        // Properties
        public Inventory Inventory
        {
            get { return _inventory; } // Readonly properties
        }

        public string ArrivalJourney
        {
            get { return _arrivalJourney; }
        }

        public override string ShortDescription
        {
            // need to make base's properties as virtual to make specific for location
            get { return FirstId; }
        }

        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}\n{FindExists()}\nIn this room you can see\n{Inventory.ItemList}";
            }
        }

        public Dictionary<string, Location> Exists
        {
            get { return _exists; }
            set { _exists = value; }
        }

        // Methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            return _inventory.Fetch(id);
        }

        public string FindExists()
        {
            // Currently placeholder fortesting
            // will be implemented in itertaion 7
            return "There are exits to the south.";
        }
    }
}
