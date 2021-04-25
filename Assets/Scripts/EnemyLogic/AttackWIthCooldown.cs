using System;
using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(EnemyAttack))]
    public class AttackWIthCooldown : MonoBehaviour
    {
        [SerializeField] 
        private float _cooldownTime;

        private float _elapsedTime;

        private EnemyAttack _attack;

        private void Awake()
        {
            _attack = GetComponent<EnemyAttack>();
        }

        private void Update()
        {
            if (_elapsedTime > _cooldownTime)
            {
                _attack.StartAttack(_cooldownTime);
                _elapsedTime = 0f;
            }
            else
            {
                _elapsedTime += Time.deltaTime;
            }
        }
    }
}