using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{

    public abstract class Bag : IBag
    {
        //private const int CapacityDefaultValue = 100;
        private readonly List<Item> items;
        protected Bag(int capacity) // CapacityDefaultValue
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get ; set; }

        public int Load => items.Sum(x => x.Weight); //{ items.Select(x => x.Weight).Sum(); }

        public IReadOnlyCollection<Item> Items => items as IReadOnlyList<Item>;

        public void AddItem(Item item)
        {  
            if (this.Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
           
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);

            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
	    
            else if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(item);
            return item;
        }
    }
}
