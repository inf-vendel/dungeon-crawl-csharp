using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class  Bed : Actor
    {
        public override int DefaultSpriteId => 388;
        public override string DefaultName => "Bed";
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
