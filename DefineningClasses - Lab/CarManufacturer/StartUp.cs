using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            List<Tire[]> tiresSets = new List<Tire[]>();
            while (true)
            {
                string tiresInfo = Console.ReadLine();
                if (tiresInfo == "No more tires")
                {
                    break;
                }

                string[] tokens = tiresInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Tire[] tires = new Tire[4];
                for (int i = 0, setCounter = 0; i < tokens.Length; i += 2, setCounter++)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);
                    tires[setCounter] = new Tire(year, pressure);
                }

                tiresSets.Add(tires);
            }

            List<Engine> engines = new List<Engine>();
            while (true)
            {
                string engineInfo = Console.ReadLine();
                if (engineInfo == "Engines done")
                {
                    break;
                }

                string[] tokens = engineInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> cars = new List<Car>();
            while (true)
            {
                string carInfo = Console.ReadLine();
                if (carInfo == "Show special")
                {
                    break;
                }

                string[] tokens = carInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tiresSets[tiresIndex]);
                cars.Add(car);
            }

            var filtered = cars.Where(c => c.Year >= 2017)
                            .Where(c => c.Engine.HorsePower >= 330)
                            .Where(c => c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10);
            if (filtered.Count() > 0)
            {
                foreach (var car in filtered)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}