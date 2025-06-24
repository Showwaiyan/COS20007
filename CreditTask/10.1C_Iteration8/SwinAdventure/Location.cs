namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        // Fields
        private readonly Inventory _inventory;
        private List<Path> _exits; // to indicate 10 directions

        // Constructor
        public Location(string[] ids, string name, string description)
            : base(ids.Concat(new string[] { "location", "place" }).ToArray(), name, description)
        {
            _inventory = new Inventory();
            _exits = new List<Path>();
        }

        // Properties
        public Inventory Inventory
        {
            get { return _inventory; } // Readonly properties
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
                return $"{base.FullDescription}\n{GetExits()}\nIn this room you can see\n{Inventory.ItemList}";
            }
        }

        public List<Path> Exits
        {
            get { return _exits; }
            set { _exits = value; }
        }

        // Methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            return _inventory.Fetch(id);
        }

        public string GetExits()
        {
            if (_exits.Count == 0)
                return "There is no exist from here.";

            string exitsString = "There are exits to ";

            if (_exits.Count == 1)
                return exitsString + $"{_exits[0].FirstId}.";

            foreach (Path p in _exits)
            {
                if (p == _exits.Last())
                    exitsString += $"and {p.FirstId}.";
                else
                    exitsString += $"{p.FirstId}, ";
            }
            return exitsString;
        }

        public void AddPath(Path path)
        {
            _exits.Add(path);
        }

        public Path FindExits(string direction)
        {
            foreach (Path p in _exits)
            {
                if (p.AreYou(direction))
                    return p;
            }
            return null;
        }
    }
}
