using System;

namespace HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greeting from Message Object. My Student ID is 105293041");
            myMessage.Print();

            Message[] messages = {
                new Message("Hi Kaung Htet Nyein, how are you?"),
                new Message("Hi Khant Thu Aung, how are you?"),
                new Message("Hi Zin Ko Oo, how are you?"),
                new Message("Welcome Admin"),
                new Message("Welcome, nice to meet you")
            };

            while (true)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine().ToLower();

                if (name == "exit") break;
                else if (name == "kaung htet nyein") messages[0].Print();
                else if (name == "khant thu aung") messages[1].Print();
                else if (name == "zin ko oo") messages[2].Print();
                else if (name == "show wai yan") messages[3].Print();
                else messages[4].Print();
            }
        }
    }
}
