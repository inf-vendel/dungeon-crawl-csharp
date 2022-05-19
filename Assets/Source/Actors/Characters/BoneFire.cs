using Assets.Source.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class BoneFire : Character
    {
        public override int DefaultSpriteId => 493;
        public override string DefaultName => "BoneFire";

        public override int Z => -1;

        protected override void OnDeath()
        
        {
            throw new System.NotImplementedException();
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                StartCoroutine(Battle.Message("You feel more comfortable"));
            }

            return false;
        }
    }
}