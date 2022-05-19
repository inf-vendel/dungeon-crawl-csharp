using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Boss : Character, IEnemy
    {
        public override bool Detectable => true;

        public const float SPEED = 0.7f;
        private float _moveCounter;


        public float Vision { get; set; }

        private const int DEFAULT_HEALTH = 120;
        private const int DEFAULT_DAMAGE = 8;
        public bool IsAgressive { get; set; }

        public Boss()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = true;
            IsColored = true;
            spriteColor = Color.red;
            Vision = 9.0f;
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
            Debug.Log("You are the big boss now...");

        }

        public override int DefaultSpriteId => 27;
        public override string DefaultName => "Boss";
    }

}
