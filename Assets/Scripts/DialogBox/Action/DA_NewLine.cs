using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using Game.TextAnimation;

namespace Game.DialogBox
{
    [System.Serializable]
    public class DA_NewLine : DialogAction
    {
        public override IEnumerator DoAction(DialogBox dialogBox)
        {
            dialogBox.UI.NewLine();
            yield return null;
        }
    }
}