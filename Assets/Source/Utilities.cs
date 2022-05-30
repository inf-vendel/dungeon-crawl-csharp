using System;
using System.Collections;
using Assets.Source.Core;
using UnityEngine;
using Random = System.Random;

namespace DungeonCrawl
{
    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class Utilities
    {
        public static IEnumerator Message(string text, UserInterface.TextPosition position, float time = 1.0f)
        {
            UserInterface.Singleton.SetText(text, position);
            yield return new WaitForSeconds(1.0f);
            UserInterface.Singleton.SetText(String.Empty, position);
        }


        public static void Message(UserInterface.TextPosition position,string text, Color color)
        {
            UserInterface.Singleton.SetText(text, position, color);
        }

        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return (0, 1);
                case Direction.Down:
                    return (0, -1);
                case Direction.Left:
                    return (-1, 0);
                case Direction.Right:
                    return (1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }

        public static Direction GetRandomDirection()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
            return randomDir;
        }

        public static void PlaySound(string tag)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag(tag);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
