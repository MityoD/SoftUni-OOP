using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly DriverRepository drivers;
        private readonly CarRepository cars;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            cars = new CarRepository();
            races = new RaceRepository();
        }



        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = cars.GetByName(carModel);
            IDriver driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException("Driver {name} could not be found.");
            }
            if (car == null)
            {
                throw new InvalidOperationException("Car {name} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            //Check Input!!!
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            cars.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            drivers.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            races.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var driversToRace = race.Drivers.ToList();
            int laps = race.Laps;
            int count = 1;

            StringBuilder sb = new StringBuilder();
            foreach (var item in driversToRace.OrderByDescending(x => x.Car.CalculateRacePoints(laps)))
            {
                if (count == 1)
                {
                    sb.AppendLine($"Driver {item.Name} wins {raceName} race.");
                }
                else if (count == 2)
                {
                    sb.AppendLine($"Driver {item.Name} is second in {raceName} race.");
                }
                else if (count == 3)
                {
                    sb.AppendLine($"Driver {item.Name} is third in {raceName} race.");

                }
                else
                {
                    break;
                }
                count++;
            }


            races.Remove(race);
            return sb.ToString().TrimEnd();


        }
    }
}
