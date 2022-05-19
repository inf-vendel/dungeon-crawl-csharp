using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DungeonCrawl.Actors.Static.Items;
using UnityEngine;
using Debug = UnityEngine.Debug;

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

        public Item GetSelectedItem
        {
            get
            {
                if (Items.ElementAtOrDefault(_selectedItem) != null)
                {
                    return Items[_selectedItem];
                }
                else
                {
                    return new NullItem();
                }
            }
        } 

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
            foreach (Item i in Items)
            {

                if (i.DefaultName.Equals(item.DefaultName) && item.Stackable)
                {
                    Debug.Log("stackable");
                    i.Quantity++;
                    return;
                }
            }
            Items.Add(item);
 
        }

        public bool HasItem(string name)
        {
            foreach (Item i in Items)
            {
                if (i.DefaultName == name)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasItem(Item item)
        {
            foreach (Item i in Items)
            {
                if (i == item)
                {
                    return true;
                }
            }

            return false;
        }
        public void RemoveItem(Item item)
        {
            foreach (var i in Items)
            {
                if (i.DefaultName.Equals(item.DefaultName) && item.Stackable)
                {
                    if (i.Quantity > 1)
                    {
                        i.Quantity--;
                        return;
                    }
                }
            }
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

            //Dictionary<string, int> dict = new();

            int counter = 1;
            foreach (Item item in Items)
            {
                result.Append($"{counter}. {item.DefaultName} {item.Quantity}");
                result.Append(Environment.NewLine);
                counter++;
            }

            

            //foreach (KeyValuePair<string, int> item in dict)
            //{
            //    result.Append($"{counter}. {item.Key} ({item.Value})");
            //    result.Append(Environment.NewLine);
            //    counter++;
            

            return result.ToString();
        }
    }
}