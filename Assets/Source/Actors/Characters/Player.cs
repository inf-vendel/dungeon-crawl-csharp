using System;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private string _baseName = "JustAGamer";
        public Inventory PlayerInventory { get; private set; }
        private int MAX_HEALTH = 30;
        private const int DEFAULT_HEALTH = 30;
        private const int DEFAULT_DAMAGE = 5;
        public bool CanMove;
        public bool InFight;
        public string Name;
        private int _damage;
        private Random r = new Random();

        public Player()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            CanMove = true;
            PlayerInventory = new Inventory();
            if (SetPlayerName.PlayerName == "")
            {
                Name = _baseName;
            }
            else
            {
                Name = SetPlayerName.PlayerName;
            }
            
        }
        //public Player(int health, int damage)
        //{
        //    SetHp(health);
        //    SetDamage(damage);
        //}
        public override int Damage
        {
            get
            {
                int bonusdamage = 0;
                foreach (var item in PlayerInventory.Items)
                {
                    if (item is Sword)
                    {
                        Sword sword = (Sword)item;
                        bonusdamage += sword.Damage;
                    }
                }

                return _damage + bonusdamage;
            }
        }

        protected override void SetDamage(int damage)
        {
            _damage = damage;
        }

        protected override void OnUpdate(float deltaTime)
        {
            float hpScale = (float) Health / MAX_HEALTH;
            this.gameObject.transform.Find("hpbar").transform.localScale = new Vector3(hpScale, 0.9f+hpScale/5, 1);
            //var top = ;
            //top.;

            if (!CanMove)
            {
                return;
            }
            //UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Move up
                TryMove(Direction.Up);
                ChangeSpriteDirection(Direction.Up);
                if (r.Next(100) <=10)
                {
                    Utilities.PlaySound("Footstep");
                }
                
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ChangeSpriteDirection(Direction.Down);
                // Move down
                if (r.Next(100) <= 10)
                {
                    Utilities.PlaySound("Footstep");
                }
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeSpriteDirection(Direction.Left);
                // Move left
                if (r.Next(100) <= 10)
                {
                    Utilities.PlaySound("Footstep");
                }
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeSpriteDirection(Direction.Right); 
                // Move right
                if (r.Next(100) <= 10)
                {
                    Utilities.PlaySound("Footstep");
                }
                TryMove(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerInventory.GetSelectedItem.Action();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                PlayerInventory.ToggleInventoryVisibility();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Utilities.Message( UserInterface.TextPosition.BottomCenter, string.Empty);
            }


            if (PlayerInventory._isOpen)
            {

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    PlayerInventory.SelectedItem = 0;
                    PlayerInventory.Display();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    PlayerInventory.SelectedItem = 1;
                    PlayerInventory.Display();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    PlayerInventory.SelectedItem = 2;
                    PlayerInventory.Display();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    PlayerInventory.SelectedItem = 3;
                    PlayerInventory.Display();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    PlayerInventory.SelectedItem = 4;
                    PlayerInventory.Display();
                }
            }
            Item item = ActorManager.Singleton.GetActorAt<Item>(Position);

            if (item is not null && item.Pickable)
            {
                StartCoroutine(Utilities.Message($"Press E to pick up {item.name}",
                    UserInterface.TextPosition.BottomRight));
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Item copyObject = (Item)item.Clone();
                    PlayerInventory.AddItem(copyObject);
                    ActorManager.Singleton.DestroyActor(item);
                    PlayerInventory.Display();
                }
            }
            Utilities.Message(UserInterface.TextPosition.BottomLeft,$"HP: {Health.ToString()}\nDamage: {Damage.ToString()}", Color.white);

        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            
            Debug.Log("Oh no, I'm dead!");
            SceneManager.LoadScene("GameOver");
        }

        public void Heal(int heal)
        {
            SetHp(Health+heal);
            if (Health > MAX_HEALTH)
            {
                SetHp(MAX_HEALTH);
            }
        }

        public List<string> TopSprite { get; set; }
        public List<string> BottomSprite { get; set; }

        public override void SetSprite(int id)
        {
        }


        public override int DefaultSpriteId => 27;

        public override int Z => -2;

        public override string DefaultName => "Player";

        // capacity, display, item selection, move/delete,
        // protected List<Item> Inventory;

        public void ChangeSpriteDirection(Direction direction)
        {
            this.gameObject.transform.Find("topimage")
                .GetComponent<SpriteRenderer>().sprite = ActorManager.Singleton.GetSprite((int)direction, "chars");
            GetComponent<SpriteRenderer>().sprite = ActorManager.Singleton.GetSprite((int)direction+4, "chars");
        }
    }
}