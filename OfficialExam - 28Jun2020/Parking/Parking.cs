using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;

            data = new List<Car>(this.Capacity);
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var result = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return this.data.Remove(result);
        }

        public Car GetLatestCar()
        {
            var result = this.data
                .OrderByDescending(c => c.Year)
                .FirstOrDefault();

            return result;
        }

        public Car GetCar(string manufacturer, string model)
        {
            var result = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return result;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}