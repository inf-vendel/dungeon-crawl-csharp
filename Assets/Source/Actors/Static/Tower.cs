using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Tower : Actor
    {
        public override int DefaultSpriteId => 623;
        public override string DefaultName => "Tower";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                if (player.Name == "Vendel" || player.Name == "Zsolt" || player.Name == "Viktor")
                {
                    return true;
                }
            }
            if (anotherActor is Ghost)
            {
                return true;
            }
            return false;
        }
    }
}
