using System;
using UnityEngine;

namespace Map.Block
{
    public class Blood : Block
    {
        public float coolTime;

        private bool _cooled;

        private void Start()
        {
            _cooled = true;
        }

        protected override void EnterEffect(Collider2D col)
        {
            if (col.CompareTag("Player") && _cooled)
            {
                GameApi.GameApi.Instance.AddOneBlood();
                _cooled = false;

                Invoke(nameof(Cooled), coolTime);
            }
        }

        private void Cooled()
        {
            _cooled = true;
        }
    }
}