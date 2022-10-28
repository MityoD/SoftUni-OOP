using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double GainWeightPercent => 0.3;

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
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
            return "Meow";
        }
    }
}
