using System;
using System.Collections;
using Common;
using UnityEngine;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] 
        private Health _target;

        [SerializeField] 
        private RectTransform _rectTransform;

        [SerializeField] 
        private float _smoothSpeed;

        private float _desiredValue;

        private Coroutine _coroutine;

        private void OnEnable()
        {
            _target.Changed += OnValueChanged;
            OnValueChanged(_target.Value);
        }

        private void OnDisable()
        {
            _target.Changed -= OnValueChanged;
        }

        private void OnValueChanged(int currentValue)
        {
            _desiredValue = currentValue / 5f;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            _coroutine = StartCoroutine(Changing());
        }

        private IEnumerator Changing()
        {
            var currentValue = _rectTransform.localScale.x;
            var targetValue = _desiredValue;
            var step = Time.fixedDeltaTime / _smoothSpeed;
            var t = 0f;

            while (t < 1f)
            {
                t += step;
                var value = Mathf.Lerp(currentValue, targetValue, t);
                _rectTransform.localScale = new Vector3(value, 1, 1);
                yield return new WaitForFixedUpdate();
            }
            _coroutine = null;
        }
    }
}