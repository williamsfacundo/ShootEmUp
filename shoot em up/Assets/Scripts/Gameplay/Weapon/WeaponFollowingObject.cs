using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon 
{    
    public class WeaponFollowingObject : WeaponBase, IActionable
    {
        private Transform _target;

        void OnDestroy()
        {
            Identity.PickedUp.OnWeaponPickedUpWithTransform -= SetTarget;
        }

        public void SetTarget(Transform target)
        {            
            if (target != null)
            {
                _target = target.transform;
            }
        }

        public void DoAction()
        {
            FollowTarget();
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            Identity.PickedUp.OnWeaponPickedUpWithTransform += SetTarget;
        }

        private void FollowTarget() 
        {
            if (_target != null) 
            {
                transform.position = _target.transform.position;
            }
        }
    }
}