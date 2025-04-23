namespace ClockProgrm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int secondsInADay = 86400;
            Clock myClock = new Clock();
            for (int i = 0; i < secondsInADay; i++)
            {
                myClock.Tick();
                Console.WriteLine(myClock.GetTime());
            }
        }
    }
}
