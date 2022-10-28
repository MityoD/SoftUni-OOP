using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);
            string result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            decorations.Add(decoration);
            string result = string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            return result;

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);


            bool IsSuitable = false;

            if (fish.GetType().Name == nameof(FreshwaterFish) && aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                IsSuitable = true;
            }
            else if (fish.GetType().Name == nameof(SaltwaterFish) && aquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                IsSuitable = true;
            }

            string result;

            if (!IsSuitable)
            {
                result = OutputMessages.UnsuitableWater;
            }
            else
            {
                result = string.Format(OutputMessages.SuccessfullyAdded, fishType + " to " + aquariumName);
                aquarium.AddFish(fish);
            }
            return result;
        }



        public string CalculateValue(string aquariumName)
        {
            
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal fishPrice = aquarium.Fish.Select(x => x.Price).Sum();
            decimal decorationPrice = aquarium.Decorations.Select(x => x.Price).Sum();
            decimal totalPrice = fishPrice + decorationPrice;

            //List<IFish> fishPrice = aquarium.Fish as List<IFish>;
            //List<IDecoration> decorationPrice = aquarium.Decorations as List<IDecoration>;

            //foreach (var item in fishPrice)
            //{
            //    totalPrice += item.Price;
            //}
            //foreach (var item in decorationPrice)
            //{
            //    totalPrice += item.Price;
            //}

            string result = string.Format(OutputMessages.AquariumValue, aquariumName, $"{totalPrice:F2}");
            return result; 
            /*Parameters
	•	aquariumName - string
Functionality
Calculates the value of the Aquarium with the given name. It is calculated by the sum of all Fish’s and Decorations’ prices in the Aquarium.
Return a string in the following format:
	•	"The value of Aquarium {aquariumName} is {value}."
The value should be formatted to the 2nd decimal place!*/
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            string result = string.Format(OutputMessages.FishFed, aquarium.Fish.Count());
            return result;

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.Decorations.Add(decoration);
            decorations.Remove(decoration);
            string result = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
            
        }
    }
}
