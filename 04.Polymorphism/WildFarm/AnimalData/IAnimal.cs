using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract void Eat(Food food);

        public abstract string MakeSount();
    }
}
