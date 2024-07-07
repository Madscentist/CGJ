using System;
using UnityEngine;
using UnityEngine.AI;

namespace Controller.Tools
{
    public class Point : Tool
    {
        public float existTime;

        public GameObject light;
        public float speed;

        private Transform _player;

        private void Start()
        {
            _player = GameApi.GameApi.Instance.Player();
            light.SetActive(false);
            transform.SetParent(null);
        }

        private Vector3 _targetPosition;

        private void Update()
        {
            if (light.activeSelf)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
            }
        }

        public override void Use(CharacterController controller)
        {
            light.SetActive(true);
            transform.position = _player.position;
            _targetPosition = GameApi.GameApi.Instance.GetTargetPosition();
            Invoke(nameof(Off), existTime);
        }

        private void Off()
        {
            light.SetActive(false);
        }
    }
}