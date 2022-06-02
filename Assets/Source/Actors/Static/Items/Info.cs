using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Info : Item
    {
        public override int DefaultSpriteId => 336;
        public override string DefaultName => "Info";
        public string Message { get; set; } = $"Hey player, welcome to the BackStreet";

        public override bool Detectable => true;
        public override bool Pickable => false;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                StartCoroutine(Utilities.Message(Message.Replace("player",player.Name), UserInterface.TextPosition.BottomCenter, Color.cyan, 5.0f));
            }
            
            return true;
        }
    }
}