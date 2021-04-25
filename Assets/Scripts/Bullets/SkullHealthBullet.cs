using System;
using Common;
using Player;
using UnityEngine;

namespace Bullets
{
    public class SkullHealthBullet : MonoBehaviour
    {
        [SerializeField] 
        private int _addValue;
        
        [SerializeField]
        private float _cooldownTime;

        private float _elapsedTime;
        
        private bool _isHealing;
        private Health _playerHealth;

        private void Update()
        {
            if (_isHealing == false)
                return;

            if (_elapsedTime > _cooldownTime)
            {
                Heal();
                _elapsedTime = 0f;
            }
            else
            {
                _elapsedTime += Time.deltaTime;
            }
        }

        private void Heal()
        {
            _playerHealth.Heal(_addValue);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInput player))
            {
                _playerHealth = player.GetComponent<Health>();
                _isHealing = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerInput player))
            {
                _isHealing = false;
            }
        }
    }
}