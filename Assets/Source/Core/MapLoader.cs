using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Actors.Static.Items;
using System;
using System.Text.RegularExpressions;
using DungeonCrawl.Actors;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {

        public static int _width { get; set; }
        public static int _height { get; set; }
        public static int _actualMap { get; set; }

        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="id"></param>
        public static void LoadMap(int id)
        {

            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{id}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);
            _actualMap = id;

            _width = width;
            _height = height;

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    SpawnActor(character, (x, -y));
                }
            }

            // Set default camera size and position
            CameraController.Singleton.Size = 10;
            CameraController.Singleton.Position = ActorManager.Singleton.GetPlayer().Position;
        }

        private static void SpawnActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                case '#':
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '/':
                    ActorManager.Singleton.Spawn<Door>(position);
                    break;
                case '<':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '>':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    ActorManager.Singleton.GetPlayer().Position = position;
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'X':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'l':
                    ActorManager.Singleton.Spawn<Sword>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Key>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'g':
                    ActorManager.Singleton.Spawn<Ghost>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'S':
                    ActorManager.Singleton.Spawn<Slime>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'd':
                    ActorManager.Singleton.Spawn<StairDown>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'u':
                    ActorManager.Singleton.Spawn<StairUp>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case ' ':
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public static void SpawnPlayer((int x, int y) position)
        {
            ActorManager.Singleton.Spawn<Player>(position);
        }
    }
}
