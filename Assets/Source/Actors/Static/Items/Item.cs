namespace DungeonCrawl.Actors.Static.Items
{
    public class Item : Actor
    {   
        public override int DefaultSpriteId => 1;
        public override string DefaultName => "Item";

        public override bool Detectable => false;

        public virtual bool Stackable { get; }

        public int Quantity = 1;
        public virtual bool Pickable => false;

        public override int Z => -1;

        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}