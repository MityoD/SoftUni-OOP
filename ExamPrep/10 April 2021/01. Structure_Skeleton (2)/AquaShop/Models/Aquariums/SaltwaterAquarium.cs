using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    class SaltwaterAquarium : Aquarium
    {
        private const int defCapacity = 25;
        public SaltwaterAquarium(string name) : base(name, defCapacity)
        {
        }
        //public override void AddFish(IFish fish)
        //{
        //    if (fish.GetType().Name == nameof(SaltwaterFish))
        //    {
        //        base.AddFish(fish);
        //    }
        //    else
        //    {
        //        throw new ArgumentException(OutputMessages.UnsuitableWater);
        //    }
        //}
    }
}
