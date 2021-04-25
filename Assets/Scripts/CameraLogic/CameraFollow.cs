using UnityEngine;
using UnityEngine.Serialization;

namespace CameraLogic
{
    public class CameraFollow : MonoBehaviour
    { 
        [SerializeField]
        private float _rotationAngleX;
        
        [SerializeField]
        private float _distance;
        
        [SerializeField]
        private Vector3 _offset;
    
        [SerializeField]
        private Transform _following;

        [SerializeField] 
        private float _smoothSpeed;
        
        private void LateUpdate()
        {
            if (_following == null)
                return;

            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);

            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _smoothSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, position, _smoothSpeed * Time.deltaTime);
        }
        
        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition += _offset;

            followingPosition.y = Mathf.Clamp(followingPosition.y, 0, _offset.y);
            
            return followingPosition;
        }

        public void ZoomIn()
        {
            _distance = 0;
        }
        
        public void ResetZoom()
        {
            _distance = 8;
        }

    }
}
