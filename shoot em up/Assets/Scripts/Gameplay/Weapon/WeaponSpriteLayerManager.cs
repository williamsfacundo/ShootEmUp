using ShootEmUp.Gameplay.Identity;
using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon 
{
    public class WeaponSpriteLayerManager : WeaponBase
    {
        private SpriteRenderer _weaponSpriteRenderer;

        void OnDestroy()
        {
            Identity.PickedUp.OnWeaponPickedUp -= SetSortingLayerForPickUp;

            Identity.PickedUp.OnWeaponDropped -= SetSortingLayerForDropDown;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            _weaponSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

            Identity.PickedUp.OnWeaponPickedUp += SetSortingLayerForPickUp;

            Identity.PickedUp.OnWeaponDropped += SetSortingLayerForDropDown;
        }

        private void SetSortingLayerForPickUp() 
        {
            _weaponSpriteRenderer.sortingOrder = 0;
        }

        private void SetSortingLayerForDropDown() 
        {
            _weaponSpriteRenderer.sortingOrder = 1;
        }
    }
}