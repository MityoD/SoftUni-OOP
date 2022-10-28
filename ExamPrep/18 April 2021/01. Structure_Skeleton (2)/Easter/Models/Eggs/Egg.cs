﻿using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                name = value;
            }
        }

        public int EnergyRequired
        {
            get => energyRequired;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                energyRequired = value;
            }
        }

        public void GetColored()
        {
            //The GetColored() method decreases the required energy of the egg by 10 units.
            //An egg's required energy should not drop below 0.
            this.EnergyRequired -= 10;
        }

        public bool IsDone() => this.EnergyRequired == 0;
        //The IsDone() method returns true if the energyRequired is equal to 0.

       
    }
}
