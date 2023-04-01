using UnityEngine;
using System;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Player.Items
{
    public class PlayerInventory : PlayerBase
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

        public WeaponIdentity WeaponIdentityAux 
        {
            get 
            { 
                return _weaponIdentityAux;
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

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

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

        public void WeaponPickedUp() 
        {
            _weaponIdentityAux.PickedUp.PickedUp(gameObject);
        }

        private void SetInitialWeapon() 
        {
            _weapon = Instantiate(_initialWeaponPrefab, transform.position, Quaternion.identity);

            _weaponIdentityAux = _weapon.GetComponent<WeaponIdentity>();

        }

        private bool IsGameObjectAWeapon(GameObject gameObject) 
        {
            return gameObject.GetComponent<WeaponIdentity>() != null;
        }
    }
}