using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class ChairSmall : Actor
    {
        public override int DefaultSpriteId => 384;
        public override string DefaultName => "ChairSmall";
        public override int Z => -1;

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
