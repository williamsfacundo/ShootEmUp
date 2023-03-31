using UnityEngine;
using System;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Player.Items
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _initialWeaponPrefab;

        public event Action OnWeaponChanged;

        private GameObject _weapon;

        private WeaponIdentity _weaponIdentityAux;

        public GameObject Weapon 
        {
            get 
            {
                return _weapon;
            }
        }

        void Start()
        {
            if (_initialWeaponPrefab == null) 
            {
                Debug.LogError("No initial weapon was given!");
            }
            else 
            {
                if (IsGameObjectAWeapon(_initialWeaponPrefab)) 
                {
                    SetInitialWeapon();
                }
                else 
                {
                    Debug.LogError("The initial weapon given is not a weapon!");
                }
            }
        }

        public void SwitchWeapon(GameObject newWeapon) 
        {
            if (IsGameObjectAWeapon(newWeapon)) 
            {
                if (_weapon != null)
                {
                    Destroy(_weapon);
                }

                _weapon = newWeapon;

                _weapon.GetComponent<WeaponIdentity>().PickedUp.PickedUp(gameObject);

                OnWeaponChanged?.Invoke();
            }
        }

        private void SetInitialWeapon() 
        {
            _weapon = Instantiate(_initialWeaponPrefab, transform.position, Quaternion.identity);

            _weaponIdentityAux = _weapon.GetComponent<WeaponIdentity>();

            _weaponIdentityAux.PickedUp.PickedUp(gameObject);

            _weaponIdentityAux.Dimensions.ApplyOffsetToSpritePosition();
        }

        private bool IsGameObjectAWeapon(GameObject gameObject) 
        {
            return gameObject.GetComponent<WeaponIdentity>() != null;
        }
    }
}