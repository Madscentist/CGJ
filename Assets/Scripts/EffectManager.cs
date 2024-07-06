using System.Collections;
using System.Collections.Generic;
using Mmang;
using UnityEngine;

namespace Game
{
    public class EffectManager : SingletonMono<EffectManager>
    {
        [SerializeField]
        private AnimationCurve _hurtEffectCurve;

        private Coroutine _coroutine;

        public void StartHurtEffect(float time, float idensity = 0.5f)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(HurtEffectCoroutine(time, idensity));
        }

        private IEnumerator HurtEffectCoroutine(float time, float idensity)
        {
            float timer = 0f;
            while (timer <= time)
            {
                timer += Time.deltaTime;
                timer = Mathf.Min(timer, time);
                Shader.SetGlobalFloat("_Hurt", _hurtEffectCurve.Evaluate(timer / time) * idensity);
                yield return null;
            }
            _coroutine = null;
        }

    }

}