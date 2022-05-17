using System.Threading;
using UnityEngine;

namespace Assets.Source.Core
{
    public class Battle
    {
        public Battle()
        {
            Loop();
        }

        public void Loop()
        {
            new WaitForTime(1);
        }
    }
}