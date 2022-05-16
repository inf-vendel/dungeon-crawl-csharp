namespace DungeonCrawl.Actors.Static.Items
{
    public class Item : Actor
    {   
        public override int DefaultSpriteId => 1;
        public override string DefaultName => "Item";

        public override bool Detectable => false;

        public virtual bool Pickable => false;
    }
}