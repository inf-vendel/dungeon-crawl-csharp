using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; private set; } = 100;
        public int Damage { get; private set; } = 10;
        protected int Defense { get; set; } = 1;


        public void ApplyDamage(int damage)
        {
            Health -= damage - Defense;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected void SetHp(int health)
        {
            Health = health;
        }

        protected void SetDamage(int damage)
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
