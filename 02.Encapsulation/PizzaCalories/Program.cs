using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Pizza pizza = null;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();
                string ingredientType = input[0];
                string type = input[1];
                try
                {
                    if (ingredientType == "Pizza")
                    {
                        pizza = new Pizza(type);
                    }
                    else if (ingredientType == "Dough")
                    {
                        string bakingTechnique = input[2];
                        double grams = double.Parse(input[3]);
                        Dough dough = new Dough(type, bakingTechnique, grams);
                        pizza.Dough = dough;
                    }
                    else if (ingredientType == "Topping")
                    {
                        double grams = double.Parse(input[2]);
                        Topping topping = new Topping(type, grams);
                        pizza.AddTopping(topping);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            Console.WriteLine($"{pizza.Name} - {pizza.PizzaCalories():F2} Calories.");
        }
    }
}
