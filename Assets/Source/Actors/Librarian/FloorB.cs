using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class FloorB : Actor
    {
        public override int DefaultSpriteId => 758;
        public override string DefaultName => "BFloor";
        public override bool Detectable => false;
        

        public FloorB()
        {
            // IsColored = true;
            // spriteColor = Color.red;
        }

    }
}
