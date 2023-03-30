using UnityEngine;

namespace ShootEmUp.Gameplay.Health 
{
    public class EnemyHealth : ObjectHealth
    {
        [SerializeField] [Range(1, 100)] private int _initialHealth;

        void Start()
        {
            Health = _initialHealth;            
        }

        public override void HealthReachedZero()
        {
            Debug.Log("I DIED!");

            Destroy(gameObject);
        }
    }
}