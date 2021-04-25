using System;
using UnityEngine;
using UnityEngine.Events;

namespace Common
{
    [RequireComponent(typeof(Health))]
    public class Death : MonoBehaviour
    {
        //public event Action Happened;
        public UnityEvent Happened;
        
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged(int value)
        {
            if (value <= 0)
                Happened?.Invoke();
        }
    }
}