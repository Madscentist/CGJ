using System;
using UnityEngine;

namespace Map.Block
{
    public class Cave : Block
    {
        public float triggeredTime;
        public float maintainTime;

        public Sprite triggered;
        public Sprite triggering;
        public Sprite unTriggered;
        
        private bool _triggered;
        private bool _caveOn;

        private SpriteRenderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        protected override void EnterEffect(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                GameApi.GameApi.Instance.Die();
            }
        }

        protected override void ExitEffect(Collider2D col)
        {
            if (!_triggered)
            {
                _triggered = true;

                _renderer.sprite = triggering;
                //GetComponent<SpriteRenderer>().color = Color.yellow;

                Invoke(nameof(CaveOn), triggeredTime);
            }
        }

        private void CaveOn()
        {
            _caveOn = true;
            Invoke(nameof(Off), maintainTime);

            _renderer.sprite = triggered;
            //GetComponent<SpriteRenderer>().color = Color.red;
        }

        private void Off()
        {
            _caveOn = false;
            _triggered = false;
            _renderer.sprite = unTriggered;
            //GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}