using UnityEngine;

using ShootEmUp.Gameplay.Weapon.Enums;
using ShootEmUp.Gameplay.Weapon.Shooting;

namespace ShootEmUp.Gameplay.Weapon 
{
    public static class ShootingBuilder
    {
        public static WeaponShootingAction GenerateShootingScriptComponent(GameObject weaponObject, WeaponShootingTypeEnum shootingType)
        {
            switch (shootingType)
            {
                case WeaponShootingTypeEnum.INDIVIDUAL:

                    return ((WeaponSingleShooting)weaponObject.AddComponent(typeof(WeaponSingleShooting)));

                    
                case WeaponShootingTypeEnum.BURST:

                    return ((WeaponSingleShooting)weaponObject.AddComponent(typeof(WeaponSingleShooting)));

                    
                case WeaponShootingTypeEnum.SHOTGUN:

                    return ((WeaponSingleShooting)weaponObject.AddComponent(typeof(WeaponSingleShooting)));

                default:

                    return null;
            }
        }
    }
}