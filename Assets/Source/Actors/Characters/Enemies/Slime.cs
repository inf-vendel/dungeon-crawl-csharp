using System;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Slime : Character, IEnemy
    {

        public override bool Detectable => true;


        private const int DEFAULT_HEALTH = 20;
        private const int DEFAULT_DAMAGE = 1;
        public bool IsAgressive { get; set; }

        public Slime()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = false;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                this.ApplyDamage(player.Damage);
                player.ApplyDamage(Damage);
            }
            return false;
        }

        protected override void OnUpdate(float deltaTime)
        {
            throw new NotImplementedException();

        }

        protected override void OnDeath()
        {
            Debug.Log("Blugy...blugy...");
        }

        public override int DefaultSpriteId => 453;
        public override string DefaultName => "Slime";
    }
}