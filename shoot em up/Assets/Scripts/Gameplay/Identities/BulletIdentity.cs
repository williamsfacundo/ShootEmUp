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

        public BulletMovementAction Movement 
        {
            get 
            {
                return _bulletMovement;
            }
        }

        public BulletDeactivationAction Deactivator 
        {
            get 
            {
                return _bulletDeactivator;
            }
        }        

        public BulletCollisionAction Collision 
        {
            get 
            {
                return _bulletCollision;
            }
        }

        public BulletDamage Damage 
        {
            get 
            {
                return _bulletDamage;
            }
        }        

        public override void InitialSettings()
        {
            SetRigidbody2D();

            GetComponents();

            SetScripts();
        }

        protected override void SetScripts()
        {
            _bulletMovement.InitialSettings();

            _bulletDeactivator.InitialSettings();            
        }

        protected override void GetComponents()
        {
            _bulletMovement = GetComponent<BulletMovementAction>();

            _bulletDeactivator = GetComponent<BulletDeactivationAction>();

            _bulletCollision = GetComponent<BulletCollisionAction>();

            _bulletDamage = GetComponent<BulletDamage>();
        }
    }
}