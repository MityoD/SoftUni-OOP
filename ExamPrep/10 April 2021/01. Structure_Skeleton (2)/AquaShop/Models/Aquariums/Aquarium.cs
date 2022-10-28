using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Select(x => x.Comfort).Sum(); // if empty? or field?

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish; // as readonly??


        public void AddDecoration(IDecoration decoration) => decorations.Add(decoration);
       

        public  void AddFish(IFish fish) //virtual to check if fish can live inside???
        {
            /*Adds a Fish in the Aquarium if there is capacity for it, otherwise throw an InvalidOperationException with message "Not enough capacity.";
*/          int fishesSize = this.Fish.Select(x => x.Size).Sum(); //
            if (fish.Size + fishesSize > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            //The Feed() method feeds all fish, calls their Eat() method.
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            /*Returns a string with information about the Aquarium in the format below. If the Aquarium doesn't have fish, print "none" instead.
"{aquariumName} ({aquariumType}):Fish: {fishName1}, {fishName2}, {fishName3} (…) / noneDecorations: {decorationsCount}Comfort: {aquariumComfort}"*/
            StringBuilder sb = new StringBuilder();
            string fishInfo = null;
            if (this.fish.Count == 0)
            {
                fishInfo = "none";
            }
            else
            {
                for (int i = 0; i < this.fish.Count; i++)
                {
                    if (i == this.fish.Count -1)
                    {
                        fishInfo += fish[i].Name;
                    }
                    else
                    {
                        fishInfo += fish[i].Name + ", ";
                    }
                }
                
            }
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishInfo}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();


        }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);
        
    }
}
