using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static.Items;

namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        
        public override int DefaultSpriteId => 435;
        public override string DefaultName => "Door";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                if (player.PlayerInventory.SelectedItem is Key)
                {
                    player.PlayerInventory.RemoveItem(player.PlayerInventory.SelectedItem);
                    player.PlayerInventory.SelectedItem = null;
                    player.PlayerInventory.Display();
                    return true;
                }
            }
            return false;
        }
    }
}