using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class IdentityObject : MonoBehaviour, IInitiallySettable
    {
        private Rigidbody2D _entityRigidbody2D;

        public Rigidbody2D EntityRigidbody2D
        {
            get
            {
                return _entityRigidbody2D;
            }
        }

        public abstract void InitialSettings();

        protected abstract void SetScripts();

        protected abstract void GetComponents();

        protected void SetRigidbody2D() 
        {
            _entityRigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}