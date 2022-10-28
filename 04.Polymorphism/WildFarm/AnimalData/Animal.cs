using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        protected abstract double GainWeightPercent { get; }

        public abstract void Eat(Food food);

        public abstract string MakeSount();
       
    }
}
