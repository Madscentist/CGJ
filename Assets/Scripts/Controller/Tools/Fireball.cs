using System;
using UnityEngine;

namespace Controller.Tools
{
    public class Fireball : Tool
    {
        public float coolTime;
        
        public float existTime;
        public float speed;
        public GameObject ball;
        
        private float _remainTime;
        private bool _on;
        private Vector3 _flyDir;
        private bool _cooling;
        private float _coolingRemainTime;

        private void Start()
        {
            transform.SetParent(null);
        }

        private void Update()
        {
            ball.SetActive(_on);
            
            if (_on)
            {
                transform.position += _flyDir * (speed * Time.deltaTime);
                
                _remainTime -= Time.deltaTime;
                if (_remainTime < 0f)
                {
                    _on = false;
                }
            }

            if (_cooling)
            {
                _coolingRemainTime -= Time.deltaTime;

                if (_coolingRemainTime < 0)
                {
                    _cooling = false;
                }
            }
        }

        public override void Use(CharacterController controller)
        {
            if (_cooling)
            {
                return;
            }
            transform.position = controller.transform.position;
            _flyDir = controller.Velocity().normalized;
            _on = true;
            _cooling = true;
            _coolingRemainTime = coolTime;
            _remainTime = existTime;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                return;
            }

            if (other.CompareTag("Monster"))
            {
                //TODO
                
                other.GetComponent<MonsterController>().Hurt();
                
                return;
            }

            _on = false;
        }
    }
}