using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command = "";
            while ((command = Console.ReadLine()) != "Beast!")
            {
                //try
                //{
                string[] input = Console.ReadLine().Split();
                //if (input.Length != 3)
                //{
                //    throw new Exception("Invalid input!");
                //}
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];
                //Animal newAnimal = null;
                if (command == "Cat")
                {
                    Cat newAnimal = new Cat(name, age, gender);
                    animals.Add(newAnimal);
                }
                else if (command == "Dog")
                {
                    Dog newAnimal = new Dog(name, age, gender);
                    animals.Add(newAnimal);
                }
                else if (command == "Frog")
                {
                    Frog newAnimal = new Frog(name, age, gender);
                    animals.Add(newAnimal);
                }
                else if (command == "Tomcat")
                {
                    Tomcat newAnimal = new Tomcat(name, age, gender);
                    animals.Add(newAnimal);
                }
                else if (command == "Kitten")
                {
                    Kitten newAnimal = new Kitten(name, age, gender);
                    animals.Add(newAnimal);
                }
                //else
                //{
                //    throw new Exception("Invalid input!");
                //}

                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

            }
            foreach (var item in animals)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                Console.WriteLine(item.ProduceSound());
            }
        }
    }
}
