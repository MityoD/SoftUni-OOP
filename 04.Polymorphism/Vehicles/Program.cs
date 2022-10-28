using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckInfo = Console.ReadLine().Split();

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split();

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                string vehicle = command[1];
                double value = double.Parse(command[2]);
                if (vehicle == "Bus")
                {   
                    if (action == "DriveEmpty")
                    {
                        bus.DriveEmpty(value);
                    }
                    else if (action == "Drive")
                    {
                        bus.Drive(value);
                    }
                    else if (action == "Refuel")
                    {
                        bus.Refuel(value);
                    }
                }
                else if (vehicle == "Car")
                {
                    if (action == "Drive")
                    {
                        car.Drive(value);
                    }
                    else if (action == "Refuel")
                    {
                        car.Refuel(value);
                    }
                }
                else if (vehicle == "Truck")
                {
                    if (action == "Drive")
                    {
                        truck.Drive(value);
                    }
                    else if (action == "Refuel")
                    {
                        truck.Refuel(value);
                    }
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");


        }
    }
}
