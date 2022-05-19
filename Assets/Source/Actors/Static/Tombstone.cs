using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class  Tombstone : Actor
    {
        public override int DefaultSpriteId => 672;
        public override string DefaultName => "Tombstone";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Ghost)
            {
                return true;
            }
            return false;
        }
    }
}
