using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{
    public class DA_Wait : DialogAction
    {
        public float WaitTime;

        public override IEnumerator DoAction(DialogBox dialogBox)
        {
            float timer = 0f;
            while (timer <= WaitTime)
            {
                if (dialogBox.SkipKeyPressed)
                    break;
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}