using UnityEngine;

namespace ShootEmUp.Gameplay.Identity 
{
    public class EnemyIdentity : IdentityObject
    {
        void Awake()
        {
            SetRigidbody2D();
        }
    }
}