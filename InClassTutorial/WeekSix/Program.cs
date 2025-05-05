using System;

namespace ShipManagement
{
    abstract class Ship
    {
        protected string name;
        protected int year;

        public Ship()
        {
            name = "Unknown";
            year = 0;
        }

        public virtual void setAll(string name, int year)
        {
            this.name = name;
            this.year = year;
        }

        public abstract void show();
    }

    class CruiseShip : Ship
    {
        private int maxPassengers;

        public CruiseShip() : base()
        {
            maxPassengers = 0;
        }

        // Overloaded setAll method
        public void setAll(string name, int year, int maxPassengers)
        {
            base.setAll(name, year);
            this.maxPassengers = maxPassengers;
        }

        public override void show()
        {
            Console.WriteLine("\nCruise Ship Details:");
            Console.WriteLine("===================");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Year Built: {year}");
            Console.WriteLine($"Maximum Passengers: {maxPassengers}");
        }
    }

    class CargoShip : Ship
    {
        private double capacity;

        public CargoShip() : base()
        {
            capacity = 0.0;
        }

        public void setAll(string name, int year, double capacity)
        {
            base.setAll(name, year);
            this.capacity = capacity;
        }

        public override void show()
        {
            Console.WriteLine("\nCargo Ship Details:");
            Console.WriteLine("===================");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Year Built: {year}");
            Console.WriteLine($"Cargo Capacity: {capacity} tons");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ship Management System");
            Console.WriteLine("=====================");

            Ship[] ships = new Ship[4];

            ships[0] = new CruiseShip();
            ships[1] = new CruiseShip();

            ships[2] = new CargoShip();
            ships[3] = new CargoShip();

            ((CruiseShip)ships[0]).setAll("Royal Caribbean", 2015, 3500);

            ((CruiseShip)ships[1]).setAll("Carnival Dream", 2009, 4500);

            ((CargoShip)ships[2]).setAll("Maersk Line", 2018, 18000);

            ((CargoShip)ships[3]).setAll("Evergreen Marine", 2020, 15000);

            Console.WriteLine("\nDisplaying All Ships Information:");
            Console.WriteLine("===============================");

            foreach (Ship ship in ships)
            {
                ship.show();
            }

            Console.WriteLine("\nProgram completed.");
        }
    }
}
