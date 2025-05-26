namespace Task1
{
    public class File : Thing
    {
        // Fields
        private string _extension;
        private int _size;

        //Constructors
        public File(string name, string extension, int size)
            : base(name)
        {
            _extension = extension;
            _size = size;
        }

        // Methods
        public override int Size()
        {
            return _size;
        }

        public override void Print() {
          Console.WriteLine($"File '{Name}.{_extension}' Size: {Size()} bytes");
        }
    }
}
