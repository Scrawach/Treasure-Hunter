using System;
using Common;
using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Health))]
    public class SkullBullet : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;

        [SerializeField] 
        private int _damage;

        [SerializeField] 
        private float _damageRadius;

        [SerializeField] 
        private LayerMask _enemyMask;
        
        private Health _health;
        
        private Collider[] _hits = new Collider[10];
        
        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            var step = _speed * Time.deltaTime;
            var movement =  transform.forward * step;

            transform.position += movement;
        }

        private void OnTriggerEnter(Collider other)
        {
            for (var i = 0; i < Hit(); i++)
            {
                if (_hits[i].TryGetComponent(out Health health))
                    health.TakeDamage(_damage);
            }

            _health.TakeDamage(10);
        }

        private int Hit() => 
            Physics.OverlapSphereNonAlloc(transform.position, _damageRadius, _hits, _enemyMask);
    }
}