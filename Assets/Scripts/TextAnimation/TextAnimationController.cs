using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using TMPro;
using System;
using System.Text;

namespace Game.TextAnimation
{
    public enum TextAnimationType
    {
        None,
        Shake,
    }

    public abstract class TextAnimation
    {
        public bool Finish { get; protected set; } = false;
        public virtual void Update() { }
        public abstract Vector3 GetOffset(int charIndex, int vertexIndex, float width, float height);
    }

    public class CharAnimationData
    {
        public TextAnimationType Type;
        public List<TextAnimation> Animations { get; } = new();

        public void Update()
        {
            Animations.ForEach(anim => anim.Update());
            Animations.RemoveAll(anim => anim.Finish);
        }
        
        public Vector3 GetOffset(int charIndex, int vertexIndex, float width, float height)
        {
            Vector3 offset = Vector3.zero;
            Animations.ForEach(anim => offset += anim.GetOffset(charIndex, vertexIndex, width, height));
            return offset;
        }
    }

    public class TextAnimationController : MonoBehaviour
    {
        public TMP_Text TMPText { get; private set; }
        public List<CharAnimationData> CharAnimationDatas { get; } = new();
        private StringBuilder _textBuilder = new();

        private void Awake() => TMPText = GetComponent<TMP_Text>();

        private void Update()
        {
            UpdateAnimation();
            CharAnimationDatas.ForEach(data => data.Update());
        }

        public void UpdateText() => TMPText.text = _textBuilder.ToString();

        public void SetText(string text, params TextAnimation[] animations)
        {
            ClearText();
            AddText(text, animations);
        }

        public void AddChar(Char chars, params TextAnimation[] animations)
        {
            CharAnimationData data = new();
            foreach (var anim in animations)
            {
                if (anim != null)
                    data.Animations.Add(anim);
            }
            CharAnimationDatas.Add(data);
            _textBuilder.Append(chars);
            UpdateText();
        }

        public void AddText(string text, params TextAnimation[] animations)
        {
            var charArray = text.ToCharArray();
            int length = charArray.Length;
            for (int i = 0; i < length; i++)
                AddChar(charArray[i], animations);
        }

        public void RemoveChar(int count)
        {
            if (count <= 0)
                return;
            if (CharAnimationDatas.Count <= count)
            {
                ClearText();
                return;
            }
            CharAnimationDatas.RemoveRange(CharAnimationDatas.Count - count, count);
            _textBuilder.Remove(_textBuilder.Length - count, count);
            UpdateText();
        }

        public void ClearText()
        {
            CharAnimationDatas.Clear();
            //_textBuilder.Clear();
            _textBuilder.Remove(0, _textBuilder.Length);
            TMPText.text = "";
        }

        private void UpdateAnimation()
        {
            TMPText.ForceMeshUpdate();
            var textInfo = TMPText.textInfo;
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                var charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible)
                    continue;
                
                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
                float width = (verts[1] - verts[0]).x;
                float height = (verts[1] - verts[2]).y;
                for (int v = 0; v < 4; v++)
                {
                    var origin = verts[charInfo.vertexIndex + v];
                    Vector3 offset = CharAnimationDatas[i].GetOffset(i, v, width, height);
                    verts[charInfo.vertexIndex + v] = origin + offset;
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                TMPText.UpdateGeometry(meshInfo.mesh, i);
            }
        }
    }
}