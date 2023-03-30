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

        void Awake()
        {
            SetRigidbody2D();            

            _pullTheTriggerAction = GetComponent<PlayerPullTheTriggerAction>();

            _movementController = GetComponent<PlayerMovementController>();

            _aimWeapon = GetComponent<PlayerAimWeapon>();

            _inventory = GetComponent<PlayerInventory>();
        }
    }
}