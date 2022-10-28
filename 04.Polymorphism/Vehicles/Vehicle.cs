using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected abstract double SummerConsumption { get; }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        {
            get => fuelQuantity;
            set
            {
                if (value > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public double TankCapacity { get => tankCapacity; set => tankCapacity = value; }

        public virtual void Drive(double distance)
        {
            if (fuelQuantity - (distance * (fuelConsumption + SummerConsumption)) >= 0)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                fuelQuantity -= distance * (fuelConsumption + SummerConsumption);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (liters + fuelQuantity > tankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
            fuelQuantity += liters;
            }
        }


    }
}
