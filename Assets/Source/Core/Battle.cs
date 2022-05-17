using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Core
{
    public class Battle
    {
        public Player Player;
        public Character Enemy;


        public Battle(Player player, Character enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        public IEnumerator Loop()
        {
            List<Character> characters = new List<Character> {Player, Enemy};
            this.Enemy.ApplyDamage(this.Player.Damage);
            yield return new WaitForSeconds(0.5f);
            Enemy.GetMessage();
            yield return new WaitForSeconds(0.5f);
            Player.ApplyDamage(Enemy.Damage);
            UserInterface.Singleton.SetText($"You have {Player.Health.ToString()} HP left",
                        UserInterface.TextPosition.BottomCenter);
            yield return new WaitForSeconds(0.5f);
            UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.BottomCenter);
        }
    }
}


    
