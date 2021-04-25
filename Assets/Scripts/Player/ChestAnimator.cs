using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Player
{
    public class ChestAnimator : MonoBehaviour
    {
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int MoveHash = Animator.StringToHash("Move");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int ShowHash = Animator.StringToHash("Show");
        private static readonly int HideHash = Animator.StringToHash("Hide");
        private static readonly int DeathHash = Animator.StringToHash("Death");
        
        [SerializeField]
        private Animator _animator;
        
        public void PlayMove()
        {
            ResetAll();
            _animator.SetTrigger(MoveHash);
        }

        public void PlayIdle()
        {
            ResetAll();
            _animator.SetTrigger(IdleHash);
        }
        
        public void PlayShowInventory()
        {
            ResetAll();
            _animator.SetTrigger(ShowHash);
        }
        
        public void PlayHideInventory()
        {
            ResetAll();
            _animator.SetTrigger(HideHash);
        }

        public void PlayAttack()
        {
            ResetAll();
            _animator.SetTrigger(AttackHash);
        }

        [UsedImplicitly]
        public void PlayDeath()
        {
            ResetAll();
            _animator.SetTrigger(ShowHash);
        }

        private void ResetAll()
        {
            _animator.ResetTrigger(MoveHash);
            _animator.ResetTrigger(IdleHash);
            _animator.ResetTrigger(AttackHash);
            _animator.ResetTrigger(ShowHash);
            _animator.ResetTrigger(HideHash);
        }
    }
}