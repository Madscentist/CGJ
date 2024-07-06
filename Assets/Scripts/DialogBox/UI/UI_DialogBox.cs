using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Game.DialogBox
{
    public class UI_DialogBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textDisplay;
        
        public RectTransform RectTrans => transform as RectTransform;
        public CanvasGroup Group { get; private set; }

        private StringBuilder textBuilder = new();

        private void Awake()
        {
            Group = GetComponent<CanvasGroup>();
        }

        public void SetText(string text)
        {
            textBuilder.Clear();
            textBuilder.Append(text);
            _textDisplay.text = textBuilder.ToString();
        }

        public void AddText(string text)
        {
            textBuilder.Append(text);
            _textDisplay.text = textBuilder.ToString();
        }

        public void AddText(Char chars)
        {
            textBuilder.Append(chars);
            _textDisplay.text = textBuilder.ToString();
        }

        public void ClearText()
        {
            textBuilder.Clear();
            _textDisplay.text = textBuilder.ToString();
        }

        public void RemoveChar(int count)
        {
            if (count >= textBuilder.Length)
            {
                ClearText();
                return;
            }
            textBuilder.Remove(textBuilder.Length - count, count);
            _textDisplay.text = textBuilder.ToString();
        }
    }
}