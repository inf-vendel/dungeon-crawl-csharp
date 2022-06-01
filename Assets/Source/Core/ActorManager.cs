using System;
using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static.Items;
using UnityEngine;
using UnityEngine.U2D;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Main class for Actor management - spawning, destroying, detecting at positions, etc
    /// </summary>
    public class ActorManager : MonoBehaviour
    {
        /// <summary>
        ///     ActorManager singleton
        /// </summary>
        public static ActorManager Singleton { get; private set; }

        private SpriteAtlas _spriteAtlas;
        private SpriteAtlas _charAtlas;
        private SpriteAtlas _monsterAtlas;
        private HashSet<Actor> _allActors;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;

            _allActors = new HashSet<Actor>();
            _spriteAtlas = Resources.Load<SpriteAtlas>("Spritesheet");
            _charAtlas = Resources.Load<SpriteAtlas>("LibrarianSheet");
            _monsterAtlas = Resources.Load<SpriteAtlas>("EldrigesSheet");
        }


        public Player GetPlayer()
        {
            foreach (Actor actor in _allActors)
            {
                if (actor is Player)
                {
                    return (Player)actor;
                }
            }
            return null;
        }

        public Actor GetGoldenKey()
        {
            foreach (Actor actor in _allActors)
            {
                if (actor is GoldenKey)
                {
                    return actor;
                }
            }
            return null;
        }

        /// <summary>
        ///     Returns actor present at given position (returns null if no actor is present)
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Actor GetActorAt((int x, int y) position)
        {
            return _allActors.FirstOrDefault(actor => actor.Detectable && actor.Position == position);
        }

        /// <summary>
        ///     Returns actor of specific subclass present at given position (returns null if no actor is present)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <returns></returns>
        public T GetActorAt<T>((int x, int y) position) where T : Actor
        {
            return _allActors.FirstOrDefault(actor => actor.Detectable && actor is T && actor.Position == position) as T;
        }

        /// <summary>
        ///     Unregisters given actor (use when killing/destroying)
        /// </summary>
        /// <param name="actor"></param>
        public void DestroyActor(Actor actor)
        {
            _allActors.Remove(actor);
            Destroy(actor.gameObject);
        }

        /// <summary>
        ///     Used for cleaning up the scene before loading a new map
        /// </summary>
        public void DestroyAllActors()
        {
            var actors = _allActors.ToArray();

            foreach (var actor in actors)
                if (actor is not Player)
                {
                    DestroyActor(actor);
                }
                
        }

        /// <summary>
        ///     Returns sprite with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sprite GetSprite(int id)
        {
            return _spriteAtlas.GetSprite($"kenney_transparent_{id}");
        }

        public Sprite GetSprite(int id, string s)
        {
            return _spriteAtlas.GetSprite($"{s}_{id}");
        }

        /// <summary>
        ///     Spawns given Actor type at given position
        /// </summary>
        /// <typeparam name="T">Actor type</typeparam>
        /// <param name="position">Position</param>
        /// <param name="actorName">Actor's name (optional)</param>
        /// <returns></returns>
        public T Spawn<T>((int x, int y) position, string actorName = null) where T : Actor
        {
            return Spawn<T>(position.x, position.y, actorName);
        }


        public T Spawn<T>(int x, int y, Player player, string actorName = null) where T : Actor
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();

            var component = go.AddComponent<T>();

            go.name = actorName ?? component.DefaultName;
            component.Position = (x, y);
            component.player = player;

            _allActors.Add(component);

            return component;
        }


        public T SpawnPlayer<T>(int x, int y, string actorName = null) where T : Actor
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();

            var component = go.AddComponent<T>();

            go.name = actorName ?? component.DefaultName;
            component.Position = (x, y);

            go.GetComponent<SpriteRenderer>().sprite = ActorManager.Singleton.GetSprite(5, "chars");

            GameObject HPBar = new();
            HPBar.name = "hpbar";
            HPBar.AddComponent<SpriteRenderer>();
            HPBar.GetComponent<SpriteRenderer>().sprite = ActorManager.Singleton.GetSprite(287);
            HPBar.transform.SetParent(go.transform);
            var position = go.transform.position;
            HPBar.transform.position = position + new Vector3(0, 1.6f, 0);
            Color tmp = HPBar.GetComponent<SpriteRenderer>().color;
            tmp.a = 0.8f;
            HPBar.GetComponent<SpriteRenderer>().color = tmp;

            GameObject topImage = new();
            topImage.name = "topimage";
            topImage.AddComponent<SpriteRenderer>();
            topImage.GetComponent<SpriteRenderer>().sprite = ActorManager.Singleton.GetSprite(1, "chars");
            topImage.transform.SetParent(go.transform);
            var position2 = go.transform.position;
            topImage.transform.position = position2 + new Vector3(0, 1f, 0);

            _allActors.Add(component);

            return component;
        }


        public T SpawnMonsters<T>(int x, int y, List<int> spriteIds, string sheet, string actorName = null) where T : Actor
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();

            var component = go.AddComponent<T>();

            go.name = actorName ?? component.DefaultName;
            component.Position = (x, y);

            GameObject TopLeft = new();
            TopLeft.name = "topleft";
            TopLeft.AddComponent<SpriteRenderer>();
            TopLeft.GetComponent<SpriteRenderer>().sprite = GetSprite(spriteIds[0], sheet);
            TopLeft.transform.SetParent(go.transform);
            var position1 = go.transform.position;
            TopLeft.transform.position = position1 + new Vector3(-0.5f, 0, 0);

            GameObject TopRight = new();
            TopRight.name = "topright";
            TopRight.AddComponent<SpriteRenderer>();
            TopRight.GetComponent<SpriteRenderer>().sprite = GetSprite(spriteIds[1], sheet);
            TopRight.transform.SetParent(go.transform);
            var position2 = go.transform.position;
            TopRight.transform.position = position2 + new Vector3(0.5f, 0, 0);

            GameObject DownLeft = new();
            DownLeft.name = "downleft";
            DownLeft.AddComponent<SpriteRenderer>();
            DownLeft.GetComponent<SpriteRenderer>().sprite = GetSprite(spriteIds[2], sheet);
            DownLeft.transform.SetParent(go.transform);
            var position3 = go.transform.position;
            DownLeft.transform.position = position3 + new Vector3(-0.5f, -1f, 0);

            GameObject DownRight = new();
            DownRight.name = "downright";
            DownRight.AddComponent<SpriteRenderer>();
            DownRight.GetComponent<SpriteRenderer>().sprite = GetSprite(spriteIds[3], sheet);
            DownRight.transform.SetParent(go.transform);
            var position4 = go.transform.position;
            DownRight.transform.position = position4 + new Vector3(0.5f, -1f, 0);


            //GameObject HPBar = new();
            //HPBar.name = "hpbar";
            //HPBar.AddComponent<SpriteRenderer>();
            //HPBar.GetComponent<SpriteRenderer>().sprite = ActorManager.Singleton.GetSprite(287);
            //HPBar.transform.SetParent(go.transform);
            //var position = go.transform.position;
            //HPBar.transform.position = position + new Vector3(0, 1.6f, 0);
            //Color tmp = HPBar.GetComponent<SpriteRenderer>().color;
            //tmp.a = 0.8f;
            //HPBar.GetComponent<SpriteRenderer>().color = tmp;

            //GameObject topImage = new();
            //topImage.name = "topimage";
            //topImage.AddComponent<SpriteRenderer>();
            //topImage.GetComponent<SpriteRenderer>().sprite = ActorManager.Singleton.GetSprite(1, "chars");
            //topImage.transform.SetParent(go.transform);
            //var position2 = go.transform.position;
            //topImage.transform.position = position2 + new Vector3(0, 1f, 0);

            _allActors.Add(component);

            return component;
        }

        /// <summary>
        ///     Spawns given Actor type at given position
        /// </summary>
        /// <typeparam name="T">Actor type</typeparam>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="actorName">Actor's name (optional)</param>
        /// <returns></returns>
        public T Spawn<T>(int x, int y, string actorName = null) where T : Actor
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();

            var component = go.AddComponent<T>();

            go.name = actorName ?? component.DefaultName;
            component.Position = (x, y);
            
            _allActors.Add(component);

            return component;
        }
    }
}
