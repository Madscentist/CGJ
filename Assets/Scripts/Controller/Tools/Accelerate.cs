using System;
using UnityEngine;

namespace Controller.Tools
{
    public class Accelerate :  Tool
    {
        public float maintainTime;
        public float accelerateRate;
        
        private float _originForce;
        private bool _on;
        private float _remainTime;

        // private void Update()
        // {
        //     if (_on)
        //     {
        //         _remainTime -= Time.deltaTime;
        //
        //         if (_remainTime<= 0f)
        //         {
        //             _on = false;
        //         }
        //     }
        // }

        public override void Use(CharacterController controller)
        {
            if (!_on)
            {
                _on = true;
                controller.Accelerate(accelerateRate, maintainTime);
                Invoke(nameof(Off), maintainTime);
            }
            
        }

        private void Off()
        {
            _on = false;
        }
    }
}