using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class OpenDoor : ClosedDoor
    {
        public override int DefaultSpriteId => 437;
        public override string DefaultName => "OpenDoor";
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}