using System;
using System.Collections;
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

        IEnumerator battle()
        {
            int counter = 0;
            while (counter < 10)
            {
                UserInterface.Singleton.SetText(counter.ToString() + " secs", UserInterface.TextPosition.BottomCenter);
                counter++;
                yield return new WaitForSeconds(0.5f);

            }

        }
        public override bool OnCollision(Actor anotherActor)
        {
            StartCoroutine(battle());
            if (anotherActor is Player)
            {
                return false;
            }
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
