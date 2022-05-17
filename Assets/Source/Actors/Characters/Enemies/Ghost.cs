using System;
using System.Collections;
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

        private const int DEFAULT_HEALTH = 12;
        private const int DEFAULT_DAMAGE = 3;
        public bool IsAgressive { get; set; }
        public Ghost()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = true;
            spriteAlpha = 0.5f;
        }

        protected override void OnUpdate(float deltaTime)
        {
            // szellem látómezője
            Actor player = ActorManager.Singleton.GetPlayer();
            (int x, int y) playerPosition = player.Position;

            _moveCounter -= deltaTime;

            if (_moveCounter <= 0.0f)
            {
                if (Position.x < playerPosition.x)
                {
                    TryMove(Direction.Right);
                }
                if (Position.x > playerPosition.x)
                {
                    TryMove(Direction.Left);
                }
                if (Position.y < playerPosition.y)
                {
                    TryMove(Direction.Up);
                }
                if (Position.y > playerPosition.y)
                {
                    TryMove(Direction.Down);
                }
                _moveCounter = SPEED;
            }

        }

        public override bool OnCollision(Actor anotherActor)
        {
            var battle = new Battle((Player)anotherActor, this);
            StartCoroutine(battle.Loop());
            if (anotherActor is Player)
            {
                return false;
            }
            return true;

        }

        protected override void OnDeath()
        {
            UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.BottomCenter);
            Debug.Log("huuuuuuuuu...");
        }

        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghost";
    }

}
