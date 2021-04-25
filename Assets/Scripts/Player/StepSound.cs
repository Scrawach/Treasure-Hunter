using JetBrains.Annotations;
using UnityEngine;

namespace Player
{
    public class StepSound : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audio;

        [UsedImplicitly]
        public void Step()
        {
            Instantiate(_audio, transform.position, Quaternion.identity);
        }
    }
}