using System;
using Common;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace EnemyLogic
{
    [RequireComponent(typeof(Collider))]
    public class Aggro : MonoBehaviour
    {
        public UnityEvent<PlayerInput> PlayerEnter;
        public UnityEvent<PlayerInput> PlayerExit;

        private PlayerInput _player;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInput player))
            {
                if (_player != null)
                {
                    _player.GetComponent<Health>().Changed -= OnPlayerHealthChanged;
                }
                
                _player = player;
                PlayerEnter?.Invoke(player);
                _player.GetComponent<Health>().Changed += OnPlayerHealthChanged;
            }
        }

        private void OnPlayerHealthChanged(int value)
        {
            if (value > 0) 
                return;
            
            PlayerExit?.Invoke(_player);
            _player.GetComponent<Health>().Changed -= OnPlayerHealthChanged;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerInput player))
            {
                PlayerExit?.Invoke(player);
            }
        }
    }
}