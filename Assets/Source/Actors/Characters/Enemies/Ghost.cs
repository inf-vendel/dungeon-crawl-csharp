using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Character, IEnemy
    {
        public override bool Detectable => true;

        public const float SPEED = 1.0f;
        private float _moveCounter;

        public float Vision { get; set; }

        private const int DEFAULT_HEALTH = 12;
        private const int DEFAULT_DAMAGE = 3;
        public bool IsAgressive { get; set; }

        public Ghost()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = true;
            spriteAlpha = 0.5f;
            Vision = 5.0f;
        }

        protected override void OnUpdate(float deltaTime)
        {
            Actor player = ActorManager.Singleton.GetPlayer();
            (int x, int y) playerPosition = player.Position;

            _moveCounter -= deltaTime;

            Vector2 ghostVector = new Vector2(Position.x, Position.y);
            Vector2 playerVector = new Vector2(player.Position.x, player.Position.y);

            float distance = Vector2.Distance(ghostVector, playerVector);

            if (_moveCounter <= 0.0f)
            {
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
                    TryMove(Utilities.GetRandomDirection());
                }
                _moveCounter = SPEED;
            }


        }

        public override bool OnCollision(Actor anotherActor)
        { 
            StartCoroutine(Battle.Loop((Player)anotherActor, this));
            if (anotherActor is Player)
            {
                return false;
            }
            return true;
        }

        protected override void OnDeath()
        {
            IsAlive = false;
            UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.BottomCenter);
            Debug.Log("huuuuuuuuu...");
        }

        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghost";
    }

}
