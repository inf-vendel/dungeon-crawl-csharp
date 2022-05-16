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
            UserInterface.Singleton.SetText(ToString(), UserInterface.TextPosition.TopLeft);
            
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
            for (int i = 0; i < Items.Count; i++)
            {
                sb.Append($"{i+1}. {Items[i].DefaultName}");
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}