using System;
using DungeonCrawl.Actors.Characters;
using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Fire : Actor
    {
        public override int DefaultSpriteId => 494;
        public override string DefaultName => "Fire";
        public override bool Detectable => true;
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player) anotherActor;
                player.ApplyDamage(2);
            }
            return true;
        }

    }
}
