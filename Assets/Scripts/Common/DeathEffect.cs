using System;
using Unity.Mathematics;
using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(Death))]
    public class DeathEffect : MonoBehaviour
    {
        [SerializeField] 
        private ParticleSystem _effect;

        [SerializeField] 
        private AudioSource _audio;

        private Death _death;

        private void Awake()
        {
            _death = GetComponent<Death>();
        }

        private void OnEnable() =>
            _death.Happened.AddListener(OnDeathHappened);

        private void OnDisable() =>
            _death.Happened.RemoveListener(OnDeathHappened);

        private void OnDeathHappened()
        {
            Instantiate(_effect, transform.position, quaternion.identity);
            Instantiate(_audio, transform.position, quaternion.identity);
        }
    }
}