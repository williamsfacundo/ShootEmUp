using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Weapon.Shooting;

namespace ShootEmUp.Gameplay.Player.Actions.Combat 
{
    [RequireComponent(typeof(PlayerIdentity))]
    public class PlayerUseInventoryItemAction : PlayerBase
    {
        void OnDestroy()
        {
            Identity.UseInventoryItemMouseInput.OnMouseButtonPressed -= UseInventoryItem;
        }

        public void UseInventoryItem() 
        {
            Identity.Inventory.EquipableItem.UseItem();
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

            Identity.UseInventoryItemMouseInput.OnMouseButtonPressed += UseInventoryItem;
        }
    }
}