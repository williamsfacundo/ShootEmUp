using UnityEngine;

using ShootEmUp.Gameplay.ScriptableObjects;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon.Shooting
{    
    public class WeaponBulletActivator : WeaponBase
    {
        BulletIdentity _bulletIdentity;

        GameObject _bullet;

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();
        }

        public bool ActivateBullet(BulletStats bulletStats,Vector3 spawnPosition, Vector3 bulletDirection)
        {           
            _bullet = Identity.BulletPool.GetAvailableBullet();

            if (_bullet != null) 
            {
                _bullet.SetActive(true);

                _bulletIdentity = _bullet.GetComponent<BulletIdentity>();

                _bulletIdentity.Movement.MoveDirection = bulletDirection;

                _bulletIdentity.Movement.MoveSpeed = bulletStats._bulletSpeed;

                _bulletIdentity.Deactivator.BulletRange = bulletStats._bulletRange;

                _bulletIdentity.Damage.Damage = bulletStats._bulletDamage;

                return true;
            }
            else 
            {
                return false;
                
            }
        }               
    }
}