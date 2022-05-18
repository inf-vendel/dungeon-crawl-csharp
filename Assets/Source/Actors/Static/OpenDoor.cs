using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class OpenDoor : Actor
    {
        
        public override int DefaultSpriteId => 825;
        public override string DefaultName => "OpenDoor";
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}