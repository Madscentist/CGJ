using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Game.TextAnimation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.DialogBox
{
    public class UI_DialogBox : MonoBehaviour
    {
        [SerializeField] private TextAnimationController _textController;

        [SerializeField] private Image _bg1;
        [SerializeField] private Image _bg2;
        
        public RectTransform RectTrans => transform as RectTransform;
        public CanvasGroup Group { get; private set; }

        private void Awake()
        {
            Group = GetComponent<CanvasGroup>();
        }

        public void SetBG(int i)
        {
            _textController.SetBG(i);
            if (i == 0)
            {
                _bg1.gameObject.SetActive(true);
                _bg2.gameObject.SetActive(false);
            }
            else
            {
                _bg1.gameObject.SetActive(false);
                _bg2.gameObject.SetActive(true);
            }
        }

        public void SetText(string text, params TextAnimation.TextAnimation[] animations) => _textController.SetText(text, animations);
        public void AddText(string text, params TextAnimation.TextAnimation[] animations) => _textController.AddText(text, animations);
        public void AddText(Char chars, params TextAnimation.TextAnimation[] animations) => _textController.AddChar(chars, animations);
        public void ClearText() => _textController.ClearText();
        public void NewLine() => _textController.NewLine();
        public void RemoveChar(int count) => _textController.RemoveChar(count);
    }
}