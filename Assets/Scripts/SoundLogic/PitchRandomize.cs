using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SoundLogic
{
    public class PitchRandomize : MonoBehaviour
    {
        [SerializeField] 
        private Vector2 _range;

        [SerializeField] 
        private AudioSource _source;
        
        private void Awake()
        {
            _source.pitch = Random.Range(_range.x, _range.y);
        }
    }
}