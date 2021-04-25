using System;
using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(Health))]
    public class TakeDamageEffect : MonoBehaviour
    {
        [SerializeField] 
        private ParticleSystem _damagedEffect;
        
        private Health _health;

        private void Awake() => 
            _health = GetComponent<Health>();

        private void OnEnable() => 
            _health.DeltaChanged += OnHealthChanged;

        private void OnDisable() => 
            _health.DeltaChanged -= OnHealthChanged;

        private void OnHealthChanged(int delta)
        {
            if (delta < 0)
            {
                Instantiate(_damagedEffect, transform.position, Quaternion.identity);
            }
        }
    }
}