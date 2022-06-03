using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Fence : Actor
    {
        public override int DefaultSpriteId => 148;
        public override string DefaultName => "Fence";
        public override int Z => -1;
        public override bool Detectable => true;


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
                Ghost ghost = (Ghost)anotherActor;
                ghost.SPEED = 1.4f;
                return true;
            }
            return false;
        }
    }
}
