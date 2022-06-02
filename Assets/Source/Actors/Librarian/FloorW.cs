using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class FloorW : Actor
    {
        public override int DefaultSpriteId => 710;
        public override string DefaultName => "FloorW";
        public override bool Detectable => false;
        

        public FloorW()
        {
            // IsColored = true;
            // spriteColor = Color.red;
        }

    }
}
