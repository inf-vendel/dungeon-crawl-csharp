﻿using System;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private Inventory _inventory = new Inventory();
        private const int DEFAULT_HEALTH = 30;
        private const int DEFAULT_DAMAGE = 5;
        public Player()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
        }
        //public Player(int health, int damage)
        //{
        //    SetHp(health);
        //    SetDamage(damage);
        //}

        protected override void OnUpdate(float deltaTime)
        {

            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);

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



            Item item = ActorManager.Singleton.GetActorAt<Item>(Position);

            if (item is not null && item.Pickable)
            {
                UserInterface.Singleton.SetText($"Press E to pick up {item.name}", UserInterface.TextPosition.BottomRight);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Item copyObject = (Item)item.Clone();
                    _inventory.AddItem(copyObject);
                    ActorManager.Singleton.DestroyActor(item);
                    _inventory.Display();
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