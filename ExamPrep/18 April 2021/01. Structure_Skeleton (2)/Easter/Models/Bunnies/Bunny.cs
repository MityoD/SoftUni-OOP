using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        //private readonly List<IDye> dyes;
        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.Dyes = new List<IDye>();
        }
        
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }
        public int Energy 
        {
            get => energy; 
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                energy = value;
            }
        }

        public ICollection<IDye> Dyes { get; }

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
        }


    }
}
