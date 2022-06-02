using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Assets.Source.Core;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Character, IEnemy
    {
        public override bool Detectable => true;

        public  float SPEED = .7f;
        private float _moveCounter;

        public float Vision { get; set; }

        private const int DEFAULT_HEALTH = 50;
        private const int DEFAULT_DAMAGE = 15;
        public bool IsAgressive { get; set; }
        public override int Z => -2;
        public int MapHeight { get; set; }
        public int MapWidth { get; set; }

        public Ghost()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = true;
            spriteAlpha = 1f;
            Vision = 50.0f;
        }

        private void Awake()
        {
            
        }

        protected override void OnUpdate(float deltaTime)
        {
            (int x, int y) playerPosition = player.Position;
            

            //Actor player = ActorManager.Singleton.GetPlayer();
            //(int x, int y) playerPosition = player.Position;

            _moveCounter -= deltaTime;

            Vector2 ghostVector = new Vector2(Position.x, Position.y);
            Vector2 playerVector = new Vector2(player.Position.x, player.Position.y);

            float distance = Vector2.Distance(ghostVector, playerVector);

            if (_moveCounter <= 0.0f)
            {
                SPEED = .7f;
                if (distance < Vision)
                {
                    if (Position.x < playerPosition.x)
                    {
                        TryMove(Direction.Right);
                    }
                    else if (Position.x > playerPosition.x)
                    {
                        TryMove(Direction.Left);
                    }
                   
                    if (Position.y < playerPosition.y)
                    {
                        TryMove(Direction.Up);
                    }
                    else if (Position.y > playerPosition.y)
                    {
                        TryMove(Direction.Down);
                    }
                }
                else
                {
                    TryMove(Utilities.GetRandomDirection(), MapWidth, MapHeight);
                }
                _moveCounter = SPEED;
            }


        }

        

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                StartCoroutine(Battle.Loop((Player)anotherActor, this));
                return false;
            }
            return true;
        }

        protected override void OnDeath()
        {
            IsAlive = false;
            // UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.BottomCenter);
            Debug.Log("huuuuuuuuu...");
            ActorManager.Singleton.DestroyActor(this);
        }

        public bool CanChangeSpeed { get; set; } = true;


        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghost";
    }

}
