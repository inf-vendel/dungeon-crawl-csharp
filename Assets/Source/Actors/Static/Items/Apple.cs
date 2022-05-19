using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Apple : Item
    {
        private int HealAmount = 5;
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

        public override void Action()
        {
            Player player = (Player) ActorManager.Singleton.GetPlayer();
            player.Heal(HealAmount);
            player.PlayerInventory.RemoveItem(this);
        }
    }
}