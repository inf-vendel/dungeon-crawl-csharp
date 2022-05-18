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
        public Item SelectedItem { get; set; }
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
            StringBuilder result = new();
            result.Append("Inventory:\n");

            Dictionary<string, int> dict = new();

            foreach (Item item in Items)
            {
                if (dict.ContainsKey(item.DefaultName))
                    dict[item.DefaultName]++;
                else
                    dict.Add(item.DefaultName, 1);
            }

            int counter = 1;

            foreach (KeyValuePair<string, int> item in dict)
            {
                result.Append($"{counter}. {item.Key} ({item.Value})");
                result.Append(Environment.NewLine);
                counter++;
            }

            return result.ToString();
        }
    }
}