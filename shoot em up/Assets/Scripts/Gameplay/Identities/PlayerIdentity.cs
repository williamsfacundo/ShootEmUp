using UnityEngine;

using ShootEmUp.Gameplay.Player.Items;
using ShootEmUp.Gameplay.Player.Actions.Items;
using ShootEmUp.Gameplay.Player.Actions.Combat;
using ShootEmUp.Gameplay.Player.Actions.Movement;
using ShootEmUp.Gameplay.Player.ScriptableObjects;
using ShootEmUp.Gameplay.Player.InputSystem;

namespace ShootEmUp.Gameplay.Identity 
{
    [RequireComponent(typeof(PlayerMouseInput),typeof(PlayerMovementController), (typeof(PlayerAimWeapon)))]
    [RequireComponent(typeof(PlayerInventory), typeof(PlayerUseInventoryItemAction), typeof(PlayerPickUpItem))]
    [RequireComponent(typeof(PlayerKeyboardInput), typeof(PlayerAxisInput))]
    public class PlayerIdentity : IdentityObject
    {
        [SerializeField] private PlayerStats _playerStats;

        private PlayerMouseInput _useInventoryItemMouseInput;

        private PlayerMovementController _movementController;

        private PlayerAimWeapon _aimWeapon;

        private PlayerInventory _inventory;
        
        private PlayerUseInventoryItemAction _useInventoryItem;

        private PlayerPickUpItem _pickUpItem;

        private PlayerKeyboardInput _pickUpItemKeyboardInput;

        private PlayerAxisInput _movementAxisInput;

        public PlayerStats Stats 
        {
            get 
            {
                return _playerStats;
            }
        }

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

        public PlayerKeyboardInput PickUpItemKeyboardInput 
        {
            get 
            {
                return _pickUpItemKeyboardInput;
            }
        }

        public PlayerAxisInput MovementAxisInput 
        {
            get 
            {
                return _movementAxisInput;
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
            if (_playerStats == null) 
            {
                Debug.LogError("PlayerStats missing!");
            }

            _useInventoryItemMouseInput.Button = _playerStats._useItemMouseButton;

            _pickUpItemKeyboardInput.KeyboardButton = _playerStats._pickUpItemButton;

            _movementAxisInput.AxisOneName = _playerStats._horizontalAxisName;

            _movementAxisInput.AxisTwoName = _playerStats._verticalAxisName;

            _aimWeapon.InitialSettings();
            
            _inventory.InitialSettings();           

            _useInventoryItem.InitialSettings();

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

            _pickUpItemKeyboardInput = GetComponent<PlayerKeyboardInput>();

            _movementAxisInput = GetComponent<PlayerAxisInput>();
        }
    }
}