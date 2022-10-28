using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {   //Can only live in FreshwaterAquarium!

        private int initialSize = 3;
        private int eatAddToSize = 3;
        public FreshwaterFish(string name, string species, decimal price)
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
