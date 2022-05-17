using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Core
{
    public class WaitForTime : MonoBehaviour
    {
        public WaitForTime(int seconds)
        {
            Start(seconds);
        }
        public void Start(int seconds)
        {
            StartCoroutine(Wait(seconds));
        }
        public IEnumerator Wait(int seconds)
        {

            

        }
    }
}
