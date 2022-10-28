using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double GainWeightPercent => 0.25;

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += GainWeightPercent * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string MakeSount()
        {
            return "Hoot Hoot";
        }
    }
}
