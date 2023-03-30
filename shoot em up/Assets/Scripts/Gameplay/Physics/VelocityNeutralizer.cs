using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Physics 
{
    [RequireComponent(typeof(IdentityObject))]
    public class VelocityNeutralizer : MonoBehaviour
    {
        //Make a deceleration system

        private IdentityObject _identityObject;

        void Awake()
        {
            _identityObject = GetComponent<IdentityObject>();            
        }

        void LateUpdate()
        {
            NeutralizeVelocity();
        }

        private void NeutralizeVelocity() 
        {
            if (_identityObject.EntityRigidbody2D.velocity != Vector2.zero) 
            {
                _identityObject.EntityRigidbody2D.velocity = Vector3.zero;
            }
        }
    }
}