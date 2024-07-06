using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;

namespace Game.DialogBox
{
    [System.Serializable]
    public class DA_ShowText : DialogAction
    {
        public float IntervalTime;
        public string Text;

        public override IEnumerator DoAction(DialogBox dialogBox)
        {
            if (IntervalTime <= 0)
            {
                dialogBox.UI.AddText(Text);
            }
            else
            {
                bool skip = false;
                int length = Text.Length;
                var chars = Text.ToCharArray();
                for (int i = 0; i < length; i++)
                {
                    dialogBox.UI.AddText(chars[i]);
                    if (skip)
                        continue;
                    else
                    {
                        if (dialogBox.SkipKeyPressed)
                        {
                            Debug.Log("Skip");
                            skip = true;
                            continue;
                        }
                        yield return GameUtil.WaitSeconds(IntervalTime);
                    }
                }
            }
            yield return null;
        }
    }
}