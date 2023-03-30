using UnityEngine;

using ShootEmUp.Gameplay.Bullet.Actions;
using ShootEmUp.Gameplay.Bullet.Attributes;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(BulletDeactivationAction), typeof(BulletMovementAction), typeof(BulletCollisionAction))]
    [RequireComponent(typeof(BulletDamage))]
    public class BulletIdentity : IdentityObject
    {
        private BulletMovementAction _bulletMovement;

        private BulletDeactivationAction _bulletDeactivator;        

        private BulletCollisionAction _bulletCollision;

        private BulletDamage _bulletDamage;

        public BulletMovementAction BulletMovementObject 
        {
            get 
            {
                return _bulletMovement;
            }
        }

        public BulletDeactivationAction BulletDeactivatorObject 
        {
            get 
            {
                return _bulletDeactivator;
            }
        }        

        public BulletCollisionAction BulletCollisionObject 
        {
            get 
            {
                return _bulletCollision;
            }
        }

        public BulletDamage BulletDamageObject 
        {
            get 
            {
                return _bulletDamage;
            }
        }

        void Awake()
        {
            SetRigidbody2D();

            _bulletMovement = GetComponent<BulletMovementAction>();

            _bulletDeactivator = GetComponent<BulletDeactivationAction>();            

            _bulletCollision = GetComponent<BulletCollisionAction>();

            _bulletDamage = GetComponent<BulletDamage>();
        }
    }
}