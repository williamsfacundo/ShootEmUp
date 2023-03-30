using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Bullet.Actions 
{
    public class BulletCollisionAction : MonoBehaviour
    {
        private IHittable _hittableObject;

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsCollisionHittable(collision))
            {
                _hittableObject.ObjectHit(gameObject);

                Destroy(gameObject);
            }
        }

        private bool IsCollisionHittable(Collider2D collision) 
        {
            _hittableObject = collision.GetComponent<IHittable>();

            return _hittableObject != null;
        }
    }
}