using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonsAndCodeWizards.Abstracts
{
    public abstract class Bag
    {
        private int capacity;
        private List<Item> items;

        protected Bag()
        {
            this.items = new List<Item>();
            this.Capacity = 100;
        }

        protected Bag(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }
        
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public double Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            var currentLoad = this.Load + item.Weight;
            if (currentLoad > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            var existingItem = this.items.Find(i => i.GetType().Name == name);
            if (existingItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
                //throw new ArgumentException($"No item with name {name} in bag!");
            }
            this.items.Remove(existingItem);
            return existingItem;
        }
    }
}
