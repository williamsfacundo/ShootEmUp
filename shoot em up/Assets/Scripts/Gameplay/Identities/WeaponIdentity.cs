using UnityEngine;

using ShootEmUp.Gameplay.Weapon;
using ShootEmUp.Gameplay.Weapon.Enums;
using ShootEmUp.Gameplay.Weapon.Shooting;
using ShootEmUp.Gameplay.Weapon.ScriptableObjects;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(WeaponBulletActivator), typeof(WeaponDimensions), typeof(WeaponPickedUp))]
    [RequireComponent(typeof(WeaponLevitation), typeof(WeaponFollowingObject), typeof(WeaponBulletsPool))]
    [RequireComponent(typeof(WeaponParabolaMovement), typeof(WeaponColliderManager))]
    [RequireComponent(typeof(WeaponSpriteLayerManager), typeof(WeaponSpriteController))]
    public class WeaponIdentity : IdentityObject
    {
        [SerializeField] private WeaponStats _weaponStats;       

        private WeaponBulletActivator _bulletsActivator;

        private WeaponShootingAction _shootingAction;

        private WeaponDimensions _dimensions;

        private WeaponPickedUp _pickedUp;

        private WeaponLevitation _levitation;

        private WeaponFollowingObject _followingObject;

        private WeaponBulletsPool _bulletPool;

        private WeaponParabolaMovement _parabolaMovement;

        private WeaponColliderManager _colliderManager;

        private WeaponSpriteLayerManager _spriteLayerManager;

        private WeaponSpriteController _spriteController;

        public WeaponBulletActivator BulletsActivator 
        {
            get 
            {
                return _bulletsActivator;
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

        public WeaponParabolaMovement ParabolaMovement 
        {
            get
            { 
                return _parabolaMovement;
            }
        }

        public WeaponSpriteLayerManager SpriteLayerManager 
        {
            get 
            { 
                return _spriteLayerManager; 
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
                _shootingAction = ShootingBuilder.GenerateShootingScriptComponent(gameObject, _weaponStats._weaponShootingType);
            }

            SetRigidbody2D();

            GetComponents();

            SetScripts();
        }

        protected override void SetScripts() 
        {
            _bulletsActivator.InitialSettings();

            _bulletPool.InitialSettings();

            _followingObject.InitialSettings();

            _levitation.InitialSettings();

            _dimensions.InitialSettings();

            _colliderManager.InitialSettings();

            _spriteLayerManager.InitialSettings();

            _spriteController.InitialSettings();

            _pickedUp.InitialSettings();

            _shootingAction.InitialSettings();

            _parabolaMovement.InitialSettings();
        }

        protected override void GetComponents()
        {
            _bulletsActivator = GetComponent<WeaponBulletActivator>();

            _shootingAction = GetComponent<WeaponShootingAction>();

            _dimensions = GetComponent<WeaponDimensions>();

            _pickedUp = GetComponent<WeaponPickedUp>();

            _levitation = GetComponent<WeaponLevitation>();

            _followingObject = GetComponent<WeaponFollowingObject>();

            _bulletPool = GetComponent<WeaponBulletsPool>();

            _parabolaMovement = GetComponent<WeaponParabolaMovement>();

            _colliderManager = GetComponent<WeaponColliderManager>();

            _spriteLayerManager = GetComponent<WeaponSpriteLayerManager>();

            _spriteController = GetComponent<WeaponSpriteController>();
        }       
    }
}