using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(WallFinder))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;

        [SerializeField] 
        private float _stepLength;

        [SerializeField] 
        private float _stepHeight;

        [SerializeField] 
        private StepSound _steps;
        
        private bool _isMoving;

        private WallFinder _wallFinder;

        [SerializeField] 
        private ChestAnimator _animator;

        public bool IsMoving => _isMoving;

        public Action Done;
        
        private void Awake()
        {
            _wallFinder = GetComponent<WallFinder>();
        }

        public void Move(Vector3 direction, bool playAnimation = true)
        {
            if (_isMoving)
                return;

            _isMoving = true;
            
            if (playAnimation)
                _animator.PlayMove();

            StartCoroutine(
                _wallFinder.Check(transform.position, direction)
                ? Moving(Vector3.zero)
                : Moving(direction * _stepLength));
        }

        private IEnumerator Moving(Vector3 direction)
        {
            var startPosition = transform.position;
            var targetPosition = startPosition + direction;

            var step = _speed * Time.fixedDeltaTime;
            var t = 0f;
            
            while (t <= 1.0f)
            {
                t += step;

                var x = Mathf.Lerp(startPosition.x, targetPosition.x, t);
                var y = Functions.Bezier(startPosition.y, _stepHeight, targetPosition.y, t);
                var z = Mathf.Lerp(startPosition.z, targetPosition.z, t);
                transform.position = new Vector3(x, y, z);
                
                yield return new WaitForFixedUpdate();
            }
            
            _steps.Step();
            _isMoving = false;
            Done?.Invoke();
        }
    }
}
