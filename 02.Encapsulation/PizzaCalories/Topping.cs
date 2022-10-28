using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double baseCalories = 2;
        private double grams;
        private string type;
        private double toppingCalories;

        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }

        private string Type
        {
            set
            {
                if (string.Equals(value, "Meat", StringComparison.OrdinalIgnoreCase))
                {
                    toppingCalories = 1.2;
                }
                else if (string.Equals(value, "Veggies", StringComparison.OrdinalIgnoreCase))
                {
                    toppingCalories = 0.8;
                }
                else if (string.Equals(value, "Cheese", StringComparison.OrdinalIgnoreCase))
                {
                    toppingCalories = 1.1;
                }
                else if (string.Equals(value, "Sauce", StringComparison.OrdinalIgnoreCase))
                {
                    toppingCalories = 0.9;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }

        public double ToppingCalories()
        {
            return toppingCalories * baseCalories * grams;
        }

    }
}
