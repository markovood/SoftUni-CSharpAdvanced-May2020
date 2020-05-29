namespace DefiningClasses
{
    public class Tire
    {
        public Tire(int age, double preasure)
        {
            this.Age = age;
            this.Preasure = preasure;
        }

        public int Age { get; set; }

        public double Preasure { get; set; }
    }
}
