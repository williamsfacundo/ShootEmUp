using System.Collections.Generic;
using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.ScriptableObjects;

namespace ShootEmUp.Gameplay.Weapon.Shooting 
{
    public class WeaponBulletsPool : WeaponBase
    {
        private List<GameObject> _bullets;

        public override void InitialSettings() 
        {
            Identity = GetComponent<WeaponIdentity>();

            if (Identity.Stats._bulletStats._bulletPrefab.GetComponent<BulletIdentity>() == null)
            {
                Debug.Log("The given bullet prefab is not a bullet!");
            }
            else 
            {
                _bullets = new List<GameObject>();

                for (short i = 0; i < Identity.Stats._magazineCapacity; i++) 
                {
                    _bullets.Add(Instantiate(Identity.Stats._bulletStats._bulletPrefab));

                    _bullets[i].GetComponent<BulletIdentity>().InitialSettings();
                
                    _bullets[i].SetActive(false);
                }
            }
        }

        public GameObject GetAvailableBullet() 
        {
            for (short i = 0; i < _bullets.Count; i++) 
            {
                if (!_bullets[i].activeSelf) 
                {
                    return _bullets[i];
                }
            }

            return null;
        }
    }
}
