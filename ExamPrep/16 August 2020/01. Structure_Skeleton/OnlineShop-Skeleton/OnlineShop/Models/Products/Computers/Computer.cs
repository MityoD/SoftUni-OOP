using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        //private decimal price;
        private double overallPerformance;
        private double averageOverallPerformance;
        private List<IComponent> components = new List<IComponent>();
        private List<IPeripheral> peripherals = new List<IPeripheral>();



        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
: base(id, manufacturer, model, price, overallPerformance)
        {

        }

        public IReadOnlyCollection<IComponent> Components { get => components; }

        public IReadOnlyCollection<IPeripheral> Peripherals { get => peripherals; }

        public void AddComponent(IComponent component)
        {
            IComponent checkComponent = components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);
            if (checkComponent != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, checkComponent.Id));
            }
            else
            {
                components.Add(component);
            }

        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            IPeripheral checkPeripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name);
            if (checkPeripheral != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, checkPeripheral.Id));
            }
           
            peripherals.Add(peripheral);

            
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent removeComponent = components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (components.Count == 0 || removeComponent == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            components.Remove(removeComponent);
            return removeComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral removePeripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripherals.Count == 0 || removePeripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            peripherals.Remove(removePeripheral);
            return removePeripheral;
        }

        //public override double OverallPerformance
        //{
        //    get => overallPerformance;

        //    protected set
        //    {
        //        {
        //            overallPerformance = value;
        //        }
        //    }
        //}

        public double AverageOverallPerformance
        {
            get

            {
                double sumOfComponents = 0;
                foreach (var component in components)
                {
                    sumOfComponents += component.OverallPerformance;
                }
                sumOfComponents /= components.Count;

                return averageOverallPerformance = OverallPerformance + sumOfComponents;
            }

        }

        //public override decimal Price
        //{
        //    get => price;
        //    protected set => price = value;

        //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //double sumOfComponents = 0;
            //foreach (var component in components)
            //{
            //    sumOfComponents += component.OverallPerformance;
            //}
            //sumOfComponents /= components.Count;
            //double averageOverallPerformance = 0;
            //averageOverallPerformance = OverallPerformance + sumOfComponents;

            decimal totalPrice = 0;
            foreach (var component in components)
            {
                totalPrice += component.Price;
            }

            foreach (var peripheral in peripherals)
            {
                totalPrice += peripheral.Price;
            }

            sb.AppendLine($"Overall Performance: {AverageOverallPerformance:F2}. Price: {totalPrice + Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({components.Count}):");
            foreach (var item in components)
            {
                sb.AppendLine($"  {item}");
            }

            //double PsumOfComponents = 0;
            //foreach (var peripheral in peripherals)
            //{
            //    PsumOfComponents += peripheral.OverallPerformance;
            //}
            //sumOfComponents /= peripherals.Count;
            //double PaverageOverallPerformance = 0;
            //PaverageOverallPerformance = OverallPerformance + sumOfComponents;
            string ovrallprfmnc = peripherals.Count == 0 ? "0.00" : $"{peripherals.Sum(x => x.OverallPerformance) / peripherals.Count:F2}";
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({ovrallprfmnc}):");
            foreach (var item in peripherals)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public decimal GetTotalPrice()
        {

            decimal totalPrice = 0;
            foreach (var component in components)
            {
                totalPrice += component.Price;
            }

            foreach (var peripheral in peripherals)
            {
                totalPrice += peripheral.Price;
            }
            return totalPrice + this.Price;
        }
    }

}
