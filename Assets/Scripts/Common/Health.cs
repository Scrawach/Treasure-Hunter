using System;
using UnityEngine;

namespace Common
{
    public class Health : MonoBehaviour
    {
        [SerializeField] 
        private int _value;

        [SerializeField] 
        private int _maxValue;

        private int _currentValue;

        public Action<int> Changed;
        public Action<int> DeltaChanged;
        public int Value => _value;

        private void Awake()
        {
            _currentValue = _value;
        }

        public void TakeDamage(int damage)
        {
            if (_currentValue <= 0)
                return;

            _currentValue -= damage;

            if (_currentValue < 0)
                _currentValue = 0;
            
            DeltaChanged?.Invoke(-damage);
            Changed?.Invoke(_currentValue);
        }

        public void Heal(int addValue)
        {
            if (_currentValue < _maxValue)
            {
                _currentValue += addValue;
                Changed?.Invoke(_currentValue);
                DeltaChanged?.Invoke(addValue);
            }
        }
    }
}