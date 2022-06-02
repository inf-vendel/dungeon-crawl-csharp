using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class  Table2 : Actor
    {
        public override int DefaultSpriteId => 343;
        public override string DefaultName => "Table2";
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
