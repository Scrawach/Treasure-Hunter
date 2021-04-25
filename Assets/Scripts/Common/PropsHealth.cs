using UnityEngine;

namespace Common
{
    public class PropsHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _healValue;

        [SerializeField] 
        private ParticleSystem _deathEffect;
        
        [SerializeField] 
        private AudioSource _audio;

        public int Use()
        {
            if (_deathEffect != null)
            {
                Instantiate(_deathEffect, transform.position, Quaternion.identity);
                Instantiate(_audio, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
            return _healValue;
        }
    }
}