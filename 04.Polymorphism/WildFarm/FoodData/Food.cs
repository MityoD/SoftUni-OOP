using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodData;

namespace WildFarm
{
    
    public  class Food : FoodCreator
    {
        public Food()
        {

        }
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }
        
    }
}
