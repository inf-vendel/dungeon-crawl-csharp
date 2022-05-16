using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonCrawl.Actors.Static.Items;

namespace Assets.Source.Core
{
    public class Inventory
    {
        protected int Capacity { get; private set; }
        public List<Item> Items;

        public Inventory()
        {
            Items = new();

        }
        public void Display()
        {
            UserInterface.Singleton.SetText(Items.Count.ToString(), UserInterface.TextPosition.TopLeft);

        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public Item SelectItem(Item item)
        {
            //return Items.Select(x => x == item);
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (Item item in Items)
            {
                sb.Append(item.name);
            }

            return sb.ToString();
        }
    }
}