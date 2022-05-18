using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonCrawl.Actors.Static.Items;
using UnityEngine;

namespace Assets.Source.Core
{
    public class Inventory
    {
        protected int Capacity { get; private set; }
        public List<Item> Items;
        private int _selectedItem;
        public int SelectedItem {
            get => _selectedItem;
            set
            {
                if (value < Items.Count)
                {
                    _selectedItem = value;
                }
                
            }

        }
        public Item GetSelectedItem => Items[_selectedItem];

        public Inventory()
        {
            Items = new();

        }

        public void HideDisplay()
        {
            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopLeft);
        }
        public void Display()
        {
            UserInterface.Singleton.SetText(ToString(), UserInterface.TextPosition.TopLeft);
            UserInterface.Singleton.SetText("Selected: " + GetSelectedItem.DefaultName, UserInterface.TextPosition.TopCenter, Color.cyan);


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