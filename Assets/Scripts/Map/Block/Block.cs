using UnityEngine;

namespace Map.Block
{
    public class Block : MonoBehaviour
    {
        protected virtual void EnterEffect(Collider2D col)
        {
        
        }

        protected virtual void StayEffect(Collider2D col)
        {
        
        }


        protected virtual void ExitEffect(Collider2D col)
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            EnterEffect(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            StayEffect(other);
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            ExitEffect(other);
        }
    }
}
