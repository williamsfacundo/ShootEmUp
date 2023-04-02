using UnityEngine;

namespace ShootEmUp.Gameplay.ScriptableObjects 
{
    [CreateAssetMenu(fileName = "NewBulletStats", menuName = "ShootEmUp/Bullet Stats", order = 1)]
    public class BulletStats : ScriptableObject
    {
        public GameObject _bulletPrefab;

        [Range(1.0f, 60.0f)] public float _bulletSpeed;

        [Range(1.0f, 100.0f)] public float _bulletRange;

        [Range(1, 100)] public short _bulletDamage;
    }
}