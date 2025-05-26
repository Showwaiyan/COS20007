namespace Task1
{
    public abstract class Thing
    {
        // Fields
        private string _name;

        // Constructors
        public Thing(string name)
        {
            _name = name;
        }

        // Method
        public abstract int Size();
        public abstract void Print();

        // Properties
        public string Name
        {
            get { return _name; }
        }
    }
}
