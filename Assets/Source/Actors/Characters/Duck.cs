using Assets.Source.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DungeonCrawl.Actors.Characters
{
    public class Duck : Character
    {
        public const float SPEED = 1.0f;
        public override int DefaultSpriteId => 360;
        public override string DefaultName => "Duck";
        private float _moveCounter;
        public override int Z => -1;

        protected Direction direction = Direction.Right;
        
        public Duck()
        {
            _moveCounter = SPEED;
        }


        protected override void OnDeath()
        
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdate(float deltaTime)
        {
            _moveCounter -= deltaTime;
           
            if (_moveCounter <= 0.0f)
            { 
                TryMove(direction);
                direction = direction == Direction.Left ? Direction.Right : Direction.Left;
                _moveCounter = SPEED;
            }
           
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                //StartCoroutine(Utilities.Message("Quack", UserInterface.TextPosition.BottomCenter, Color.white));
                SceneManager.LoadScene("ToBeContinued");
            }

            return false;
        }
    }
}