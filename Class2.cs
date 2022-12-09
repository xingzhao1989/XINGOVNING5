using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xingovning5
{
    internal class TEST
    {
        private readonly Garage<Vehicle> garage;

        public TEST(int capacity)
        {

            garage = new Garage<Vehicle>(capacity);
        }


        public IEnumerable<string> GaragePrinter()
        {
            if (!garage.Any())
                Console.WriteLine("Garage is empty");
            return garage
                .Select(v => v.DisplayInfo());
        }
        public IEnumerable<string>? GaragePrinter(string value)
        {
            if (!garage.Any())
            {
                Console.WriteLine("Garage is empty");
                return garage.Select(v => v.DisplayInfo());
            }

            return garage.Where(v => v.Color.ToLower() == "red" || v.RegNumber.ToLower() == value || v.GetType().Name == value || v.NumberOfWheels.ToString() == value)
                .Select(v => v.DisplayInfo());
        }
  


        public bool SeedData()
        {
            Vehicle motorcycle = new Motorcycle("abc123", "white", 2);
            Vehicle motorcycle2 = new Motorcycle("red", "gray", 2);
            Vehicle car = new Car("cbc123", "red", 4);
            if (garage.Add(motorcycle) == false) { return false; }
            if (garage.Add(motorcycle2) == false) { return false; }
            if (garage.Add(car) == false) { return false; }
            return true;
        }

        internal bool Park(Vehicle vehicle)
        {
            return garage.Add(vehicle);
        }
        internal bool GarageIsFull()
        {
            return garage.IsFull();
        }

        internal bool RegisterVehicle(string type, string reg, string color, int wheels)
        {
            switch (type)
            {
                case "car":
                    Car car = new Car(reg, color, wheels);
                    return garage.Add(car);
                case "airplane":
                    Motorcycle airplane = new Motorcycle(reg, color, wheels);
                    return garage.Add(airplane);
            }
            return false;
        }

    }
}
