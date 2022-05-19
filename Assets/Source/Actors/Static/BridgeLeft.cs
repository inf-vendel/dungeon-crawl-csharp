using DungeonCrawl.Actors.Characters;
using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class BridgeLeft : Actor
    {
        public override int DefaultSpriteId => 729;
        public override int Z => -1;
        public override string DefaultName => "BrigdeLeft";
        public override bool Detectable => true;

        public override bool OnCollision(Actor anotherActor)
        {

            return true;
        }

    }
}
