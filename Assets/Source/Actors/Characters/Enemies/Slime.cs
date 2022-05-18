using System;
using Assets.Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Slime : Character, IEnemy
    {

        public override bool Detectable => true;


        private const int DEFAULT_HEALTH = 20;
        private const int DEFAULT_DAMAGE = 2;
        public bool IsAgressive { get; set; }

        public Slime()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = false;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            StartCoroutine(Battle.Loop((Player)anotherActor, this));
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