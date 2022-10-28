using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> foodBought = new Dictionary<string, IBuyer>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);
                if (commandArgs.Length == 4)
                {
                    string id = commandArgs[2];
                    string birthDate = commandArgs[3];
                    IBuyer person = new Citizen(name, age, id, birthDate);
                    foodBought.Add(name, person);
                }
                else if (commandArgs.Length == 3)
                {
                    string group = commandArgs[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    foodBought.Add(name, rebel);
                }
            }
            string nameToBuyFood;
            int totalFood = 0;
            while ((nameToBuyFood = Console.ReadLine()) != "End")
            {
                foreach (var item in foodBought)
                {
                    if (item.Key == nameToBuyFood)
                    {
                        item.Value.BuyFood();                        
                    }
                }
            }
            foreach (var item in foodBought)
            {
                totalFood += item.Value.Food;
            }
            Console.WriteLine(totalFood);

            //List<IBirthDate> birthDatesInfo = new List<IBirthDate>();
            //string command = "";
            //while ((command = Console.ReadLine()) != "End")
            //{
            //    string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    string name = commandArgs[1];
            //    if (commandArgs.Length == 5)
            //    {
            //        int age = int.Parse(commandArgs[2]);
            //        string id = commandArgs[3];
            //        string birthDate = commandArgs[4];
            //        IBirthDate citizen = new Citizen(name, age, id, birthDate);
            //        birthDatesInfo.Add(citizen);
            //    }
            //    else if (commandArgs.Length == 3)
            //    {
            //        if (commandArgs[0] == "Pet")
            //        {
            //            string birthDate = commandArgs[2];
            //            IBirthDate pet = new Pet(name, birthDate);
            //            birthDatesInfo.Add(pet);
            //        }
            //    }
            //}
            //string birthDateEndsWith = Console.ReadLine();
            //foreach (var item in birthDatesInfo)
            //{
            //    if (item.BirthDate.EndsWith(birthDateEndsWith))
            //    {
            //        Console.Write(item.BirthDate);
            //        Console.WriteLine();

            //    }





            //List<IIdentifiable> idControl = new List<IIdentifiable>();
            //string command = "";
            //while ((command = Console.ReadLine()) != "End")
            //{
            //    string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    string nameOrModel = commandArgs[0];
            //    if (commandArgs.Length == 3)
            //    {
            //        int age = int.Parse(commandArgs[1]);
            //        string id = commandArgs[2];
            //        IIdentifiable citizen = new Citizen(nameOrModel, age, id);
            //        idControl.Add(citizen);
            //    }
            //    else if (commandArgs.Length == 2)
            //    {
            //        string id = commandArgs[1];
            //        IIdentifiable robot = new Robot(nameOrModel, id);
            //        idControl.Add(robot);
            //    }
            //}
            //string idEndsWith = Console.ReadLine();
            //foreach (var id in idControl)
            //{
            //    if (id.Id.EndsWith(idEndsWith))
            //    {
            //        Console.WriteLine(id.Id);
            //    }
        }
    }
}

