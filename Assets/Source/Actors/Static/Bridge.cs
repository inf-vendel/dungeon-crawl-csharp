using DungeonCrawl.Actors.Characters;
using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Bridge : Actor
    {
        public override int DefaultSpriteId => 291;
        public override int Z => -1;
        public override string DefaultName => "Brigde";
        public override bool Detectable => true;

        public override bool OnCollision(Actor anotherActor)
        {

            return true;
        }

    }
}
