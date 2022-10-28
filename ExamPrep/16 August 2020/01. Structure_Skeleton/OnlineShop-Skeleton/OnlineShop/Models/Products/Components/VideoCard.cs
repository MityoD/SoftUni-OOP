using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class VideoCard : Component
    {
        //private double overallPerformanceConst = 1.15;
        
        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance * 1.15, generation)
        {
        }
        //public override double OverallPerformance
        //{
        //    get => overallPerformance;
        //    protected set => overallPerformance = value * 1.15;
        //}

        
    }
}
