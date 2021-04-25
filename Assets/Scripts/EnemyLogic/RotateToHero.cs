using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyLogic
{
    public class RotateToHero : MonoBehaviour
    {
        [SerializeField]
        public float _turnFactor;

        [SerializeField]
        private Transform _heroTransform;

        private void Update() =>
            UpdateRotationTowardsHero();

        public void SetTransform(PlayerInput player)
        {
            _heroTransform = player.transform;
        }

        private void UpdateRotationTowardsHero()
        {
            if (_heroTransform)
                LerpRotationTowardsHero();
        }

        private void LerpRotationTowardsHero() =>
            transform.rotation = Quaternion.Lerp(transform.rotation, TurnTowardsHero(ToHero()), ScaleFactor());

        private Quaternion TurnTowardsHero(Vector3 toHero)
        {
            return toHero == Vector3.zero ? 
                transform.rotation : 
                Quaternion.LookRotation(toHero);
        }

        private Vector3 ToHero()
        {
            Vector3 toHero = _heroTransform.transform.position - transform.position;

            return new Vector3(toHero.x, 0f, toHero.z);
        }

        private float ScaleFactor() =>
            Time.deltaTime * _turnFactor;
    }

}