using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal()
        {

        }
        public Animal(string name, int age, string gender)
        {

            this.Name = name;
            this.Age = age;
            this.Gender = gender;

        }

        public string Name
        {
            get => name;

            private set
            {
                //if (!Regex.Match(value, "[A-Z][a-z]{1,}").Success)
                //{
                //    throw new Exception("Invalid input!");
                //}
                name = value;
            }
        }

        public int Age
        {
            get => age;

            private set
            {
                //if (value < 0)
                //{
                //    throw new Exception("Invalid input!");                  
                //}
                age = value;
            }
        }

        public string Gender
        {
            get => gender;

            private set
            {
                //if (value != "Female" && value != "Male")
                //{
                //    throw new Exception("Invalid input!");
                //}
                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
