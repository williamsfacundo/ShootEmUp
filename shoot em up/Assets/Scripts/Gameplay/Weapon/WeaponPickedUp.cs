using UnityEngine;
using System;

using ShootEmUp.Gameplay.Interfaces;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon 
{
    [RequireComponent(typeof(WeaponIdentity))]
    public class WeaponPickedUp : MonoBehaviour, IPickable
    {
        private IActionable _onPickedUpBehaviour;
        
        private WeaponIdentity _identity;

        public event Action<Transform> OnWeaponPickedUpWithTransform;

        public event Action OnWeaponPickedUp;

        public event Action OnWeaponDropped;

        void Awake()
        {
            _identity = GetComponent<WeaponIdentity>();

            DroppedDown();
        }

        void LateUpdate()
        {
            _onPickedUpBehaviour?.DoAction();
        }

        public void PickedUp(GameObject objectThatPickedUp)
        {
            if (_onPickedUpBehaviour != (IActionable)_identity.Levitation) 
            {
                _onPickedUpBehaviour = _identity.Levitation;
            }

            OnWeaponPickedUpWithTransform?.Invoke(objectThatPickedUp.transform);
            OnWeaponPickedUp?.Invoke();
        } 
        
        public void DroppedDown()
        {
            if (_onPickedUpBehaviour != (IActionable)_identity.FollowingObject)
            {
                _onPickedUpBehaviour = _identity.FollowingObject;
            }            

            OnWeaponDropped?.Invoke();
        }
    }
}