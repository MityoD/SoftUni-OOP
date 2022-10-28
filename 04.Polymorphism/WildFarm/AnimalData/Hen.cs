using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double GainWeightPercent => 0.35;

        public override void Eat(Food food)
        {
            this.Weight += GainWeightPercent * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string MakeSount()
        {
            return "Cluck";
        }
    }
}
