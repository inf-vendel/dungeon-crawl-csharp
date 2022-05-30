using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Info : Item
    {
        public override int DefaultSpriteId => 336;
        public override string DefaultName => "Info";

        public override bool Detectable => true;
        public override bool Pickable => false;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                StartCoroutine(Battle.Message($"Hey {player.Name}, welcome to the BackStreet"));
            }
            
            return true;
        }
    }
}