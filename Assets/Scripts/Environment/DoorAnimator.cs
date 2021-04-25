using System;
using UnityEngine;

namespace Environment
{
    [RequireComponent(typeof(Animator))]
    public class DoorAnimator : MonoBehaviour
    {
        private static readonly int OpenHash = Animator.StringToHash("Open");
        private static readonly int CloseHash = Animator.StringToHash("Close");

        private Animator _animator;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void PlayOpen()
        {
            ResetAll();
            _animator.SetTrigger(OpenHash);
        }

        public void PlayClose()
        {
            ResetAll();
            _animator.SetTrigger(CloseHash);
        }

        private void ResetAll()
        {
            _animator.ResetTrigger(OpenHash);
            _animator.ResetTrigger(CloseHash);
        }
        
    }
}