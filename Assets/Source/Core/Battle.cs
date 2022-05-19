using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Core
{
    public static class Battle
    {
        

        static Battle()
        {
        }

        public static IEnumerator Message(string text)
        {
            UserInterface.Singleton.SetText(text, UserInterface.TextPosition.BottomCenter);
            yield return new WaitForSeconds(1.0f);
            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomCenter);
        }

        public static IEnumerator Loop(Player Player, Character Enemy)
        {
            Player.CanMove = false;
            if ((Enemy.Health - Player.Damage) <= 0)
            {
                UserInterface.Singleton.SetText("You win!", UserInterface.TextPosition.BottomCenter);
                yield return new WaitForSeconds(1.0f);
                UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.BottomCenter);
            }
            else
            {
                UserInterface.Singleton.SetText($"{Enemy.DefaultName} {(Enemy.Health - Player.Damage).ToString()} HP left",
                    UserInterface.TextPosition.BottomCenter);
                yield return new WaitForSeconds(1.0f);
                UserInterface.Singleton.SetText($"You have {(Player.Health + 1 - Enemy.Damage).ToString()} HP left",
                    UserInterface.TextPosition.BottomCenter);
            }

            Player.ApplyDamage(Enemy.Damage);

            Player.CanMove = true;

            Enemy.ApplyDamage(Player.Damage);

            yield return new WaitForSeconds(1.0f);

            UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.BottomCenter);

        }
    }
}