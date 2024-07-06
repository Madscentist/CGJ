using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using TMPro;
using System.Text;

namespace Game.TextAnimation
{
    public class TA_Shake : TextAnimation
    {
        public float Radius = 8f;
        public float IntervalTime = 0.3f;

        public float LerpTime { get; private set; }
        public Vector2 CurPoint { get; private set; } = Vector2.zero;
        public Vector2 NextPoint { get; private set; } = Vector2.zero;
        public override Vector3 GetOffset(int charIndex, int vertexIndex, float width, float height)
        {
            LerpTime += Time.deltaTime / IntervalTime;
            while (LerpTime > 1f)
            {
                CurPoint = NextPoint;
                NextPoint = GameUtil.GetRandomPointInCircle(Vector2.zero, Radius);
                LerpTime--;
            }
            return Vector3.Lerp(CurPoint, NextPoint, LerpTime);    
        }
    }
}