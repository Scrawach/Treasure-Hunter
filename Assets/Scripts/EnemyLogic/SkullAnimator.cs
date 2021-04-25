using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(Animator))]
    public class SkullAnimator : MonoBehaviour
    {
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int AttackSpeedHash = Animator.StringToHash("AttackSpeed");
        
        [SerializeField] 
        private Animator _animator;

        public void PlayAttack(float time)
        {
            ResetAll();
            _animator.SetTrigger(AttackHash);

            var speed = 1 / time;
            _animator.SetFloat(AttackSpeedHash, speed);
        }

        public void PlayIdle()
        {
            ResetAll();
            _animator.SetTrigger(IdleHash);
        }

        private void ResetAll()
        {
            _animator.ResetTrigger(AttackHash);
            _animator.ResetTrigger(IdleHash);
        }
    }
}