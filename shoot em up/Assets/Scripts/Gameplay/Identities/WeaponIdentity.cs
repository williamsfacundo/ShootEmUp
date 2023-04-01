using UnityEngine;

using ShootEmUp.Gameplay.Weapon.ScriptableObjects;
using ShootEmUp.Gameplay.Weapon.Shooting;
using ShootEmUp.Gameplay.Weapon.Enums;
using ShootEmUp.Gameplay.Weapon;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(WeaponBulletActivator), typeof(WeaponDimensions), typeof(WeaponPickedUp))]
    [RequireComponent(typeof(WeaponLevitation), typeof(WeaponFollowingObject), typeof(WeaponBulletsPool))]
    public class WeaponIdentity : IdentityObject
    {
        [SerializeField] private WeaponStats _weaponStats;       

        private WeaponBulletActivator _bulletsInstantiator;

        private WeaponShootingAction _shootingAction;

        private WeaponDimensions _dimensions;

        private WeaponPickedUp _pickedUp;

        private WeaponLevitation _levitation;

        private WeaponFollowingObject _followingObject;

        private WeaponBulletsPool _bulletPool;

        public WeaponBulletActivator BulletsInstantiator 
        {
            get 
            {
                return _bulletsInstantiator;
            }
        }

        public WeaponShootingAction ShootingAction 
        {
            get 
            {
                return _shootingAction;
            }
        }

        public WeaponDimensions Dimensions 
        {
            get 
            {
                return _dimensions;
            }
        }

        public WeaponStats Stats 
        {
            get 
            { 
                return _weaponStats;
            }
        }

        public WeaponPickedUp PickedUp 
        {
            get 
            {
                return _pickedUp;
            }
        }

        public WeaponLevitation Levitation 
        {
            get 
            {
                return _levitation;
            }
        }

        public WeaponFollowingObject FollowingObject 
        {
            get 
            { 
                return _followingObject;
            }
        }          
        
        public WeaponBulletsPool BulletPool 
        {
            get 
            {
                return _bulletPool;
            }
        }

        public override void InitialSettings()
        {
            if (_weaponStats == null)
            {
                Debug.Log("Missing serialize field weapon stats!");
            }
            else
            {
                GenerateShootingScriptComponent();
            }

            SetRigidbody2D();

            GetComponents();

            SetScripts();
        }

        protected override void SetScripts() 
        {
            _bulletPool.InitialSettings();

            _followingObject.InitialSettings();

            _levitation.InitialSettings();

            _dimensions.InitialSettings();

            _pickedUp.InitialSettings();

            _shootingAction.InitialSettings();
        }

        protected override void GetComponents()
        {
            _bulletsInstantiator = GetComponent<WeaponBulletActivator>();

            _shootingAction = GetComponent<WeaponShootingAction>();

            _dimensions = GetComponent<WeaponDimensions>();

            _pickedUp = GetComponent<WeaponPickedUp>();

            _levitation = GetComponent<WeaponLevitation>();

            _followingObject = GetComponent<WeaponFollowingObject>();

            _bulletPool = GetComponent<WeaponBulletsPool>();
        }
        
        private void GenerateShootingScriptComponent() 
        {
            switch (_weaponStats._weaponShootingType) 
            {
                case WeaponShootingTypeEnum.INDIVIDUAL:

                    _shootingAction = ((WeaponSingleShooting)gameObject.AddComponent(typeof(WeaponSingleShooting)));                    

                    break;
                case WeaponShootingTypeEnum.BURST:

                    _shootingAction = ((WeaponSingleShooting)gameObject.AddComponent(typeof(WeaponSingleShooting)));

                    break;
                case WeaponShootingTypeEnum.SHOTGUN:

                    _shootingAction = ((WeaponSingleShooting)gameObject.AddComponent(typeof(WeaponSingleShooting)));

                    break;
            }            
        }
    }
}