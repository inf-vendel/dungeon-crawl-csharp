using System;
using System.Threading;
using Assets.Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character, IEnemy
    {

        public override bool Detectable => true;

        public const float SPEED = 1.0f;
        private float _moveCounter;

        private const int DEFAULT_HEALTH = 10;
        private const int DEFAULT_DAMAGE = 2;
        public bool IsAgressive { get; set; }

        public Skeleton()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = false;
            _moveCounter = SPEED;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            StartCoroutine(Battle.Loop((Player)anotherActor, this));
            return false;
        }

        protected override void OnUpdate(float deltaTime)
        {
            _moveCounter -= deltaTime;

            if (_moveCounter <= 0.0f)
            {
                TryMove(Utilities.GetRandomDirection());
                _moveCounter = SPEED;
            }
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}
