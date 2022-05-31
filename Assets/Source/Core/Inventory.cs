using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DungeonCrawl.Actors.Static.Items;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Assets.Source.Core;
using DungeonCrawl;
using DungeonCrawl.Core;
using UnityEngine.UI;


namespace Assets.Source.Core
{
    public class Inventory : MonoBehaviour
    {
        protected int Capacity { get; private set; }
        public List<Item> Items;
        private int _selectedItem;
        // private GameObject _inventory;
        public bool _isOpen;

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
            _isOpen = false;
        }

        //private void Awake()
        //{
        //    _inventory = GameObject.Find("Inventory");
        //}

        public void HideDisplay()
        {
            // Utilities.Message(UserInterface.TextPosition.TopLeft, string.Empty, Color.white);
            ToggleInventoryVisibility();

        }
        public void Display()
        {
            // TODO selected item for botton left
            if (_isOpen)
            {
                ToUserInterface();
            }
        }

        public void ToggleInventoryVisibility()
        {
            _isOpen = !_isOpen;

            //var inventory = GameObject.Find("Inventory");
            //var color = inventory.GetComponent<SpriteRenderer>().color;
            //color.a = color.a == 0f ? 1f : 0f;
            //inventory.GetComponent<SpriteRenderer>().color = color;


            Renderer r = GameObject.Find("Inventory").GetComponent<Renderer>();
            Color newColor = r.material.color;
            newColor.a = 0;
            r.material.color = newColor;

            //if (GameObject.Find("Inventory").activeSelf)
            //{
            //    GameObject.Find("Inventory").active = false;
            //}
            //else
            //{
            //    GameObject.Find("Inventory").active = true;
            //}
            //_inventory.SetActive(!_inventory.activeSelf);


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

        public void ToUserInterface()
        {
            for (int i = 0; i < 5; i++)
            {
                UserInterface.Singleton.SetInventorySlot(i);
                UserInterface.Singleton.SetInventorySlotSelected(i, 0.8f,0.2f);
            }
            foreach (var item in Items)
            {
                UserInterface.Singleton.SetInventorySlot(Items.IndexOf(item), item.DefaultSpriteId, item.Quantity);
            }

            UserInterface.Singleton.SetInventorySlotSelected(_selectedItem, 1.2f,0.3f);
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