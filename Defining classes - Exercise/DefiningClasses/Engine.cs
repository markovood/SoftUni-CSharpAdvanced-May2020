using System;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement = 0, string efficiency = "n/a")
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public int Speed { get; private set; }

        public int Power { get; private set; }

        public string Model { get; private set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacement = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();
            return $"  {this.Model}:" + Environment.NewLine +
                    $"    Power: {this.Power}" + Environment.NewLine +
                    $"    Displacement: {displacement}" + Environment.NewLine +
                    $"    Efficiency: {this.Efficiency}";
        }
    }
}
