using UnityEngine;

using ShootEmUp.ScriptsUtils;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Player.Actions.Combat
{
    [RequireComponent(typeof(PlayerIdentity))]
    public class PlayerAimWeapon : PlayerBase
    {
        private Transform _weaponTransform;

        private Vector3 _mousePosition;

        private Vector3 _aimDirection;        

        private Vector3 _eulerAngles;

        Vector3 _aimLocalScale;

        private float _aimAngle;

        void Update()
        {
            AimingWeapon();
        }

        void OnDestroy()
        {
            Identity.Inventory.OnWeaponChanged -= UpdateWeaponTransform;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

            Identity.Inventory.OnWeaponChanged += UpdateWeaponTransform;            

            _eulerAngles = new Vector3();            
        }

        private void AimingWeapon()
        {
            WeaponRotation();

            WeaponYScale();
        }

        private void WeaponRotation()
        {
            _mousePosition = Utils.GetMouseWorldPositionWithZeroZ();

            _aimDirection = (_mousePosition - transform.position).normalized;

            _aimAngle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;

            _eulerAngles.x = 0.0f;
            _eulerAngles.y = 0.0f;
            _eulerAngles.z = _aimAngle;

            _weaponTransform.eulerAngles = _eulerAngles;
        }

        private void WeaponYScale()
        {
            _aimLocalScale = Vector3.one;

            if (_aimAngle > 90f || _aimAngle < -90f)
            {
                _aimLocalScale.y = -1f;
            }
            else
            {
                _aimLocalScale.y = 1f;
            }

            _weaponTransform.localScale = _aimLocalScale;
        }

        private void UpdateWeaponTransform() 
        {
            _weaponTransform = Identity.Inventory.EquippedItem.transform;
        }
    }
}