using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon 
{
    [RequireComponent(typeof(WeaponIdentity))]
    public class WeaponFollowingObject : MonoBehaviour, IActionable
    {
        private WeaponIdentity _identity;

        private Transform _target;

        void Awake()
        {
            _identity = GetComponent<WeaponIdentity>();

            _identity.PickedUp.OnWeaponPickedUpWithTransform += SetTarget;
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

        private void FollowTarget() 
        {
            if (_target != null) 
            {
                transform.position = _target.transform.position;
            }
        }
    }
}