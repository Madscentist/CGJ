using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPoints : MonoBehaviour
{
    public List<Transform> points;

    private void OnDrawGizmos()
    {
        foreach (var point in points)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(point.position, 0.3f);
        }
    }
}
