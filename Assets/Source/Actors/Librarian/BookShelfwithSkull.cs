using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class  BookShelfwithSkull : Actor
    {
        public override int DefaultSpriteId => 339;
        public override string DefaultName => "BookShelfwithSkull";
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
