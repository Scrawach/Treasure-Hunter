using System;
using Bullets;
using JetBrains.Annotations;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] 
        private SkullBullet _bullet;

        [SerializeField] 
        private Transform _firePoint;
        
        [SerializeField] 
        private SkullAnimator _animator;

        [SerializeField] 
        private ParticleSystem _prepareEffect;

        [SerializeField] 
        private AudioSource _audioEffect;

        protected SkullBullet BulletPrefab => _bullet;
        protected Transform FirePoint => _firePoint;

        public void StartAttack(float time)
        {
            _animator.PlayAttack(time);
            _prepareEffect.Play();
        }

        [UsedImplicitly]
        protected virtual void OnAttack()
        {
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
            Instantiate(_audioEffect, _firePoint.position, _firePoint.rotation);
        }
    }
}