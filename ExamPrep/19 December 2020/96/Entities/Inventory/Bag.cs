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
        private int capacity = 100;
        private readonly List<Item> items;
        protected Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get => capacity; set => capacity = value; }

        public int Load { get => items.Sum(x => x.Weight); }

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
