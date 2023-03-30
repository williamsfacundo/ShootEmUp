using ShootEmUp.Gameplay.Identity;
using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon.Shooting
{
    [RequireComponent(typeof(WeaponIdentity))]
    public abstract class WeaponShootingAction : MonoBehaviour
    {
        private WeaponIdentity _weaponIdentity;

        private float _nextShotAvailableTimer;

        protected WeaponIdentity Identity 
        {
            get 
            { 
                return _weaponIdentity;
            }
        }        

        void Awake()
        {
            _weaponIdentity = GetComponent<WeaponIdentity>();
        }

        void Start()
        {
            ResetTimer();            
        }

        void Update()
        {
            DecreaseTimer();
        }

        public abstract void Shoot();

        private Vector3 CalculateBulletDirection()
        {
            return (_weaponIdentity.Dimensions.Front.position - _weaponIdentity.Dimensions.Back.position).normalized;
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
            _weaponIdentity.BulletsInstantiator.InstantiateBullet(_weaponIdentity.Stats._bulletStats, 
                _weaponIdentity.Dimensions.Front.position, CalculateBulletDirection());
        }

        protected void ResetTimer()
        {
            _nextShotAvailableTimer = _weaponIdentity.Stats._fireRate;
        }
    }
}