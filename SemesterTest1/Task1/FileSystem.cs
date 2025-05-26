namespace Task1
{
    public class FileSystem
    {
        // Field
        private List<Thing> _contents;

        // Constructor
        public FileSystem()
        {
            _contents = new List<Thing> { };
        }

        // Methods
        public void Add(Thing toAdd)
        {
            _contents.Add(toAdd);
        }

        public void PrintContents()
        {
            Console.WriteLine("This File System contains:");
            foreach (Thing item in _contents)
            {
                item.Print();
            }
        }

        // Properties
    }
}
