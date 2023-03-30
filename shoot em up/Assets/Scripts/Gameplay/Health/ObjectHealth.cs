using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Health 
{
    public abstract class ObjectHealth : MonoBehaviour, IHittable, IKillable
    {
        private int _health;
    
        private IAttack _objectAttacking;

        public int Health 
        {
            set
            { 
                _health = value; 
            }
            get 
            {
                return _health;
            }
        }

        public void ObjectHit(GameObject objectThatHit)
        {
            _objectAttacking = objectThatHit.GetComponent<IAttack>();

            if (_objectAttacking != null) 
            {                
                ReceiveDamage(_objectAttacking.GetDamage());         
            }
        }

        public void ReceiveDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0) 
            {
                HealthReachedZero();
            }
        }

        public abstract void HealthReachedZero();
    }
}