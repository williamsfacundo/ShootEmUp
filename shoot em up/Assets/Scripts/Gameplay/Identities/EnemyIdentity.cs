using UnityEngine;

namespace ShootEmUp.Gameplay.Identity 
{
    public class EnemyIdentity : IdentityObject
    {
        void Awake()
        {
        }

        public override void InitialSettings()
        {
            SetRigidbody2D();            
        }

        protected override void SetScripts()
        {
            
        }

        protected override void GetComponents()
        {
            
        }
    }
}