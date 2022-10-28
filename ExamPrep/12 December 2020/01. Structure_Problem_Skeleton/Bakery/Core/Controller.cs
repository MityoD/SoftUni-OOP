using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome;


        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }
            drinks.Add(drink);
            string result = string.Format(OutputMessages.DrinkAdded, name, brand);
            return result;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            else if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }
            bakedFoods.Add(food);
            string result = string.Format(OutputMessages.FoodAdded, name, type);
            return result;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            tables.Add(table);
            string result = string.Format(OutputMessages.TableAdded, tableNumber);
            return result;
        }

        public string GetFreeTablesInfo()
        {
            //Finds all not reserved tables and for each table returns the table info.
            List<ITable> freeTables = tables.Where(x => x.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome() => string.Format(OutputMessages.TotalIncome, totalIncome);

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.First(x => x.TableNumber == tableNumber);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():F2}");
            totalIncome += table.GetBill();
            table.Clear();
            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {

            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            IDrink drink = drinks.Where(x => x.Name == drinkName && x.Brand == drinkBrand).FirstOrDefault();
            string result;
            if (table == null)
            {
                result = string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else if (drink == null)
            {
                result = string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            else
            {
                string drinkNameAndBrand = drinkName + " " + drinkBrand;
                table.OrderDrink(drink);
                result = string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkNameAndBrand);
            }
            return result;

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            IBakedFood food = bakedFoods.Where(x => x.Name == foodName).FirstOrDefault();
            string result;
            if (table == null)
            {
                result = string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else if (food == null)
            {
                result = string.Format(OutputMessages.NonExistentFood, foodName);
            }
            else
            {
                table.OrderFood(food);
                result = string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
            }
            return result;
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.Where(x => x.IsReserved == false && x.Capacity >= numberOfPeople).FirstOrDefault();
            string result;
            if (table == null)
            {
                result = string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);
                result = string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }

            return result;
        }
    }
}
