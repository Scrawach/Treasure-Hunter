using System;
using Common;
using UI.Monologue;
using UnityEngine;

namespace Player.WorldUI
{
    [RequireComponent(typeof(Health))]
    public class HealthChangeWorldView : MonoBehaviour
    {
        [SerializeField] 
        private TextHealth _textTemplate;
        
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.DeltaChanged += OnHealthChange;
        }

        private void OnDisable()
        {
            _health.DeltaChanged -= OnHealthChange;
        }

        private void OnHealthChange(int value)
        {
            var instance = Instantiate(_textTemplate, transform.position, _textTemplate.transform.rotation);
            var isHeal = value > 0;

            var isEng = MonologueSystem.IsEnglish;
            var hpText = isEng ? "HP" : "ХП";
            var result = isHeal ? $"+{value} {hpText}" : $"{value} {hpText}";
            var color = isHeal ? Color.green : Color.red;
            instance.Construct(result, 1f, color);
        }
    }
}