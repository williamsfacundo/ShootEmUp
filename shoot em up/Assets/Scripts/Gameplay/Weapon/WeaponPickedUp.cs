using UnityEngine;
using System;

using ShootEmUp.Gameplay.Interfaces;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon 
{    
    public class WeaponPickedUp : WeaponBase, IEquipableItem
    {
        private IActionable _onPickedUpBehaviour;     

        public event Action<Transform> OnWeaponPickedUpWithTransform;

        public event Action OnWeaponPickedUp;

        public event Action OnWeaponDropped;          

        void LateUpdate()
        {
            _onPickedUpBehaviour?.DoAction();
        }

        public GameObject PickedUp(GameObject objectThatPickedUp)
        {
            if (_onPickedUpBehaviour != (IActionable)Identity.FollowingObject)
            {
                _onPickedUpBehaviour = Identity.FollowingObject;
            }            

            OnWeaponPickedUpWithTransform?.Invoke(objectThatPickedUp.transform);

            OnWeaponPickedUp?.Invoke();

            return gameObject;
        } 
        
        public void DroppedDown()
        {
            if (_onPickedUpBehaviour != (IActionable)Identity.Levitation)
            {
                _onPickedUpBehaviour = Identity.Levitation;
            }

            OnWeaponDropped?.Invoke();
        }

        public void UseItem() //Shoot
        {
            Identity.ShootingAction.ShootMechanic(); 
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            DroppedDown();
        }
    }
}