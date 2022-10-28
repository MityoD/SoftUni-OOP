using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class CentralProcessingUnit : Component
    {
       // private double overallPerformance;

        public CentralProcessingUnit(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * 1.25, generation)
        {
        }

        //public override double OverallPerformance 
        //{
        //    get => overallPerformance;
        //    protected set => overallPerformance = value * 1.25; 
        //}
    }
}
