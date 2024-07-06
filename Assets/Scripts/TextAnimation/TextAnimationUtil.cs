using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using TMPro;
using System;
using System.Text;

namespace Game.TextAnimation
{
    public static class TextAnimationUtil
    {
        public static TextAnimation CreateAnimation(TextAnimationType type)
        {
            return type switch
            {
                TextAnimationType.Shake => new TA_Shake(),
                _ => null,
            };
        }
    }
}