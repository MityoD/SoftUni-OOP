using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private const int totalToppings = 10;

        public string Name
        {
            get => name;

            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }

        }

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        private List<Topping> Toppings { get; set; }
        public Dough Dough;
        public void AddTopping(Topping topping)
        {
            if (Toppings.Count <= totalToppings)
            {
                Toppings.Add(topping);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }

        public double PizzaCalories()
        {
            double totalCalories = 0;
            foreach (var topping in Toppings)
            {
                totalCalories += topping.ToppingCalories();
            }
            totalCalories += Dough.CalculateCalories();

            return totalCalories;
        }
    }
}
