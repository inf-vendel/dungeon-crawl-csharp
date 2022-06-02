using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        private bool _isOpen = false;
        public override int DefaultSpriteId => _isOpen ? 437 : 435;
        public override string DefaultName => "Door";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                if (player.PlayerInventory.GetSelectedItem.DefaultName is "Key" && !_isOpen)
                {
                    player.PlayerInventory.RemoveItem(player.PlayerInventory.GetSelectedItem);
                    player.PlayerInventory.Display();
                    _isOpen = true;
                    SetSprite(DefaultSpriteId);
                }
            }
            return _isOpen;
        }
    }
}