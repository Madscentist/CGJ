using UnityEngine;

namespace Map.Block
{
    public class AccelerationBlock : Block
    {
        public float force;
        
        protected override void EnterEffect(Collider2D col)
        {
            var rb = col.GetComponent<Rigidbody2D>();
            rb.AddForce(rb.velocity.normalized * force);
            
        }
    }
}