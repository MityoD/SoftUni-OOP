using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle 
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double SummerConsumption => 1.4;

        
        public override void Drive(double distance)
        {
            base.Drive(distance);
        }

        public void DriveEmpty(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) >= 0)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQuantity -= distance * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
