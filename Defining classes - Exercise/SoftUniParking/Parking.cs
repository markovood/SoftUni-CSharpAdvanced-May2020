using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> parkingLot;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.parkingLot = new List<Car>(this.capacity);
        }

        public int Count => this.parkingLot.Count;

        public string AddCar(Car car)
        {
            if (this.parkingLot.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Count >= this.parkingLot.Capacity)
            {
                return "Parking is full!";
            }

            this.parkingLot.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            var car = this.GetCar(registrationNumber);
            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.parkingLot.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.parkingLot.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            List<Car> carsToRemove = new List<Car>();
            foreach (var regNum in registrationNumbers)
            {
                var carIndex = this.parkingLot.FindIndex(c => c.RegistrationNumber == regNum);
                if (carIndex != -1)
                {
                    this.parkingLot.RemoveAt(carIndex);
                }
            }
        }
    }
}
