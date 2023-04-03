using ShootEmUp.Gameplay.Identity;
using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon 
{
    public class WeaponSpriteController : WeaponBase
    {
        void OnDestroy()
        {
            Identity.PickedUp.OnWeaponPickedUp -= SetWeaponSpriteToWeaponWithHand;

            Identity.PickedUp.OnWeaponDropped -= SetWeaponSpriteToWeaponRaw;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            Identity.PickedUp.OnWeaponPickedUp += SetWeaponSpriteToWeaponWithHand;

            Identity.PickedUp.OnWeaponDropped += SetWeaponSpriteToWeaponRaw;
        }

        private void SetWeaponSpriteToWeaponRaw() 
        {
            Identity.SpriteLayerManager.SpriteRenderer.sprite = Identity.Stats._rawSprite;
        }

        private void SetWeaponSpriteToWeaponWithHand()
        {
            Identity.SpriteLayerManager.SpriteRenderer.sprite = Identity.Stats._handSprite;
        }
    }
}