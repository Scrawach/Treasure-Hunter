using System;
using System.Collections;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Lighting
{
    [RequireComponent(typeof(Light))]
    public class LightJitter : MonoBehaviour
    {
        [SerializeField] 
        private Vector2 _range;

        [SerializeField] 
        private float _time;

        private Light _light;

        private void Awake()
        {
            _light = GetComponent<Light>();
            StartCoroutine(Jitter());
        }

        [UsedImplicitly]
        public void IncreaseIntensity(float value)
        {
            _range += value * Vector2.one;
        }

        private IEnumerator Jitter()
        {
            while (true)
            {
                var step = _time * Time.fixedDeltaTime;
                var t = 0f;

                while (t < 1f)
                {
                    _light.intensity = Mathf.Lerp(_range.x, _range.y, t);
                    t += step;
                    yield return new WaitForFixedUpdate();
                }

                while (t > 0)
                {
                    _light.intensity = Mathf.Lerp(_range.x, _range.y, t);
                    t -= step;
                    yield return new WaitForFixedUpdate();
                }
            }
        }
    }
}
