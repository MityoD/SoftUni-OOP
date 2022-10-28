using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<Computer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<Computer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckForExistingComputer(computerId);

            IComponent component;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            if (components.Any(x => x.Id == component.Id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            components.Add(component);
            computers.First(x => x.Id == computerId).AddComponent(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        private void CheckForExistingComputer(int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            Computer computer;

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            Computer toCheck = computers.FirstOrDefault(x => x.Id == id);
            if (toCheck != null)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            peripherals.Add(peripheral);
            computer.AddPeripheral(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {

            Computer pc = null;

            foreach (var item in computers.OrderByDescending(x => x.AverageOverallPerformance))
            {
                decimal price = item.GetTotalPrice();
                if (price <= budget)
                {
                    pc = item;
                    break;
                }

            }

            if (computers.Count == 0 || pc == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            computers.Remove(pc);
            return pc.ToString();
        }

        public string BuyComputer(int id)
        {
            Computer computer = computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            computer.RemoveComponent(componentType);
            IComponent toRemove = components.Where(x => x.GetType().Name == componentType).FirstOrDefault();
            components.Remove(toRemove);

            return $"Successfully removed {componentType} with id {toRemove.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            computer.RemovePeripheral(peripheralType);


            IPeripheral peripheral = peripherals.First(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";


        }
    }
}
