using System;
using Assets.Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Character, IEnemy
    {
        public override bool Detectable => true;

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
            throw new NotImplementedException();

        }

        public override bool OnCollision(Actor anotherActor)
        {
            new Battle();
            //if (anotherActor is Player)
            //{
            //    Player player = (Player)anotherActor;
            //    this.ApplyDamage(player.Damage);
            //    player.ApplyDamage(Damage);
            //    return false;
            //}
            return true;

        }

        protected override void OnDeath()
        {
            Debug.Log("huuuuuuuuu...");
        }

        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghost";
    }

}
