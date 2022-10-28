using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.FoodData
{
    public class FoodCreator
    {

        public Food CreateFood(string foodType, int quantity)
        {
            Food food = null;
            if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            return food;
        }
    }
}
