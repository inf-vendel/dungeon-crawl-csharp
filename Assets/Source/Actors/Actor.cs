using System;
using System.Threading;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static.Items;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors
{
    public abstract class Actor : MonoBehaviour
    {

        protected float spriteAlpha { get; set; } = 1.0f;
        protected bool IsColored { get; set; }
        protected Color spriteColor { get; set; }

    public (int x, int y) Position
        {
            get => _position;
            set
            {
                _position = value;
                transform.position = new Vector3(value.x, value.y, Z);
            }
        }

        private (int x, int y) _position;

        public Player player { get; set; }

        private void Awake()
        {
            SetSprite(DefaultSpriteId);
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        public virtual void SetSprite(int id)
        {
            var _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = ActorManager.Singleton.GetSprite(id);
            Color tmp = _spriteRenderer.color;
            if (IsColored)
            {
                tmp = spriteColor;
            }
            tmp.a = spriteAlpha;
            _spriteRenderer.color = tmp;
        }

        public void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);
            {
                if (actorAtTargetPosition == null)
                {
                    // No obstacle found, just move
                    Position = targetPosition;
                }
                else
                {
                    if (actorAtTargetPosition.OnCollision(this))
                    {
                        // Allowed to move
                        Position = targetPosition;
                    }
                }
            }
        }

        public void TryMove(Direction direction, int width, int height)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (targetPosition.x <= width && targetPosition.y <= - 1 && targetPosition.x >= - 1 && targetPosition.y >= -height)
            {
                if (actorAtTargetPosition == null)
                {
                    // No obstacle found, just move
                    Position = targetPosition;
                }
                else
                {
                    if (actorAtTargetPosition.OnCollision(this))
                    {
                        // Allowed to move
                        Position = targetPosition;
                    }
                }
            }
        }


        /// <summary>
        ///     Invoked whenever another actor attempts to walk on the same position
        ///     this actor is placed.
        /// </summary>
        /// <param name="anotherActor"></param>
        /// <returns>true if actor can walk on this position, false if not</returns>
        public virtual bool OnCollision(Actor anotherActor)
        {
            // All actors are passable by default
            return true;
        }

        /// <summary>
        ///     Invoked every animation frame, can be used for movement, character logic, etc
        /// </summary>
        /// <param name="deltaTime">Time (in seconds) since the last animation frame</param>
        protected virtual void OnUpdate(float deltaTime)
        {
        }

        /// <summary>
        ///     Can this actor be detected with ActorManager.GetActorAt()? Should be false for purely cosmetic actors
        /// </summary>
        public virtual bool Detectable => true;

        /// <summary>
        ///     Z position of this Actor (0 by default)
        /// </summary>
        public virtual int Z => 0;

        /// <summary>
        ///     Id of the default sprite of this actor type
        /// </summary>
        public abstract int DefaultSpriteId { get; }

        /// <summary>
        ///     Default name assigned to this actor type
        /// </summary>
        public abstract string DefaultName { get; }
    }
}