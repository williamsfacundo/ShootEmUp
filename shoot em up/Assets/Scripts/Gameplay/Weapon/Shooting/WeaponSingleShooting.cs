using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon.Shooting 
{
    public class WeaponSingleShooting : WeaponShootingAction
    {
        public override void Shoot() 
        {
            if (CanShoot()) 
            {
                InstantiateBullet();

                ResetTimer();
            }
        }        
    }
}