using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int numberOfPeople;
        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;

        public Table(int tableNumber, int capacity, decimal pricePerPerson
)
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders => foodOrders as IReadOnlyList<IBakedFood>;

        public IReadOnlyCollection<IDrink> DrinkOrders => drinkOrders as IReadOnlyList<IDrink>;

        public int TableNumber { get => tableNumber; private set => tableNumber = value; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get => pricePerPerson; private set => pricePerPerson = value; }

        public bool IsReserved => numberOfPeople > 0;

        public decimal Price => NumberOfPeople * PricePerPerson;

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.drinkOrders.Clear();
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal totalPrice = this.Price;
            foreach (var drink in drinkOrders)
            {
                totalPrice += drink.Price;
            }
            foreach (var food in foodOrders)
            {
                totalPrice += food.Price;
            }
            return totalPrice;
        }

        public string GetFreeTableInfo()
        { ///??
            StringBuilder sb = new StringBuilder();
            //if (IsReserved == false)
            //{
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson:F2}");
            //    }

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
        }
    }
}
