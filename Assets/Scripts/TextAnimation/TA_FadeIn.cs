using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using TMPro;
using System.Text;

namespace Game.TextAnimation
{
    public class TA_FadeIn : TextAnimation
    {
        public float AnimLength = 0.2f;

        public Vector2 IntroOffset = Vector2.up * 30f;
        public float IntroScale = 0f;

        public float CurTime { get; private set; } = 0f;


        public override void Update()
        {
            base.Update();
            CurTime += Time.deltaTime;
            if (CurTime >= AnimLength)
            {
                Finish = true;
                CurTime = AnimLength;
            }
        }

        public override Vector3 GetOffset(int charIndex, int vertexIndex, float width, float height)
        {
            float t = CurTime / AnimLength;
            //Vector3 scaleOffset = Mathf.Lerp(IntroScale - 0.5f, 0f, t) * Scale(vertexIndex, width, height); 
            return Vector3.Lerp(IntroOffset, Vector2.zero, t);
        }

        private Vector2 Scale(int vIndex, float width, float height)
        {
            return vIndex switch
            {
                0 => new(width, height),
                1 => new(-width, height),
                2 => new(-width, -height),
                3 => new(width, -height),
                _ => Vector2.zero
            };
        }
    }
}