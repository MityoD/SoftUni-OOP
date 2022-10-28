using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        //private double overallPerformace;

        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance * 1.05, generation)
        {
        }

        //public override double OverallPerformance
        //{
        //    get => overallPerformace;
        //    protected set => overallPerformace = value * 1.05;
        //}

    }
}
