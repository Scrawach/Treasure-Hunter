using System;
using System.Linq;
using Common;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] 
        private int _damage;

        [SerializeField] 
        private float _damageRadius;

        [SerializeField] 
        private float _cooldownTime;
        
        [SerializeField] 
        private ChestAnimator _animator;

        [SerializeField] 
        private LayerMask _enemyMask;

        [SerializeField] 
        private Inventory _inventory;

        [SerializeField] 
        private Health _playerHealth;

        private float _elapsedTime = float.MaxValue;
        private Collider[] _hits = new Collider[5];
        

        private void Update()
        {
            if (CanAttack() == false)
                UpdateCooldown();
        }
        
        public void Attack()
        {
            _animator.PlayAttack();
            _elapsedTime = 0f;
        }

        [UsedImplicitly]
        public void OnAttack()
        {
            for (var i = 0; i < Hit(); i++)
            {
                if (_hits[i].TryGetComponent(out Health health))
                {
                    health.TakeDamage(_damage);
                }

                if (_hits[i].TryGetComponent(out BonusData bonus))
                {
                    _inventory.AddItem(bonus);
                }

                if (_hits[i].TryGetComponent(out QuestItem item))
                {
                    item.Take();
                }
                
                if (_hits[i].TryGetComponent(out PropsHealth heal))
                {
                    _playerHealth.Heal(heal.Use());
                }
            }
        }
        
        private int Hit() => 
            Physics.OverlapSphereNonAlloc(AttackPoint(), _damageRadius, _hits, _enemyMask);

        private Vector3 AttackPoint() => 
            transform.position + Vector3.forward / 2f;

        private void UpdateCooldown() => 
            _elapsedTime += Time.deltaTime;

        public bool CanAttack() => 
            _cooldownTime < _elapsedTime;
    }
}