using UnityEngine;

using ShootEmUp.Gameplay.ScriptableObjects;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon.Shooting
{    
    public class WeaponBulletInstantiator : MonoBehaviour
    {
        private BulletIdentity _bulletIdentity;

        private GameObject _instantiatedBullet;

        public void InstantiateBullet(BulletStats bulletStats,Vector3 spawnPosition, Vector3 bulletDirection)
        {
            if (bulletStats._bulletPrefab.GetComponent<BulletIdentity>() == null)
            {
                Debug.Log("The given prefab is not a bullet!");
            }
            else 
            {
                _instantiatedBullet = Instantiate(bulletStats._bulletPrefab, spawnPosition, Quaternion.identity);

                _bulletIdentity = _instantiatedBullet.GetComponent<BulletIdentity>();

                _bulletIdentity.BulletMovementObject.MoveDirection = bulletDirection;

                _bulletIdentity.BulletMovementObject.MoveSpeed = bulletStats._bulletSpeed;

                _bulletIdentity.BulletDeactivatorObject.BulletRange = bulletStats._bulletRange;

                _bulletIdentity.BulletDamageObject.Damage = bulletStats._bulletDamage;
            }
        }               
    }
}