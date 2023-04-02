using UnityEngine;

using ShootEmUp.Gameplay.Player.Actions.Combat;
using ShootEmUp.Gameplay.Player.Actions.Movement;
using ShootEmUp.Gameplay.Player.Actions.Items;
using ShootEmUp.Gameplay.Player.Items;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(PlayerMouseInput),typeof(PlayerMovementController), (typeof(PlayerAimWeapon)))]
    [RequireComponent(typeof(PlayerInventory), typeof(PlayerUseInventoryItemAction), typeof(PlayerPickUpItem))]
    public class PlayerIdentity : IdentityObject
    {    
        private PlayerMouseInput _useInventoryItemMouseInput;

        private PlayerMovementController _movementController;

        private PlayerAimWeapon _aimWeapon;

        private PlayerInventory _inventory;
        
        private PlayerUseInventoryItemAction _useInventoryItem;

        private PlayerPickUpItem _pickUpItem;

        public PlayerMouseInput UseInventoryItemMouseInput
        {
            get 
            {
                return _useInventoryItemMouseInput;
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

        public PlayerUseInventoryItemAction UseInventoryItem 
        {
            get 
            {
                return _useInventoryItem;
            }
        }

        public PlayerPickUpItem PickUpItem 
        {
            get 
            {
                return _pickUpItem;
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

            _useInventoryItem.InitialSettings();

            _aimWeapon.InitialSettings();

            _movementController.InitialSettings();

            _pickUpItem.InitialSettings();
        }

        protected override void GetComponents()
        {
            _useInventoryItemMouseInput = GetComponent<PlayerMouseInput>();

            _movementController = GetComponent<PlayerMovementController>();

            _aimWeapon = GetComponent<PlayerAimWeapon>();

            _inventory = GetComponent<PlayerInventory>();

            _useInventoryItem = GetComponent<PlayerUseInventoryItemAction>();

            _pickUpItem = GetComponent<PlayerPickUpItem>();
        }
    }
}