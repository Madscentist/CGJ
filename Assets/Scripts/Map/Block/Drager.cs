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
            var rb = col.GetComponent<Rigidbody2D>();
            _dragMemory.Add(col.gameObject, rb.drag);
            rb.drag = drag;
        }

        protected override void ExitEffect(Collider2D col)
        {
            var rb = col.GetComponent<Rigidbody2D>();
            rb.drag = _dragMemory[col.gameObject];
            _dragMemory.Remove(col.gameObject);
        }
    }
}