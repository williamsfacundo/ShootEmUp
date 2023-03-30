using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Weapon.Shooting;

namespace ShootEmUp.Gameplay.Player.Actions.Combat 
{
    [RequireComponent(typeof(PlayerIdentity))]
    public class PlayerUseInventoryItem : MonoBehaviour
    {
        private PlayerIdentity _identity;

        void Awake()
        {
            _identity = GetComponent<PlayerIdentity>();
        }

        void Start()
        {
            _identity.PullTheTriggerAction.OnTriggerPulled += UseInventoryItem;
        }

        void OnDestroy()
        {
            _identity.PullTheTriggerAction.OnTriggerPulled -= UseInventoryItem;
        }

        void UseInventoryItem() 
        {
            _identity.Inventory.Weapon.GetComponent<WeaponSingleShooting>().Shoot();
        }
    }
}