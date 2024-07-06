using UnityEngine;

namespace Map.Block
{
    public class Target : Block
    {
        protected override void EnterEffect(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                GameApi.GameApi.Instance.TouchTarget();
            }
        }
    }
}