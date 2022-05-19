using Assets.Source.Core;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; private set; } = 100;
        public virtual int Damage { get; private set; } = 10;
        protected int Defense { get; set; } = 1;

        public bool IsAlive { get; set; } = true;

        

        public void ApplyDamage(int damage)
        {
            Health -= damage - Defense;

            if (Health <= 0)
            {
                // Die
                OnDeath();
                UserInterface.Singleton.SetText(string.Empty,UserInterface.TextPosition.BottomCenter);
                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected void SetHp(int health)
        {
            Health = health;
        }


        protected virtual void SetDamage(int damage)
        {
            Damage = damage;
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

    }
}
