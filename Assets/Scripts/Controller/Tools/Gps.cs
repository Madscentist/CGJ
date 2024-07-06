using System;
using UnityEngine;
using UnityEngine.AI;

namespace Controller.Tools
{
    public class Gps :  Tool
    {
        public float existTime;
        public GameObject light;

        
        private Transform _player;
        private NavMeshAgent _agent;

        private void Start()
        {
            _player = GameApi.GameApi.Instance.Player();
            _agent = GetComponent<NavMeshAgent>();
            light.SetActive(false);
            transform.SetParent(null);
        }

        private void Update()
        {

        }
        

        public override void Use(CharacterController controller)
        {
            light.SetActive(true);
            transform.position = _player.position;
            _agent.SetDestination(GameApi.GameApi.Instance.GetTargetPosition());
            Invoke(nameof(Off), existTime);
        }

        private void Off()
        {
            light.SetActive(false);
        }
        
        
    }
}