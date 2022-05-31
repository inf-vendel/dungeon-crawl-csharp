﻿using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Actors.Static.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DungeonCrawl.Actors;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UIElements;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        private static int _width { get; set; }
        private static int _height { get; set; }
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
            CameraController.Singleton.Size = 5;
            CameraController.Singleton.Position = ActorManager.Singleton.GetPlayer().Position;
        }

        private static void TxtReader(string filename, int id)
        {


            
        }

        private static void SpawnActor(char c, (int x, int y) position)
        {
            var player = ActorManager.Singleton.GetPlayer();
            string nums = "1234";

            if (nums.Contains(c))
            {
                ActorManager.Singleton.Spawn<Info>(position);
                ActorManager.Singleton.Spawn<Floor>(position);
            }

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
                case 'p':
                    player.Position = position;
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'X':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'h':
                    ActorManager.Singleton.Spawn<Bridge>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '{':
                    ActorManager.Singleton.Spawn<Duck>(position);
                    ActorManager.Singleton.Spawn<Water>(position);
                    break;
                case 'l':
                    ActorManager.Singleton.Spawn<Sword>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'a':
                    ActorManager.Singleton.Spawn<Apple>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Key>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'g':
                    Ghost ghost = ActorManager.Singleton.Spawn<Ghost>(position.x,position.y, player);
                    ghost.MapWidth = _width;
                    ghost.MapHeight = _height;
                    
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'G':
                    ActorManager.Singleton.Spawn<GoldenKey>(position);
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
                case 'i':
                    ActorManager.Singleton.Spawn<Info>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'D':
                    ActorManager.Singleton.Spawn<Dog>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'B':
                    ActorManager.Singleton.Spawn<Boss>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'f':
                    ActorManager.Singleton.Spawn<BoneFire>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'w':
                    ActorManager.Singleton.Spawn<Water>(position);
                    break;
                case 'y':
                    ActorManager.Singleton.Spawn<BridgeRight>(position);
                    ActorManager.Singleton.Spawn<Water>(position);
                    break;
                case 'x':
                    ActorManager.Singleton.Spawn<BridgeLeft>(position);
                    ActorManager.Singleton.Spawn<Water>(position);
                    break;
                case 't':
                    ActorManager.Singleton.Spawn<Tombstone>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'á':
                    ActorManager.Singleton.Spawn<Fire>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '$':
                    ActorManager.Singleton.Spawn<Skull>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'W':
                    ActorManager.Singleton.Spawn<Web>(position);
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

        public static void SpawnPlayer()
        {
            ActorManager.Singleton.SpawnPlayer<Player>(0,0);
        }
    }
}
