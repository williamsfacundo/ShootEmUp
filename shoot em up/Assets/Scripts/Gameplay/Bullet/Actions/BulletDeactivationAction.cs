using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Bullet.Actions
{
    [RequireComponent(typeof(BulletIdentity))]
    public class BulletDeactivationAction : MonoBehaviour
    {
        private BulletIdentity _bulletIdentity;

        private float _bulletRange;

        public float BulletRange
        {
            set 
            {
                _bulletRange = value;
            }
        }

        void Awake()
        {
            _bulletIdentity = GetComponent<BulletIdentity>();
        }

        void FixedUpdate()
        {
            DeactivateBullet();
        }

        private void DeactivateBullet()
        {
            if (_bulletRange > 0.0f)
            {
                _bulletRange -= _bulletIdentity.BulletMovementObject.MoveDistance.magnitude;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}