using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person()
        {

        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get => name; set => name = value; }

        public int Age
        {
            get => age;

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Negative age!");
                }
                age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
