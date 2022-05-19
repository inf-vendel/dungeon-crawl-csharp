namespace DungeonCrawl.Actors.Static.Items
{
    public class GoldenKey : Item
    {
        public override int DefaultSpriteId => 561;
        public override string DefaultName => "GoldenKey";

        private int _id;

        public override bool Stackable => true;

        public override bool Detectable => true;
        public override bool Pickable => true;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}