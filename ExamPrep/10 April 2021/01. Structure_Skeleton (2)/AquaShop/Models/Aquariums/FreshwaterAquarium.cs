using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int defCapacity = 50;
        public FreshwaterAquarium(string name) : base(name, defCapacity)
        {
        }
        //public override void AddFish(IFish fish)
        //{
        //    if (fish.GetType().Name == nameof(FreshwaterFish))
        //    {
        //        base.AddFish(fish);
        //    }
        //    else
        //    {
        //       throw new ArgumentException(OutputMessages.UnsuitableWater);
        //    }
        //}
    }
}
