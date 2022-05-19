using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Wall : Actor
    {
        public override int DefaultSpriteId => 145;
        public override string DefaultName => "Wall";
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
