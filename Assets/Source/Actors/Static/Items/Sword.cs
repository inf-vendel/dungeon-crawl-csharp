using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Sword : Item
    {
        public override int DefaultSpriteId => 227;
        public override string DefaultName => "Sword";

        public override bool Stackable => false;

        public override bool Detectable => true;
        public override bool Pickable => true;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

    }
}