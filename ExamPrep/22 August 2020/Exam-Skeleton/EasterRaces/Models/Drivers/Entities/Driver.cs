using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private int numberOfWins;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins => numberOfWins;

        public bool CanParticipate => Car != null;

        public void AddCar(ICar car)
        {
            
            if (car == null)
            {
                throw new ArgumentNullException(nameof(ICar),"Car cannot be null."); //ORDER!!!
            }
            Car = car;
        }

        public void WinRace()
        {
            numberOfWins++;
        }
    }
}
