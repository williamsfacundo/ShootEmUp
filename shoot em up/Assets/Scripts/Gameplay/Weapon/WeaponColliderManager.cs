using ShootEmUp.Gameplay.Identity;
using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon
{
    public class WeaponColliderManager : WeaponBase
    {
        private Collider2D _weaponCollider;

        void OnDestroy()
        {
            Identity.PickedUp.OnWeaponPickedUp -= DisableCollider;

            Identity.PickedUp.OnWeaponDropped -= EnableCollider;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            _weaponCollider = GetComponent<Collider2D>();

            Identity.PickedUp.OnWeaponPickedUp += DisableCollider;

            Identity.PickedUp.OnWeaponDropped += EnableCollider;
        }

        private void EnableCollider() 
        {
            _weaponCollider.enabled = true;
        }

        private void DisableCollider() 
        {
            _weaponCollider.enabled = false;
        }
    }
}