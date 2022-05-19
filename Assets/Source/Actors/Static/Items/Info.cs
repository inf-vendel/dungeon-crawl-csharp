﻿using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Info : Item
    {
        public override int DefaultSpriteId => 753;
        public override string DefaultName => "Info";

        public override bool Detectable => true;
        public override bool Pickable => false;

        public override bool OnCollision(Actor anotherActor)
        {
            StartCoroutine(Battle.Message("alma"));
            return true;
        }
    }
}