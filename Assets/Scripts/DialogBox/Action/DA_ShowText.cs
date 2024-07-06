using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using Game.TextAnimation;

namespace Game.DialogBox
{
    [System.Serializable]
    public class DA_ShowText : DialogAction
    {
        public float IntervalTime;
        public string Text;
        public TextAnimationType AnimationType;

        public override IEnumerator DoAction(DialogBox dialogBox)
        {
            bool skip = false;
            int length = Text.Length;
            var chars = Text.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                dialogBox.UI.AddText(chars[i], TextAnimationUtil.CreateAnimation(AnimationType), new TA_FadeIn());
                if (skip)
                    continue;
                else
                {
                    if (dialogBox.SkipKeyPressed)
                    {
                        skip = true;
                        continue;
                    }
                    if (IntervalTime > 0f)
                        yield return GameUtil.WaitSeconds(IntervalTime);
                }
            }

            yield return null;
        }
    }
}