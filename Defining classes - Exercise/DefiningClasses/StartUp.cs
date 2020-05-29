using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            // task 1 and 2
            //var pesho = new Person(30, "Pesho");
            //var stamat = new Person(31, "Stamat");

            //List<Person> persons = new List<Person>()
            //{
            //    pesho,
            //    new Person(35, "Gosho"),
            //    stamat
            //};

            // var p = new Person();
            // var p = new Person(35);
            //var p = new Person(37, "Joro");
            //Console.WriteLine(p.Name);
            //Console.WriteLine(p.Age);

            // task 3
            //int N = int.Parse(Console.ReadLine());
            //var family = new Family();
            //for (int i = 0; i < N; i++)
            //{
            //    string[] args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    var person = new Person(int.Parse(args[1]), args[0]);
            //    family.AddMember(person);
            //}

            //var oldest = family.GetOldestMember();
            //Console.WriteLine($"{oldest.Name} {oldest.Age}");

            // task 4
            //int N = int.Parse(Console.ReadLine());
            //List<Person> people = new List<Person>();
            //for (int i = 0; i < N; i++)
            //{
            //    string[] args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    var person = new Person(int.Parse(args[1]), args[0]);
            //    people.Add(person);
            //}

            //var ordered = people
            //                .Where(p => p.Age > 30)
            //                .OrderBy(p => p.Name)
            //                .ToList();

            //ordered.ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));

            // task 5
            //string date = Console.ReadLine();
            //string otherDate = Console.ReadLine();
            //int daysDiff = DateModifier.CalculateDifference(date, otherDate);
            //Console.WriteLine(daysDiff);

            // task 6
            //int N = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();
            //for (int i = 0; i < N; i++)
            //{
            //    string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string model = carInfo[0];
            //    double fuelAmount = double.Parse(carInfo[1]);
            //    double fuelConsumption = double.Parse(carInfo[2]);

            //    var car = new Car(model, fuelAmount, fuelConsumption);
            //    cars.Add(car);
            //}

            //while (true)
            //{
            //    string cmd = Console.ReadLine();
            //    if (cmd == "End")
            //    {
            //        break;
            //    }

            //    string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string carModel = cmdArgs[1];
            //    double distance = double.Parse(cmdArgs[2]);

            //    cars.FirstOrDefault(c => c.Model == carModel).Drive(distance);
            //}

            //cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:F2} {c.TravelledDistance}"));

            // task 7
            //int N = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();
            //for (int i = 0; i < N; i++)
            //{
            //    string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    string model = carInfo[0];
            //    int engineSpeed = int.Parse(carInfo[1]);
            //    int enginePower = int.Parse(carInfo[2]);
            //    int cargoWeight = int.Parse(carInfo[3]);
            //    string cargoType = carInfo[4];
            //    double tire1Pressure = double.Parse(carInfo[5]);
            //    int tire1Age = int.Parse(carInfo[6]);
            //    double tire2Pressure = double.Parse(carInfo[7]);
            //    int tire2Age = int.Parse(carInfo[8]);
            //    double tire3Pressure = double.Parse(carInfo[9]);
            //    int tire3Age = int.Parse(carInfo[10]);
            //    double tire4Pressure = double.Parse(carInfo[11]);
            //    int tire4Age = int.Parse(carInfo[12]);

            //    var engine = new Engine(engineSpeed, enginePower);
            //    var cargo = new Cargo(cargoWeight, cargoType);
            //    var tires = new Tire[]
            //    {
            //        new Tire(tire1Age, tire1Pressure),
            //        new Tire(tire2Age, tire2Pressure),
            //        new Tire(tire3Age, tire3Pressure),
            //        new Tire(tire4Age, tire4Pressure)
            //    };

            //    var car = new Car(model, engine, cargo, tires);
            //    cars.Add(car);
            //}

            //string filter = Console.ReadLine();
            //switch (filter)
            //{
            //    case "fragile":
            //        cars
            //            .Where(c => c.Cargo.Type == filter)
            //            .Where(c => c.Tires.Any(t => t.Preasure < 1))
            //            .ToList()
            //            .ForEach(c => Console.WriteLine(c.Model));
            //        break;
            //    case "flamable":
            //        cars
            //            .Where(c => c.Cargo.Type == filter)
            //            .Where(c => c.Engine.Power > 250)
            //            .ToList()
            //            .ForEach(c => Console.WriteLine(c.Model));
            //        break;
            //}

            // task 8
            //int N = int.Parse(Console.ReadLine());
            //List<Engine> engines = new List<Engine>();
            //for (int i = 0; i < N; i++)
            //{
            //    string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    var engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));
            //    switch (engineInfo.Length)
            //    {
            //        case 3:
            //            if (int.TryParse(engineInfo[2], out int displacement))
            //            {
            //                engine.Displacement = displacement;
            //            }
            //            else
            //            {
            //                engine.Efficiency = engineInfo[2];
            //            }

            //            break;
            //        case 4:
            //            engine.Displacement = int.Parse(engineInfo[2]);
            //            engine.Efficiency = engineInfo[3];
            //            break;
            //    }

            //    engines.Add(engine);
            //}

            //int M = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();
            //for (int i = 0; i < M; i++)
            //{
            //    string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string model = carInfo[0];
            //    string engineModel = carInfo[1];

            //    var engine = engines.First(e => e.Model == engineModel);
            //    var car = new Car(model, engine);
            //    switch (carInfo.Length)
            //    {
            //        case 3:
            //            if (int.TryParse(carInfo[2], out int weight))
            //            {
            //                car.Weight = weight;
            //            }
            //            else
            //            {
            //                car.Color = carInfo[2];
            //            }

            //            break;
            //        case 4:
            //            car.Weight = int.Parse(carInfo[2]);
            //            car.Color = carInfo[3];
            //            break;
            //    }

            //    cars.Add(car);
            //}

            //cars.ForEach(Console.WriteLine);

            // task 9
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string[] pokemonInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (pokemonInfo[0] == "Tournament")
                {
                    break;
                }

                string trainerName = pokemonInfo[0];
                string pokemonName = pokemonInfo[1];
                string pokemonElement = pokemonInfo[2];
                int pokemonHealth = int.Parse(pokemonInfo[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                var trainer = new Trainer(trainerName, new List<Pokemon>() { pokemon });

                int trainerIndex = trainers.FindIndex(tr => tr.Name == trainerName);
                if (trainerIndex != -1)
                {
                    trainers[trainerIndex].Pokemons.Add(pokemon);
                }
                else
                {
                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                string element = Console.ReadLine();
                if (element == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            var ordered = trainers.OrderByDescending(tr => tr.Badges).ToList();
            ordered.ForEach(tr => Console.WriteLine($"{tr.Name} {tr.Badges} {tr.Pokemons.Count}"));
        }
    }
}
