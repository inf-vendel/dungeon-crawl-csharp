using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class StairUp : Stairs
    {
        public override int DefaultSpriteId => 289;
        public override string DefaultName => "StairUp";
 
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap(MapLoader._actualMap - 1);
            }

            return true;
        }
    }
}