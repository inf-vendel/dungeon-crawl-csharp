using Assets.Source.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Duck : Character
    {
        public override int DefaultSpriteId => 360;
        public override string DefaultName => "Duck";

        public override int Z => -1;

        protected override void OnDeath()
        
        {
            throw new System.NotImplementedException();
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                StartCoroutine(Battle.Message("Quack"));
            }

            return false;
        }
    }
}