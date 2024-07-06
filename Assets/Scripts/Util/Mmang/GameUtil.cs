using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mmang
{
    public static class GameUtil
    {
        public static IEnumerator WaitSeconds(float seconds)
        {
            while (seconds > 0)
            {
                seconds -= Time.deltaTime;
                yield return null;
            }
        }
    }
}