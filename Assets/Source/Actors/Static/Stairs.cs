﻿using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Stairs : Actor
    {
        public override int DefaultSpriteId => 290;
        public override string DefaultName => "StairDown";
        public override int Z => -1;
        public override bool Detectable => true;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap(2);
            }
            return true;
        }

       
    }
}