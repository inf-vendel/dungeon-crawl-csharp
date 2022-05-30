using Assets.Source.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Dog : Character
    {
        public override int DefaultSpriteId => 366;
        public override string DefaultName => "Dog";

        public override int Z => -1;

        protected override void OnDeath()
        
        {
            throw new System.NotImplementedException();
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                // Utilities.Message("Bark...");
                StartCoroutine(Utilities.Message("Bark...", UserInterface.TextPosition.BottomCenter));
            }

            return false;
        }
    }
}