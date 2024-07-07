using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using Game.TextAnimation;

namespace Game.DialogBox
{
    [System.Serializable]
    public class DA_SetBG : DialogAction
    {
        public int BG;
        public override IEnumerator DoAction(DialogBox dialogBox)
        {
            dialogBox.UI.SetBG(BG);
            yield return null;
        }
    }
}