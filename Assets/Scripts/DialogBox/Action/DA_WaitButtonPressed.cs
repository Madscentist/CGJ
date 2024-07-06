using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{
    public class DA_WaitButtonPressed : DialogAction
    {
        public override IEnumerator DoAction(DialogBox dialogBox)
        {
            while (!dialogBox.SkipKeyPressed)
                yield return null;
        }
    }
}