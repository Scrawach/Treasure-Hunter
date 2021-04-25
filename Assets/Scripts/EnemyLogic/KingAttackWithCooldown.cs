using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(EnemyAttack))]
    public class KingAttackWithCooldown : MonoBehaviour
    {
        [SerializeField] 
        private float _cooldownTime;

        [SerializeField] 
        private int _attackInWave;
        
        [SerializeField] 
        private float _cooldownBetweenWaves;

        private float _elapsedTime;
        private float _elapsedTimeBetweenWaves = float.MaxValue;
        private float _attacksNum;

        private EnemyAttack _attack;

        private void Awake() => 
            _attack = GetComponent<EnemyAttack>();

        private void Update()
        {
            if (_elapsedTimeBetweenWaves > _cooldownBetweenWaves)
            {
                if (CanAttack())
                    Attack();
                else
                    UpdateCooldown();
            }
            else
            {
                _elapsedTimeBetweenWaves += Time.deltaTime;
            }
        }

        private void UpdateCooldown() => 
            _elapsedTime += Time.deltaTime;

        private bool CanAttack() => 
            _elapsedTime > _cooldownTime;

        private void Attack()
        {
            _attacksNum++;
            _attack.StartAttack(_cooldownTime);
            _elapsedTime = 0f;

            if (_attacksNum > _attackInWave)
            {
                _attacksNum = 0;
                _elapsedTimeBetweenWaves = 0f;
            }
        }
    }
}