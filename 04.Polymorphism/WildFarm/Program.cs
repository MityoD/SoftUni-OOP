using System;
using System.Collections.Generic;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<IAnimal> animals = new List<IAnimal>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string animalType = commandArgs[0];
                string animalName = commandArgs[1];
                double animalWeight = double.Parse(commandArgs[2]);

                IAnimal animal = null;

                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);
                //Food food = null;
                ////food.CreateFood(foodType, foodQuantity);

                Food newFood = new Food();
                Food eatFood = newFood.CreateFood(foodType, foodQuantity);
                //if (foodType == "Meat")
                //{
                //    food = new Meat(foodQuantity);
                //}
                //else if (foodType == "Seeds")
                //{
                //    food = new Seeds(foodQuantity);
                //}
                //else if (foodType == "Vegetable")
                //{
                //    food = new Vegetable(foodQuantity);
                //}
                //else if (foodType == "Fruit")
                //{
                //    food = new Fruit(foodQuantity);
                //}

                if (animalType == "Owl" || animalType == "Hen")
                {
                    double wingSize = double.Parse(commandArgs[3]);
                    if (animalType == "Owl")
                    {
                    animal = new Owl(animalName,animalWeight, wingSize);
                    }
                    else
                    {
                        animal = new Hen(animalName, animalWeight, wingSize);
                    }
                }
                else if (animalType == "Cat" || animalType == "Tiger")
                {
                    string livingRegion = commandArgs[3];
                    string breed = commandArgs[4];
                    if (animalType == "Cat")
                    {
                        animal = new Cat(animalName, animalWeight, livingRegion, breed);
                    }
                    else
                    {
                        animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                    }
                }
                else
                {
                    string livingRegion = commandArgs[3];
                    if (animalType == "Dog")
                    {
                        animal = new Dog(animalName, animalWeight, livingRegion);
                    }
                    else
                    {
                        animal = new Mouse(animalName, animalWeight, livingRegion);
                    }
                }
                Console.WriteLine(animal.MakeSount());
                animal.Eat(eatFood);
                animals.Add(animal);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}
