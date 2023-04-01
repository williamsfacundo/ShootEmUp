using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Bullet.Actions
{   
    public class BulletMovementAction : BulletBase
    {
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

        void FixedUpdate()
        {
            _moveDistance = _moveDirection * _moveSpeed * Time.deltaTime;

            Identity.EntityRigidbody2D.MovePosition(transform.position + _moveDistance);
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<BulletIdentity>();
        }
    }
}