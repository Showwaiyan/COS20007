namespace SwinAdventure
{
    public class Path : GameObject
    {
        // Fields
        private Location _endLocation;
        private bool _lookable; // To indicate path is blocked or not

        // Constructor
        public Path(string[] ids, string name, string description, Location endLocation)
            : base(ids.Concat(new string[] { "path" }).ToArray(), name, description)
        {
            _endLocation = endLocation;
            _lookable = true;
        }

        // Properties
        public Location EndLocation
        {
            get { return _endLocation; }
            set { _endLocation = value; }
        }

        public bool Lookable
        {
            get { return _lookable; }
            set { _lookable = value; }
        }

        // Methods
    }
}
