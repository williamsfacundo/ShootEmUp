using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.ScriptsUtils;

namespace ShootEmUp.Gameplay.Bullet.Actions
{   
    public class BulletMovementAction : MonoBehaviour
    {
        private BulletIdentity _bulletIdentity;

        private Vector3 _moveDirection;

        private Vector3 _moveDistance;

        private float _moveSpeed;

        public Vector3 MoveDirection 
        {
            set 
            {
                _moveDirection = value;
            }            
        }

        public Vector3 MoveDistance 
        {            
            get 
            {
                return _moveDistance;
            }
        }

        public float MoveSpeed 
        {
            set 
            {
                _moveSpeed = value;
            }
        }

        void Awake()
        {
            _bulletIdentity= GetComponent<BulletIdentity>();
        }

        void Start()
        {
            _bulletIdentity.EntityRigidbody2D.MoveRotation(Utils.GetAngleFromVectorFloat(_moveDirection));
        }

        void FixedUpdate()
        {
            _moveDistance = _moveDirection * _moveSpeed * Time.deltaTime;

            _bulletIdentity.EntityRigidbody2D.MovePosition(transform.position + _moveDistance);
        }
    }
}