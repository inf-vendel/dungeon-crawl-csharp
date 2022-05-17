using System;
using System.Collections;
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
            int counter = 0;
            while (true)
            {
                // Use Player.CalculateDamage();
                this.Enemy.ApplyDamage(this.Player.Damage);
                UserInterface.Singleton.SetText($"{Enemy.DefaultName} {Enemy.Health.ToString()} HP left", UserInterface.TextPosition.BottomCenter);
                yield return new WaitForSeconds(0.5f);
                Player.ApplyDamage(Enemy.Damage);
                UserInterface.Singleton.SetText($"You have {Player.Health.ToString()} HP left", UserInterface.TextPosition.BottomCenter);
                counter++;

                if (Enemy.Health <= Player.Damage)
                {
                    Player.BattleWon();
                    break;
                }
                
                yield return new WaitForSeconds(0.5f);
            }
            
            
        }
    }
}