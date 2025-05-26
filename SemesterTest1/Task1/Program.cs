namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // First 10 prime number
            int[] A = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

            // Last four digit of my student id - 3041
            int[] B = { A[3], A[0], A[4], A[1] };

            // Create File Systems
            FileSystem midTest = new FileSystem();

            // Adding B[0] files to midTest
            string myStudentId = "105293041";

            for (int i = 0; i < B[0]; i++)
            {
                midTest.Add(
                    new File(
                        $"{myStudentId}-{i.ToString("D2")}",
                        "txt",
                        new Random().Next(1000, 10000)
                    )
                );
            }

            // Adding a folder that contains B[1] files to midTest
            Folder Test1 = new Folder("Test1");
            // Add B[1] files to Test1
            for (int i = 0; i < B[1]; i++)
            {
                Test1.Add(
                    new File(
                        $"{myStudentId}-{i.ToString("D2")}",
                        "txt",
                        new Random().Next(1000, 10000)
                    )
                );
            }
            midTest.Add(Test1); // Add that folder to midTest;

            // Adding a folder that contains a folder that contains B[2] files
            Folder Test2 = new Folder("Test2"); // Creating a parent folder
            Folder Test2Child = new Folder("Test2Child"); // Creating child folder of Parent

            // Add B[2] files to Test2Child
            for (int i = 0; i < B[1]; i++)
            {
                Test2Child.Add(
                    new File(
                        $"{myStudentId}-{i.ToString("D2")}",
                        "txt",
                        new Random().Next(1000, 10000)
                    )
                );
            }

            // Add Child folder to parent
            Test2.Add(Test2Child);
            // Add parent folder to midTest
            midTest.Add(Test2);

            // Adding a number of B[3] empty folders to the file system
            for (int i = 0; i < B[3]; i++)
            {
                midTest.Add(new Folder($"Test{i + 3}"));
            }

            midTest.PrintContents();
        }
    }
}
