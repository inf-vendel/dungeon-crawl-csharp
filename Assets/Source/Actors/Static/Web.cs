using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEditor;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Web : Actor
    {
        public override int DefaultSpriteId => 721;
        public override string DefaultName => "Web";
        public override bool Detectable => true;

        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            ActorManager.Singleton.DestroyActor(this);
            return true;
        }

    }
}
