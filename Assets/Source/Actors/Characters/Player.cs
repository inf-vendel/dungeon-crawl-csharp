using System;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Inventory PlayerInventory { get; private set; }
        private const int DEFAULT_HEALTH = 30;
        private const int DEFAULT_DAMAGE = 5;
        public bool CanMove;
        public bool InventoryOpen;
        public bool InFight;
        
        public Player()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            CanMove = true;
            InventoryOpen = false;
            PlayerInventory = new Inventory();
        }
        //public Player(int health, int damage)
        //{
        //    SetHp(health);
        //    SetDamage(damage);
        //}

        protected override void OnUpdate(float deltaTime)
        {
            //if (!CanMove)
            //{
            //    return;
            //}

            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
            UserInterface.Singleton.SetText($"{Position.x}-{Position.y}", UserInterface.TextPosition.BottomRight);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Move right
                TryMove(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryOpen = !InventoryOpen;
                UserInterface.Singleton.SetText(InventoryOpen.ToString(), UserInterface.TextPosition.MiddleCenter);
                
            }

            if (InventoryOpen)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    PlayerInventory.SelectedItem = PlayerInventory.Items[0];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    PlayerInventory.SelectedItem = PlayerInventory.Items[1];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    PlayerInventory.SelectedItem = PlayerInventory.Items[2];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    PlayerInventory.SelectedItem = PlayerInventory.Items[3];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    PlayerInventory.SelectedItem = PlayerInventory.Items[4];
                }
            }
            Item item = ActorManager.Singleton.GetActorAt<Item>(Position);

            if (item is not null && item.Pickable)
            {
                UserInterface.Singleton.SetText($"Press E to pick up {item.name}", UserInterface.TextPosition.BottomRight);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Item copyObject = (Item)item.Clone();
                    PlayerInventory.AddItem(copyObject);
                    ActorManager.Singleton.DestroyActor(item);
                    PlayerInventory.Display();
                }
            }

            UserInterface.Singleton.SetText($"HP: {Health.ToString()}\nDamage: {Damage.ToString()}", UserInterface.TextPosition.BottomLeft);
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        // capacity, display, item selection, move/delete,
        // protected List<Item> Inventory;
    }
}