using System;
using Assets.Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character, IEnemy
    {

        private const int DEFAULT_HEALTH = 10;
        private const int DEFAULT_DAMAGE = 2;
        private const float SPEED = 6.0F;
        public bool IsAgressive { get; set; }
        public Skeleton()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = false;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.SetText(deltaTime.ToString(),UserInterface.TextPosition.MiddleCenter );
            if (deltaTime*1000 >= SPEED)
            {
                TryMove(Utilities.GetRandomDirection());
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
