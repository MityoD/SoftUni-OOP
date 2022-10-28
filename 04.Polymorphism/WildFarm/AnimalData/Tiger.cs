using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double GainWeightPercent => 1;

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
            return "ROAR!!!";
        }
    }
}
