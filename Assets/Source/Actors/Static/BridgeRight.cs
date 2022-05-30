using DungeonCrawl.Actors.Characters;
using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class BridgeRight : Actor
    {
        public override int DefaultSpriteId => 731;

        public override int Z => -1;
        public override string DefaultName => "BrigdeRight";
        public override bool Detectable => true;

        public override bool OnCollision(Actor anotherActor)
        {

            return true;
        }

    }
}
