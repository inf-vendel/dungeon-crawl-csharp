using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Character, IEnemy
    {
        public override bool Detectable => true;

        public const float SPEED = 0.6f;
        private float _moveCounter;

        private const int DEFAULT_HEALTH = 12;
        private const int DEFAULT_DAMAGE = 3;
        public bool IsAgressive { get; set; }

        public Ghost()
        {
            SetHp(DEFAULT_HEALTH);
            SetDamage(DEFAULT_DAMAGE);
            IsAgressive = true;
            spriteAlpha = 0.5f;
        }

        protected override void OnUpdate(float deltaTime)
        {
            // szellem látómezője
            Actor player = ActorManager.Singleton.GetPlayer();
            (int x, int y) playerPosition = player.Position;

            _moveCounter -= deltaTime;

            List<Tuple<int, int>> neighbours = new();

            for (int i = 1; i < 5; i++)
            {
                neighbours.Add(Tuple.Create(Position.x + i, Position.y));
                neighbours.Add(Tuple.Create(Position.x, Position.y + i));
                neighbours.Add(Tuple.Create(Position.x - i, Position.y));
                neighbours.Add(Tuple.Create(Position.x, Position.y - i));
                neighbours.Add(Tuple.Create(Position.x + i, Position.y + i));
                neighbours.Add(Tuple.Create(Position.x - i, Position.y - i));
                neighbours.Add(Tuple.Create(Position.x + i, Position.y - i));
                neighbours.Add(Tuple.Create(Position.x - i, Position.y + i));
            }

            if (_moveCounter <= 0.0f)
            {
                foreach (Tuple<int, int> neighbour in neighbours)
                {
                    if (ActorManager.Singleton.GetActorAt<Player>((neighbour.Item1, neighbour.Item2)))
                    {
                        if (Position.x < playerPosition.x)
                        {
                            TryMove(Direction.Right);
                        }
                        else if (Position.x > playerPosition.x)
                        {
                            TryMove(Direction.Left);
                        }
                        if (Position.y < playerPosition.y)
                        {
                            TryMove(Direction.Up);
                        }
                        else if (Position.y > playerPosition.y)
                        {
                            TryMove(Direction.Down);
                        }
                        _moveCounter = SPEED;
                    }
                }
            }


        }

        public override bool OnCollision(Actor anotherActor)
        {
            var battle = new Battle((Player)anotherActor, this);
            StartCoroutine(battle.Loop());
            if (anotherActor is Player)
            {
                return false;
            }
            return true;
        }

        protected override void OnDeath()
        {
            IsAlive = false;
            UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.BottomCenter);
            Debug.Log("huuuuuuuuu...");
        }

        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghost";
    }

}
