using DungeonCrawl.Actors.Characters;
using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class FloorForCollision : Actor
    {
        public override int DefaultSpriteId => 247;
        public override string DefaultName => "FloorForCollision";
        public override bool Detectable => true;
        

        public FloorForCollision()
        {
            IsColored = true;
            spriteColor = Color.red;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                if (player.Name == "Vendel" || player.Name == "Zsolt" || player.Name == "Viktor")
                {
                    return true;
                }
            }
            if (anotherActor is Ghost)
            {
                return true;
            }
            return false;
        }

    }
}
