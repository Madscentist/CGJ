using UnityEngine;

namespace Map.Block
{
    public class Cave : Block
    {
        public float triggeredTime;
        public float maintainTime;

        private bool _triggered;
        private bool _caveOn;

        protected override void EnterEffect(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                GameApi.GameApi.Instance.Die();
            }
        }

        protected override void ExitEffect(Collider2D col)
        {
            if (!_triggered)
            {
                _triggered = true;
                GetComponent<SpriteRenderer>().color = Color.yellow;

                Invoke(nameof(CaveOn), triggeredTime);
            }
        }

        private void CaveOn()
        {
            _caveOn = true;
            Invoke(nameof(Off), maintainTime);
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        private void Off()
        {
            _caveOn = false;
            _triggered = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}