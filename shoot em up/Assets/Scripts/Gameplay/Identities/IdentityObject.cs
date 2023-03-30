using UnityEngine;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class IdentityObject : MonoBehaviour
    {
        private Rigidbody2D _entityRigidbody2D;

        public Rigidbody2D EntityRigidbody2D
        {
            get
            {
                return _entityRigidbody2D;
            }
        }

        protected void SetRigidbody2D() 
        {
            _entityRigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}