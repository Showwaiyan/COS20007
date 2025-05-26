namespace Task1
{
    public class Folder : Thing
    {
        // Field
        private List<Thing> _contents;

        // Constructor
        public Folder(string name)
            : base(name)
        {
            _contents = new List<Thing> { };
        }

        // Methods
        public void Add(Thing toAdd)
        {
            _contents.Add(toAdd);
        }

        public override int Size()
        {
            int totalSize = 0;
            foreach (Thing item in _contents)
            {
                totalSize += item.Size();
            }
            return totalSize;
        }

        public override void Print()
        {
            if (_contents.Count() == 0)
            {
                Console.WriteLine($"The Folder: '{Name}' is empty!");
                return;
            }

            // Couting folders and files
            int foldersCount = 0;
            int filesCount = 0;
            foreach (Thing item in _contents)
            {
                if (item.GetType() == typeof(Folder)) foldersCount++;
                else if (item.GetType() == typeof(File)) filesCount++;
            }

            string folderStatus = foldersCount > 1 ? $"{foldersCount} folders" : $"{foldersCount} folder";
            string fileStatus = filesCount > 1 ? $"{filesCount} files" : $"{filesCount} file";

            Console.WriteLine(
                $"The Folder: '{Name}' contains {folderStatus} and {fileStatus} totalling {Size()} bytes:"
            );
            foreach (Thing item in _contents)
            {
                item.Print();
            }
        }
    }
}
