using UnityEngine;

using ShootEmUp.Gameplay.Weapon.Enums;
using ShootEmUp.Gameplay.ScriptableObjects;

namespace ShootEmUp.Gameplay.Weapon.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewWeaponStats", menuName = "ShootEmUp/Weapon Stats", order = 1)]
    public class WeaponStats : ScriptableObject
    {
        public Sprite _rawSprite;

        public Sprite _handSprite;

        public BulletStats _bulletStats;

        public WeaponShootingTypeEnum _weaponShootingType;
        
        [Range(0.1f, 5.0f)] public float _fireRate;              
        
        [Range(0.1f, 5.0f)] public float _reloadSpeed;        
        
        [Range(1, 5)] public short _bulletsShotWhenFire;
        
        [Range(1, 100)] public short _magazineCapacity;        
        
        [Range(1, 500)] public short _maxAmmo;   
    }
}