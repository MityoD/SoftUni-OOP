using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double GainWeightPercent => 0.4;

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
            return "Woof!";
        }
    }
}
