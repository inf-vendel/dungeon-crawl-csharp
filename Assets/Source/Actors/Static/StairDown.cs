using System.Drawing;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class StairDown : Actor
    {
        public override int DefaultSpriteId => 290;
        public override string DefaultName => "StairDown";
        public override int Z => -1;
        public override bool Detectable => true;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {

                Player player = (Player)anotherActor;
                if (player.PlayerInventory.HasItem("GoldenKey"))
                {
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.LoadMap(MapLoader._actualMap + 1);
                    
                }
                else
                {
                    UserInterface.Singleton.SetText("You need a golden key to go to the next level", UserInterface.TextPosition.BottomRight);
                }

            }

            return false;
        }
        }
}