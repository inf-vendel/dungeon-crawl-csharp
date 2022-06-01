using DungeonCrawl.Actors.Characters;
using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Water : Actor
    {
        public override int DefaultSpriteId => 247;
        public override string DefaultName => "Water";
        public override bool Detectable => true;

        public override int Z => 1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                return false;
            }
            return true;
        }

    }
}
