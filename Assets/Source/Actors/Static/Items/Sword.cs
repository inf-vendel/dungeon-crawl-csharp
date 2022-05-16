namespace DungeonCrawl.Actors.Static.Items
{
    public class Sword : Item
    {
        public override int DefaultSpriteId => 227;
        public override string DefaultName => "Sword";

        public override bool Detectable => false;
        public bool Pickable => true;

    }
}