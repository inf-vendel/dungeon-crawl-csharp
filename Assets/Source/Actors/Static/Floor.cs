using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Floor : Actor
    {
        public override int DefaultSpriteId => 247;
        public override string DefaultName => "Floor";
        public override bool Detectable => false;

        public Floor()
        {
            spriteColor = Color.red;
        }

    }
}
