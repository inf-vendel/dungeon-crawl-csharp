using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class  Table1 : Actor
    {
        public override int DefaultSpriteId => 337;
        public override string DefaultName => "Table1";
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
