using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private NavMeshAgent _agent;

    public Transform player;

    public float chasingDistance;
    public Setting setting;
    public State state;

    [Serializable]
    public enum State
    {
        Idle,
        Chasing
    }

    [Serializable]
    public struct Setting
    {
        public float chasingMaxSpeed;
        public float chasingSpeed;
        public float chasingDetectRange;
        public float chasingEndDistance;
    }
    
    private void Start()
    {
        player = GameApi.GameApi.Instance.Player();

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _agent.SetDestination(player.position);

    }

    private void Update()
    {
        StateUpdate();
    }

    private float _currentSpeed;
    private float _refCurrentSpeed;
    
    private void StateUpdate()
    {
        switch (state)
        {
            case State.Idle:

                _agent.speed = Mathf.Lerp(_agent.speed, 0f, 0.1f);

                if (Vector3.Distance(transform.position, player.position) < setting.chasingDetectRange
                    )
                {
                    _agent.speed = setting.chasingMaxSpeed;
                    state = State.Chasing;
                }

                break;
            case State.Chasing:

                _agent.SetDestination(player.position);
                _agent.speed = Mathf.SmoothDamp(_agent.speed, setting.chasingSpeed, ref _refCurrentSpeed, 2f);
                

                if (Vector3.Distance(transform.position, player.position) > setting.chasingEndDistance)
                {
                    state = State.Idle;
                }
                

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
}