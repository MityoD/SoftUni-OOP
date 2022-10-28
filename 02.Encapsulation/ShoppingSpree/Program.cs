using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, Product> products = new Dictionary<string, Product>();
                Dictionary<string, Person> persons = new Dictionary<string, Person>();
                string[] personInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < personInput.Length; i++)
                {
                    string[] personInfo = personInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);
                    Person newPerson = new Person(name, money);
                    persons.Add(name, newPerson);
                }

                string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productInput.Length; i++)
                {
                    string[] productInfo = productInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);
                    Product newProduct = new Product(cost, name);
                    products.Add(name, newProduct);
                }

                string command = "";
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArgs = command.Split();
                    string name = commandArgs[0];
                    string productToBuy = commandArgs[1];
                    persons[name].BuyProduct(products[productToBuy]);
                }
                foreach (var item in persons)
                {
                    Console.Write($"{item.Value.Name} - ");
                    if (item.Value.Bag.Count == 0)
                    {
                        Console.WriteLine("Nothing bought");
                    }
                    else
                    {
                        for (int i = 0; i < item.Value.Bag.Count; i++)
                        {
                            if (i > 0)
                            {
                                Console.Write(", ");
                            }
                            Console.Write(item.Value.Bag[i].Name);
                        }
                        Console.WriteLine();

                    }
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);              
            }
        }
    }
}
