using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Game.TextAnimation;
using TMPro;
using UnityEngine;

namespace Game.DialogBox
{
    public class UI_DialogBox : MonoBehaviour
    {
        [SerializeField] private TextAnimationController _textController;
        
        public RectTransform RectTrans => transform as RectTransform;
        public CanvasGroup Group { get; private set; }

        private void Awake()
        {
            Group = GetComponent<CanvasGroup>();
        }

        public void SetText(string text, params TextAnimation.TextAnimation[] animations) => _textController.SetText(text, animations);
        public void AddText(string text, params TextAnimation.TextAnimation[] animations) => _textController.AddText(text, animations);
        public void AddText(Char chars, params TextAnimation.TextAnimation[] animations) => _textController.AddChar(chars, animations);
        public void ClearText() => _textController.ClearText();
        public void RemoveChar(int count) => _textController.RemoveChar(count);
    }
}