using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Apple : Item
    {
        public override int DefaultSpriteId => 896;
        public override string DefaultName => "Apple";

        private int _id;
        public override bool  Stackable => true;

        public override bool Detectable => true;
        public override bool Pickable => true;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

    }
}