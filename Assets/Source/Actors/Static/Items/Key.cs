using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Key : Item
    {
        public override int DefaultSpriteId => 561;
        public override string DefaultName => "Key";

        private int _id;
        public override bool Detectable => true;
        public override bool Pickable => true;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        public bool CanOpen(int doorId)
        {
            return _id == doorId;
        }
    }
}