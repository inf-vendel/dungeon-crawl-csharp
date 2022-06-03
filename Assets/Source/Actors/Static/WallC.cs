using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class WallC : Actor
    {
        public override int DefaultSpriteId => 629;
        public override string DefaultName => "WallC";
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
