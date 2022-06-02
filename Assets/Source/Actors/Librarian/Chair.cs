using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Chair : Actor
    {
        public override int DefaultSpriteId => 383;
        public override string DefaultName => "Chair";
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
