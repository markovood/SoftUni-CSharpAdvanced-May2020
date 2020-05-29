using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        private int weight;
        private string color;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.travelledDistance = 0;
        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.tires = tires;
        }

        public Car(string model, Engine engine, int weight = 0, string color = "n/a")
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get => this.model; private set => this.model = value; }
        public double FuelAmount { get => this.fuelAmount; private set => this.fuelAmount = value; }
        public double FuelConsumptionPerKilometer { get => this.fuelConsumptionPerKilometer; private set => this.fuelConsumptionPerKilometer = value; }
        public double TravelledDistance { get => this.travelledDistance; }

        public Engine Engine { get => this.engine; private set => this.engine = value; }
        public Cargo Cargo { get => this.cargo; private set => this.cargo = value; }
        public IReadOnlyCollection<Tire> Tires { get => Array.AsReadOnly(this.tires); }

        public int Weight { get; set; }
        public string Color { get; set; }

        public void Drive(double distance)
        {
            if (CanPassDistance(distance))
            {
                this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
                this.travelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            string weight = this.Weight == 0 ? "n/a" : this.Weight.ToString();
            return $"{this.Model}:" + Environment.NewLine +
                    $"{this.Engine}" + Environment.NewLine +
                    $"Weight: {weight}" + Environment.NewLine +
                    $"Color: {this.Color}";
        }

        private bool CanPassDistance(double distance)
        {
            double neededFuel = distance * this.FuelConsumptionPerKilometer;
            if (this.FuelAmount >= neededFuel)
            {
                return true;
            }

            return false;
        }
    }
}
