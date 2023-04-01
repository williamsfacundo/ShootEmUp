using UnityEngine;

namespace ShootEmUp.Gameplay.Camera 
{
    public class CameraFollowingObject : MonoBehaviour
    {
        [SerializeField] [Range(1.0f, 10.0f)] private float _followingVelocity;

        [SerializeField] [Range(-15.0f, -1.0f)] private float _initialZPosition;
        
        private Transform _targetTransform;

        private Vector3 _followingDirection;
        
        private Vector3 _movePosition;

        private Vector3 _movePositionVerifier;

        private float _distanceWithTarget;

        private float _distanceAfterMoving;

        private bool _cameraHasTarget;        

        void Start()
        {   
            SetInitialPosition();
        }

        void LateUpdate()
        {
            if (_cameraHasTarget) 
            {
                UpdatePosition();
            }
        }

        public void SetTarget(Transform targetTransform) 
        {
            _targetTransform = targetTransform;

            _cameraHasTarget = true;
        }

        private void SetInitialPosition() 
        {           
            transform.position = new Vector3(_targetTransform.position.x, _targetTransform.position.y, _initialZPosition);           
        }

        private void UpdatePosition() 
        {
            _movePosition = _targetTransform.position;

            _movePosition.z = transform.position.z;

            _distanceWithTarget = Vector3.Distance(_movePosition, transform.position);

            //Solved problem when low FPS and delta time is too large

            if (_distanceWithTarget > 0.0f) 
            {
                _followingDirection = (_movePosition - transform.position).normalized;
                
                _movePositionVerifier = transform.position + _followingDirection * _distanceWithTarget * _followingVelocity * Time.deltaTime;

                _distanceAfterMoving = Vector3.Distance(_movePositionVerifier, _movePosition);

                if (_distanceAfterMoving > _distanceWithTarget) 
                {
                    _movePositionVerifier = _movePosition;
                }

                transform.position = _movePositionVerifier;
            }
        }
    }
}