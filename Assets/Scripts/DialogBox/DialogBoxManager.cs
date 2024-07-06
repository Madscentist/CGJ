using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;

namespace Game.DialogBox
{
    public class DialogBoxManager : SingletonMono<DialogBoxManager>
    {
        public List<DialogBox> Boxes { get; } = new();
        public List<DialogBox> BoxesToRemove { get; } = new();

        private void Update()
        {
            float dt = Time.deltaTime;
            Boxes.ForEach(box => box.Update(dt));
            if (BoxesToRemove.Count > 0)
            {
                BoxesToRemove.ForEach(box => Boxes.Remove(box));
                BoxesToRemove.Clear();
            }
        }

        public static void AddBox(DialogBox box)
        {
            Instance?.Boxes.Add(box);
        }

        public static void RemoveBox(DialogBox box)
        {
            Instance?.BoxesToRemove.Add(box);
        }
    }
}