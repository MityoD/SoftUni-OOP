using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            HorsePower = horsePower; //Order!!!
        }

        public string Model 
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters { get => cubicCentimeters; private set => cubicCentimeters = value; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
