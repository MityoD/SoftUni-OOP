using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {   //Can only live in SaltwaterAquarium!

        private int initialSize = 5;
        private int eatAddToSize = 2;
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
        }
        public override int Size => initialSize;

        public override void Eat()
        {
            this.Size += eatAddToSize;
        }
    }
}
