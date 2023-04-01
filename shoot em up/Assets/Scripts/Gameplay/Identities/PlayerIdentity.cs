using UnityEngine;

using ShootEmUp.Gameplay.Player.Actions.Combat;
using ShootEmUp.Gameplay.Player.Actions.Movement;
using ShootEmUp.Gameplay.Player.Items;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(PlayerPullTheTriggerAction),typeof(PlayerMovementController), (typeof(PlayerAimWeapon)))]
    [RequireComponent(typeof(PlayerInventory), typeof(PlayerUseInventoryItem))]
    public class PlayerIdentity : IdentityObject
    {    
        private PlayerPullTheTriggerAction _pullTheTriggerAction;

        private PlayerMovementController _movementController;

        private PlayerAimWeapon _aimWeapon;

        private PlayerInventory _inventory; 
        
        private PlayerUseInventoryItem _useInventoryItem;

        public PlayerPullTheTriggerAction PullTheTriggerAction
        {
            get 
            {
                return _pullTheTriggerAction;
            }
        }

        public PlayerMovementController MovementController 
        {
            get 
            {
                return _movementController;
            }
        }
        
        public PlayerAimWeapon AimWeapon 
        {
            get
            { 
                return _aimWeapon;
            }
        }

        public PlayerInventory Inventory 
        {
            get 
            {
                return _inventory;
            }
        }

        public PlayerUseInventoryItem UseInventoryItem 
        {
            get 
            {
                return _useInventoryItem;
            }
        }

        public override void InitialSettings()
        {
            SetRigidbody2D();

            GetComponents();

            SetScripts();
        }

        protected override void SetScripts()
        {
            _inventory.InitialSettings();

            _inventory.WeaponIdentityAux.InitialSettings();

            _inventory.WeaponPickedUp();

            _useInventoryItem.InitialSettings();

            _aimWeapon.InitialSettings();

            _movementController.InitialSettings();
        }

        protected override void GetComponents()
        {
            _pullTheTriggerAction = GetComponent<PlayerPullTheTriggerAction>();

            _movementController = GetComponent<PlayerMovementController>();

            _aimWeapon = GetComponent<PlayerAimWeapon>();

            _inventory = GetComponent<PlayerInventory>();

            _useInventoryItem = GetComponent<PlayerUseInventoryItem>();
        }
    }
}