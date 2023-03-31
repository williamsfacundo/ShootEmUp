using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Bullet.Actions
{
    [RequireComponent(typeof(BulletIdentity))]
    public class BulletDeactivationAction : BulletBase
    {
        private float _bulletRange;

        public float BulletRange
        {
            set 
            {
                _bulletRange = value;
            }
        }        

        void FixedUpdate()
        {
            DeactivateBullet();
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<BulletIdentity>();
        }

        private void DeactivateBullet()
        {
            if (_bulletRange > 0.0f)
            {
                _bulletRange -= Identity.Movement.MoveDistance.magnitude;
            }
            else
            {
                Destroy(gameObject);
            }
        }                
    }
}