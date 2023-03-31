using ShootEmUp.Gameplay.Identity;
using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon.Shooting
{    
    public abstract class WeaponShootingAction : WeaponBase
    {
        private float _nextShotAvailableTimer;
        
        void Update()
        {
            DecreaseTimer();
        }

        public abstract void Shoot();

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            ResetTimer();
        }

        private Vector3 CalculateBulletDirection()
        {
            return (Identity.Dimensions.Front.position - Identity.Dimensions.Back.position).normalized;
        }

        private void DecreaseTimer() 
        {
            if (_nextShotAvailableTimer > 0.0f) 
            {
                _nextShotAvailableTimer -= Time.deltaTime;
            }
        }

        protected bool CanShoot() 
        {
            return _nextShotAvailableTimer <= 0.0f;
        }

        protected void InstantiateBullet() 
        {
            Identity.BulletsInstantiator.InstantiateBullet(Identity.Stats._bulletStats, 
                Identity.Dimensions.Front.position, CalculateBulletDirection());
        }

        protected void ResetTimer()
        {
            _nextShotAvailableTimer = Identity.Stats._fireRate;
        }        
    }
}