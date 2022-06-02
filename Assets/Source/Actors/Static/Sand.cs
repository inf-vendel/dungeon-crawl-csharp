using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Sand : Actor
    {
        public override int DefaultSpriteId => 246;
        public override string DefaultName => "Sand";
        public override bool Detectable => false;
        

        public Sand()
        {
            IsColored = true;
            spriteColor = Color.yellow;
        }

    }
}
