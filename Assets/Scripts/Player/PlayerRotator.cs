using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _isRotating;
    
        public void Rotate(Vector3 direction)
        {
            if (_isRotating)
                return;

            _isRotating = true;
            StartCoroutine(Rotating(direction));
        }

        private IEnumerator Rotating(Vector3 direction)
        {
            var startRot = transform.rotation;
            var targetRot = Quaternion.LookRotation(direction);
            
            var step = _speed * Time.fixedDeltaTime;
            var t = 0f;

            while (t <= 1.0f)
            {
                t += step;
                transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
                yield return new WaitForFixedUpdate();
            }
            
            _isRotating = false;
        }
    
        private void SmoothRotationChange(Quaternion start, Quaternion end, float t) => 
            transform.rotation = Quaternion.Slerp(start, end, t);
    }
}