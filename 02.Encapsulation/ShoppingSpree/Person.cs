using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> Bag { get; set; }

        public void BuyProduct(Product product)
        {
            if (Money - product.Cost < 0)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                Money -= product.Cost;
                Bag.Add(product);
            }
        }
    }
}
