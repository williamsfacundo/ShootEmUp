using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Bullet.Attributes
{
    public class BulletDamage : MonoBehaviour, IAttack
    {
        private int _damage;

        public int Damage 
        {
            set 
            { 
                _damage = value; 
            }
        }

        public int GetDamage()
        {
            return _damage;
        }
    }
}