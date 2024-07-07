using System;
using UnityEngine;
using CharacterController = Controller.CharacterController;

namespace Map.Block
{
    public class Throne : Block
    {
        public float maintainTime;
        public float coolTime;

        public float blockTime = 1.5f;
        
        public float triggerDistance;

        public SpriteRenderer image;

        public Sprite triggered;
        public Sprite unTriggered;
        
        private bool _on;
        private bool _cooling;
        private float _coolTimeLeft;
        private Transform _player;
        private Collider2D _collider;


        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            var distance = _collider.Distance(_player.GetComponent<Collider2D>()).distance;

            if (distance < triggerDistance && !_cooling)
            {
                _on = true;
                image.sprite = triggered;
                Invoke(nameof(Triggered), maintainTime);
            }

            if (_cooling)
            {
                image.sprite = unTriggered;
                _coolTimeLeft -= Time.deltaTime;

                if (_coolTimeLeft <= 0f)
                {
                    _cooling = false;
                }
            }
        }

        
        
        private void Triggered()
        {
            _on = false;
            _cooling = true;
            _coolTimeLeft = coolTime;
        }

        protected override void EnterEffect(Collider2D col)
        {
            if (_on)
            {
                if (col.CompareTag("Player"))
                {
                    col.GetComponent<CharacterController>().DisableMove(blockTime);
                }
                //TODO  Monster
            }
        }

        protected override void ExitEffect(Collider2D col)
        {

        }
    }
}