using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        // private int generation;

        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation { get; } //=> generation; private set => generation = value;


        public override string ToString()
        {
            return base.ToString() + $" Generation: {this.Generation}";
            
        }
        //public override string ToString()
        //{
        //    return $"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id}) Generation: {this.Generation}";
        //}
    }
}
