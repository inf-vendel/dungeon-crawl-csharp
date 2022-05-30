using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class ClosedDoor : Actor
    {
        public override int DefaultSpriteId => 435;
        public override string DefaultName => "Door";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                if (player.PlayerInventory.GetSelectedItem is Key)
                {
                    player.PlayerInventory.RemoveItem(player.PlayerInventory.GetSelectedItem);
                    //player.PlayerInventory.SelectedItem = 0;
                    player.PlayerInventory.Display();

                    ActorManager.Singleton.Spawn<OpenDoor>(this.Position);
                    ActorManager.Singleton.DestroyActor(this);
                }
            }
            return false;
        }
    }
}