using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Weapon.Shooting;

namespace ShootEmUp.Gameplay.Player.Actions.Combat 
{
    [RequireComponent(typeof(PlayerIdentity))]
    public class PlayerUseInventoryItem : PlayerBase
    {
        void OnDestroy()
        {
            Identity.PullTheTriggerAction.OnTriggerPulled -= UseInventoryItem;
        }

        void UseInventoryItem() 
        {
            Identity.Inventory.Weapon.GetComponent<WeaponSingleShooting>().ShootMechanic();
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>(); 
            
            Identity.PullTheTriggerAction.OnTriggerPulled += UseInventoryItem;
        }
    }
}