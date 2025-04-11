namespace CounterTask
{
   internal class Program
   {
        private static void PrintCounters(Counter[] coutners)
        {
            foreach (Counter c in coutners)
            {
                Console.WriteLine("{0} is {1}",c.Name,c.Ticks);
            }
        }
        public static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];
            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[1];

            for (int i = 1; i <= 9; i++)
            {
                myCounters[0].Increment();
            }

            for (int i = 1; i <= 14; i++)
            {
                myCounters[1].Increment();
            }

            Program.PrintCounters(myCounters);
            myCounters[2].Reset();
            Program.PrintCounters(myCounters);
        }
   }
}
