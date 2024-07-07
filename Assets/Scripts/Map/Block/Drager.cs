using System;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Block
{
    public class Drager : Block
    {
        public float drag;

        private Dictionary<GameObject, float> _dragMemory;

        private void Start()
        {
            _dragMemory = new Dictionary<GameObject, float>();
        }

        protected override void EnterEffect(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var rb = col.GetComponent<Rigidbody2D>();
                rb.drag = drag;
            }
            
            
        }

        protected override void ExitEffect(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var rb = col.GetComponent<Rigidbody2D>();
                rb.drag = 4f;
            }
            
        }
    }
}