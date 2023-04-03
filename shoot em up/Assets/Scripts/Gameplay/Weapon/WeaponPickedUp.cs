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

            transform.eulerAngles = Vector3.zero;

            transform.localScale = Vector3.one;

            OnWeaponPickedUpWithTransform?.Invoke(objectThatPickedUp.transform);

            OnWeaponPickedUp?.Invoke();

            return gameObject;
        } 
        
        public void DroppedDown(Vector3 objectPosition)
        {
            _onPickedUpBehaviour = null;

            transform.position = objectPosition;

            transform.eulerAngles = Vector3.zero;

            transform.localScale = Vector3.one;            

            OnWeaponDropped?.Invoke();
        }

        public void UseItem()
        {
            Identity.ShootingAction.ShootMechanic(); 
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            Identity.ParabolaMovement.OnParabolaFinished += SetPickedUpBehaviourToLevitation;

            DroppedDown(transform.position);

            SetPickedUpBehaviourToLevitation();
        }

        private void SetPickedUpBehaviourToLevitation() 
        {
            if (_onPickedUpBehaviour != (IActionable)Identity.Levitation)
            {
                _onPickedUpBehaviour = Identity.Levitation;
            }
        }
    }
}