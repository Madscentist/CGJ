using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounder : MonoBehaviour
{
    public float length;
    public float width;
    private Vector3 _leftTop;
    private Vector3 _rightTop;
    private Vector3 _leftDown;
    private Vector3 _rightDown;

    public Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        GetVertex();
    }

    private void Update()
    {
        var pPosition = player.position;
        if (pPosition.x < transform.position.x - length / 2f - 0.5f)
        {
            pPosition.x = transform.position.x + length / 2f;

            player.position = pPosition;
            return;
        }

        if (pPosition.x >= transform.position.x + length / 2f + 0.5f)
        {
            pPosition.x = transform.position.x - length / 2f;
            player.position = pPosition;

            return;
        }

        if (pPosition.y > transform.position.y + width / 2f + 0.5f)
        {
            pPosition.y = transform.position.y - width / 2f;
            player.position = pPosition;

            return;
        }
        
        if (pPosition.y <= transform.position.y - width / 2f - 0.5f)
        {
            pPosition.y = transform.position.y + width / 2f;
            player.position = pPosition;

            return;
        }
    }


    private void GetVertex()
    {
        _leftTop = transform.position + new Vector3(-length / 2f, width / 2f);
        _rightTop = transform.position + new Vector3(length / 2f, width / 2f);
        _leftDown = transform.position + new Vector3(-length / 2f, -width / 2f);
        _rightDown = transform.position + new Vector3(length / 2f, -width / 2f);
    }

    private void OnDrawGizmos()
    {
        GetVertex();
        Gizmos.color = Color.green;
        Gizmos.DrawLine(_leftTop, _rightTop);
        Gizmos.color = Color.green;

        Gizmos.DrawLine(_leftTop, _leftDown);
        Gizmos.color = Color.green;

        Gizmos.DrawLine(_rightTop, _rightDown);
        Gizmos.color = Color.green;

        Gizmos.DrawLine(_leftDown, _rightDown);
    }
}